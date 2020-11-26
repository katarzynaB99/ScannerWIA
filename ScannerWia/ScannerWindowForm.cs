using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIA;

namespace ScannerTwain
{
    public partial class ScannerWindowForm : Form
    {
        List<WIADeviceInfo> devices;

        public ScannerWindowForm()
        {
            InitializeComponent();
            ListScanners();
        }

        private void ListScanners()
        {
            scannerListBox.Items.Clear();

            devices = WiaScanner.GetDevices().ToList();

            foreach (var device in devices)
            {
                scannerListBox.Items.Add(device.Name);
            }
        }

        private void ScannerWindowForm_Load(object sender, EventArgs e)
        {
            ListScanners();
            outputFolderTextBox.Text = Path.GetTempPath();

            imageFormatComboBox.SelectedIndex = 0;
            colorModeComboBox.SelectedIndex = 0;
        }

        private void changeFilePathButton_Click(object sender, EventArgs e)
        {
            var folderDlg = new FolderBrowserDialog {ShowNewFolderButton = true};
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
            WIADeviceInfo deviceInfo = new WIADeviceInfo();
            deviceInfo.DeviceID = null;
            deviceInfo.Name = null;

            this.Invoke(new MethodInvoker(delegate()
            {
                if (scannerListBox.Items.Count == 0)
                {
                    ShowSelectDeviceMessageBox();
                    
                    return;
                }
                else
                {
                    WIADeviceInfo info = devices[scannerListBox.SelectedIndex];
                    deviceInfo.DeviceID = info.DeviceID;
                    deviceInfo.Name = info.Name;
                }
            }));

            WiaScanner device = new WiaScanner();
            if (String.IsNullOrEmpty(outputFolderTextBox.Text))
            {
                ShowNoFileNameMessageBox();
                return;
            }

            ImageFile image = new ImageFile();
            int fileFormat = 1; //ok
            int colorMode = 1; //ok
            int resolution = 100; //ok
            int brightness = 0; //ok
            int contrast = 0; //ok
            int bitDepth = 24; //ok
            string fileExtension = ""; //ok
            int widthPixels;
            int heightPixels;


            this.Invoke(new MethodInvoker(delegate()
            {
                switch (colorModeComboBox.SelectedIndex)
                {
                    case 0:
                        colorMode = 1;
                        bitDepth = 24;
                        break;
                    case 1:
                        colorMode = 2;
                        bitDepth = 8;
                        break;
                }

                switch (imageFormatComboBox.SelectedIndex)
                {
                    case 0:
                        // JPEG
                        fileFormat = 1;
                        fileExtension = ".jpeg";
                        break;
                    case 1:
                        // PNG
                        fileFormat = 2;
                        fileExtension = ".png";
                        break;
                    case 2:
                        // BMP
                        fileFormat = 3;
                        fileExtension = ".bmp";
                        break;
                    case 3:
                        // GIF
                        fileFormat = 4;
                        fileExtension = ".gif";
                        break;
                }
                resolution = int.Parse(resolutionTextBox.Text);
                brightness = int.Parse(brightnessTextBox.Text);
                contrast = int.Parse(contrastTextBox.Text);
            }));

            this.Invoke(new MethodInvoker(delegate()
            {
                widthPixels = (int) (8.3f * resolution);
                heightPixels = (int) (11.7f * resolution);
                    device.Scan(deviceInfo.DeviceID, resolution, widthPixels, heightPixels, brightness, contrast,
                        colorMode, bitDepth, fileFormat, outputFolderTextBox.Text,
                        fileNameTextBox.Text);

                    var imagePath = outputFolderTextBox.Text;
                    imagePath += "\\";
                    imagePath += fileNameTextBox.Text;
                    imagePath += fileExtension;

                    scannedImagePictureBox.Image = new Bitmap(imagePath);
                }));
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
