namespace Lab1
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnDrawAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChosenFigure = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDrawAll
            // 
            this.btnDrawAll.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawAll.Location = new System.Drawing.Point(32, 23);
            this.btnDrawAll.Name = "btnDrawAll";
            this.btnDrawAll.Size = new System.Drawing.Size(150, 60);
            this.btnDrawAll.TabIndex = 0;
            this.btnDrawAll.Text = "Draw all figures";
            this.btnDrawAll.UseVisualStyleBackColor = true;
            this.btnDrawAll.Click += new System.EventHandler(this.btnDrawAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.lblChosenFigure);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDrawAll);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 661);
            this.panel1.TabIndex = 1;
            // 
            // lblChosenFigure
            // 
            this.lblChosenFigure.AutoSize = true;
            this.lblChosenFigure.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.lblChosenFigure.Location = new System.Drawing.Point(3, 131);
            this.lblChosenFigure.Name = "lblChosenFigure";
            this.lblChosenFigure.Size = new System.Drawing.Size(87, 24);
            this.lblChosenFigure.TabIndex = 2;
            this.lblChosenFigure.Text = "Chosen: ";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(32, 605);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 31);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "free-icon-plus-747530.png");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(882, 663);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Figures";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDrawAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Label lblChosenFigure;
    }
}

