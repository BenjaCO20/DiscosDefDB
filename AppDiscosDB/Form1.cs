using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDiscosDB
{
    public partial class frmDiscos : Form
    {
        private List<Disco> listaDiscos;
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void pbDisco_Click(object sender, EventArgs e)
        {

        }

        private void cargarImagen(string imagen)
        {
            try
            {
               
                pbDisco.Load(imagen);

            }
            catch (Exception ex)
            {
                pbDisco.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9cSGzVkaZvJD5722MU5A-JJt_T5JMZzotcw&s");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            listaDiscos = negocio.listar();

            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagen"].Visible = false;
            cargarImagen(listaDiscos[0].UrlImagen);

        }

     

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
         
           Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
           cargarImagen(seleccionado.UrlImagen);
            
        } 
        private void dgvDiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
