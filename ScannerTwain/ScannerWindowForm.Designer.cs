namespace ScannerTwain
{
    partial class ScannerWindowForm
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
            this.propertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.changeFilePathButton = new System.Windows.Forms.Button();
            this.imageFormatComboBox = new System.Windows.Forms.ComboBox();
            this.colorModeComboBox = new System.Windows.Forms.ComboBox();
            this.colorModeLabel = new System.Windows.Forms.Label();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.contrastTextBox = new System.Windows.Forms.TextBox();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.resolutionTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.imageFormatLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.scannerListLabel = new System.Windows.Forms.Label();
            this.scannerListBox = new System.Windows.Forms.ListBox();
            this.startScanningButton = new System.Windows.Forms.Button();
            this.scannedImageGroupBox = new System.Windows.Forms.GroupBox();
            this.scannedImagePictureBox = new System.Windows.Forms.PictureBox();
            this.propertiesGroupBox.SuspendLayout();
            this.scannedImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scannedImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // propertiesGroupBox
            // 
            this.propertiesGroupBox.Controls.Add(this.changeFilePathButton);
            this.propertiesGroupBox.Controls.Add(this.imageFormatComboBox);
            this.propertiesGroupBox.Controls.Add(this.colorModeComboBox);
            this.propertiesGroupBox.Controls.Add(this.colorModeLabel);
            this.propertiesGroupBox.Controls.Add(this.outputFolderTextBox);
            this.propertiesGroupBox.Controls.Add(this.contrastTextBox);
            this.propertiesGroupBox.Controls.Add(this.brightnessTextBox);
            this.propertiesGroupBox.Controls.Add(this.resolutionTextBox);
            this.propertiesGroupBox.Controls.Add(this.fileNameTextBox);
            this.propertiesGroupBox.Controls.Add(this.outputFolderLabel);
            this.propertiesGroupBox.Controls.Add(this.contrastLabel);
            this.propertiesGroupBox.Controls.Add(this.brightnessLabel);
            this.propertiesGroupBox.Controls.Add(this.resolutionLabel);
            this.propertiesGroupBox.Controls.Add(this.imageFormatLabel);
            this.propertiesGroupBox.Controls.Add(this.fileNameLabel);
            this.propertiesGroupBox.Controls.Add(this.scannerListLabel);
            this.propertiesGroupBox.Controls.Add(this.scannerListBox);
            this.propertiesGroupBox.Location = new System.Drawing.Point(21, 23);
            this.propertiesGroupBox.Name = "propertiesGroupBox";
            this.propertiesGroupBox.Size = new System.Drawing.Size(395, 559);
            this.propertiesGroupBox.TabIndex = 0;
            this.propertiesGroupBox.TabStop = false;
            this.propertiesGroupBox.Text = "Properties";
            // 
            // changeFilePathButton
            // 
            this.changeFilePathButton.Location = new System.Drawing.Point(19, 499);
            this.changeFilePathButton.Name = "changeFilePathButton";
            this.changeFilePathButton.Size = new System.Drawing.Size(358, 35);
            this.changeFilePathButton.TabIndex = 21;
            this.changeFilePathButton.Text = "Change path";
            this.changeFilePathButton.UseVisualStyleBackColor = true;
            this.changeFilePathButton.Click += new System.EventHandler(this.changeFilePathButton_Click);
            // 
            // imageFormatComboBox
            // 
            this.imageFormatComboBox.FormattingEnabled = true;
            this.imageFormatComboBox.Items.AddRange(new object[] {
            "JPEG",
            "PNG",
            "BMP",
            "GIF"});
            this.imageFormatComboBox.Location = new System.Drawing.Point(17, 275);
            this.imageFormatComboBox.Name = "imageFormatComboBox";
            this.imageFormatComboBox.Size = new System.Drawing.Size(361, 21);
            this.imageFormatComboBox.TabIndex = 20;
            // 
            // colorModeComboBox
            // 
            this.colorModeComboBox.FormattingEnabled = true;
            this.colorModeComboBox.Items.AddRange(new object[] {
            "RGB",
            "Grayscale"});
            this.colorModeComboBox.Location = new System.Drawing.Point(17, 226);
            this.colorModeComboBox.Name = "colorModeComboBox";
            this.colorModeComboBox.Size = new System.Drawing.Size(361, 21);
            this.colorModeComboBox.TabIndex = 18;
            // 
            // colorModeLabel
            // 
            this.colorModeLabel.AutoSize = true;
            this.colorModeLabel.Location = new System.Drawing.Point(16, 210);
            this.colorModeLabel.Name = "colorModeLabel";
            this.colorModeLabel.Size = new System.Drawing.Size(63, 13);
            this.colorModeLabel.TabIndex = 14;
            this.colorModeLabel.Text = "Color mode:";
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Enabled = false;
            this.outputFolderTextBox.Location = new System.Drawing.Point(17, 467);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.Size = new System.Drawing.Size(360, 20);
            this.outputFolderTextBox.TabIndex = 13;
            // 
            // contrastTextBox
            // 
            this.contrastTextBox.Location = new System.Drawing.Point(17, 419);
            this.contrastTextBox.Name = "contrastTextBox";
            this.contrastTextBox.Size = new System.Drawing.Size(361, 20);
            this.contrastTextBox.TabIndex = 12;
            this.contrastTextBox.Text = "0";
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Location = new System.Drawing.Point(17, 371);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.Size = new System.Drawing.Size(361, 20);
            this.brightnessTextBox.TabIndex = 11;
            this.brightnessTextBox.Text = "0";
            // 
            // resolutionTextBox
            // 
            this.resolutionTextBox.Location = new System.Drawing.Point(17, 323);
            this.resolutionTextBox.Name = "resolutionTextBox";
            this.resolutionTextBox.Size = new System.Drawing.Size(361, 20);
            this.resolutionTextBox.TabIndex = 10;
            this.resolutionTextBox.Text = "100";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(17, 179);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(361, 20);
            this.fileNameTextBox.TabIndex = 8;
            this.fileNameTextBox.Text = "scan";
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.AutoSize = true;
            this.outputFolderLabel.Location = new System.Drawing.Point(14, 451);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(71, 13);
            this.outputFolderLabel.TabIndex = 7;
            this.outputFolderLabel.Text = "Output folder:";
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(16, 403);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(49, 13);
            this.contrastLabel.TabIndex = 6;
            this.contrastLabel.Text = "Contrast:";
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(15, 355);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(59, 13);
            this.brightnessLabel.TabIndex = 5;
            this.brightnessLabel.Text = "Brightness:";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(15, 307);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(60, 13);
            this.resolutionLabel.TabIndex = 4;
            this.resolutionLabel.Text = "Resolution:";
            // 
            // imageFormatLabel
            // 
            this.imageFormatLabel.AutoSize = true;
            this.imageFormatLabel.Location = new System.Drawing.Point(16, 259);
            this.imageFormatLabel.Name = "imageFormatLabel";
            this.imageFormatLabel.Size = new System.Drawing.Size(71, 13);
            this.imageFormatLabel.TabIndex = 3;
            this.imageFormatLabel.Text = "Image format:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(15, 163);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(55, 13);
            this.fileNameLabel.TabIndex = 2;
            this.fileNameLabel.Text = "File name:";
            // 
            // scannerListLabel
            // 
            this.scannerListLabel.AutoSize = true;
            this.scannerListLabel.Location = new System.Drawing.Point(14, 26);
            this.scannerListLabel.Name = "scannerListLabel";
            this.scannerListLabel.Size = new System.Drawing.Size(84, 13);
            this.scannerListLabel.TabIndex = 1;
            this.scannerListLabel.Text = "Select a device:";
            // 
            // scannerListBox
            // 
            this.scannerListBox.FormattingEnabled = true;
            this.scannerListBox.Location = new System.Drawing.Point(17, 42);
            this.scannerListBox.Name = "scannerListBox";
            this.scannerListBox.Size = new System.Drawing.Size(361, 108);
            this.scannerListBox.TabIndex = 0;
            // 
            // startScanningButton
            // 
            this.startScanningButton.Location = new System.Drawing.Point(21, 602);
            this.startScanningButton.Name = "startScanningButton";
            this.startScanningButton.Size = new System.Drawing.Size(395, 33);
            this.startScanningButton.TabIndex = 1;
            this.startScanningButton.Text = "Scan image";
            this.startScanningButton.UseVisualStyleBackColor = true;
            this.startScanningButton.Click += new System.EventHandler(this.startScanningButton_Click);
            // 
            // scannedImageGroupBox
            // 
            this.scannedImageGroupBox.Controls.Add(this.scannedImagePictureBox);
            this.scannedImageGroupBox.Location = new System.Drawing.Point(433, 23);
            this.scannedImageGroupBox.Name = "scannedImageGroupBox";
            this.scannedImageGroupBox.Size = new System.Drawing.Size(465, 612);
            this.scannedImageGroupBox.TabIndex = 2;
            this.scannedImageGroupBox.TabStop = false;
            this.scannedImageGroupBox.Text = "Scanned Image";
            // 
            // scannedImagePictureBox
            // 
            this.scannedImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scannedImagePictureBox.Location = new System.Drawing.Point(18, 26);
            this.scannedImagePictureBox.Name = "scannedImagePictureBox";
            this.scannedImagePictureBox.Size = new System.Drawing.Size(432, 572);
            this.scannedImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scannedImagePictureBox.TabIndex = 0;
            this.scannedImagePictureBox.TabStop = false;
            // 
            // ScannerWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 666);
            this.Controls.Add(this.scannedImageGroupBox);
            this.Controls.Add(this.startScanningButton);
            this.Controls.Add(this.propertiesGroupBox);
            this.Name = "ScannerWindowForm";
            this.Text = "Scanner App";
            this.Load += new System.EventHandler(this.ScannerWindowForm_Load);
            this.propertiesGroupBox.ResumeLayout(false);
            this.propertiesGroupBox.PerformLayout();
            this.scannedImageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scannedImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox propertiesGroupBox;
        private System.Windows.Forms.Button changeFilePathButton;
        private System.Windows.Forms.ComboBox imageFormatComboBox;
        private System.Windows.Forms.ComboBox colorModeComboBox;
        private System.Windows.Forms.Label colorModeLabel;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.TextBox contrastTextBox;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.TextBox resolutionTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label imageFormatLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label scannerListLabel;
        private System.Windows.Forms.ListBox scannerListBox;
        private System.Windows.Forms.Button startScanningButton;
        private System.Windows.Forms.GroupBox scannedImageGroupBox;
        private System.Windows.Forms.PictureBox scannedImagePictureBox;
    }
}

