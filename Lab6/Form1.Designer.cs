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
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnDrawAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblChosenFigure = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPluginSettings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbChoosePlugin = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "free-icon-plus-747530.png");
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
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(32, 619);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 31);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear ";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.lblChosenFigure);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDrawAll);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 662);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.btnPluginSettings);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbChoosePlugin);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(215, 526);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(668, 146);
            this.panel2.TabIndex = 2;
            // 
            // btnPluginSettings
            // 
            this.btnPluginSettings.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnPluginSettings.Location = new System.Drawing.Point(334, 80);
            this.btnPluginSettings.Name = "btnPluginSettings";
            this.btnPluginSettings.Size = new System.Drawing.Size(218, 36);
            this.btnPluginSettings.TabIndex = 5;
            this.btnPluginSettings.Text = "Settings";
            this.btnPluginSettings.UseVisualStyleBackColor = true;
            this.btnPluginSettings.Click += new System.EventHandler(this.btnPluginSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.label1.Location = new System.Drawing.Point(332, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Modification algorithms";
            // 
            // cbChoosePlugin
            // 
            this.cbChoosePlugin.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.cbChoosePlugin.FormattingEnabled = true;
            this.cbChoosePlugin.Location = new System.Drawing.Point(334, 44);
            this.cbChoosePlugin.Name = "cbChoosePlugin";
            this.cbChoosePlugin.Size = new System.Drawing.Size(218, 32);
            this.cbChoosePlugin.TabIndex = 3;
            this.cbChoosePlugin.SelectedIndexChanged += new System.EventHandler(this.cbChoosePlugin_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnLoad.Location = new System.Drawing.Point(82, 83);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(150, 32);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnSave.Location = new System.Drawing.Point(82, 36);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(882, 663);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmMain";
            this.Text = "Figures";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Button btnDrawAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblChosenFigure;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbChoosePlugin;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPluginSettings;
    }
}

