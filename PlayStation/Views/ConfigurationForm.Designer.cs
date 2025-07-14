using PlayStationData;

namespace PlayStation.Views
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.buttonEffacerAllJoueurs = new System.Windows.Forms.Button();
            this.btnEffacerJoueur = new System.Windows.Forms.Button();
            this.btnAddJoueur = new System.Windows.Forms.Button();
            this.dataGridJoueursTournoi = new System.Windows.Forms.DataGridView();
            this.nomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomCompletDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceJoueurs = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipConfiguration = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddJoueurSaison = new System.Windows.Forms.Button();
            this.btnRemoveJoueurSaison = new System.Windows.Forms.Button();
            this.groupBoxOptionTournoois = new System.Windows.Forms.GroupBox();
            this.textBoxNomTournois = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radioBtnAllerRetour = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnAller = new System.Windows.Forms.RadioButton();
            this.groupBoxTournois = new System.Windows.Forms.GroupBox();
            this.groupBoxJoueursTournoi = new System.Windows.Forms.GroupBox();
            this.btnSortListPlayersTournois = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxJoeursSaison = new System.Windows.Forms.GroupBox();
            this.dataGridJoueursSaison = new System.Windows.Forms.DataGridView();
            this.nomDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomCompletDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceJoueurSaison = new System.Windows.Forms.BindingSource(this.components);
            this.tbxIdJoueurSaison = new System.Windows.Forms.TextBox();
            this.tbxTeamJoeurSaison = new System.Windows.Forms.TextBox();
            this.tbxNomJoueurSaison = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxSaison = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueursTournoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJoueurs)).BeginInit();
            this.groupBoxOptionTournoois.SuspendLayout();
            this.groupBoxTournois.SuspendLayout();
            this.groupBoxJoueursTournoi.SuspendLayout();
            this.groupBoxJoeursSaison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueursSaison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJoueurSaison)).BeginInit();
            this.groupBoxSaison.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEffacerAllJoueurs
            // 
            this.buttonEffacerAllJoueurs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEffacerAllJoueurs.Location = new System.Drawing.Point(888, 148);
            this.buttonEffacerAllJoueurs.Name = "buttonEffacerAllJoueurs";
            this.buttonEffacerAllJoueurs.Size = new System.Drawing.Size(112, 26);
            this.buttonEffacerAllJoueurs.TabIndex = 3;
            this.buttonEffacerAllJoueurs.Text = "Tout effacer";
            this.toolTipConfiguration.SetToolTip(this.buttonEffacerAllJoueurs, "Effacer tous les joueurs");
            this.buttonEffacerAllJoueurs.UseVisualStyleBackColor = true;
            this.buttonEffacerAllJoueurs.Click += new System.EventHandler(this.buttonEffacerAllJoueurs_Click);
            // 
            // btnEffacerJoueur
            // 
            this.btnEffacerJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEffacerJoueur.Enabled = false;
            this.btnEffacerJoueur.Location = new System.Drawing.Point(888, 116);
            this.btnEffacerJoueur.Name = "btnEffacerJoueur";
            this.btnEffacerJoueur.Size = new System.Drawing.Size(112, 26);
            this.btnEffacerJoueur.TabIndex = 2;
            this.btnEffacerJoueur.Text = "Effacer";
            this.toolTipConfiguration.SetToolTip(this.btnEffacerJoueur, "Effacer un joueur");
            this.btnEffacerJoueur.UseVisualStyleBackColor = true;
            this.btnEffacerJoueur.Click += new System.EventHandler(this.buttonEffacerJoueur_Click);
            // 
            // btnAddJoueur
            // 
            this.btnAddJoueur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddJoueur.Enabled = false;
            this.btnAddJoueur.Location = new System.Drawing.Point(888, 69);
            this.btnAddJoueur.Name = "btnAddJoueur";
            this.btnAddJoueur.Size = new System.Drawing.Size(112, 26);
            this.btnAddJoueur.TabIndex = 1;
            this.btnAddJoueur.Text = "Ajouter";
            this.toolTipConfiguration.SetToolTip(this.btnAddJoueur, "Ajoutr un nouveau joueur");
            this.btnAddJoueur.UseVisualStyleBackColor = true;
            this.btnAddJoueur.Click += new System.EventHandler(this.btnAddJoueur_Click);
            // 
            // dataGridJoueursTournoi
            // 
            this.dataGridJoueursTournoi.AllowDrop = true;
            this.dataGridJoueursTournoi.AllowUserToAddRows = false;
            this.dataGridJoueursTournoi.AllowUserToDeleteRows = false;
            this.dataGridJoueursTournoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridJoueursTournoi.AutoGenerateColumns = false;
            this.dataGridJoueursTournoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridJoueursTournoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridJoueursTournoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomDataGridViewTextBoxColumn,
            this.equipeDataGridViewTextBoxColumn,
            this.nomCompletDataGridViewTextBoxColumn});
            this.dataGridJoueursTournoi.DataSource = this.bindingSourceJoueurs;
            this.dataGridJoueursTournoi.Location = new System.Drawing.Point(17, 24);
            this.dataGridJoueursTournoi.Name = "dataGridJoueursTournoi";
            this.dataGridJoueursTournoi.Size = new System.Drawing.Size(838, 178);
            this.dataGridJoueursTournoi.TabIndex = 0;
            this.dataGridJoueursTournoi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridJoueurs_CellValueChanged);
            this.dataGridJoueursTournoi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridJoueurs_RowPostPaint);
            this.dataGridJoueursTournoi.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridJoueurs_RowsRemoved);
            this.dataGridJoueursTournoi.SelectionChanged += new System.EventHandler(this.dataGridJoueurs_SelectionChanged);
            this.dataGridJoueursTournoi.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridJoueursTournoi_DragDrop);
            this.dataGridJoueursTournoi.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridJoueursTournoi_DragEnter);
            this.dataGridJoueursTournoi.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridJoueursTournoi_DragOver);
            // 
            // nomDataGridViewTextBoxColumn
            // 
            this.nomDataGridViewTextBoxColumn.DataPropertyName = "Nom";
            this.nomDataGridViewTextBoxColumn.HeaderText = "Nom";
            this.nomDataGridViewTextBoxColumn.Name = "nomDataGridViewTextBoxColumn";
            // 
            // equipeDataGridViewTextBoxColumn
            // 
            this.equipeDataGridViewTextBoxColumn.DataPropertyName = "Equipe";
            this.equipeDataGridViewTextBoxColumn.HeaderText = "Equipe";
            this.equipeDataGridViewTextBoxColumn.Name = "equipeDataGridViewTextBoxColumn";
            // 
            // nomCompletDataGridViewTextBoxColumn
            // 
            this.nomCompletDataGridViewTextBoxColumn.DataPropertyName = "NomComplet";
            this.nomCompletDataGridViewTextBoxColumn.HeaderText = "NomComplet";
            this.nomCompletDataGridViewTextBoxColumn.Name = "nomCompletDataGridViewTextBoxColumn";
            this.nomCompletDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceJoueurs
            // 
            this.bindingSourceJoueurs.DataSource = typeof(PlayStationData.Joueurs);
            // 
            // btnAddJoueurSaison
            // 
            this.btnAddJoueurSaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddJoueurSaison.Location = new System.Drawing.Point(876, 146);
            this.btnAddJoueurSaison.Name = "btnAddJoueurSaison";
            this.btnAddJoueurSaison.Size = new System.Drawing.Size(140, 26);
            this.btnAddJoueurSaison.TabIndex = 8;
            this.btnAddJoueurSaison.Text = "Ajouter joueur  saison";
            this.toolTipConfiguration.SetToolTip(this.btnAddJoueurSaison, "Ajoutr un nouveau joueur");
            this.btnAddJoueurSaison.UseVisualStyleBackColor = true;
            this.btnAddJoueurSaison.Click += new System.EventHandler(this.btnAddJoueurSaison_Click);
            // 
            // btnRemoveJoueurSaison
            // 
            this.btnRemoveJoueurSaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveJoueurSaison.Enabled = false;
            this.btnRemoveJoueurSaison.Location = new System.Drawing.Point(876, 178);
            this.btnRemoveJoueurSaison.Name = "btnRemoveJoueurSaison";
            this.btnRemoveJoueurSaison.Size = new System.Drawing.Size(140, 26);
            this.btnRemoveJoueurSaison.TabIndex = 11;
            this.btnRemoveJoueurSaison.Text = "Supprimer joueur(s)";
            this.toolTipConfiguration.SetToolTip(this.btnRemoveJoueurSaison, "Suppression des joueurs selectionnés");
            this.btnRemoveJoueurSaison.UseVisualStyleBackColor = true;
            this.btnRemoveJoueurSaison.Click += new System.EventHandler(this.btnRemoveJoueurSaison_Click);
            // 
            // groupBoxOptionTournoois
            // 
            this.groupBoxOptionTournoois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOptionTournoois.Controls.Add(this.textBoxNomTournois);
            this.groupBoxOptionTournoois.Controls.Add(this.label3);
            this.groupBoxOptionTournoois.Controls.Add(this.radioBtnAllerRetour);
            this.groupBoxOptionTournoois.Controls.Add(this.label1);
            this.groupBoxOptionTournoois.Controls.Add(this.radioBtnAller);
            this.groupBoxOptionTournoois.Location = new System.Drawing.Point(31, 41);
            this.groupBoxOptionTournoois.Name = "groupBoxOptionTournoois";
            this.groupBoxOptionTournoois.Size = new System.Drawing.Size(1027, 105);
            this.groupBoxOptionTournoois.TabIndex = 3;
            this.groupBoxOptionTournoois.TabStop = false;
            this.groupBoxOptionTournoois.Text = "Option du tournoi";
            // 
            // textBoxNomTournois
            // 
            this.textBoxNomTournois.Location = new System.Drawing.Point(192, 52);
            this.textBoxNomTournois.Name = "textBoxNomTournois";
            this.textBoxNomTournois.Size = new System.Drawing.Size(232, 20);
            this.textBoxNomTournois.TabIndex = 4;
            this.textBoxNomTournois.TextChanged += new System.EventHandler(this.textBoxNomTournois_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nom du tournoi";
            // 
            // radioBtnAllerRetour
            // 
            this.radioBtnAllerRetour.AutoSize = true;
            this.radioBtnAllerRetour.Checked = true;
            this.radioBtnAllerRetour.Location = new System.Drawing.Point(40, 52);
            this.radioBtnAllerRetour.Name = "radioBtnAllerRetour";
            this.radioBtnAllerRetour.Size = new System.Drawing.Size(118, 17);
            this.radioBtnAllerRetour.TabIndex = 1;
            this.radioBtnAllerRetour.TabStop = true;
            this.radioBtnAllerRetour.Text = "Matchs Aller-Retour";
            this.radioBtnAllerRetour.UseVisualStyleBackColor = true;
            this.radioBtnAllerRetour.CheckedChanged += new System.EventHandler(this.radioBtnAllerRetour_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type de tournoi";
            // 
            // radioBtnAller
            // 
            this.radioBtnAller.AutoSize = true;
            this.radioBtnAller.Location = new System.Drawing.Point(40, 76);
            this.radioBtnAller.Name = "radioBtnAller";
            this.radioBtnAller.Size = new System.Drawing.Size(78, 17);
            this.radioBtnAller.TabIndex = 2;
            this.radioBtnAller.Text = "Match Aller";
            this.radioBtnAller.UseVisualStyleBackColor = true;
            // 
            // groupBoxTournois
            // 
            this.groupBoxTournois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTournois.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxTournois.Controls.Add(this.groupBoxJoueursTournoi);
            this.groupBoxTournois.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTournois.Name = "groupBoxTournois";
            this.groupBoxTournois.Size = new System.Drawing.Size(1065, 376);
            this.groupBoxTournois.TabIndex = 4;
            this.groupBoxTournois.TabStop = false;
            this.groupBoxTournois.Text = "Configuration du tournoi";
            // 
            // groupBoxJoueursTournoi
            // 
            this.groupBoxJoueursTournoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxJoueursTournoi.Controls.Add(this.btnSortListPlayersTournois);
            this.groupBoxJoueursTournoi.Controls.Add(this.label7);
            this.groupBoxJoueursTournoi.Controls.Add(this.dataGridJoueursTournoi);
            this.groupBoxJoueursTournoi.Controls.Add(this.btnAddJoueur);
            this.groupBoxJoueursTournoi.Controls.Add(this.btnEffacerJoueur);
            this.groupBoxJoueursTournoi.Controls.Add(this.buttonEffacerAllJoueurs);
            this.groupBoxJoueursTournoi.Location = new System.Drawing.Point(18, 141);
            this.groupBoxJoueursTournoi.Name = "groupBoxJoueursTournoi";
            this.groupBoxJoueursTournoi.Size = new System.Drawing.Size(1027, 220);
            this.groupBoxJoueursTournoi.TabIndex = 7;
            this.groupBoxJoueursTournoi.TabStop = false;
            this.groupBoxJoueursTournoi.Text = "Joueurs du tournoi";
            // 
            // btnSortListPlayersTournois
            // 
            this.btnSortListPlayersTournois.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSortListPlayersTournois.Location = new System.Drawing.Point(888, 179);
            this.btnSortListPlayersTournois.Name = "btnSortListPlayersTournois";
            this.btnSortListPlayersTournois.Size = new System.Drawing.Size(112, 23);
            this.btnSortListPlayersTournois.TabIndex = 5;
            this.btnSortListPlayersTournois.Text = "Trie aléatoire";
            this.btnSortListPlayersTournois.UseVisualStyleBackColor = true;
            this.btnSortListPlayersTournois.Click += new System.EventHandler(this.btnSortListPlayersTournois_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(885, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Joueur(s) tournois";
            // 
            // groupBoxJoeursSaison
            // 
            this.groupBoxJoeursSaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxJoeursSaison.Controls.Add(this.btnRemoveJoueurSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.dataGridJoueursSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.tbxIdJoueurSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.btnAddJoueurSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.tbxTeamJoeurSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.tbxNomJoueurSaison);
            this.groupBoxJoeursSaison.Controls.Add(this.label6);
            this.groupBoxJoeursSaison.Controls.Add(this.label5);
            this.groupBoxJoeursSaison.Controls.Add(this.label4);
            this.groupBoxJoeursSaison.Location = new System.Drawing.Point(18, 24);
            this.groupBoxJoeursSaison.Name = "groupBoxJoeursSaison";
            this.groupBoxJoeursSaison.Size = new System.Drawing.Size(1027, 215);
            this.groupBoxJoeursSaison.TabIndex = 8;
            this.groupBoxJoeursSaison.TabStop = false;
            this.groupBoxJoeursSaison.Text = "Joueurs officiels de la saison";
            // 
            // dataGridJoueursSaison
            // 
            this.dataGridJoueursSaison.AllowUserToAddRows = false;
            this.dataGridJoueursSaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridJoueursSaison.AutoGenerateColumns = false;
            this.dataGridJoueursSaison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridJoueursSaison.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomDataGridViewTextBoxColumn1,
            this.equipeDataGridViewTextBoxColumn1,
            this.nomCompletDataGridViewTextBoxColumn1,
            this.idDataGridViewTextBoxColumn});
            this.dataGridJoueursSaison.DataSource = this.bindingSourceJoueurSaison;
            this.dataGridJoueursSaison.Location = new System.Drawing.Point(21, 25);
            this.dataGridJoueursSaison.Name = "dataGridJoueursSaison";
            this.dataGridJoueursSaison.ReadOnly = true;
            this.dataGridJoueursSaison.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridJoueursSaison.Size = new System.Drawing.Size(834, 178);
            this.dataGridJoueursSaison.TabIndex = 10;
            this.dataGridJoueursSaison.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridJoueursSaison_RowPostPaint);
            this.dataGridJoueursSaison.SelectionChanged += new System.EventHandler(this.dataGridJoueursSaison_SelectionChanged);
            this.dataGridJoueursSaison.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridJoueursSaison_UserDeletingRow);
            this.dataGridJoueursSaison.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridJoueursSaison_MouseDown);
            // 
            // nomDataGridViewTextBoxColumn1
            // 
            this.nomDataGridViewTextBoxColumn1.DataPropertyName = "Nom";
            this.nomDataGridViewTextBoxColumn1.HeaderText = "Nom";
            this.nomDataGridViewTextBoxColumn1.Name = "nomDataGridViewTextBoxColumn1";
            this.nomDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nomDataGridViewTextBoxColumn1.Width = 250;
            // 
            // equipeDataGridViewTextBoxColumn1
            // 
            this.equipeDataGridViewTextBoxColumn1.DataPropertyName = "Equipe";
            this.equipeDataGridViewTextBoxColumn1.HeaderText = "Equipe";
            this.equipeDataGridViewTextBoxColumn1.Name = "equipeDataGridViewTextBoxColumn1";
            this.equipeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.equipeDataGridViewTextBoxColumn1.Width = 250;
            // 
            // nomCompletDataGridViewTextBoxColumn1
            // 
            this.nomCompletDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomCompletDataGridViewTextBoxColumn1.DataPropertyName = "NomComplet";
            this.nomCompletDataGridViewTextBoxColumn1.HeaderText = "NomComplet";
            this.nomCompletDataGridViewTextBoxColumn1.Name = "nomCompletDataGridViewTextBoxColumn1";
            this.nomCompletDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // bindingSourceJoueurSaison
            // 
            this.bindingSourceJoueurSaison.DataMember = "Joueurs";
            this.bindingSourceJoueurSaison.DataSource = typeof(PlayStationData.JoueursConfigures);
            // 
            // tbxIdJoueurSaison
            // 
            this.tbxIdJoueurSaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxIdJoueurSaison.Location = new System.Drawing.Point(876, 120);
            this.tbxIdJoueurSaison.Name = "tbxIdJoueurSaison";
            this.tbxIdJoueurSaison.ReadOnly = true;
            this.tbxIdJoueurSaison.Size = new System.Drawing.Size(63, 20);
            this.tbxIdJoueurSaison.TabIndex = 9;
            // 
            // tbxTeamJoeurSaison
            // 
            this.tbxTeamJoeurSaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxTeamJoeurSaison.Location = new System.Drawing.Point(876, 79);
            this.tbxTeamJoeurSaison.Name = "tbxTeamJoeurSaison";
            this.tbxTeamJoeurSaison.Size = new System.Drawing.Size(140, 20);
            this.tbxTeamJoeurSaison.TabIndex = 5;
            // 
            // tbxNomJoueurSaison
            // 
            this.tbxNomJoueurSaison.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxNomJoueurSaison.Location = new System.Drawing.Point(876, 39);
            this.tbxNomJoueurSaison.Name = "tbxNomJoueurSaison";
            this.tbxNomJoueurSaison.Size = new System.Drawing.Size(140, 20);
            this.tbxNomJoueurSaison.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(873, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Id joueur:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(873, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Equipe:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(873, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nom:";
            // 
            // groupBoxSaison
            // 
            this.groupBoxSaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSaison.Controls.Add(this.groupBoxJoeursSaison);
            this.groupBoxSaison.Location = new System.Drawing.Point(13, 404);
            this.groupBoxSaison.Name = "groupBoxSaison";
            this.groupBoxSaison.Size = new System.Drawing.Size(1065, 254);
            this.groupBoxSaison.TabIndex = 5;
            this.groupBoxSaison.TabStop = false;
            this.groupBoxSaison.Text = "Configuration de la saison";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(916, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Aouter joueur(s) depuis la liste officiel de la saison";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1106, 670);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBoxSaison);
            this.Controls.Add(this.groupBoxOptionTournoois);
            this.Controls.Add(this.groupBoxTournois);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueursTournoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJoueurs)).EndInit();
            this.groupBoxOptionTournoois.ResumeLayout(false);
            this.groupBoxOptionTournoois.PerformLayout();
            this.groupBoxTournois.ResumeLayout(false);
            this.groupBoxJoueursTournoi.ResumeLayout(false);
            this.groupBoxJoueursTournoi.PerformLayout();
            this.groupBoxJoeursSaison.ResumeLayout(false);
            this.groupBoxJoeursSaison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueursSaison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceJoueurSaison)).EndInit();
            this.groupBoxSaison.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceJoueurs;
        private System.Windows.Forms.DataGridView dataGridJoueursTournoi;
        private System.Windows.Forms.ToolTip toolTipConfiguration;
        private System.Windows.Forms.GroupBox groupBoxOptionTournoois;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnAllerRetour;
        private System.Windows.Forms.RadioButton radioBtnAller;
        private System.Windows.Forms.TextBox textBoxNomTournois;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomCompletDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBoxTournois;
        private System.Windows.Forms.GroupBox groupBoxJoueursTournoi;
        private System.Windows.Forms.Button buttonEffacerAllJoueurs;
        private System.Windows.Forms.Button btnEffacerJoueur;
        private System.Windows.Forms.Button btnAddJoueur;
        private System.Windows.Forms.GroupBox groupBoxJoeursSaison;
        private System.Windows.Forms.TextBox tbxIdJoueurSaison;
        private System.Windows.Forms.Button btnAddJoueurSaison;
        private System.Windows.Forms.TextBox tbxTeamJoeurSaison;
        private System.Windows.Forms.TextBox tbxNomJoueurSaison;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxSaison;
        private System.Windows.Forms.BindingSource bindingSourceJoueurSaison;
        private System.Windows.Forms.DataGridView dataGridJoueursSaison;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomCompletDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnRemoveJoueurSaison;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSortListPlayersTournois;
    }
}