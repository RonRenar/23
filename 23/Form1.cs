using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace _23
{
    public partial class Form1 : Form
    {



        public Form2 f = new Form2();
        
       



        bool drawing;
        GraphicsPath currentPath; 
Point oldLocation;
        Pen currentPen;
        Color historyColor;
        
        int historyCounter;
        List<Image> History;
        public Form1()
        {
          
            InitializeComponent();
            History = new List<Image>();
            drawing = false; //Переменная, ответственная за рисование 
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом 
            currentPen.Width = trackBarPen.Value; //Инициализация толщины пера 

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
          

            Bitmap pic = new Bitmap(700, 352);
            picDrawingSurface.Image = pic;
            Graphics g = Graphics.FromImage(picDrawingSurface.Image);
            g.Clear(Color.White);
            g.DrawImage(picDrawingSurface.Image, 0, 0, 700, 352);

            History.Clear();
            historyCounter = 0;
            
            History.Add(new Bitmap(picDrawingSurface.Image));

            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                case DialogResult.No: break;
                case DialogResult.Yes: saveToolStripMenuItem_Click(sender, e); break;
                case DialogResult.Cancel: return;
            }
        }


    }

    private void picDrawingSurface_MouseDown(object sender, MouseEventArgs e)
        {
            if (picDrawingSurface.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
            }
           
                if (picDrawingSurface.Image == null)
                {
                    MessageBox.Show("Сначаласоздайтеновыйфайл!");
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    drawing = true;
                    oldLocation = e.Location;
                    currentPath = new GraphicsPath();
                }

            


        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "") //Если введено не пустое имя 
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "") //Если введено не пустое имя 
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image.Save(fs, ImageFormat.Png);
                        break;
                }
                fs.Close();
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;
            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);
            picDrawingSurface.AutoSize = true;


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap pic = new Bitmap(700, 352);
            picDrawingSurface.Image = pic;

            History.Clear();
            historyCounter = 0;

            History.Add(new Bitmap(picDrawingSurface.Image));

            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: saveToolStripMenuItem_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|BitmapImage|*.bmp|GIFImage|*.gif|PNGImage|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1;
            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);
            picDrawingSurface.AutoSize = true;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form2 snk = new Form2();
            snk.ShowDialog();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picDrawingSurface_MouseUp(object sender, MouseEventArgs e)
        {

            drawing = false;
            try
            {
                currentPath.Dispose();
            }
            catch { };
            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(picDrawingSurface.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                currentPath.Dispose();
            }
            catch { };
        }


    

    private void picDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            label_XY.Text = e.X.ToString() + ", " + e.Y.ToString();
            if (drawing)
            {
                Graphics g = Graphics.FromImage(picDrawingSurface.Image);
                currentPath.AddLine(oldLocation, e.Location);
                g.DrawPath(currentPen, currentPath);
                oldLocation = e.Location;
                g.Dispose();
                picDrawingSurface.Invalidate();
            }
           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trackBarPen.Value;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCounter != 0)
            {
                picDrawingSurface.Image = new Bitmap(History[--historyCounter]);
            }
            else MessageBox.Show("Историяпуста");
        }

        private void renoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1)
            {
                picDrawingSurface.Image = new Bitmap(History[++historyCounter]);
            }
            else MessageBox.Show("Историяпуста");

        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;
            solidStyleMenu.Checked = true;
            dotStyleMenu.Checked = false;
            dashDotDotStyleMenu.Checked = false;

        }

        private void picDrawingSurface_Click(object sender, EventArgs e)
        {
            
        }

        private void picDrawingSurface_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Right)
            {


                currentPen = new Pen(Color.White);



            }
        }

        private void picDrawingSurface_DoubleClick(object sender, EventArgs e)
        {
            if (MouseButtons == MouseButtons.Right)
            {

               



            }
        }
    }
}
