namespace PlayStation.Views
{
    partial class TournoisForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridTournois = new System.Windows.Forms.DataGridView();
            this.ColNumeroMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMatchJoue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColEquipe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScoreEquipe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColScoreEquipe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEquipe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTournois1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridTournois)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTournois
            // 
            this.gridTournois.AllowUserToAddRows = false;
            this.gridTournois.AllowUserToDeleteRows = false;
            this.gridTournois.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTournois.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridTournois.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTournois.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTournois.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTournois.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNumeroMatch,
            this.ColMatchJoue,
            this.ColEquipe1,
            this.ColScoreEquipe1,
            this.ColScoreEquipe2,
            this.ColEquipe2,
            this.TV});
            this.gridTournois.Location = new System.Drawing.Point(0, 0);
            this.gridTournois.MultiSelect = false;
            this.gridTournois.Name = "gridTournois";
            this.gridTournois.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridTournois.Size = new System.Drawing.Size(658, 389);
            this.gridTournois.TabIndex = 0;
            this.gridTournois.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTournois_CellContentClick);
            this.gridTournois.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTournois_CellValidated);
            this.gridTournois.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridTournois_CellValidating);
            this.gridTournois.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTournois_CellValueChanged);
            // 
            // ColNumeroMatch
            // 
            this.ColNumeroMatch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColNumeroMatch.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColNumeroMatch.FillWeight = 30.45685F;
            this.ColNumeroMatch.HeaderText = "Numero";
            this.ColNumeroMatch.Name = "ColNumeroMatch";
            this.ColNumeroMatch.ReadOnly = true;
            this.ColNumeroMatch.Width = 75;
            // 
            // ColMatchJoue
            // 
            this.ColMatchJoue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColMatchJoue.FillWeight = 113.9086F;
            this.ColMatchJoue.HeaderText = "MatchJoue";
            this.ColMatchJoue.Name = "ColMatchJoue";
            this.ColMatchJoue.Width = 75;
            // 
            // ColEquipe1
            // 
            this.ColEquipe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColEquipe1.FillWeight = 113.9086F;
            this.ColEquipe1.HeaderText = "Equipe 1";
            this.ColEquipe1.Name = "ColEquipe1";
            this.ColEquipe1.ReadOnly = true;
            this.ColEquipe1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColEquipe1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEquipe1.Width = 63;
            // 
            // ColScoreEquipe1
            // 
            this.ColScoreEquipe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColScoreEquipe1.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColScoreEquipe1.FillWeight = 113.9086F;
            this.ColScoreEquipe1.HeaderText = "But Equipe 1";
            this.ColScoreEquipe1.Name = "ColScoreEquipe1";
            this.ColScoreEquipe1.Width = 105;
            // 
            // ColScoreEquipe2
            // 
            this.ColScoreEquipe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ColScoreEquipe2.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColScoreEquipe2.FillWeight = 113.9086F;
            this.ColScoreEquipe2.HeaderText = "But Equipe 2";
            this.ColScoreEquipe2.Name = "ColScoreEquipe2";
            this.ColScoreEquipe2.Width = 105;
            // 
            // ColEquipe2
            // 
            this.ColEquipe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColEquipe2.FillWeight = 113.9086F;
            this.ColEquipe2.HeaderText = "Equipe 2";
            this.ColEquipe2.Name = "ColEquipe2";
            this.ColEquipe2.ReadOnly = true;
            this.ColEquipe2.Width = 82;
            // 
            // TV
            // 
            this.TV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TV.DefaultCellStyle = dataGridViewCellStyle5;
            this.TV.HeaderText = "    TV   ";
            this.TV.Name = "TV";
            this.TV.Width = 76;
            // 
            // panelTournois1
            // 
            this.panelTournois1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTournois1.Location = new System.Drawing.Point(0, 0);
            this.panelTournois1.Name = "panelTournois1";
            this.panelTournois1.Size = new System.Drawing.Size(658, 389);
            this.panelTournois1.TabIndex = 1;
            // 
            // TournoisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 389);
            this.Controls.Add(this.gridTournois);
            this.Controls.Add(this.panelTournois1);
            this.Name = "TournoisForm";
            this.Activated += new System.EventHandler(this.TournoisForm_Activated);
            this.Deactivate += new System.EventHandler(this.TournoisForm_Deactivate);
            this.Load += new System.EventHandler(this.TournoisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTournois)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTournois;
        private System.Windows.Forms.Panel panelTournois1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumeroMatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColMatchJoue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEquipe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScoreEquipe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColScoreEquipe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEquipe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TV;
    }
}