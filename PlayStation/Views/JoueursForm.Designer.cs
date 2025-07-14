namespace PlayStation.Views
{
    partial class JoueursForm
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
            this.dataGridJoueurs = new System.Windows.Forms.DataGridView();
            this.nomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomCompletDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingListJoueurSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelListJouerManip = new System.Windows.Forms.Panel();
            this.groupBoxJoueursconfForm = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingListJoueurSource)).BeginInit();
            this.groupBoxJoueursconfForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridJoueurs
            // 
            this.dataGridJoueurs.AllowUserToAddRows = false;
            this.dataGridJoueurs.AllowUserToDeleteRows = false;
            this.dataGridJoueurs.AllowUserToResizeRows = false;
            this.dataGridJoueurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridJoueurs.AutoGenerateColumns = false;
            this.dataGridJoueurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridJoueurs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridJoueurs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomDataGridViewTextBoxColumn,
            this.equipeDataGridViewTextBoxColumn,
            this.nomCompletDataGridViewTextBoxColumn});
            this.dataGridJoueurs.DataSource = this.bindingListJoueurSource;
            this.dataGridJoueurs.Location = new System.Drawing.Point(21, 33);
            this.dataGridJoueurs.Name = "dataGridJoueurs";
            this.dataGridJoueurs.Size = new System.Drawing.Size(269, 250);
            this.dataGridJoueurs.TabIndex = 0;
            this.dataGridJoueurs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridJoueurs_CellValueChanged);
            this.dataGridJoueurs.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridJoueurs_RowPostPaint);
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
            // bindingListJoueurSource
            // 
            this.bindingListJoueurSource.DataSource = typeof(PlayStationData.Joueurs);
            // 
            // panelListJouerManip
            // 
            this.panelListJouerManip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelListJouerManip.Location = new System.Drawing.Point(307, 24);
            this.panelListJouerManip.Name = "panelListJouerManip";
            this.panelListJouerManip.Size = new System.Drawing.Size(259, 259);
            this.panelListJouerManip.TabIndex = 5;
            // 
            // groupBoxJoueursconfForm
            // 
            this.groupBoxJoueursconfForm.Controls.Add(this.panelListJouerManip);
            this.groupBoxJoueursconfForm.Controls.Add(this.dataGridJoueurs);
            this.groupBoxJoueursconfForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxJoueursconfForm.Location = new System.Drawing.Point(0, 0);
            this.groupBoxJoueursconfForm.Name = "groupBoxJoueursconfForm";
            this.groupBoxJoueursconfForm.Size = new System.Drawing.Size(569, 355);
            this.groupBoxJoueursconfForm.TabIndex = 1;
            this.groupBoxJoueursconfForm.TabStop = false;
            this.groupBoxJoueursconfForm.Text = "Liste de joueurs";
            this.groupBoxJoueursconfForm.UseCompatibleTextRendering = true;
            // 
            // JoueursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 355);
            this.Controls.Add(this.groupBoxJoueursconfForm);
            this.Name = "JoueursForm";
            this.Text = "Liste des joueurs";
            this.Load += new System.EventHandler(this.JoueursForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridJoueurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingListJoueurSource)).EndInit();
            this.groupBoxJoueursconfForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridJoueurs;
        private System.Windows.Forms.Panel panelListJouerManip;
        private System.Windows.Forms.GroupBox groupBoxJoueursconfForm;
        private System.Windows.Forms.BindingSource bindingListJoueurSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomCompletDataGridViewTextBoxColumn;
    }
}