namespace PlayStation.Views
{
    partial class GeneralSelectionFileForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSelectionFileForm));
            this.toolTipConfiguration = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnEffacerFile = new System.Windows.Forms.Button();
            this.btnEffacerAllFiles = new System.Windows.Forms.Button();
            this.groupBoxTournois = new System.Windows.Forms.GroupBox();
            this.checkBoxTournoiClassement = new System.Windows.Forms.CheckBox();
            this.dataGridFiles = new System.Windows.Forms.DataGridView();
            this.isUpToDateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullPathNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceClassementItems = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxTournois.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassementItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.Location = new System.Drawing.Point(618, 43);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(127, 26);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "Ajouter fichier(s)";
            this.toolTipConfiguration.SetToolTip(this.btnAddFile, "Ajoutr un nouveau joueur");
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnEffacerFile
            // 
            this.btnEffacerFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEffacerFile.Enabled = false;
            this.btnEffacerFile.Location = new System.Drawing.Point(618, 75);
            this.btnEffacerFile.Name = "btnEffacerFile";
            this.btnEffacerFile.Size = new System.Drawing.Size(127, 26);
            this.btnEffacerFile.TabIndex = 2;
            this.btnEffacerFile.Text = "Effacer fichier(s)";
            this.toolTipConfiguration.SetToolTip(this.btnEffacerFile, "Effacer un joueur");
            this.btnEffacerFile.UseVisualStyleBackColor = true;
            this.btnEffacerFile.Click += new System.EventHandler(this.btnEffacerFile_Click);
            // 
            // btnEffacerAllFiles
            // 
            this.btnEffacerAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEffacerAllFiles.Enabled = false;
            this.btnEffacerAllFiles.Location = new System.Drawing.Point(618, 107);
            this.btnEffacerAllFiles.Name = "btnEffacerAllFiles";
            this.btnEffacerAllFiles.Size = new System.Drawing.Size(127, 26);
            this.btnEffacerAllFiles.TabIndex = 3;
            this.btnEffacerAllFiles.Text = "Tout effacer";
            this.toolTipConfiguration.SetToolTip(this.btnEffacerAllFiles, "Effacer tous les joueurs");
            this.btnEffacerAllFiles.UseVisualStyleBackColor = true;
            this.btnEffacerAllFiles.Click += new System.EventHandler(this.btnEffacerAllFiles_Click);
            // 
            // groupBoxTournois
            // 
            this.groupBoxTournois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTournois.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxTournois.Controls.Add(this.checkBoxTournoiClassement);
            this.groupBoxTournois.Controls.Add(this.btnAddFile);
            this.groupBoxTournois.Controls.Add(this.btnEffacerFile);
            this.groupBoxTournois.Controls.Add(this.dataGridFiles);
            this.groupBoxTournois.Controls.Add(this.btnEffacerAllFiles);
            this.groupBoxTournois.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTournois.Name = "groupBoxTournois";
            this.groupBoxTournois.Size = new System.Drawing.Size(762, 283);
            this.groupBoxTournois.TabIndex = 4;
            this.groupBoxTournois.TabStop = false;
            this.groupBoxTournois.Text = "Selection des fichiers";
            // 
            // checkBoxTournoiClassement
            // 
            this.checkBoxTournoiClassement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTournoiClassement.AutoCheck = false;
            this.checkBoxTournoiClassement.AutoSize = true;
            this.checkBoxTournoiClassement.Location = new System.Drawing.Point(618, 238);
            this.checkBoxTournoiClassement.Name = "checkBoxTournoiClassement";
            this.checkBoxTournoiClassement.Size = new System.Drawing.Size(138, 17);
            this.checkBoxTournoiClassement.TabIndex = 6;
            this.checkBoxTournoiClassement.Text = "Ajouter tournoi en cours";
            this.checkBoxTournoiClassement.UseVisualStyleBackColor = true;
            this.checkBoxTournoiClassement.Click += new System.EventHandler(this.checkBoxTournoiClassement_Click);
            // 
            // dataGridFiles
            // 
            this.dataGridFiles.AllowDrop = true;
            this.dataGridFiles.AllowUserToAddRows = false;
            this.dataGridFiles.AllowUserToDeleteRows = false;
            this.dataGridFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridFiles.AutoGenerateColumns = false;
            this.dataGridFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isUpToDateDataGridViewCheckBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.fullPathNameDataGridViewTextBoxColumn});
            this.dataGridFiles.DataSource = this.bindingSourceClassementItems;
            this.dataGridFiles.Location = new System.Drawing.Point(18, 28);
            this.dataGridFiles.Name = "dataGridFiles";
            this.dataGridFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFiles.Size = new System.Drawing.Size(581, 238);
            this.dataGridFiles.TabIndex = 0;
            this.dataGridFiles.SelectionChanged += new System.EventHandler(this.dataGridFiles_SelectionChanged);
            // 
            // isUpToDateDataGridViewCheckBoxColumn
            // 
            this.isUpToDateDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isUpToDateDataGridViewCheckBoxColumn.DataPropertyName = "IsUpToDate";
            this.isUpToDateDataGridViewCheckBoxColumn.FillWeight = 31.9797F;
            this.isUpToDateDataGridViewCheckBoxColumn.HeaderText = "Modifié";
            this.isUpToDateDataGridViewCheckBoxColumn.Name = "isUpToDateDataGridViewCheckBoxColumn";
            this.isUpToDateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isUpToDateDataGridViewCheckBoxColumn.Width = 47;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fileNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fileNameDataGridViewTextBoxColumn.FillWeight = 85.68995F;
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Nom du fichier";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullPathNameDataGridViewTextBoxColumn
            // 
            this.fullPathNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullPathNameDataGridViewTextBoxColumn.DataPropertyName = "FullPathName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fullPathNameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fullPathNameDataGridViewTextBoxColumn.FillWeight = 92.33035F;
            this.fullPathNameDataGridViewTextBoxColumn.HeaderText = "Nom du fichier complet";
            this.fullPathNameDataGridViewTextBoxColumn.Name = "fullPathNameDataGridViewTextBoxColumn";
            this.fullPathNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceClassementItems
            // 
            this.bindingSourceClassementItems.DataSource = typeof(PlayStationData.ClassementGeneralFileItem);
            // 
            // GeneralSelectionFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(787, 308);
            this.Controls.Add(this.groupBoxTournois);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneralSelectionFileForm";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.groupBoxTournois.ResumeLayout(false);
            this.groupBoxTournois.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassementItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFiles;
        private System.Windows.Forms.ToolTip toolTipConfiguration;
        private System.Windows.Forms.GroupBox groupBoxTournois;
        private System.Windows.Forms.Button btnEffacerAllFiles;
        private System.Windows.Forms.Button btnEffacerFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.BindingSource bindingSourceClassementItems;
        private System.Windows.Forms.CheckBox checkBoxTournoiClassement;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUpToDateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathNameDataGridViewTextBoxColumn;
    }
}