﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NRO_Forwarder
{
    public partial class MainMenu : Form
    {
        protected bool validData;
        string path;
        protected Image image;
        protected Thread getImageThread;
        string filepath = "";

        public MainMenu()
        {
            InitializeComponent();
            titlegen();
            comboBox();
            pictureBox1.AllowDrop = true;
            textBox_TIT.MaxLength = 16;
            textBox_Version.MaxLength = 16; //
            textBox_AppTitle.MaxLength = 512;
            textBox_publisher.MaxLength = 256;
            textBox_nropath.MaxLength = 256;
            textBox_RomPath.MaxLength = 256;
            checkBox1_Video.Checked = true;
            checkBox_profile.Checked = true;
            checkBox_Screeshot.Checked = true;
            if (!Directory.Exists("Tools/control"))
            {
                Directory.CreateDirectory("Tools/control");
            }
            if (!Directory.Exists("Tools/romfs"))
            {
                Directory.CreateDirectory("Tools/romfs");
            }
            String iconpath = "Tools/control/icon_AmericanEnglish.dat";
            pictureBox1.BackgroundImage.Save(iconpath); //always set the default icon
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".jpeg") || (ext == ".jfif") || (ext == ".png") || (ext == ".bmp") || (ext == ".gif") || (ext == ".tif") || (ext == ".ico"))
                        {
                            ret = true;
                        }
                        else if (ext == ".nro")
                        {
                            filepath = filename;
                            string name = Path.GetFileName(filepath);
                            string newpath = (("/switch/tinwoo/tinwoo.nro").Replace("tinwoo", name).Replace(ext, "") + ext);
                            textBox_nropath.Text = newpath;
                            Find();
                        }
                    }
                }
            }
            return ret;
        }

        private void comboBox()
        {
            //Create, Populate and Sort list automatically
            List<EMU> items = new List<EMU>();
            items.Add(new EMU() { emulator = "Uae4all2", nropath = "/switch/uae4all2/uae4all2.nro", rompath = "/switch/uae4all2/conf/benefactor.conf" });
            items.Add(new EMU() { emulator = "BSNes", nropath = "/retroarch/cores/bsnes_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "Citra", nropath = "/retroarch/cores/citra_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "Gambatte", nropath = "/retroarch/cores/gambatte_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "Mgba", nropath = "/retroarch/cores/mgba_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "Mgba Standalone", nropath = "/switch/mgba/mgba.nro", rompath = "/switch/mgba/xxx" });
            items.Add(new EMU() { emulator = "Mupen64plus", nropath = "/retroarch/cores/mupen64plus_next_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "Nestopia", nropath = "/retroarch/cores/nestopia_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "PCSX Rearmed", nropath = "/retroarch/cores/pcsx_rearmed_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx/" });
            items.Add(new EMU() { emulator = "PicoDrive", nropath = "/retroarch/cores/picodrive_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });
            items.Add(new EMU() { emulator = "PPSSPP (GLES2)", nropath = "/switch/ppsspp/PPSSPP_GLES2.nro", rompath = "/switch/ppsspp/xxx" });
            items.Add(new EMU() { emulator = "PPSSPP (GL)", nropath = "/switch/PPSSPP_GL/PPSSPP_GL.nro", rompath = "/switch/PPSSPP_GL/xxx" });
            items.Add(new EMU() { emulator = "Snes9x", nropath = "/retroarch/cores/snes9x_libretro_libnx.nro", rompath = "/retroarch/downloads/xxx" });

            //create a new sorted list from the list above
            List<EMU> SortedList = items.OrderBy(o => o.emulator).ToList();
            items.Clear(); //remove all items in previous list as we don't need them now we are using a sorted list

            //add sorted list to the combobox
            comboBox_retro.DataSource = SortedList;
            comboBox_retro.DisplayMember = "emulator";
            comboBox_retro.ValueMember = "nropath";

        }

        private void titlegen()
        {
            //generate a random title id
            var csprng = new RNGCryptoServiceProvider();
            var bytes = new byte[8];
            csprng.GetNonZeroBytes(bytes); // or csprng.GetBytes(…)
            bytes[0] = 0x01; //make first byte a zero
            textBox_TIT.Text = string.Join("", bytes.Select(b => b.ToString("X2"))); // or "X2" for upper case
        }

        private void checkBox_Retro_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_Retro.Checked)
            {
                label_nro.Text = "Core Path:";
                label_apptitle.Text = "Game Title:";
                int last = comboBox_retro.Items.Count - 1;
                comboBox_retro.SelectedIndex = last; //auto select last item in comboxbox
                textBox_RomPath.Enabled = true;
                textBox_CorePath.Enabled = true;
                textBox_CorePath.Visible = true;
                textBox_nropath.Visible = false;
                comboBox_retro.Visible = true;
                comboBox_retro.Enabled = true;
            }
            else
            {
                label_nro.Text = "NRO Path:";
                label_apptitle.Text = "App Title:";
                textBox_RomPath.Enabled = false;
                textBox_CorePath.Enabled = false;
                textBox_CorePath.Visible = false;
                textBox_nropath.Visible = true;
                comboBox_retro.Visible = false;
                comboBox_retro.Enabled = false;
            }
        }

        private void textBox_TIT_DoubleClick(object sender, EventArgs e)
        {
            titlegen();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EMU info = this.comboBox_retro.SelectedItem as EMU;
            textBox_CorePath.Text = info.nropath;
            textBox_RomPath.Text = info.rompath;
        }

        private void pictureBox1_DragOver(object sender, DragEventArgs e)
        {
            try

            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Link;
                else
                    e.Effect = DragDropEffects.None;
            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)

        {
            //required
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pictureBox1.Image = image;
                //MessageBox.Show("", filename);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        protected void LoadImage()

        {
            //resize image first
            Bitmap b = new Bitmap(path);
            System.Drawing.Image i = ResizeImage(b, 256, 256);
            //pictureBox1.BackgroundImage = new Bitmap(i);

            // Save the image in JPEG format.
            if (File.Exists("Tools/control/icon_AmericanEnglish.dat"))
            {
                pictureBox1.BackgroundImage.Dispose();
                File.Delete("Tools/control/icon_AmericanEnglish.dat");
            }
            i.Save("Tools/control/icon_AmericanEnglish.dat", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox1.BackgroundImage = Image.FromFile("Tools/control/icon_AmericanEnglish.dat");
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            image.Dispose(); //release icon.png once loaded into the picturebox so we can save without crashing the app
            return (destImage);
        }


        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select a graphics file";
                openFileDialog.Filter = "Supported Files|*.jpg;*.jpeg;*.jfif;*.png;*.bmp;*.gif;*.tif;*.tiff;*.ico|JPEG files (*.jpg;*.jpeg;*.jfif)|*.jpg;*.jpeg;*.jfif|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|TIFF (*.tiff, *.tif)|*.tiff;*.tif|ICO (*.ico)|*.ico|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    String x = openFileDialog.FileName;
                    Bitmap b = null;
                    bool myfile = x.Contains("png") || x.Contains("jpg") || x.Contains("jpeg") || x.Contains("jfif") ||  x.Contains("gif") || x.Contains("bmp") || x.Contains("tiff") || x.Contains("tif") || x.Contains("ico") || x.Contains("webp");
                    if (myfile)
                    {
                        if (myfile = x.Contains("webp"))
                        {
                            //add converion code for webp and other image formats here later....
                            //https://briancaos.wordpress.com/2022/08/29/c-convert-webp-to-jpeg-in-net/
                            //b = new Bitmap(x);
                            MessageBox.Show("File not supported yet, this will be added later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            b = new Bitmap(x);
                        }
                        System.Drawing.Image i = ResizeImage(b, 256, 256);
                        //pictureBox1.BackgroundImage = new Bitmap(i);
                        // Save the image in JPEG format.
                        if (File.Exists("Tools/control/icon_AmericanEnglish.dat"))
                        {
                            pictureBox1.BackgroundImage.Dispose();
                            File.Delete("Tools/control/icon_AmericanEnglish.dat");
                        }
                        i.Save("Tools/control/icon_AmericanEnglish.dat", System.Drawing.Imaging.ImageFormat.Jpeg);
                        pictureBox1.BackgroundImage = Image.FromFile("Tools/control/icon_AmericanEnglish.dat");
                    }

                    else
                    {
                        MessageBox.Show("File not supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        private void openNROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nrostuff();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string filePath = "";
            saveFileDialog.FileName = Path.GetFileName("icon.jpg");
            saveFileDialog.Filter = "JPG (*.jpg)|*.jpg";
            saveFileDialog.OverwritePrompt = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                pictureBox1.BackgroundImage.Save(filePath);
                MessageBox.Show(filePath + " icon saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void nrostuff()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select an NRO file";
                openFileDialog.Filter = "NRO Files|*.nro";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    String x = openFileDialog.FileName;
                    string name = Path.GetFileName(x);
                    string ext = Path.GetExtension(x);
                    string newpath = (("/switch/tinwoo/tinwoo.nro").Replace("tinwoo", name).Replace(ext, "") + ext);
                    textBox_nropath.Text = newpath;
                    bool myfile = x.Contains("nro");
                    if (myfile)
                    {
                        filepath = x;
                        //next load nro file into an array and search for ASET (0x41534554)
                        new Thread(() =>
                        {
                            Thread.CurrentThread.IsBackground = true;
                            /* run your code here */
                            Find();
                        }).Start();
                    }

                    else
                    {
                        MessageBox.Show("File not supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        private void Find()
        {
            try
            {
                int foundloc = 0;
                BinaryReader reader = new BinaryReader(new FileStream(filepath, FileMode.Open));
                reader.BaseStream.Position = 24;  //get ASET start
                byte[] bytes = reader.ReadBytes(8);
                foundloc = BitConverter.ToInt32(bytes, 0); //i = icon size
                //MessageBox.Show(BitConverter.ToString(bytes)); //show bytes pattern
                //MessageBox.Show(pos.ToString()); //show byte array as int

                //Patern found here...so do more stuff
                reader.BaseStream.Position = foundloc + 16;  //get size of icon
                bytes = reader.ReadBytes(8);
                //Array.Reverse(bytes);
                int iconsize = BitConverter.ToInt32(bytes, 0); //i = icon size
                Array.Clear(bytes, 0, bytes.Length); //clear array.
                reader.BaseStream.Position = foundloc + 56;  //Goto start of icon
                bytes = reader.ReadBytes(iconsize);

                //resize the image/byte array
                System.Drawing.Image i = ResizeImage(ByteToImage(bytes), 256, 256);
                //pictureBox1.BackgroundImage = new Bitmap(i);
                //convert png to jpg or the forwarder won't display the icon
                if (File.Exists("Tools/control/icon_AmericanEnglish.dat"))
                {
                    pictureBox1.BackgroundImage.Dispose();
                    File.Delete("Tools/control/icon_AmericanEnglish.dat");
                }
                i.Save("Tools/control/icon_AmericanEnglish.dat", System.Drawing.Imaging.ImageFormat.Jpeg);
                pictureBox1.BackgroundImage = Image.FromFile("Tools/control/icon_AmericanEnglish.dat");


                //File.WriteAllBytes("icon.png", bytes); //copy icon byte array to file
                Array.Clear(bytes, 0, bytes.Length); //clear array.
                reader.BaseStream.Position = foundloc + 56 + iconsize;  //Goto start of app title
                bytes = reader.ReadBytes(512);
                String title = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                Array.Clear(bytes, 0, bytes.Length); //clear array.
                textBox_AppTitle.Text = title; //set app title from nro
                reader.BaseStream.Position = foundloc + 56 + iconsize + 512;  //Goto start of app dev
                bytes = reader.ReadBytes(256);
                String dev = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                Array.Clear(bytes, 0, bytes.Length); //clear array.
                textBox_publisher.Text = dev;
                reader.BaseStream.Position = foundloc + 56 + iconsize + 12384;  //Goto start of version
                bytes = reader.ReadBytes(34);
                String ver = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                textBox_Version.Text = ver;
                Array.Clear(bytes, 0, bytes.Length); //clear array.
                reader.Close();
            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void textBox_TIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39) || (c == 0x16) || (c == 0x03)))
            {
                e.Handled = true;
            }
        }

        private void textBox_Version_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c != '\b' && c != '.' && !((c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39) || (c == 0x16) || (c == 0x03)))
            //if (c != '\b' && c != '.' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39) || (c == 0x16) || (c == 0x03)))
            {
                e.Handled = true;
            }
        }

        private void button_explore_Click(object sender, EventArgs e)
        {
            try
            {
                string mydir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = mydir + "/Tools",
                    UseShellExecute = true,
                    Verb = "open"
                });
            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                //try to create an NRO forwarder, get all the infowe need.
                String apptitle = textBox_AppTitle.Text;
                String titleid = textBox_TIT.Text;
                String version = textBox_Version.Text;
                String publisher = textBox_publisher.Text;
                String corepath = "sdmc:" + textBox_CorePath.Text;
                String nropath = "sdmc:" + textBox_nropath.Text;
                String rompath = "sdmc:" + textBox_RomPath.Text;
                String nextNroPath = "Tools/romfs/nextNroPath";
                String nextArgvPath = "Tools/romfs/nextArgv";
                String iconpath = "Tools/control/icon_AmericanEnglish.dat";
                int pos = 0;
                String file = "Tools/control/control.nacp";

                //we better check title id is the correct length
                if (titleid.Length != 16)
                {
                    titlegen();
                }
                //create new blank control.nacp               
                byte[] newcontrol = { 0x00 };
                Array.Resize(ref newcontrol, newcontrol.Length + 16383);
                using (FileStream fileStream = new FileStream(file, FileMode.Create))
                {
                    for (int q = 0; q < newcontrol.Length; q++)
                    {
                        fileStream.WriteByte(newcontrol[q]);
                    }
                    fileStream.Close();
                    fileStream.Dispose();
                }

                //patch main.npdm with correct ID
                int npdmloc = 848;
                int npdmloc2 = 856;
                byte[] npdm = Encoding.ASCII.GetBytes(titleid);
                byte[] blank = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                ReplaceData("Tools/exefs/main.npdm", npdmloc, npdm);
                ReplaceData("Tools/exefs/main.npdm", npdmloc2, blank);


                //PlayLogQueryCapability + PlayLogPolicy patches
                int pos1 = 12343;
                int pos2 = 12816;
                byte[] patch = { 0x02 };
                ReplaceData(file, pos1, patch);
                ReplaceData(file, pos2, patch);
                //

                if (checkBox_licence.Checked && checkBox_licence.Text == "Distributed By")
                {
                    pos = 12528; //Change Licence info to Distributed By (0x30F0)
                    byte[] licence = { 0x01 };
                    ReplaceData(file, pos, licence);
                }
                else if (checkBox_licence.Checked && checkBox_licence.Text == "Licenced By")
                {
                    pos = 12528; //Change Licence info to Licenced By (0x30F0)
                    byte[] licence = { 0x00 };
                    ReplaceData(file, pos, licence);
                }
                else
                {
                    pos = 12528; //Change Licence info to no text (0x30F0)
                    byte[] licence = { 0x02 };
                    ReplaceData(file, pos, licence);
                }

                if (checkBox_Screeshot.Checked)
                {
                    pos = 12340; //Screenshots Enable (0x3034)
                    byte[] ScreenShotEnable = { 0x00 };
                    ReplaceData(file, pos, ScreenShotEnable);
                }
                else
                {
                    pos = 12340; //Screenshots disable (0x3034)
                    byte[] ScreenShotBlank = { 0x01 };
                    ReplaceData(file, pos, ScreenShotBlank);
                }
                if (checkBox1_Video.Checked)
                {

                    pos = 12341; //Video capture (0x3035)
                    byte[] VideoEnable = { 0x02 }; //auto
                    ReplaceData(file, pos, VideoEnable);
                }
                else
                {
                    pos = 12341; //Video (0x3035)
                    byte[] videoblank = { 0x00 }; //off
                    ReplaceData(file, pos, videoblank);
                }
                if (checkBox_profile.Checked)
                {
                    pos = 12325; //profile Enable (0x3025) //StartupUserAccount
                    byte[] ProfileEnable = { 0x01 };
                    ReplaceData(file, pos, ProfileEnable);
                }
                else
                {
                    pos = 12325; //profile Enable (0x3025)
                    byte[] ProfileBlank = { 0x00 };
                    ReplaceData(file, pos, ProfileBlank);
                }

                //generate the the paths...
                if (checkBox_Retro.Checked)
                {
                    File.WriteAllText(nextNroPath, corepath);
                    File.WriteAllText(nextArgvPath, corepath + " " + '"' + rompath + '"');
                }
                else
                {
                    File.WriteAllText(nextNroPath, nropath);
                    File.WriteAllText(nextArgvPath, nropath);
                }

                //make sure that the icon exists.
                if (!File.Exists(iconpath))
                {
                    //Lets grab the image from the picturebox
                    pictureBox1.BackgroundImage.Save(iconpath);
                }

                //Write version string
                pos = 12384; //3060 (0x10) - Display version
                byte[] data = Encoding.ASCII.GetBytes(version); //convert version to byte array
                //if we don't create a new control.nacp file above,uncomment the two next lines.
                //byte[] versionblank = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                //ReplaceData(file, pos, versionblank); //Reset Version
                ReplaceData(file, pos, data);//Write New Version String
                Array.Clear(data, 0, data.Length);

                //cleanup old backup files and remove old nro's
                if (Directory.Exists("Tools/NSP"))
                {
                    var dir = new DirectoryInfo("Tools/NSP");
                    dir.Delete(true);
                }

                //Try to Build NSP
                try
                {
                    string myargs;
                    if (checkBox_nologo.Checked)
                        myargs = " --nologo --titleid " + titleid + " --titlename " + '"' + apptitle + '"' + " --titlepublisher " + '"' + publisher + '"' + " --nspdir NSP -k ./prod.keys";
                    else
                        myargs = " --titleid " + titleid + " --titlename " + '"' + apptitle + '"' + " --titlepublisher " + '"' + publisher + '"' + " --nspdir NSP -k ./prod.keys";
                    
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = "Tools";
                    process.StartInfo.FileName = "Tools\\hacbrewpack.exe";
                    process.StartInfo.Arguments = myargs;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = false;
                    process.StartInfo.RedirectStandardError = false;
                    process.Start();
                    process.WaitForExit();
                }

                catch (Exception error)
                {
                    MessageBox.Show("Error is: " + error.Message);
                }

                //rename newly generated NSP
                if (File.Exists("Tools/NSP/" + titleid + ".nsp"))
                {
                    System.IO.File.Move("Tools/NSP/" + titleid + ".nsp", "Tools/NSP/" + apptitle + ".nsp");
                }

                //remove auto backup files generated by hackbrewpack
                if (Directory.Exists("Tools/hacbrewpack_backup"))
                {
                    var dir = new DirectoryInfo("Tools/hacbrewpack_backup");
                    dir.Delete(true);
                }


                //open NSP folder
                try
                {
                    string mydir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    string nspfolder = mydir + "/Tools/NSP";
                    if (Directory.Exists(nspfolder))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = nspfolder,
                            UseShellExecute = true,
                            Verb = "open"
                        });
                    }
                }

                catch (Exception error)
                {
                    MessageBox.Show("Error is: " + error.Message);
                }

            }

            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        //Just leave this,I might use it later
        static string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }

        public static void ReplaceData(string filename, int position, byte[] data)
        {
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                stream.Position = position;
                stream.Write(data, 0, data.Length);
                stream.Close();
                stream.Dispose();
            }
        }

        private void textBox_TIT_TextChanged(object sender, EventArgs e)
        {
            string check = textBox_TIT.Text.ToUpper();
            char[] ch = check.ToCharArray();
            if (check.Length == 0)
            {
                check = "01";
            }

            if (ch.Length >= 16)
            {
                if (ch[0] != '0')
                {
                    ch[0] = '0';
                }
                if (ch[1] != '1')
                {
                    ch[1] = '1';
                }
                if (ch[12] == '1' || ch[12] == '3' || ch[12] == '5' || ch[12] == '7' || ch[12] == '9' || ch[12] == 'B' || ch[12] == 'D' || ch[12] == 'F')
                {
                    byte[] blank = { 0x30, 0x32, 0x34, 0x36, 0x38, 0x41, 0x43, 0x45 };
                    Random random = new Random();
                    int chosen = random.Next(0, blank.Length);
                    ch[12] = (char)blank[chosen];
                }
                if (ch[13] != '0')
                {
                    ch[13] = '0';
                }
                if (ch[14] != '0')
                {
                    ch[14] = '0';
                }
                if (ch[15] != '0')
                {
                    ch[15] = '0';
                }
            }
            string newstring = new string(ch);
            textBox_TIT.Text = newstring;
        }

        private void button_Generate_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            Debug Flags - Valid Flags are
            0x00
            "allow_debug": false,
            "force_debug": false,
            "force_debug_prod": false
            
            0x02
            "allow_debug": true,
            "force_debug": false,
            "force_debug_prod": false
            
            0x04
            "allow_debug": false,
            "force_debug": false,
            "force_debug_prod": true
            
            0x08
            "allow_debug": false,
            "force_debug": true,
            "force_debug_prod": false
            */

            /*
            String file = "Tools/exefs/main.npdm";
            int pos1 = 818; //(0x332)
            int pos2 = 1010; //(0x3F2)
            byte[] patch = { 0x00 };
            byte[] patch2 = { 0x02 };
            byte[] patch3 = { 0x04 };
            byte[] patch4 = { 0x08 };
            string info = "main.npdm Patched at 0x332 + 0x3F2 with: ";

            if (File.Exists("Tools/exefs/main.npdm"))
            {
                switch (e.KeyData)
                {
                    //Patch main.npdm Offsets: 0x332, 0x3F2
                    case Keys.Z:
                        ReplaceData(file, pos1, patch);
                        ReplaceData(file, pos2, patch);
                        MessageBox.Show(info + "0x00", "No debugs enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //no debugs enabled
                        break;
                    case Keys.X:
                        ReplaceData(file, pos1, patch2);
                        ReplaceData(file, pos2, patch2);
                        MessageBox.Show(info + "0x02", "Flag 'allow_debug' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //Allow debug
                        break;
                    case Keys.C:
                        ReplaceData(file, pos1, patch3);
                        ReplaceData(file, pos2, patch3);
                        MessageBox.Show(info + "0x04", "Flag 'force_debug_prod' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //force_debug_prod
                        break;
                    case Keys.V:
                        ReplaceData(file, pos1, patch4);
                        ReplaceData(file, pos2, patch4);
                        MessageBox.Show(info + "0x08", "Flag 'force_debug' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //force_debug
                        break;
                }
            }
            else
            {
                MessageBox.Show("Cant'find " + file, "Oops"); //Atmosphere pre-1.8.0
            }
            */
        }

        private void checkBox_licence_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_licence.Checked && checkBox_licence.Text == "Distributed By")
            {
                checkBox_licence.Checked = true;
                checkBox_licence.Text = "Licenced By";
            }
            else if (checkBox_licence.Checked && checkBox_licence.Text == "Licenced By")
            {
                checkBox_licence.Checked = true;
                checkBox_licence.Text = "Distributed By";
            }
            else if (!checkBox_licence.Checked && checkBox_licence.Text == "Licenced By")
            {
                checkBox_licence.Checked = true;
                checkBox_licence.Text = "No Text";
            }
            else if (!checkBox_licence.Checked && checkBox_licence.Text == "No Text")
            {
                checkBox_licence.Checked = true;
                checkBox_licence.Text = "Distributed By";
            }
        }

        private void button_open_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Process.Start("explorer", "https://nsp-forwarder-git-fork-masagrator-main-tootallteam.vercel.app/?advanced");
                    break;

                case MouseButtons.Right:
                    Process.Start("explorer", "https://nsp-forwarder.n8.io/");
                    break;
            }
        }

        public class EMU
        {
            public string emulator { get; set; }
            public string nropath { get; set; }
            public string rompath { get; set; }

            //very important, the result will be displayed in the combox
            public override string ToString()
            {
                return string.Format("{0}->{1}->{2}", emulator, nropath, rompath);
            }
        }

        private void button_Generate_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        Form search = new Form_Patch();
                        this.Hide();
                        search.ShowDialog();
                        this.Show();
                        break;

                    case MouseButtons.Left:
                        //
                        break;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error is: " + error.Message);
            }
        }

        private void textBox_AppTitle_TextChanged(object sender, EventArgs e)
        {
            /*Generate the same TID for the forwarder based on the App Title name.
            https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography?view=net-9.0
            */
            
            String sSourceData = textBox_AppTitle.Text;
            byte[] tmpSource;
            byte[] tmpHash;
            
            //Create a byte array from source data
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            
            tmpHash = new SHA1CryptoServiceProvider().ComputeHash(tmpSource);
            string hashval = ByteArrayToString(tmpHash);
            string str = hashval.Substring(0, 16); //get x amount of chars from string
            textBox_TIT.Text = str;

            string check = textBox_TIT.Text.ToUpper();
            char[] ch = check.ToCharArray();
            if (ch[12] != '0')
            {
                ch[12] = '0';
            }
            string newstring = new string(ch);
            textBox_TIT.Text = newstring;
            Array.Clear(tmpSource,0,tmpSource.Length);
            Array.Clear(tmpHash, 0, tmpHash.Length);
        }

        static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
