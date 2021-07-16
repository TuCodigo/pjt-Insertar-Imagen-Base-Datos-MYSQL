using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjtImagenbaseDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvImagen.DataSource = clsConexiones.EjecutarQuery("select * from usuario", ptbImagen.Image);
            int cont = dgvImagen.RowCount;
            for (int i = 0; i < cont; i++)
            {
                dgvImagen.Rows[i].Height = 120;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsConexiones.EjecutarQuery("INSERT INTO `bd_imagen`.`usuario`(`Nombre`,`Imagen`)VALUES('" + txtNombre.Text + "',@Imagen)", ptbImagen.Image);

            dgvImagen.DataSource = clsConexiones.EjecutarQuery("select * from usuario", ptbImagen.Image);
            int cont = dgvImagen.RowCount;
            for (int i = 0; i < cont; i++)
            {
                dgvImagen.Rows[i].Height = 120;
            }

        }
        public OpenFileDialog examinar = new OpenFileDialog();
       
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            examinar.Filter = "image files|*.jpg; *.png;";
            DialogResult r = examinar.ShowDialog();
            if (r == DialogResult.Abort)
            {
                return;
            }
            if (r == DialogResult.Cancel)
            {
                return;
            }

            ptbImagen.Image = Image.FromFile(examinar.FileName);


        }


    }
}
