using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using PlayStationData;
using PlayStation.Excel;

namespace PlayStation.Views
{
    //Enumeration type
    public enum TypeModification
    {
        ModifListJoueurs = 0,
        ModifClassement = 1,
        ModifUpdateTournoiFileName = 2,
        ClassementItemFileUpToDate = 3,
        TournoiGenerated = 4
    };

    public partial class MainView : Form
    {
        const int configuration_tag = 0;
        const int tournois_tag = 1;
        const int classementgen_tag = 2;
        const string cst_new_substring = "Nouveau tournoi";
        const string cst_configuration_joueur_file = "ConfigurationJoueurs.xml";

        //------------------------
        //- Region champs prives -
        //------------------------
        #region fields

        //Boolean pour gerer mode de marche
        /// <summary>
        /// Check if projet mofication
        /// </summary>
        bool _bprojectModified = false;

        public bool ProjectModified
        {
            get { return _bprojectModified; }
            set
            {
                if (_bopenedMode == true)
                {
                    //Set value
                    _bprojectModified = value;
                }

                //Update modification
                UpdateTitleModif(_bprojectModified);
            }
        }

        /// <summary>
        /// Check if project opened
        /// </summary>
        bool _bopenedMode = false;

        /// <summary>
        /// Check if tournoi generated
        /// </summary>
        bool _btournoisGenerated;

        public bool TournoisGenerated
        {
            get { return _btournoisGenerated; }
            set 
            { 
                // Set value
                _btournoisGenerated = value; 

                // Send notif to form
                if (_fmClassementGenSelectionFile != null)
                    _fmClassementGenSelectionFile.PropagateModificaion(TypeModification.TournoiGenerated, value);
            }
        }

        /// <summary>
        /// File name
        /// </summary>
        string _filePath = "";

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                //Set value
                _filePath = value;

                //Update title
                UpdateTitle(Path.GetFileNameWithoutExtension(value), _courantSubtitle);

                // Send notif to form
                if (_fmClassementGenSelectionFile != null)
                    _fmClassementGenSelectionFile.PropagateModificaion(TypeModification.ModifUpdateTournoiFileName, _filePath);
            }
        }

        /// <summary>
        /// Sous titre courant dans le titre
        /// </summary>
        string _courantSubtitle = "";

        /// <summary>
        /// Initialize title
        /// </summary>
        string _initialTitle = "";

        //Objet tournois
        Tournois _TournoisData;

        public Tournois TournoisData
        {
            get { return _TournoisData; }
            set { _TournoisData = value; }
        }

        // Objet joueurs classement general
        JoueursConfigures _joueursClassementGeneral;

        public JoueursConfigures JoueursClassementGeneral
        {
            get { return _joueursClassementGeneral; }
            set { _joueursClassementGeneral = value; }
        }

        //Objet formes
        // Tournoi tab
        TournoisForm _fmTournois = new TournoisForm();
        ClassementForm _fmClassement = new ClassementForm();
        JoueursForm _fmJoueurs = new JoueursForm();
        // Configuration tab
        ConfigurationForm _fmConfiguration = new ConfigurationForm();
        // Classement general tab
        GeneralSelectionFileForm _fmClassementGenSelectionFile = new GeneralSelectionFileForm();
        ClassementGeneralForm _fmClassementGeneralForm = new ClassementGeneralForm();

        //Form varible pour gerer mode de marche
        Form _fmConfFormActived;
        Form _fmTournoisFormactived;
        Form _fmClassementGenFormActived;

        // Progress form
        ProgressForm progress;
        PlayBackgroundWorker backgroundWorker = new PlayBackgroundWorker();

        #endregion fields

        //-------------------------
        //- Region Initialization -
        //-------------------------
        #region Initialization

        public MainView()
        {
            InitializeComponent();
        }

        private void mainView_Load(object sender, EventArgs e)
        {
            //Fill closed panel view
            panelClientcloseProject.Dock = DockStyle.Fill;

            //Set initialize value
            _initialTitle = Text;

            // Initialize progress
            progress = new ProgressForm(this);

            //Subcribe worker backgound notification
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        #endregion Initialization

        //-----------------------------------
        //- Region Menus (New, Open, Close) -
        //-----------------------------------
        #region Menus

        //---------------
        //- Close menus -
        //---------------
        /// <summary>
        /// Close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check if project opening
            if (_bopenedMode)
                CloseProject();

            //Close application
            Application.Exit();
        }

        /// <summary>
        /// Create un new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #if NO_BACKWORK_THREAD
                //Create project
                CreateNewProject();
            #else
                // Check if backworker busy
                if (backgroundWorker.IsBusy != true)
                {
                    //Check if project opened
                    if (_bopenedMode == true)
                        CloseProject();

                    // Set cursor
                    this.UseWaitCursor = true;

                    // Initilize backworker
                    backgroundWorker.DoWorkType = EnumDoWork.Create_Project;
                    backgroundWorker.RunWorkerAsync();

                    // Display progress
                    progress.StartDisplay("Nouveau projet", "Creation d'un nouveau projet...");

                    // Set cursor
                    Cursor.Current = Cursors.WaitCursor;
                }
            #endif
        }

        /// <summary>
        /// Open un new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                #if NO_BACKWORK_THREAD
                    // Open project
                    OpenProject();
                #else
                    // Check if backworker busy
                    if (backgroundWorker.IsBusy != true)
                    {
                        //-------------
                        //- Open file -
                        //-------------
                        //Create save file dialog
                        OpenFileDialog openFileDialog = new OpenFileDialog();

                        //Initialize save file dialog
                        openFileDialog.InitialDirectory = "d:\\play";
                        openFileDialog.Filter = "Text Files (*.xml)|*.xml";

                        // Display dialog
                        if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                            throw new ApplicationException("Ouverture annulée");

                        //Check if project opened
                        if (_bopenedMode == true)
                            CloseProject();

                        // Set cursor
                        this.UseWaitCursor = true;

                        // Initilize backworker
                        backgroundWorker.DoWorkType = EnumDoWork.Open_project;
                        backgroundWorker.RunWorkerAsync(openFileDialog.FileName);

                        // Display progress
                        progress.StartDisplay("Ouverture projet", "Ouverture d'un projet...");

                        // Set cursor
                        Cursor.Current = Cursors.WaitCursor;
                    }
                #endif
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Ouverture projet");
            }
        }

        /// <summary>
        /// Close project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close project
            CloseProject();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                #if NO_BACKWORK_THREAD
                    // Save project
                    SaveProject();
                #else
                    // Check if backworker busy
                    if (backgroundWorker.IsBusy != true)
                    {
                        // Set cursor
                        this.UseWaitCursor = true;

                        // Initilize backworker
                        backgroundWorker.DoWorkType = EnumDoWork.Save_project;
                        backgroundWorker.RunWorkerAsync();

                        // Display progress
                        progress.StartDisplay("Sauvegarde projet", "Sauvegarde du projet...");

                        // Set cursor
                        Cursor.Current = Cursors.WaitCursor;
                    }
                #endif
            }
            catch (Exception err)
            {
                //Display error
                MessageBox.Show(err.Message, "Save");
            }
        }

        /// <summary>
        /// SaveAs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                #if NO_BACKWORK_THREAD
                    // Save as project
                    SaveAsProject();
                #else
                    // Check if backworker busy
                    if (backgroundWorker.IsBusy != true)
                    {
                        //Check if tournoi generated
                        if (_btournoisGenerated == false)
                            throw new ApplicationException("Sauvegarde interrompue: Tounoi non généré");

                        //Get file name
                        string sInitialFile = FilePath;
                        if (String.IsNullOrEmpty(sInitialFile))
                        {
                            //Set file path
                            sInitialFile = _TournoisData.NomTournois;
                        }

                        //Create save file dialog
                        SaveFileDialog saveFileDialog = new SaveFileDialog();

                        //Initialize save file dialog
                        saveFileDialog.InitialDirectory = "d:\\play";
                        saveFileDialog.Filter = "Text Files (*.xml)|*.xml";
                        saveFileDialog.FileName = sInitialFile;

                        // Display dialog
                        if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
                            throw new ApplicationException("Sauvegarde sous annulée");

                        // TODO Check if file name exist in classement general

                        // Set cursor
                        this.UseWaitCursor = true;

                        // Initilize backworker
                        backgroundWorker.DoWorkType = EnumDoWork.SaveAs_project;
                        backgroundWorker.RunWorkerAsync(saveFileDialog.FileName);

                        // Display progress
                        progress.StartDisplay("Sauveagrde sous projet", "Sauvegarde sous du projet...");

                        // Set cursor
                        Cursor.Current = Cursors.WaitCursor;
                    }
                #endif
            }
            catch (Exception err)
            {
                //Display error
                MessageBox.Show(err.Message, "Sauvegarde sous");
            }
        }

        /// <summary>
        /// Check if menu enble
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            //-------------
            //- Save menu -
            //-------------
            if ((_bprojectModified == false) ||
                (_btournoisGenerated == false) ||
                 (String.IsNullOrEmpty(FilePath)))
                saveToolStripMenuItem.Enabled = false;
            else
                saveToolStripMenuItem.Enabled = true;

            //-----------
            //- Save AS -
            //-----------
            //Check if tournoi generated
            if (_btournoisGenerated == false)
                saveAsToolStripMenuItem.Enabled = false;
            else
                saveAsToolStripMenuItem.Enabled = true;
        }

#endregion Menus

        //-----------------------
        //- Region Menu service -
        //-----------------------
        #region Menu services

                /// <summary>
                /// Main menu mngt
                /// </summary>
                protected void UpateMainMenu(bool bopenmode)
                {
                    //Hide close project menu
                    mnProjetFerme.Visible = !bopenmode;

                    //Show opening project menu
                    mnProjetOuvert.Visible = bopenmode;

                    //Attach new main strip menu
                    if (bopenmode)
                        this.MainMenuStrip = this.mnProjetOuvert;
                    else
                        this.MainMenuStrip = this.mnProjetFerme;
                }

                protected void UpdateBackgoungClientZone(bool bopenmode)
                {
                    //Attach new main strip menu
                    panelClientcloseProject.Visible = !bopenmode;
                    _panelclientOpenProject.Visible = bopenmode;
                }

        #endregion Menu services

        //------------------------------------------------------------------
        //- Region Internal services (CreateNewProject, CloseProject, ...) -
        //------------------------------------------------------------------
        #region Internal services

        /// <summary>
        /// Updta title caption
        /// </summary>
        /// <param name="substring"></param>
        private void UpdateTitle(string newSubTitle, string oldSubTitle)
        {
            //Close project
            if (_bopenedMode == false)
            {
                Text = _initialTitle;
                _courantSubtitle = "";
            }
            else
            {
                //Check if old name is empty
                if (String.IsNullOrEmpty(oldSubTitle))
                    Text += " - " + newSubTitle;
                else
                {
                    Text = Text.Replace(oldSubTitle, newSubTitle);
                }

                //Set value
                _courantSubtitle = newSubTitle;
            }
        }

        /// <summary>
        /// Update title to display modification
        /// </summary>
        /// <param name="?"></param>
        private void UpdateTitleModif(bool bmodify)
        {
            //Test si nom em modif
            int iind = Text.IndexOf("*");

            //Update title
            if (bmodify == true)
            {
                //test si deja modifie
                if (iind > 0)
                    return;

                //Test si nulle
                if (String.IsNullOrEmpty(_courantSubtitle))
                    Text += "*";
                else
                {
                    string smodify = _courantSubtitle + "*";
                    Text = Text.Replace(_courantSubtitle, smodify);
                }
            }
            else
            {
                Text = Text.Replace("*", "");
            }
        }

        /// <summary>
        /// Code commun pre ouverture (New, Open) in background
        /// </summary>
        protected void CommonBeforeOuvertureInBackgroud()
        {
            //Create MDI forms
            CreateMDIForms();
        }

        /// <summary>
        /// Code commun post ouverture (New, Open) in background
        /// </summary>
        protected void CommonPostOuvertureInBackground()
        {
            //--------------
            //- Menus mngt -
            //--------------
            UpateMainMenu(true);

            //-------------------
            //- Background mngt -
            //-------------------
            UpdateBackgoungClientZone(true);

            //--------------------
            //- Initialize value -
            //--------------------
            //Set opened value
            _bopenedMode = true;
        }

        /// <summary>
        /// Code commun sur Open New
        /// </summary>
        protected void CommonOuverture()
        {
            //Check if project opened
            if (_bopenedMode == true)
                CloseProject();

            //Create MDI forms
            CreateMDIForms();

            //--------------
            //- Menus mngt -
            //--------------
            UpateMainMenu(true);

            //-------------------
            //- Background mngt -
            //-------------------
            UpdateBackgoungClientZone(true);

            //--------------------
            //- Initialize value -
            //--------------------
            //Set opened value
            _bopenedMode = true;
        }

        /// <summary>
        /// Read list of configured players
        /// </summary>
        protected void ReadConfiguredPlayers()
        {
            // Get full file name of configurated player
            string fullFileName = GetFullConfigurationFileName();

            // Check if file exist
            bool bFileExist = File.Exists(fullFileName);

            if (bFileExist)
            {
                using (StreamReader reader = new StreamReader(fullFileName))
                {
                    // Unserialize
                    System.Xml.Serialization.XmlSerializer sr = new XmlSerializer(typeof(JoueursConfigures));
                    _joueursClassementGeneral = (JoueursConfigures)sr.Deserialize(reader);
                    string result = reader.ReadToEnd();
                }
            }
            else
                _joueursClassementGeneral = new JoueursConfigures();

            return;
        }

        /// <summary>
        /// Write list of configured players
        /// </summary>
        protected void WriteConfiguredPlayers()
        {
            // Get full file name of configurated player
            string fullFileName = GetFullConfigurationFileName();
            using (TextWriter writer = new StreamWriter(fullFileName))
            {
                // Serialize
                System.Xml.Serialization.XmlSerializer sr = new XmlSerializer(typeof(JoueursConfigures));
                sr.Serialize(writer, _joueursClassementGeneral);
            }
        }

        /// <summary>
        ///Get configured players file
        /// </summary>
        string GetFullConfigurationFileName()
        {
            // Get full exe path
            string fullFilePath = Application.ExecutablePath;

            // Remove exe file name
            fullFilePath = Path.GetDirectoryName(fullFilePath);

            // Check file name
            if (fullFilePath.Length == 0)
                throw new ApplicationException("Impossible to find generla configured players file");

            // Format full file name
            fullFilePath += "\\";
            fullFilePath += cst_configuration_joueur_file;

            // Return full file name
            return fullFilePath;
        }

        /// <summary>
        /// Reset value on close project
        /// </summary>
        protected void ResetValueOpenMode()
        {
            //Update name
            UpdateTitle("", "");

            //Set inetranal value
            _bopenedMode = false;

            //Modification
            TournoisGenerated = false;

            //Modification
            ProjectModified = false;

            //File name
            FilePath = "";
        }

        /// <summary>
        /// Genere les données du tournois
        /// </summary>
        /// <returns></returns>
        protected bool GenererTorunois()
        {
            try
            {
                // Save list joueur saison
                if (_fmConfiguration.ListJoueurSaisonChanged == true)
                    WriteConfiguredPlayers();

                // Sort player list
                _fmConfiguration.SortPlayerListRandomly();

                //Create new tournement data
                _TournoisData = new Tournois();
                _TournoisData.GenererTournois(_fmConfiguration.Joueurs, _fmConfiguration.NomTournois(), _fmConfiguration.MatchAllerRetour);

                //Update vues tournoi
                if (!UpdateVuesTorunoi())
                    return false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Generer");

                return false;
            }

            return true;
        }

#endregion Internal services

        #region Menu services Create Open Close

                /// <summary>
                /// Create new project
                /// </summary>
                protected void CreateNewProject()
                {
                    try
                    {
                        //Ouverture 
                        CommonOuverture();

                        //Set modified value
                        ProjectModified = true;

                        //Set init file path
                        FilePath = "";

                        //Set tournoi generer
                        TournoisGenerated = false;

                        //Update name
                        UpdateTitle(cst_new_substring, "");

                        //-----------------------------------
                        //- Read list of configured players -
                        //-----------------------------------
                        ReadConfiguredPlayers();

                        //---------------
                        //- Update view -
                        //---------------
                        //General configured players initialisation
                        if (!UpdateConfiguredListJoueurs())
                            //Exception
                            throw new ApplicationException("Creation annulée");

                        //----------------------------
                        //- Update classemnt general -
                        //----------------------------
                        UpdateClassementGeneral(false);

                        //--------------------------
                        //- Default MDI child mngt -
                        //--------------------------
                        //Initialize form
                        DisplayAndSetFocus(_fmConfiguration);

                        //Select tab
                        _tabCtrlPanel.SelectTab(configuration_tag);

                        //Set last configuration active form
                        SetLastConfigurationFormSelected(_fmConfiguration);
                        SetLastTournoisFormSelected(_fmTournois);
                        SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Nouveau projet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                    }
                }

                /// <summary>
                /// Create new project
                /// </summary>
                protected void CreateNewProjectInBackground()
                {
                    try
                    {
                        //----------------------
                        //- Clear oldest value -
                        //----------------------
                        CommonBeforeOuvertureInBackgroud();

                        //-----------------------------------
                        //- Read list of configured players -
                        //-----------------------------------
                        ReadConfiguredPlayers();

                        //---------------
                        //- Update view -
                        //---------------
                        //General configured players initialisation
                        if (!UpdateConfiguredListJoueurs())
                            //Exception
                            throw new ApplicationException("Creation annulée");

                        //----------------------------
                        //- Update classemnt general -
                        //----------------------------
                        UpdateClassementGeneral(false);
                    }
                    catch (Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_new_project);
                    }
                }

                /// <summary>
                /// Create new project 
                /// End part
                /// </summary>
                protected void CreateNewProjectInBackgroundEndPart()
                {
                    try
                    {
                        //--------------------
                        //- Common ouverture -
                        //--------------------
                        CommonPostOuvertureInBackground();

                        //----------------
                        //- update title -
                        //----------------
                        UpdateTitle(cst_new_substring, "");

                        //--------------------------
                        //- Default MDI child mngt -
                        //--------------------------
                        //Initialize form
                        DisplayAndSetFocus(_fmConfiguration);

                        //Select tab
                        _tabCtrlPanel.SelectTab(configuration_tag);

                        //Set last configuration active form
                        SetLastConfigurationFormSelected(_fmConfiguration);
                        SetLastTournoisFormSelected(_fmTournois);
                        SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);

                        //Set modified value
                        ProjectModified = true;
                        TournoisGenerated = false;
                    }
                    catch (Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_new_project); ;
                    }
                }

                /// <summary>
                /// Open project
                /// </summary>
                private void OpenProject()
                {
                    try
                    {
                        //Ouverture 
                        CommonOuverture();

                        //-------------
                        //- Open file -
                        //-------------
                        //Create save file dialog
                        OpenFileDialog openFileDialog = new OpenFileDialog();

                        //Initialize save file dialog
                        openFileDialog.InitialDirectory = "d:\\play";
                        openFileDialog.Filter = "Text Files (*.xml)|*.xml";

                        //display dialog
                        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                        {
                            //-----------------------------------
                            //- Read list of configured players -
                            //-----------------------------------
                            ReadConfiguredPlayers();

                            //----------------------
                            //- Read tournois file -
                            //----------------------
                            // Serialization
                            System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                            using (TextReader w = new StreamReader(openFileDialog.FileName))
                            {
                                _TournoisData = (Tournois)s.Deserialize(w);
                            }

                            //set value
                            TournoisGenerated = true;

                            //Update vues tournoi
                            if (!UpdateVuesTorunoi())
                            {
                                //Reinitialise data
                                _TournoisData = new Tournois();

                                //Exception
                                throw new ApplicationException("Ouverture annulée");
                            }

                            //Set value
                            FilePath = openFileDialog.FileName;
                        }
                        else
                            throw new ApplicationException("Ouverture annulée");

                        //----------------------------
                        //- Update classemnt general -
                        //----------------------------
                        UpdateClassementGeneral(_TournoisData.ClassementGeneral.IsUpToDate);

                        //--------------------------
                        //- Default MDI child mngt -
                        //--------------------------
                        //Initialize form
                        DisplayAndSetFocus(_fmTournois);

                        //Select tab
                        _tabCtrlPanel.SelectTab(tournois_tag);

                        //Set last configuration active form
                        SetLastConfigurationFormSelected(_fmConfiguration);
                        SetLastTournoisFormSelected(_fmTournois);
                        SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);

                        //Set modification
                        ProjectModified = false;
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Open");

                        //Close project
                        CloseProject();
                    }
                    finally
                    {
                    }
                }

                /// <summary>
                /// Open project in background
                /// </summary>
                /// <param name="fileName"></param>
                private void OpenProjectInBackground(string fileName)
                {
                    try
                    {
                        //----------------------
                        //- Clear oldest value -
                        //----------------------
                        CommonBeforeOuvertureInBackgroud();

                        //-----------------------------------
                        //- Read list of configured players -
                        //-----------------------------------
                        ReadConfiguredPlayers();

                        //----------------------
                        //- Read tournois file -
                        //----------------------
                        // Serialization
                        System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                        using (TextReader w = new StreamReader(fileName))
                        {
                            _TournoisData = (Tournois)s.Deserialize(w);
                        }

                        // set value temporary
                        _filePath = fileName;
                    }
                    catch (Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_open_project);
                    }
                }

                /// <summary>
                /// Open project in background
                /// </summary>
                private void OpenProjectInBackgroundEndPart()
                {
                    try
                    {
                        //--------------------
                        //- Common ouverture -
                        //--------------------
                        CommonPostOuvertureInBackground();

                        //-----------------------
                        //- set specific values -
                        //-----------------------
                        TournoisGenerated = true;
                        FilePath = _filePath;

                        //Update vues tournoi
                        if (!UpdateVuesTorunoi())
                        {
                            //Reinitialise data
                            _TournoisData = new Tournois();

                            //Set value
                            FilePath = "";

                            //Exception
                            throw new ApplicationException("Ouverture annulée");
                        }        

                        //----------------------------
                        //- Update classemnt general -
                        //----------------------------
                        UpdateClassementGeneral(_TournoisData.ClassementGeneral.IsUpToDate);

                        //--------------------------
                        //- Default MDI child mngt -
                        //--------------------------
                        //Initialize form
                        DisplayAndSetFocus(_fmTournois);

                        //Select tab
                        _tabCtrlPanel.SelectTab(tournois_tag);

                        //Set last configuration active form
                        SetLastConfigurationFormSelected(_fmConfiguration);
                        SetLastTournoisFormSelected(_fmTournois);
                        SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);

                        //Set modification
                        ProjectModified = false;
                    }
                    catch (Exception err)
                    {
                            throw new PlayStationException(err.Message, Err.err_open_project);
                    }   
                }

                /// <summary>
                /// Close project
                /// </summary>
                protected void CloseProject()
                {
                    //--------------
                    //- Menus mngt -
                    //--------------
                    UpateMainMenu(false);

                    //-------------------
                    //- Background mngt -
                    //-------------------
                    UpdateBackgoungClientZone(false);

                    //-------------------
                    //- MDI Client mngt -
                    //-------------------
                    CloseAllMDIForms();

                    //Reset value on close project
                    ResetValueOpenMode();
                }

                /// <summary>
                /// Save project
                /// </summary>
                protected void SaveProject()
                {
                    //Force to update classement
                    _fmTournois.ForceUpdateClassement();

                    // Serialization
                    System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                    using (TextWriter w = new StreamWriter(FilePath))
                    {
                        s.Serialize(w, _TournoisData);
                    }

                    //Set modification
                    ProjectModified = false;
                }

                /// <summary>
                /// Save project in background
                /// </summary>
                protected void SaveProjectInBackground()
                {
                    try
                    {
                        //Force to update classement
                        _fmTournois.ForceUpdateClassement();

                        // Serialization
                        System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                        using (TextWriter w = new StreamWriter(FilePath))
                        {
                            s.Serialize(w, _TournoisData);
                        }
                    }
                    catch(Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_save_project);
                    }    
                }

                /// <summary>
                /// Save project in background end part
                /// </summary>
                protected void SaveProjectInBackgroundEndPart()
                {
                    try
                    {
                        //Set modification
                        ProjectModified = false;
                    }
                    catch (Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_save_project);
                    }
                }

                /// <summary>
                /// Save as project
                /// </summary>
                /// 
                protected void SaveAsProject()
                {
                    //Check if tournoi generated
                    if (_btournoisGenerated == false)
                        throw new ApplicationException("Sauvegarde interrompue: Tounoi non généré");

                    //Force to update classement
                    _fmTournois.ForceUpdateClassement();

                    //Get file name
                    string sInitialFile = FilePath;
                    if (String.IsNullOrEmpty(sInitialFile))
                    {
                        //Set file path
                        sInitialFile = _TournoisData.NomTournois;
                    }

                    //Create save file dialog
                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    //Initialize save file dialog
                    saveFileDialog.InitialDirectory = "d:\\play";
                    saveFileDialog.Filter = "Text Files (*.xml)|*.xml";
                    saveFileDialog.FileName = sInitialFile;

                    //display dialog
                    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        //Set vaalue
                        FilePath = saveFileDialog.FileName;

                        // Serialization
                        System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                        using (TextWriter w = new StreamWriter(FilePath))
                        {
                            s.Serialize(w, _TournoisData);
                        }

                        //Set modification
                        ProjectModified = false;
                    }

                    //------------------------------------
                    //- Write list of configured players -
                    //------------------------------------
                    WriteConfiguredPlayers();
                }

                /// <summary>
                /// Save as project in backgound
                /// </summary>
                /// <param name="fileName"></param>
                protected void SaveAsProjectInBackground(string fileName)
                {
                    try
                    {
                        //------------------------------
                        //- Force to update classement -
                        //------------------------------
                        _fmTournois.ForceUpdateClassement();

                        //----------------
                        //- Serialization -
                        //-----------------
                        System.Xml.Serialization.XmlSerializer s = new XmlSerializer(typeof(Tournois));
                        using (TextWriter w = new StreamWriter(fileName))
                        {
                            s.Serialize(w, _TournoisData);
                        }

                        //------------------------------------
                        //- Write list of configured players -
                        //------------------------------------
                        WriteConfiguredPlayers();

                        //------------------------------
                        //- Set temporary project name -
                        //------------------------------
                        _filePath = fileName;
                    }
                    catch(Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_saveas_project);
                    }
                }

                /// <summary>
                /// Save as project in backgound
                /// </summary>
                protected void SaveAsProjectInBackgroundEndPart()
                {
                    try
                    {
                        //--------------------
                        //- Set modification -
                        //--------------------
                        ProjectModified = false;

                        //-----------------------
                        //- Set new project name -
                        //------------------------
                        FilePath = _filePath;
                    }
                    catch (Exception err)
                    {
                        throw new PlayStationException(err.Message, Err.err_saveas_project);
                    }
                }

                #endregion Menu services Create Open Close

        #region Views services

        /// <summary>
        /// Create MDI form
        /// </summary>
        private void CreateMDIForms()
        {
            //Create all forms
            _fmTournois = new TournoisForm();
            _fmClassement = new ClassementForm();
            _fmJoueurs = new JoueursForm();
            _fmConfiguration = new ConfigurationForm();
            _fmClassementGeneralForm = new ClassementGeneralForm();
            _fmClassementGenSelectionFile = new GeneralSelectionFileForm();

            //Set last active form
            _fmConfFormActived = _fmConfiguration;
            _fmTournoisFormactived = _fmTournois;
            _fmClassementGenFormActived = _fmClassementGeneralForm;
        }

        /// <summary>
        /// Update des vues tournois
        /// </summary>
        private bool UpdateVuesTorunoi()
        {
            //General configured players initialisation
            if (!UpdateConfiguredListJoueurs())
                return false;

            //Configuration initialisation
            if (!UpdateConfiguration())
                return false;

            //Player list initialisation
            if (!UpdateListJoueurs())
                return false;

            //Update classement
            if (!UpdateClassement())
                return false;

            //Update calendrier form
            if (!UpdateCalendrier())
                return false;

            //Update classement général
            if (!UpdateClassementGeneral())
                return false;

            //Update classement general files
            if (!UpdateClassementSelectionFile())
                return false;

            //retour sans erreur
            return true;
        }


        /// <summary>
        /// Update configured list players
        /// </summary>
        /// <returns></returns>
        private bool UpdateConfiguredListJoueurs()
        {
            try
            {
                //generate players
                if (!_fmConfiguration.InitializeDataForTournment(ref _joueursClassementGeneral))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmJoueurs, error.Message, "Générer");

                return false;
            }
            return true;
        }
 
        /// <summary>
        /// Update configuration
        /// </summary>
        /// <returns></returns>
        private bool UpdateConfiguration()
        {
            try
            {
                //generate players
                if (!_fmConfiguration.InitializeDataForTournment(ref _TournoisData))
                    return false;

                //generate players
                if (!_fmConfiguration.InitializeDataForTournment(ref _joueursClassementGeneral))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmJoueurs, error.Message, "Générer");

                return false;
            }
            return true;
        }

        /// <summary>
        /// Generate list of players
        /// </summary>
        bool UpdateListJoueurs()
        {
            try
            {
                //generate players
                if (!_fmJoueurs.InitializeDataForTournment(ref _TournoisData))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmJoueurs, error.Message, "Générer");

                return false;
            }
            return true;
        }

        /// <summary>
        /// Update celandrier
        /// Efface ancieenes valeurs et re initialise les donnees
        /// </summary>
        /// <returns></returns>
        private bool UpdateCalendrier()
        {
            try
            {
                //generate players
                if (!_fmTournois.InitializeDataForTournment(ref _TournoisData))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmJoueurs, error.Message, "Générer");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Update classement
        /// </summary>
        /// <returns></returns>
        private bool UpdateClassement()
        {
            try
            {
                //generate players
                if (!_fmClassement.InitializeDataForTournment(ref _TournoisData))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmClassement, error.Message, "Générer");

                return false;
            }
            return true;
        }

        /// <summary>
        /// Update classement général
        /// Efface anciennes valeurs et re initialise les donnees
        /// </summary>
        /// <returns></returns>
        private bool UpdateClassementGeneral()
        {
            try
            {
                //Update attaque view
                if (!_fmClassementGeneralForm.InitializeDataForTournment(ref _TournoisData))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmClassementGeneralForm, error.Message, "Générer");

                return false;
            }
            return true;
        }

        /// <summary>
        /// Update selection file
        /// Efface anciennes valeurs et re initialise les donnees
        /// </summary>
        /// <returns></returns>
        private bool UpdateClassementSelectionFile()
        {
            try
            {
                //Update attaque view
                if (!_fmClassementGenSelectionFile.InitializeDataForTournment(ref _TournoisData))
                    return false;
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmClassementGenSelectionFile, error.Message, "Générer");

                return false;
            }
            return true;
        }

#endregion Views services

        //---------------------- --------------------------------------      
        //- Buttons management (Tournois click, Classement click, ... -
        //-------------------------------------------------------------
        #region Buttons management

        /// <summary>
        /// Tournois Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTournois_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmTournois);

            //Set last tounois active form
            SetLastTournoisFormSelected(_fmTournois);
        }

        /// <summary>
        /// Classement Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClassement_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassement);

            // Sort classement
            _fmClassement.SortClassement(SortEnum.Default);

            //Set last tounois active form
            SetLastTournoisFormSelected(_fmClassement);
        }

        /// <summary>
        /// Meilleurs attaques Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMeilleurAttaque_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassement);

            // Sort classement
            _fmClassement.SortClassement(SortEnum.Meilleur_Attaque);

            //Set last tounois active form
            SetLastTournoisFormSelected(_fmClassement);
        }

        /// <summary>
        /// Meilleurs defense Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMeilleurDefense_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassement);

            // Sort classement
            _fmClassement.SortClassement(SortEnum.Meilleur_Defense);

            //Set last tounois active form
            SetLastTournoisFormSelected(_fmClassement);
        }

        /// <summary>
        /// Liste des joueurs Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonJoueurs_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmJoueurs);

            //Set last tounois active form
            SetLastTournoisFormSelected(_fmJoueurs);
        }

        /// <summary>
        /// Configuration tournoi form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfigurer_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmConfiguration);

            //Set last configuration active form
            SetLastConfigurationFormSelected(_fmConfiguration);
        }

        /// <summary>
        /// Generate tournment data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerer_Click(object sender, EventArgs e)
        {
            //Check if configuration data are initialized
            try
            {
                // Validate configuraion
                _fmConfiguration.ValidateConfiguration();
            }
            catch (Exception error)
            {
                //Error mngt
                DisplayErrorMngt(_fmConfiguration, error.Message, "Générer");

                return;
            }

            //Check if already generated
            if (_btournoisGenerated)
            {
                //DisplayNameAttribute message
                DialogResult DlgRes = MessageBox.Show("Un tournoi est deja en cours, les données seront effacées.\nVoulez-vous re-initaliser les données du tournoi?", "Générer", MessageBoxButtons.YesNo);

                //Check return
                if (DlgRes != DialogResult.Yes)
                    return;
            }

            //genere les donnees du tournois
            if (!GenererTorunois())
                return;

            //Display message
            MessageBox.Show("données générées.\nBon amusement et que le meilleur gagne. ", "Generer");

            //Modify project
            ProjectModified = true;

            //Select tournoi form
            _tabCtrlPanel.SelectTab(tournois_tag);
            buttonTournois_Click(this, null);

            //Set value
            TournoisGenerated = true;
        }

        /// <summary>
        /// Classement general form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClassementGeneral_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassementGeneralForm);

            // Sort
            _fmClassementGeneralForm.SortClassement(SortEnum.Default);

            //Set last configuration active form
            SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);
        }

        /// <summary>
        /// Attaque generale form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttaqueGeneral_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassementGeneralForm);

            // Sort
            _fmClassementGeneralForm.SortClassement(SortEnum.Meilleur_Attaque);

            //Set last configuration active form
            SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);
        }

        /// <summary>
        /// Defense generale form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefenseGeneral_Click(object sender, EventArgs e)
        {
            //Initialize form
            DisplayAndSetFocus(_fmClassementGeneralForm);

            // Sort
            _fmClassementGeneralForm.SortClassement(SortEnum.Meilleur_Defense);

            //Set last configuration active form
            SetLastClassementGeneralFormSelected(_fmClassementGeneralForm);
        }

        /// <summary>
        /// Classement selection file form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionFichierTournois_Click(object sender, EventArgs e)
        {
             //Initialize form
            DisplayAndSetFocus(_fmClassementGenSelectionFile);

            //Set last configuration active form
            SetLastClassementGeneralFormSelected(_fmClassementGenSelectionFile);
        }

        /// <summary>
        /// Update clssement general
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateClassementGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                #if NO_BACKWORK_THREAD
                    // Generer classement general
                    GenererClassementGeneral();
                #else
                    // Check if backworker busy
                    if (backgroundWorker.IsBusy != true)
                    {
                        // Ask validation
                        if (MessageBox.Show("Update classement general", "", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;

                        // Set cursor
                        this.UseWaitCursor = true;

                        // Initilize backworker
                        backgroundWorker.DoWorkType = EnumDoWork.Generate_classement_general;
                        backgroundWorker.RunWorkerAsync();

                        // Display progress
                        progress.StartDisplay("Générer classement général", "Génération du classement général...");

                        // Set cursor
                        Cursor.Current = Cursors.WaitCursor;
                    }
                #endif
            }
            catch (Exception err)
            {
                //Display error
                MessageBox.Show(err.Message, "Générer classement général");
            }
        }

        /// <summary>
        /// Generer classement general
        /// </summary>
        protected void GenererClassementGeneral()
        {
            // Ask validation
            if (MessageBox.Show("Update classement general", "", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // Generate tournoi
            _fmClassementGenSelectionFile.GenerateClassement();

            // Propagate modification
            PropagateModification(TypeModification.ClassementItemFileUpToDate, true);

            // Set focus to classement general
            DisplayAndSetFocus(_fmClassementGeneralForm);
        }

        /// <summary>
        /// Generer classement general in background
        /// </summary>
        protected void GenererClassementGeneralInBackground()
        {
            try
            {
                // Generate tournoi
                _fmClassementGenSelectionFile.GenerateClassement();

                // Propagate modification
                PropagateModification(TypeModification.ClassementItemFileUpToDate, true);

                // Set focus to classement general
                _fmClassementGeneralForm.SortClassement(SortEnum.Default);
                DisplayAndSetFocus(_fmClassementGeneralForm);
            }
            catch(Exception err)
            {
                throw new PlayStationException(err.Message, Err.err_generer_class_gen);
            }
        }

        /// <summary>
        /// Export excel click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Prompt the user to enter a path/filename to save an example Excel file to
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.OverwritePrompt = false;

            //  If the user hit Cancel, then abort!
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            //Export file
            CreateExcelFile.CreateExcelDocument(TournoisData.ClassementGeneral.ListClassementGeneralItem, saveFileDialog.FileName);
        }

        #endregion Buttons management

        //-----------------------------------------------------------------
        //- MDI Child management (IsMDIChildOpening, InitializeForm, ...) -
        //-----------------------------------------------------------------
        #region MDI Child management

                /// <summary>
                /// Return MDI child object is form already opened
                /// </summary>
                /// <param name="nameForm"></param>
                /// <returns></returns>
                protected Form IsMDIChildOpening(string nameForm)
                {
                    //Check if MDI children opened
                    if (this.MdiChildren.Length == 0)
                        return null;

                    //Get MDI children
                    Form[] mdichld = this.MdiChildren;
                    foreach (Form mdifm in mdichld)
                    {
                        string str = mdifm.Name;

                        if (str == nameForm)
                            return mdifm;
                    }

                    //Default value
                    return null;
                }

                /// <summary>
                /// Initialize MDI child form
                /// </summary>
                /// <param name="mdiForm"></param>
                protected void InitializeForm(Form mdiForm)
                {
                    //Fix Microsoft bug Has to be called before set MDI parent
                    //Disable Minimize, Maximize
                    mdiForm.MinimizeBox = false;
                    mdiForm.MaximizeBox = false;

                    //Set mdi parent
                    mdiForm.MdiParent = this;

                    //Work around bug (Focus MDI maximized)
                    mdiForm.ControlBox = false;
                    mdiForm.Dock = DockStyle.Fill;
                    mdiForm.FormBorderStyle = FormBorderStyle.None;
                    mdiForm.Focus();

                    //Maximize form
                    mdiForm.WindowState = FormWindowState.Maximized;

                    //Set focus
                    mdiForm.Focus();

                    //Show
                    mdiForm.Show();
                }

                /// <summary>
                /// Fermeture de toutes les fenetres MDI
                /// </summary>
                protected void CloseAllMDIForms()
                {
                    Form[] mdichld = this.MdiChildren;
                    foreach (Form mdifm in mdichld)
                        mdifm.Close();
                }

                /// <summary>
                /// Set focus to MDI child form (MDI maximized issue)
                /// </summary>
                /// <param name="mdiForm"></param>
                protected void SetMDIChildFocus(Form mdiForm)
                {
                    try
                    {
                        //Check value
                        if (mdiForm == null)
                            return;

                        //Set focus
                        mdiForm.Focus();

                        //Work around bug (Focus MDI maximized)
                        mdiForm.WindowState = FormWindowState.Maximized;

                        return;
                    }
                    catch (Exception e)
                    {
                        string s = mdiForm.Name + e.Message;
                        MessageBox.Show(s, "SetMDIChildFocus");
                    }
                }

                /// <summary>
                /// Open form view if closed
                /// Otherwise set focus
                /// </summary>
                /// <param name="nameformview"></param>
                protected void DisplayAndSetFocus(Form fwclient)
                {
                    //Check if already opnened
                    if (IsMDIChildOpening(fwclient.Name) != null)
                    {
                        //set focus
                        SetMDIChildFocus(fwclient);
                    }
                    else
                    {
                        //Open window
                        //Initialize form
                        InitializeForm(fwclient);
                    }
                }

                /// <summary>
                /// Error management
                ///     Open form or set focus
                ///     Display message
                /// </summary>
                /// <param name="fwclient"></param>
                /// <param name="stringerror"></param>
                /// <param name="stingtitle"></param>
                /// <returns></returns>
                void DisplayErrorMngt(Form fwclient, string stringerror, string stingtitle)
                {
                    //Active form
                    DisplayAndSetFocus(fwclient);

                    //DisplayNameAttribute message
                    DialogResult DlgRes = MessageBox.Show(stringerror, stingtitle, MessageBoxButtons.OK);
                }

                /// <summary>
                /// Set last configuration form activated
                /// </summary>
                /// <param name="fwform"></param>
                void SetLastConfigurationFormSelected(Form fwform)
                {
                    _fmConfFormActived = fwform;
                }

                /// <summary>
                /// Set last tournois form activated
                /// </summary>
                /// <param name="fwform"></param>
                void SetLastTournoisFormSelected(Form fwform)
                {
                    _fmTournoisFormactived = fwform;
                }

                /// <summary>
                /// Set last tournois form activated
                /// </summary>
                /// <param name="fwform"></param>
                void SetLastClassementGeneralFormSelected(Form fwform)
                {
                    _fmClassementGenFormActived = fwform;
                }

                /// <summary>
                /// Propagation du type de modification 
                /// (ModifListJoueurs,  ModifClassement)
                /// </summary>
                /// <param name="eTypeModif"></param>
                /// <returns></returns>
                public bool PropagateModification(TypeModification eTypeModif, bool bValue)
                {
                    //Set projet to modify
                    ProjectModified = true;

                    // Check modif classement
                    if (eTypeModif == TypeModification.ClassementItemFileUpToDate)
                    {
                        UpdateClassementGeneral(bValue);
                    }
                    else if (eTypeModif == TypeModification.ModifClassement)
                    {
                        if (_TournoisData.ClassementGeneral.IsCurrentClassementAdded)
                            UpdateClassementGeneral(false);
                    }
            
                    //Iterate throw child window
                    Form[] mdichld = this.MdiChildren;
                    foreach (Form mdifm in mdichld)
                    {
                        //Check if TournoisBaseForm
                        TournoisBaseForm mdichildtournoisbaseform = (TournoisBaseForm)mdifm;
                        if (mdichildtournoisbaseform != null)
                        {
                            mdichildtournoisbaseform.PropagateModificaion(eTypeModif, bValue);
                        }
                    }
           

                    //Return value
                    return true;
                }

        #endregion MDI Child management

        //------------------------------
        //- MDI Tab control management -
        //------------------------------
        #region Tab control management

                /// <summary>
                /// Manage the tab selection to restore last opening window
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void _tabCtrlPanel_SelectedIndexChanged(object sender, EventArgs e)
                {
                    switch (_tabCtrlPanel.SelectedIndex)
                    {
                        case configuration_tag:
                            {
                                DisplayAndSetFocus(_fmConfFormActived);
                                break;
                            }
                        case tournois_tag:
                            {
                                DisplayAndSetFocus(_fmTournoisFormactived);
                                break;
                            }
                        case classementgen_tag:
                            {
                                DisplayAndSetFocus(_fmClassementGenFormActived);
                                break;
                            }
                        default:
                            break;
                    }
                }


        #endregion MDI Tab control management

        #region Public service

                /// <summary>
                /// Update controls linked with main classement
                /// </summary>
                /// <param name="enable"></param>
                public void UpdateClassementGeneral(bool updated)
                {
                    // Check if tournoi generé
                    if (TournoisGenerated == false)
                        // Modify project
                        ProjectModified = true;
                }

        #endregion Public service


        #region Background thread worker

                /// <summary>
                /// Execute backwork action
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        // Get worker action
                        PlayBackgroundWorker worker = sender as PlayBackgroundWorker;

                        // Wait cursor
                        this.UseWaitCursor = true;

                        // Switch worke action
                        string fileName = "";
                        switch (worker.DoWorkType)
                        {
                            //Create project
                            case EnumDoWork.Create_Project:
                                CreateNewProjectInBackground();
                                break;
                            //Open project
                            case EnumDoWork.Open_project:
                                fileName = (string)e.Argument;
                                OpenProjectInBackground(fileName);
                                break;
                            // Save project
                            case EnumDoWork.Save_project:                        
                                SaveProjectInBackground();
                                break;
                            // Save as project
                            case EnumDoWork.SaveAs_project:
                                fileName = (string)e.Argument;
                                SaveAsProjectInBackground(fileName);
                                break;
                            case EnumDoWork.Generate_classement_general:
                                break;
                            default:
                                break;
                        }

                        // Set value
                        e.Result = true;
                    }
                    catch(Exception err)
                    {
                        // Hide progress
                        progress.StopDisplay();

                        // Throw error
                        throw err;
                    }
                }

                /// <summary>
                /// Complete backwork action
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
                {
                    try
                    {
                        // Check error
                        if (e.Error != null)
                            throw e.Error;

                        PlayBackgroundWorker worker = sender as PlayBackgroundWorker;
                        this.UseWaitCursor = true;

                        switch (worker.DoWorkType)
                        {
                            //Create project
                            case EnumDoWork.Create_Project:
                                CreateNewProjectInBackgroundEndPart();
                                break;
                            case EnumDoWork.Open_project:
                                 OpenProjectInBackgroundEndPart();
                                break;
                            case EnumDoWork.Save_project:
                                SaveProjectInBackgroundEndPart();
                                break;
                            case EnumDoWork.SaveAs_project:
                                SaveAsProjectInBackgroundEndPart();
                                break;
                            case EnumDoWork.Generate_classement_general:
                                GenererClassementGeneralInBackground();
                                break;
                            default:
                                break;
                        }

                        // Hide progress
                        progress.StopDisplay();
                    }
                    catch (PlayStationException err)
                    {
                        // Hide progress
                        progress.StopDisplay();

                        // Manage error
                         switch (err.ErrNumber)
                        {
                            case Err.err_open_project:
                                MessageBox.Show(err.Message, "Ouverture projet");
                                CloseProject();
                                break;
                            case Err.err_new_project:
                                MessageBox.Show(err.Message, "Création projet");
                                CloseProject();
                                break;
                            case Err.err_save_project:
                                MessageBox.Show(err.Message, "Sauvegarde projet");
                                break;
                            case Err.err_saveas_project:
                                MessageBox.Show(err.Message, "Sauvegarde sous projet");
                                break;
                            case Err.err_generer_class_gen:
                                MessageBox.Show(err.Message, "Générer classement général");
                                break;
                            default:
                                MessageBox.Show(err.Message, "Error");
                                break;
                        }
                    }
                    finally
                    {
                        // Stop wit crsor
                        this.UseWaitCursor = false;
                        this.Cursor = Cursors.Default;
                    }
                }
                private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                    //this.tbProg.Text = (e.ProgressPercentage.ToString() + "%");
                }

        #endregion


    }
}