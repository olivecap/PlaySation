namespace PlayStation.Views
{
    partial class JoueurForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoueurForm));
            this.textNomJoueur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNomEquipe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNomComplet = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.errorProviderNouveauJoueur = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNouveauJoueur)).BeginInit();
            this.SuspendLayout();
            // 
            // textNomJoueur
            // 
            this.textNomJoueur.Location = new System.Drawing.Point(90, 52);
            this.textNomJoueur.Name = "textNomJoueur";
            this.textNomJoueur.Size = new System.Drawing.Size(150, 20);
            this.textNomJoueur.TabIndex = 1;
            this.textNomJoueur.Validated += new System.EventHandler(this.textNomJoueur_Validated);
            this.textNomJoueur.Leave += new System.EventHandler(this.textNomJoueur_Leave);
            this.textNomJoueur.Validating += new System.ComponentModel.CancelEventHandler(this.textNomJoueur_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom joueur :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nom equipe :";
            // 
            // textNomEquipe
            // 
            this.textNomEquipe.Location = new System.Drawing.Point(90, 22);
            this.textNomEquipe.Name = "textNomEquipe";
            this.textNomEquipe.Size = new System.Drawing.Size(150, 20);
            this.textNomEquipe.TabIndex = 0;
            this.textNomEquipe.Validated += new System.EventHandler(this.textNomEquipe_Validated);
            this.textNomEquipe.Leave += new System.EventHandler(this.textNomEquipe_Leave);
            this.textNomEquipe.Validating += new System.ComponentModel.CancelEventHandler(this.textNomEquipe_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nom complet :";
            // 
            // textNomComplet
            // 
            this.textNomComplet.Location = new System.Drawing.Point(90, 82);
            this.textNomComplet.Name = "textNomComplet";
            this.textNomComplet.ReadOnly = true;
            this.textNomComplet.Size = new System.Drawing.Size(150, 20);
            this.textNomComplet.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textNomComplet);
            this.groupBox1.Controls.Add(this.textNomJoueur);
            this.groupBox1.Controls.Add(this.textNomEquipe);
            this.groupBox1.Location = new System.Drawing.Point(160, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 124);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nouveau joueur";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(160, 152);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAjouter.Location = new System.Drawing.Point(324, 152);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(100, 23);
            this.buttonAjouter.TabIndex = 3;
            this.buttonAjouter.Text = "&Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = true;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // errorProviderNouveauJoueur
            // 
            this.errorProviderNouveauJoueur.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderNouveauJoueur.ContainerControl = this;
            // 
            // JoueurForm
            // 
            this.AcceptButton = this.buttonAjouter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(441, 187);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JoueurForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouveau joueur";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JoueurForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoueurForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNouveauJoueur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textNomJoueur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNomEquipe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNomComplet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.ErrorProvider errorProviderNouveauJoueur;
    }
}