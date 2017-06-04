using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS_TransformacionImagen
{
    public partial class Form1 : Form
    {
        public Point origenCoordenadasImagen = Point.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image File|*.png";
            openFileDialog1.Title = "Select an Image File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                this.textBox1.Text = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                textBox2.Text = (string.Format("X: {0} Y: {1}", origenCoordenadasImagen.X, origenCoordenadasImagen.Y));
            }  

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* me complique mucho con este metodo asi que hice otro lol:
         *      private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
         * 
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {

                Point pointOnPicture = PointToClient(MousePosition);
                Point picturePointOnForm = pictureBox1.FindForm().PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
                pointOnPicture.Offset(-picturePointOnForm.X, -picturePointOnForm.Y); //offsets

                MessageBox.Show(string.Format("X: {0} Y: {1}",
                    pointOnPicture.X, pointOnPicture.Y));
                origenCoordenadasImagen = pointOnPicture; //guarda variable
                drawOrigenCoordenadasImagen(origenCoordenadasImagen);
            }
        }
         */

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                origenCoordenadasImagen = e.Location;
                textBox2.Text = (string.Format("X: {0} Y: {1}", e.X, e.Y));
                pictureBox1.Invalidate();
            }
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                    Pen p = new Pen(Color.Blue, 3);
                    e.Graphics.DrawLine(p,
                        Point.Add(origenCoordenadasImagen, new Size(0, -150)), Point.Add(origenCoordenadasImagen, new Size(0, 150)));
                    p.Color = Color.Red;
                    e.Graphics.DrawLine(p,
                        Point.Add(origenCoordenadasImagen, new Size(-150, 0)), Point.Add(origenCoordenadasImagen, new Size(150, 0)));
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
