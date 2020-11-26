using System;
using System.Collections.Generic;
using WIA;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ScannerTwain
{
    public struct WIADeviceInfo
    {
        public string DeviceID;
        public string Name;

        public WIADeviceInfo(string DeviceID, string Name)
        {
            this.DeviceID = DeviceID;
            this.Name = Name;
        }
    }

    public enum WIADeviceInfoProp
    {
        DeviceID = 2,
        Manufacturer = 3,
        Description = 4,
        Type = 5,
        Port = 6,
        Name = 7,
        Server = 8,
        RemoteDevID = 9,
        UIClassID = 10,
    }

    public class WiaScanner
    {
        private string _scannerId;
        private int _resolution;
        private int _widthPixel;
        private int _heightPixel;
        private int _colorMode;
        private int _bitDepth;
        private int _brightnessPercent;
        private int _contrastPercent;
        private int _fileFormat;
        private string _path;
        private string _fileName;

        public void Scan(string scannerId, int resolution, int widthPixel, int heightPixel, int brightnessPercent,
            int contrastPercent, int colorMode, int bitDepth, int fileFormat, string path,
            string fileName)
        {
            _scannerId = scannerId;
            _resolution = resolution;
            _widthPixel = widthPixel;
            _heightPixel = heightPixel;
            _brightnessPercent = brightnessPercent;
            _contrastPercent = contrastPercent;
            _colorMode = colorMode;
            _bitDepth = bitDepth;
            _fileFormat = fileFormat;
            _path = path;
            _fileName = fileName;

            ConnectAndScanImage();
        }

        private DeviceInfo FindFirstScanner()
        {
            var deviceManager = new DeviceManager();
            DeviceInfo firstScannerAvailable = null;

            try
            {
                for (var i = 1; i < deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }

                    firstScannerAvailable = deviceManager.DeviceInfos[i];
                    break;
                }
            }
            catch (COMException e)
            {
                var errorCode = (uint) e.ErrorCode;
                PrintError(errorCode);
            }

            return firstScannerAvailable;
        }

        private void ConnectAndScanImage()
        {
            try
            {
                DeviceManager manager = new DeviceManager();
                Device device = null;

                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.DeviceID == _scannerId)
                    {
                        device = info.Connect();
                        break;
                    }
                }

                if (device == null)
                {
                    string availableDevices = "";
                    foreach (DeviceInfo info in manager.DeviceInfos)
                    {
                        availableDevices += info.DeviceID + "\n";
                    }
                    throw new Exception("The device with provided ID could not be found. Available devices:\n" + availableDevices);
                }

                var scannerItem = device.Items[1];

                AdjustScannerSettings(scannerItem, _resolution, 0, 0, _widthPixel, _heightPixel,
                    _brightnessPercent, _contrastPercent, _colorMode, _bitDepth);
                ScanImage(scannerItem);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        private void ScanImage(Item scannerItem)
        {
            var dlg = new CommonDialogClass();

            switch (_fileFormat)
            {
                // JPEG
                case 1:
                    SaveFileAsJPeg(scannerItem, dlg);
                    break;
                // PNG
                case 2:
                    SaveFileAsPng(scannerItem, dlg);
                    break;
                // BMP
                case 3:
                    SaveFileAsBmp(scannerItem, dlg);
                    break;
                // GIF
                case 4:
                    SaveFileAsGif(scannerItem, dlg);
                    break;
            }
        }

        private void SaveFileAsJPeg(Item scannerItem, CommonDialogClass dlg)
        {
            try
            {
                var scanResult = dlg.ShowTransfer(scannerItem, FormatID.wiaFormatJPEG, true);

                if (scanResult == null) return;
                var imageFile = (ImageFile) scanResult;
                _path += "\\";
                _path += _fileName;
                _path += ".jpeg";
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                imageFile.SaveFile(_path);
                Console.WriteLine("File saved to: " + _path);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        private void SaveFileAsPng(Item scannerItem, CommonDialogClass dlg)
        {
            try
            {
                var scanResult = dlg.ShowTransfer(scannerItem, FormatID.wiaFormatPNG, true);

                if (scanResult == null) return;
                var imageFile = (ImageFile)scanResult;
                _path += "\\";
                _path += _fileName;
                _path += ".png";
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                imageFile.SaveFile(_path);
                Console.WriteLine("File saved to: " + _path);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        private void SaveFileAsBmp(Item scannerItem, CommonDialogClass dlg)
        {
            try
            {
                var scanResult = dlg.ShowTransfer(scannerItem, FormatID.wiaFormatBMP, true);

                if (scanResult == null) return;
                var imageFile = (ImageFile)scanResult;
                _path += "\\";
                _path += _fileName;
                _path += ".bmp";
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                imageFile.SaveFile(_path);
                Console.WriteLine("File saved to: " + _path);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        private void SaveFileAsGif(Item scannerItem, CommonDialogClass dlg)
        {
            try
            {
                var scanResult = dlg.ShowTransfer(scannerItem, FormatID.wiaFormatGIF, true);

                if (scanResult == null) return;
                var imageFile = (ImageFile)scanResult;
                _path += "\\";
                _path += _fileName;
                _path += ".gif";
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                imageFile.SaveFile(_path);
                Console.WriteLine("File saved to: " + _path);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        /// <summary>
        /// Gets the list of available WIA devices.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<WIADeviceInfo> GetDevices()
        {
            var devices = new List<string>();
            var manager = new WIA.DeviceManager();
            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
            {
                yield return new WIADeviceInfo(info.DeviceID, (string)info.Properties[WIADeviceInfoProp.Manufacturer].get_Value());
            }
        }

        /// <summary>
        /// Adjusts the settings of the scanner with the providen parameters.
        /// </summary>
        /// <param name="scannerItem">Scanner Item</param>
        /// <param name="scanResolutionDpi">Provide the DPI resolution that should be used e.g 150</param>
        /// <param name="scanStartLeftPixel"></param>
        /// <param name="scanStartTopPixel"></param>
        /// <param name="scanWidthPixels"></param>
        /// <param name="scanHeightPixels"></param>
        /// <param name="brightnessPercents"></param>
        /// <param name="contrastPercents">Modify the contrast percent</param>
        /// <param name="colorMode">Set the color mode</param>
        /// <param name="bitDepth">Set bit depth</param>
        private static void AdjustScannerSettings(IItem scannerItem, int scanResolutionDpi,
            int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels,
            int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode,
            int bitDepth)
        {
            const string WIA_SCAN_BIT_DEPTH = "4104";
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            try
            {
                SetWiaProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI,
                    scanResolutionDpi);
                SetWiaProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI,
                    scanResolutionDpi);
                SetWiaProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL,
                    scanStartLeftPixel);
                SetWiaProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL,
                    scanStartTopPixel);
                SetWiaProperty(scannerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS,
                    scanWidthPixels);
                SetWiaProperty(scannerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS,
                    scanHeightPixels);
                SetWiaProperty(scannerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS,
                    brightnessPercents);
                SetWiaProperty(scannerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS,
                    contrastPercents);
                SetWiaProperty(scannerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
                SetWiaProperty(scannerItem.Properties, WIA_SCAN_BIT_DEPTH, bitDepth);
            }
            catch (COMException e)
            {
                var errorCode = (uint) e.ErrorCode;
                PrintError(errorCode);
            }
        }

        /// <summary>
        /// Modify a WIA property
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="propName"></param>
        /// <param name="propValue"></param>
        private static void SetWiaProperty(IProperties properties, object propName, object propValue)
        {
            try
            {
                var prop = properties.get_Item(ref propName);
                prop.set_Value(ref propValue);
            }
            catch (COMException e)
            {
                var errorCode = (uint)e.ErrorCode;
                PrintError(errorCode);
            }
        }

        private static void PrintError(uint errorCode)
        {
            switch (errorCode)
            {
                case 0x80210006:
                    Console.WriteLine(@"The scanner is busy or isn't ready.");
                    break;
                case 0x80210064:
                    Console.WriteLine(@"The scanning process has been cancelled.");
                    break;
                case 0x8021000C:
                    Console.WriteLine(@"There is an incorrect setting on the WIA device.");
                    break;
                case 0x80210005:
                    Console.WriteLine(
                        @"The device is offline. Make sure the device is powered on and connected to the PC.");
                    break;
                case 0x80210001:
                    Console.WriteLine(@"An unknown error has occured with the WIA device.");
                    break;
            }
        }
    }
}
