using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        string pathDeImagenTransformada = Directory.GetCurrentDirectory() + @"\temp.png";


        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor seleccionar una imagen primero.");
            }
            else
            {   
                if (validarMatriz())
                {
                    try
                    {
                        int[] matriz = new int[] { Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text),
                            Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text) };
                        string path = textBox1.Text;
                        Bitmap bmp = Logica.Diff(@path,origenCoordenadasImagen.X,origenCoordenadasImagen.Y,matriz);
                        pictureBox2.Image = bmp;
                        //bmp.Save("temp.bmp");
                            
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("Se ha dado un error al tratar de transformar la imagen.\n" + e2.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Por favor llenar la matriz de transformación con números enteros.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Por favor seleccionar una imagen primero.");
            }
            else
            {
                if (validarMatriz())
                {
                    try
                    {
                        MessageBox.Show("No se ha implementado la transformacion con interpolación.");

                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("Se ha dado un error al tratar de transformar la imagen.\n" + e2.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Por favor llenar la matriz de transformación con números enteros.");
                }
            }
        }

        private bool validarMatriz()
        {
            bool valor = true;
            List<TextBox> C = new List<TextBox>();
            C.Add(textBox4);
            C.Add(textBox5);
            C.Add(textBox6);
            C.Add(textBox7);
            foreach (TextBox t in C)
            {
                if (!validarNumEntero(t.Text))
                    valor = false;
            }
            return valor;
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
         *    -->  private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
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

        private bool validarNumEntero(string s)
        {
            string pattern = @"^\d+$";
                if(Regex.IsMatch(s,pattern))
                    return true;
                return false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private Color invalido = Color.Pink;
        private Color valido = Color.White;

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (!validarNumEntero(textBox4.Text))
            {
                textBox4.BackColor = invalido;
            }
            else 
            {
                textBox4.BackColor = valido;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (!validarNumEntero(textBox5.Text))
            {
                textBox5.BackColor = invalido;
            }
            else 
            {
                textBox5.BackColor = valido;
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (!validarNumEntero(textBox6.Text))
            {
                textBox6.BackColor = invalido;
            }
            else 
            {
                textBox6.BackColor = valido;
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (!validarNumEntero(textBox7.Text))
            {
                textBox7.BackColor = invalido;
            }
            else
            {
                textBox7.BackColor = valido;
            }
        }



    }
}
