namespace Lab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgwObjects = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd     = new System.Windows.Forms.Button();
            this.btnEdit    = new System.Windows.Forms.Button();
            this.btnDelete  = new System.Windows.Forms.Button();
            this.btnSave    = new System.Windows.Forms.Button();
            this.btnLoad    = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgwObjects)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            this.dgwObjects.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwObjects.Dock              = System.Windows.Forms.DockStyle.Fill;
            this.dgwObjects.Name              = "dgwObjects";
            this.dgwObjects.RowHeadersWidth   = 51;
            this.dgwObjects.RowTemplate.Height = 24;
            this.dgwObjects.TabIndex          = 0;

            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.btnAdd, this.btnEdit, this.btnDelete, this.btnSave, this.btnLoad
            });
            this.pnlButtons.Dock   = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height = 46;
            this.pnlButtons.Name   = "pnlButtons";

            this.btnAdd.Location = new System.Drawing.Point(8, 9);
            this.btnAdd.Name     = "btnAdd";
            this.btnAdd.Size     = new System.Drawing.Size(90, 28);
            this.btnAdd.Text     = "Add";
            this.btnAdd.Click   += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Location = new System.Drawing.Point(106, 9);
            this.btnEdit.Name     = "btnEdit";
            this.btnEdit.Size     = new System.Drawing.Size(90, 28);
            this.btnEdit.Text     = "Edit";
            this.btnEdit.Click   += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Location = new System.Drawing.Point(204, 9);
            this.btnDelete.Name     = "btnDelete";
            this.btnDelete.Size     = new System.Drawing.Size(90, 28);
            this.btnDelete.Text     = "Delete";
            this.btnDelete.Click   += new System.EventHandler(this.btnDelete_Click);

            this.btnSave.Location = new System.Drawing.Point(320, 9);
            this.btnSave.Name     = "btnSave";
            this.btnSave.Size     = new System.Drawing.Size(110, 28);
            this.btnSave.Text     = "Save (.bin)";
            this.btnSave.Click   += new System.EventHandler(this.btnSave_Click);

            this.btnLoad.Location = new System.Drawing.Point(438, 9);
            this.btnLoad.Name     = "btnLoad";
            this.btnLoad.Size     = new System.Drawing.Size(110, 28);
            this.btnLoad.Text     = "Load (.bin)";
            this.btnLoad.Click   += new System.EventHandler(this.btnLoad_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgwObjects);
            this.Controls.Add(this.pnlButtons);
            this.MinimumSize = new System.Drawing.Size(700, 350);
            this.Name        = "Form1";
            this.Text        = "Person List";

            ((System.ComponentModel.ISupportInitialize)(this.dgwObjects)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgwObjects;
        private System.Windows.Forms.Panel        pnlButtons;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnEdit;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.Button       btnSave;
        private System.Windows.Forms.Button       btnLoad;
    }
}
