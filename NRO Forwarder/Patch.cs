using System;
using System.IO;
using System.Windows.Forms;

namespace NRO_Forwarder
{
    public partial class Form_Patch : Form
    {
        public Form_Patch()
        {
            InitializeComponent();
            String filex = "Tools/exefs/main.npdm";
            if (File.Exists(filex))
            {
                try
                {
                    BinaryReader reader = new BinaryReader(new FileStream(filex, FileMode.Open));
                    reader.BaseStream.Position = 1010;  //
                    byte[] bytes = reader.ReadBytes(1);
                    reader.Close();
                    reader.Dispose();
                    string currentval = BitConverter.ToString(bytes);
                    //MessageBox.Show(BitConverter.ToString(bytes)); //show bytes pattern

                    if (currentval == "00")
                    {
                        radioButton_nodebug.Checked = true;
                    }
                    else if (currentval == "02")
                    {
                        radioButton_allowdebug.Checked = true;
                    }
                    else if (currentval == "04")
                    {
                        radioButton_forceprod.Checked = true;
                    }
                    else if (currentval == "08")
                    {
                        radioButton_forcedebug.Checked = true;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error is: " + error.Message);
                }
            }
            else
            {
                MessageBox.Show("Unable to find " + filex, "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button_patch_Click(object sender, EventArgs e)
        {
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
                if (radioButton_nodebug.Checked)
                {
                    ReplaceData(file, pos1, patch);
                    ReplaceData(file, pos2, patch);
                    MessageBox.Show(info + "0x00", "No debugs enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //no debugs enabled
                }
                else if (radioButton_allowdebug.Checked)
                {
                    ReplaceData(file, pos1, patch2);
                    ReplaceData(file, pos2, patch2);
                    MessageBox.Show(info + "0x02", "Flag 'allow_debug' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //Allow debug
                }
                else if (radioButton_forceprod.Checked)
                {
                    ReplaceData(file, pos1, patch3);
                    ReplaceData(file, pos2, patch3);
                    MessageBox.Show(info + "0x04", "Flag 'force_debug_prod' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //force_debug_prod
                }
                else if (radioButton_forcedebug.Checked)
                {
                    ReplaceData(file, pos1, patch4);
                    ReplaceData(file, pos2, patch4);
                    MessageBox.Show(info + "0x08", "Flag 'force_debug' enabled", MessageBoxButtons.OK, MessageBoxIcon.Information); //force_debug
                }
            }
            else
            {
                MessageBox.Show("Cant'find " + file, "Oops"); //Atmosphere pre-1.8.0
            }
        }
    }
}
