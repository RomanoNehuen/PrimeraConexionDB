using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Primera_conexionDB
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listapokemon;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
            
            
        }
       
        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPokemon.CurrentRow != null)
            {
            Pokemon seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);

            }
        }

        //para agregar automanticamente un nuevo pokemon
        private void cargarImagen (string imagen)
        {
            try
            {
                pbx.Load(imagen);
            }
            catch (Exception ex)
            {
                pbx.Load("https://thumbs.dreamstime.com/b/sin-foto-ni-icono-de-imagen-en-blanco-cargar-im%C3%A1genes-o-falta-marca-no-disponible-pr%C3%B3xima-se%C3%B1al-silueta-naturaleza-simple-marco-215973362.jpg");
                
            }
        }
        private void Cargar()
        {
            try
            {
                PokemonDatos datos = new PokemonDatos();
                listapokemon = datos.listar();
                dgvPokemon.DataSource = listapokemon;
               //Para ocultar una columna 
                dgvPokemon.Columns["UrlImagen"].Visible = false;
                dgvPokemon.Columns["Id"].Visible = false;
               //
                cargarImagen(listapokemon[0].UrlImagen);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            //Para que agregue automaticamente el nuevo pokemon
            Cargar();
        }

        //modificar pokemon
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon Seleccionado;

            Seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
           
            frmAltaPokemon modificar = new frmAltaPokemon(Seleccionado);
            modificar.ShowDialog();
    
            Cargar();

        }

        private void btnEliminacionFisica_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminacionLogica_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            PokemonDatos datos = new PokemonDatos();
            Pokemon eliminado;
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el pokemon?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {

                    eliminado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
                    
                    if (logico)
                         datos.EliminarLogico(eliminado.Id);
                    else
                        datos.Eliminar(eliminado.Id);
                    
                    Cargar();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumunas()
        {
            dgvPokemon.Columns["UrlImagen"].Visible = false;
            dgvPokemon.Columns["Id"].Visible = false;
        }
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;
            
            string filtro = txtfiltro.Text;
            
            if(filtro != "")
            {
                listaFiltrada = listapokemon.FindAll(x => x.Nombre.ToUpper().Contains (filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listaFiltrada = listapokemon;
            }

            dgvPokemon.DataSource = null;
            dgvPokemon.DataSource = listaFiltrada;
            ocultarColumunas();


        }
    }

}
