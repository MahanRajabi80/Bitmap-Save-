using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_17_17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------
        Bitmap NullPicture;
        //------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            Graphics gr=lblPicAll.CreateGraphics();
            NullPicture = new Bitmap(lblPicAll.Width, lblPicAll.Height, gr);
            lblPicAll.Image = NullPicture;
        }
        //------------------------------------------------------------------------
        private void pictureBoxSmall_MouseDown(object sender, MouseEventArgs e)
        {
            //har kodam az tasavir kochak
            PictureBox pic = (PictureBox)sender;
            DoDragDrop(pic.Image, DragDropEffects.Copy);
        }
        //------------------------------------------------------------------------
        private void lblPicAll_DragDrop(object sender, DragEventArgs e)
        {
            //tasvir asli
            int x, y;
            x = e.X - this.Left - lblPicAll.Left;
            y = e.Y - this.Top - lblPicAll.Top - 32;
            Bitmap pic_in = (Bitmap)e.Data.GetData(typeof(Bitmap));
            Bitmap bmplabel = new Bitmap(lblPicAll.Image, lblPicAll.Width, lblPicAll.Height);
            Graphics gr = Graphics.FromImage(bmplabel);
            //vaghti b gerefte mishe ro graphice tasvir kar mishe , bad mishe tasviro zakhire kard
            gr.DrawImage(pic_in, x, y, pictureBox1.Width, pictureBox1.Height);
            lblPicAll.Image = bmplabel;
        }
        //------------------------------------------------------------------------
        private void lblPicAll_DragEnter(object sender, DragEventArgs e)
        {
            //tasvir asli
            if (e.Data.GetDataPresent(typeof(Bitmap)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        //------------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear
            lblPicAll.Image = NullPicture;
        }
        //------------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            //save
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Files (*.jpg)|*.jpg|Bitmap Files (*.bmp)|*.bmp";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "" && lblPicAll.Image!=null)
            {
                lblPicAll.Image.Save(saveFileDialog1.FileName);
                MessageBox.Show("Data is Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        
    }
}
