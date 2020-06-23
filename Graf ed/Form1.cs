using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Runtime.InteropServices;

namespace Graf_ed
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Bitmap pic1;
        string mode;
        int x1, y1;
        int xclick, yclick;
        Item currItem;

        public enum Item
        {
            Text
        }
        public Form1()
        {
            mode = "Line";
            InitializeComponent();
            pic = new Bitmap(1000, 1000);
            pic1 = new Bitmap(1000, 1000);
            SolidBrush b = new SolidBrush(Color.White);
            Graphics.FromImage(pic).FillRectangle(b, 0, 0, pic.Width, pic.Height);
            Graphics.FromImage(pic1).FillRectangle(b, 0, 0, pic1.Width, pic1.Height);
            x1 = y1 = 0;
            pictureBox1.Image = pic;
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            //if (saveFileDialog1.FileName != "")
            //pic.Save(saveFileDialog1.FileName);
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle rect = pictureBox1.RectangleToScreen(pictureBox1.ClientRectangle);
            g.CopyFromScreen(rect.Location, Point.Empty, pictureBox1.Size);
            g.Dispose();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Png files|*.png|jpeg files |jpg|bitmaps|*.bmp";
            if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(s.FileName))
                {
                    File.Delete(s.FileName);
                }
                if (s.FileName.Contains(".jpg"))
                {
                    bmp.Save(s.FileName, ImageFormat.Jpeg);
                }
                else if (s.FileName.Contains(".png"))
                {
                    bmp.Save(s.FileName, ImageFormat.Png);
                }
                else if (s.FileName.Contains(".bmp"))
                {
                    bmp.Save(s.FileName, ImageFormat.Bmp);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button1.BackColor = b.BackColor;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = "Line";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mode = "Rectangle";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mode = "Oval";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button1.BackColor, trackBar1.Value);

            Graphics g;
            g = Graphics.FromImage(pic);
            if (mode == "Rectangle")
            {
                
                g.DrawRectangle(p, xclick, yclick, e.X - xclick, e.Y - yclick);
            }
            if (mode == "Oval")
            {

                g.DrawEllipse(p, xclick, yclick, e.X - xclick, e.Y - yclick);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        public class Coordinates
        {
            public double Add(double num1, double num2)
            {
                return num1 + num2;
            }
            public double Substract(double num1, double num2)
            {
                return num1 - num2;
            }
            public double divide(double num1, double num2)
            {
                return num1 / num2;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            currItem = Item.Text;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if(currItem == Item.Text) { 
            if(toolStripComboBox4.Text == "Regular")
            {
                g.DrawString(toolStripComboBox1.Text, new Font(toolStripComboBox2.Text, Convert.ToInt32(toolStripComboBox3.Text), FontStyle.Regular), new SolidBrush(button1.BackColor), new PointF(x1, y1));
            }
            else if (toolStripComboBox4.Text == "Bold")
            {
                g.DrawString(toolStripComboBox1.Text, new Font(toolStripComboBox2.Text, Convert.ToInt32(toolStripComboBox3.Text), FontStyle.Bold), new SolidBrush(button1.BackColor), new PointF(x1, y1));
            }
            else if (toolStripComboBox4.Text == "Underline")
            {
                g.DrawString(toolStripComboBox1.Text, new Font(toolStripComboBox2.Text, Convert.ToInt32(toolStripComboBox3.Text), FontStyle.Underline), new SolidBrush(button1.BackColor), new PointF(x1, y1));
            }
            else if (toolStripComboBox4.Text == "Strikeout")
            {
                g.DrawString(toolStripComboBox1.Text, new Font(toolStripComboBox2.Text, Convert.ToInt32(toolStripComboBox3.Text), FontStyle.Strikeout), new SolidBrush(button1.BackColor), new PointF(x1, y1));
            }
            else if (toolStripComboBox4.Text == "Italic")
            {
                g.DrawString(toolStripComboBox1.Text, new Font(toolStripComboBox2.Text, Convert.ToInt32(toolStripComboBox3.Text), FontStyle.Italic), new SolidBrush(button1.BackColor), new PointF(x1, y1));
            }
            }
            g.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox4.Items.Add("Regular");
            toolStripComboBox4.Items.Add("Bold");
            toolStripComboBox4.Items.Add("Underline");
            toolStripComboBox4.Items.Add("Strikeout");
            toolStripComboBox4.Items.Add("Italic");
            FontFamily[] family = FontFamily.Families; 
            foreach(FontFamily font in family)
            {
                toolStripComboBox2.Items.Add(font.GetName(1).ToString());
            }
        }

        private void toolStripComboBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xclick = e.X;
            yclick = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button1.BackColor,trackBar1.Value);

            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);

            Graphics g1;
            g1 = Graphics.FromImage(pic1);

            if(e.Button == MouseButtons.Left)
            {
                if(mode == "Line") { 
                g.DrawLine(p, x1, y1, e.X, e.Y);
                }

                if(mode == "Rectangle")
                {
                    g1.Clear(Color.White);
                    int x, y;
                    x = xclick;
                    y = yclick;
                    if (x > e.X) x = e.X;
                    if (y > e.Y) y = e.Y;
                    g1.DrawRectangle(p, x, y, Math.Abs(e.X - xclick), Math.Abs(e.Y - yclick));
                }
                if (mode == "Oval")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick, yclick, e.X - xclick, e.Y - yclick);
                }
                g1.DrawImage(pic, 0, 0);

                pictureBox1.Image = pic1;

            }
            x1 = e.X;
            y1 = e.Y;

           
        }
    }
}
