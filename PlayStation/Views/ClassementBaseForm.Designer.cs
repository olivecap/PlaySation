using PlayStationData;

namespace PlayStation.Views
{
    partial class ClassementBaseForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewClassement = new System.Windows.Forms.DataGridView();
            this.nomEquipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrePointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreMatchJouesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreVicoireDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreNulDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDefaiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreButPourDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreButContreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goalaverageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingClassementSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClassementSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClassement
            // 
            this.dataGridViewClassement.AllowUserToAddRows = false;
            this.dataGridViewClassement.AllowUserToDeleteRows = false;
            this.dataGridViewClassement.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClassement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewClassement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomEquipeDataGridViewTextBoxColumn,
            this.nombrePointDataGridViewTextBoxColumn,
            this.nombreMatchJouesDataGridViewTextBoxColumn,
            this.nombreVicoireDataGridViewTextBoxColumn,
            this.nombreNulDataGridViewTextBoxColumn,
            this.nombreDefaiteDataGridViewTextBoxColumn,
            this.nombreButPourDataGridViewTextBoxColumn,
            this.nombreButContreDataGridViewTextBoxColumn,
            this.goalaverageDataGridViewTextBoxColumn});
            this.dataGridViewClassement.DataSource = this.bindingClassementSource;
            this.dataGridViewClassement.Location = new System.Drawing.Point(20, 30);
            this.dataGridViewClassement.MultiSelect = false;
            this.dataGridViewClassement.Name = "dataGridViewClassement";
            this.dataGridViewClassement.ReadOnly = true;
            this.dataGridViewClassement.Size = new System.Drawing.Size(499, 408);
            this.dataGridViewClassement.TabIndex = 0;
            this.dataGridViewClassement.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewClassement_RowPostPaint);
            // 
            // nomEquipeDataGridViewTextBoxColumn
            // 
            this.nomEquipeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nomEquipeDataGridViewTextBoxColumn.DataPropertyName = "NomEquipe";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nomEquipeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nomEquipeDataGridViewTextBoxColumn.HeaderText = "Equipe";
            this.nomEquipeDataGridViewTextBoxColumn.Name = "nomEquipeDataGridViewTextBoxColumn";
            this.nomEquipeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomEquipeDataGridViewTextBoxColumn.Width = 65;
            // 
            // nombrePointDataGridViewTextBoxColumn
            // 
            this.nombrePointDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombrePointDataGridViewTextBoxColumn.DataPropertyName = "NombrePoint";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombrePointDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombrePointDataGridViewTextBoxColumn.HeaderText = "Pts";
            this.nombrePointDataGridViewTextBoxColumn.Name = "nombrePointDataGridViewTextBoxColumn";
            this.nombrePointDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombrePointDataGridViewTextBoxColumn.ToolTipText = "Points";
            // 
            // nombreMatchJouesDataGridViewTextBoxColumn
            // 
            this.nombreMatchJouesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreMatchJouesDataGridViewTextBoxColumn.DataPropertyName = "NombreMatchJoues";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreMatchJouesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nombreMatchJouesDataGridViewTextBoxColumn.HeaderText = "J.";
            this.nombreMatchJouesDataGridViewTextBoxColumn.Name = "nombreMatchJouesDataGridViewTextBoxColumn";
            this.nombreMatchJouesDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreMatchJouesDataGridViewTextBoxColumn.ToolTipText = "Matchs joues";
            // 
            // nombreVicoireDataGridViewTextBoxColumn
            // 
            this.nombreVicoireDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreVicoireDataGridViewTextBoxColumn.DataPropertyName = "NombreVicoire";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreVicoireDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nombreVicoireDataGridViewTextBoxColumn.HeaderText = "G.";
            this.nombreVicoireDataGridViewTextBoxColumn.Name = "nombreVicoireDataGridViewTextBoxColumn";
            this.nombreVicoireDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreVicoireDataGridViewTextBoxColumn.ToolTipText = "Matchs gagnes";
            // 
            // nombreNulDataGridViewTextBoxColumn
            // 
            this.nombreNulDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreNulDataGridViewTextBoxColumn.DataPropertyName = "NombreNul";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreNulDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.nombreNulDataGridViewTextBoxColumn.HeaderText = "N.";
            this.nombreNulDataGridViewTextBoxColumn.Name = "nombreNulDataGridViewTextBoxColumn";
            this.nombreNulDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreNulDataGridViewTextBoxColumn.ToolTipText = "Matchs nuls";
            // 
            // nombreDefaiteDataGridViewTextBoxColumn
            // 
            this.nombreDefaiteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDefaiteDataGridViewTextBoxColumn.DataPropertyName = "NombreDefaite";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreDefaiteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.nombreDefaiteDataGridViewTextBoxColumn.HeaderText = "P.";
            this.nombreDefaiteDataGridViewTextBoxColumn.Name = "nombreDefaiteDataGridViewTextBoxColumn";
            this.nombreDefaiteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDefaiteDataGridViewTextBoxColumn.ToolTipText = "Matchs Perdus";
            // 
            // nombreButPourDataGridViewTextBoxColumn
            // 
            this.nombreButPourDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreButPourDataGridViewTextBoxColumn.DataPropertyName = "NombreButPour";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreButPourDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.nombreButPourDataGridViewTextBoxColumn.HeaderText = "bp.";
            this.nombreButPourDataGridViewTextBoxColumn.Name = "nombreButPourDataGridViewTextBoxColumn";
            this.nombreButPourDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreButPourDataGridViewTextBoxColumn.ToolTipText = "Buts pour";
            // 
            // nombreButContreDataGridViewTextBoxColumn
            // 
            this.nombreButContreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreButContreDataGridViewTextBoxColumn.DataPropertyName = "NombreButContre";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nombreButContreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.nombreButContreDataGridViewTextBoxColumn.HeaderText = "bc.";
            this.nombreButContreDataGridViewTextBoxColumn.Name = "nombreButContreDataGridViewTextBoxColumn";
            this.nombreButContreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreButContreDataGridViewTextBoxColumn.ToolTipText = "Buts contre";
            // 
            // goalaverageDataGridViewTextBoxColumn
            // 
            this.goalaverageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.goalaverageDataGridViewTextBoxColumn.DataPropertyName = "Goalaverage";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.goalaverageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.goalaverageDataGridViewTextBoxColumn.HeaderText = "Diffs";
            this.goalaverageDataGridViewTextBoxColumn.Name = "goalaverageDataGridViewTextBoxColumn";
            this.goalaverageDataGridViewTextBoxColumn.ReadOnly = true;
            this.goalaverageDataGridViewTextBoxColumn.ToolTipText = "Goalaverage";
            // 
            // bindingClassementSource
            // 
            this.bindingClassementSource.DataSource = typeof(PlayStationData.Classement);
            // 
            // ClassementBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 421);
            this.Controls.Add(this.dataGridViewClassement);
            this.Name = "ClassementBaseForm";
            this.Text = "";
            this.Activated += new System.EventHandler(this.ClassementForm_Activated);
            this.Load += new System.EventHandler(this.ClassementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClassementSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClassement;
        private System.Windows.Forms.BindingSource bindingClassementSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomEquipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrePointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMatchJouesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVicoireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreNulDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDefaiteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreButPourDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreButContreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goalaverageDataGridViewTextBoxColumn;

    }
}