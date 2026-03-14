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
            this.btnDrawRhomb = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnDrawLine = new System.Windows.Forms.Button();
            this.btnDrawRect = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnDrawEllipse = new System.Windows.Forms.Button();
            this.btnDrawCircle = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.btnDrawRhomb);
            this.panel1.Controls.Add(this.btnDrawLine);
            this.panel1.Controls.Add(this.btnDrawRect);
            this.panel1.Controls.Add(this.btnTriangle);
            this.panel1.Controls.Add(this.btnDrawEllipse);
            this.panel1.Controls.Add(this.btnDrawCircle);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDrawAll);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 600);
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
            // btnDrawRhomb
            // 
            this.btnDrawRhomb.BackColor = System.Drawing.Color.White;
            this.btnDrawRhomb.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawRhomb.ImageIndex = 0;
            this.btnDrawRhomb.ImageList = this.imgList;
            this.btnDrawRhomb.Location = new System.Drawing.Point(32, 398);
            this.btnDrawRhomb.Name = "btnDrawRhomb";
            this.btnDrawRhomb.Size = new System.Drawing.Size(150, 38);
            this.btnDrawRhomb.TabIndex = 12;
            this.btnDrawRhomb.Text = "Rhomb";
            this.btnDrawRhomb.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrawRhomb.UseVisualStyleBackColor = false;
            this.btnDrawRhomb.Click += new System.EventHandler(this.btnDrawRhomb_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "free-icon-plus-747530.png");
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.BackColor = System.Drawing.Color.White;
            this.btnDrawLine.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawLine.ImageIndex = 0;
            this.btnDrawLine.ImageList = this.imgList;
            this.btnDrawLine.Location = new System.Drawing.Point(33, 354);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(150, 38);
            this.btnDrawLine.TabIndex = 11;
            this.btnDrawLine.Text = "Line";
            this.btnDrawLine.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrawLine.UseVisualStyleBackColor = false;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // btnDrawRect
            // 
            this.btnDrawRect.BackColor = System.Drawing.Color.White;
            this.btnDrawRect.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawRect.ImageIndex = 0;
            this.btnDrawRect.ImageList = this.imgList;
            this.btnDrawRect.Location = new System.Drawing.Point(32, 310);
            this.btnDrawRect.Name = "btnDrawRect";
            this.btnDrawRect.Size = new System.Drawing.Size(150, 38);
            this.btnDrawRect.TabIndex = 10;
            this.btnDrawRect.Text = "Rectangle";
            this.btnDrawRect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrawRect.UseVisualStyleBackColor = false;
            this.btnDrawRect.Click += new System.EventHandler(this.btnDrawRect_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.BackColor = System.Drawing.Color.White;
            this.btnTriangle.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnTriangle.ImageIndex = 0;
            this.btnTriangle.ImageList = this.imgList;
            this.btnTriangle.Location = new System.Drawing.Point(33, 266);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(150, 38);
            this.btnTriangle.TabIndex = 9;
            this.btnTriangle.Text = "Triangle";
            this.btnTriangle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTriangle.UseVisualStyleBackColor = false;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnDrawEllipse
            // 
            this.btnDrawEllipse.BackColor = System.Drawing.Color.White;
            this.btnDrawEllipse.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawEllipse.ImageIndex = 0;
            this.btnDrawEllipse.ImageList = this.imgList;
            this.btnDrawEllipse.Location = new System.Drawing.Point(33, 222);
            this.btnDrawEllipse.Name = "btnDrawEllipse";
            this.btnDrawEllipse.Size = new System.Drawing.Size(150, 38);
            this.btnDrawEllipse.TabIndex = 8;
            this.btnDrawEllipse.Text = "Ellipse";
            this.btnDrawEllipse.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrawEllipse.UseVisualStyleBackColor = false;
            this.btnDrawEllipse.Click += new System.EventHandler(this.btnDrawEllipse_Click);
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.BackColor = System.Drawing.Color.White;
            this.btnDrawCircle.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDrawCircle.ImageIndex = 0;
            this.btnDrawCircle.ImageList = this.imgList;
            this.btnDrawCircle.Location = new System.Drawing.Point(33, 178);
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(150, 38);
            this.btnDrawCircle.TabIndex = 2;
            this.btnDrawCircle.Text = "Circle";
            this.btnDrawCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDrawCircle.UseVisualStyleBackColor = false;
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(32, 498);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 31);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Figures";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDrawAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDrawCircle;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnDrawEllipse;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnDrawRhomb;
        private System.Windows.Forms.Button btnDrawLine;
        private System.Windows.Forms.Button btnDrawRect;
        private System.Windows.Forms.Label lblChosenFigure;
    }
}

