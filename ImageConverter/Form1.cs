using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageConverter
{
    public partial class Form1 : Form
    {
        string destFolder = "";

        public Form1()
        {
            InitializeComponent();
            tbDestFolder.Text = destFolder;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.FileNames != null &&
                    openFileDialog1.FileNames.Length != 0)
                {
                    int width = Int32.Parse(tbWidth.Text);
                    int height = Int32.Parse(tbHeight.Text);
                    Rectangle destRect = new Rectangle(0, 0, width, height);
                    ImageFormat imFormat = ImageFormat.Jpeg;
                    string fileExt = "jpg";
                    switch(cbFormat.Text)
                    {
                        case "BMP":
                            imFormat = ImageFormat.Bmp;
                            fileExt = "bmp";
                            break;
                        case "GIF":
                            imFormat = ImageFormat.Gif;
                            fileExt = "gif";
                            break;
                        case "JPEG":
                            imFormat = ImageFormat.Jpeg;
                            fileExt = "jpg";
                            break;
                        case "TIFF":
                            imFormat = ImageFormat.Tiff;
                            fileExt = "tif";
                            break;
                    }
                    foreach (string fName in openFileDialog1.FileNames)
                    {
                        Bitmap bmpOld = (Bitmap)Bitmap.FromFile(fName);
                        Bitmap bmpNew = new Bitmap(bmpOld, width, height);
                        string[] arrStr = fName.Split(new char[] { '\\', '.' });
                        string realFileName = arrStr[arrStr.Length - 2];
                        bmpNew.Save(destFolder + "\\" + realFileName +
                            "." + fileExt, imFormat);
                    }
                }
                MessageBox.Show("Преобразование успешно завершено",
                    "Преобразование завершено", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка преобразования: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                destFolder = folderBrowserDialog1.SelectedPath;
            tbDestFolder.Text = destFolder;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}