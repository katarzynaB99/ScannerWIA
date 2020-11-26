using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScannerTwain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ListScanners()
        {
            scannerListBox.Items.Clear();

            var deviceList = WiaScanner.ListDevices();

            foreach (var device in deviceList)
            {
                scannerListBox.Items.Add(
                    new WiaScanner(device)
                );
            }
        }

        private void ScannerWindowForm_Load(object sender, EventArgs e)
        {
            ListScanners();
            outputFolderTextBox.Text = Path.GetTempPath();

            imageFormatComboBox.SelectedIndex = 0;
            colorModeComboBox.SelectedIndex = 0;
            bitDepthComboBox.SelectedIndex = 0;
        }

        private void changeFilePathButton_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog { ShowNewFolderButton = true };
            var result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                outputFolderTextBox.Text = folderDlg.SelectedPath;
            }
        }

        private void startScanningButton_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(StartScanning).ContinueWith(result => TriggerScan());
        }

        private void TriggerScan()
        {
            Console.WriteLine(@"Image successfully scanned.");
        }

        public void StartScanning()
        {
            WiaScanner device = null;
            this.Invoke(new MethodInvoker(delegate ()
            {
                device = scannerListBox.SelectedItem as WiaScanner;
            }));

            if (device == null)
            {
                ShowSelectDeviceMessageBox();
                return;
            }
            else if (String.IsNullOrEmpty(outputFolderTextBox.Text))
            {
                ShowNoFileNameMessageBox();
                return;
            }

            ImageFile image = new ImageFile();
            string imageExtension = "";
            int fileFormat = 1;
            int colorMode = 1;

            switch (colorModeComboBox.SelectedIndex)
            {
                case 0:
                    colorMode = 1;
                    break;
                case 1:
                    colorMode = 2;
                    break;
            }

            switch (imageFormatComboBox.SelectedIndex)
            {
                case 0:
                    // JPEG
                    fileFormat = 1;
                    break;
                case 1:
                    // PNG
                    fileFormat = 2;
                    break;
                case 2:
                    // BMP
                    fileFormat = 3;
                    break;
                case 3:
                    // GIF
                    fileFormat = 4;
                    break;
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                device.Scan(int.Parse(resolutionTextBox.Text), 1250, 1700,
                    int.Parse(brightnessTextBox.Text), int.Parse(contrastTextBox.Text),
                    colorMode, int.Parse(bitDepthComboBox.SelectedText), fileFormat,
                    outputFolderTextBox.Text, fileNameTextBox.Text);
            }));

            var imagePath = Path.Combine(outputFolderTextBox.Text,
                fileNameTextBox.Text + imageFormatComboBox.SelectedText.ToLowerInvariant());

            scannedImagePictureBox.Image = new Bitmap(imagePath);
        }

        private void ShowSelectDeviceMessageBox()
        {
            MessageBox.Show("You need to select a scanner from the list", "Warning",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowNoFileNameMessageBox()
        {
            MessageBox.Show("Provide a file name", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
