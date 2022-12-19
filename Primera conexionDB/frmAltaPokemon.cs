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
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null;
        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            PokemonDatos negocio = new PokemonDatos();

            try
            {
                if (pokemon == null)
                    
                    pokemon = new Pokemon();
               
                pokemon.Numero = int.Parse(txtnumero.Text);
                pokemon.Nombre = txtnombre.Text;
                pokemon.Descripcion = txtdescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;
                
                if( pokemon.Id != 0)
                {
                    negocio.Modificar(pokemon);
                    MessageBox.Show("Modificado Correctamente");


                }
                else
                {
                    negocio.Agregar(pokemon);
                    MessageBox.Show("Agregado Correctamente");

                }
                

                
               



                Close();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoDatos elementoDatos = new ElementoDatos();
            
            try
            {
                cboTipo.DataSource = elementoDatos.listar();
                // Identificar con CLAVE-VALOR para precargar los combobox desplegables
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoDatos.listar();
                // Identificar con CLAVE-VALOR para precargar los combobox desplegables
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";

                if(pokemon != null)
                {
                    txtnumero.Text = pokemon.Numero.ToString();
                    txtnombre.Text = pokemon.Nombre;
                    txtdescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.Id;
                    
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxNuevopokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxNuevopokemon.Load("https://thumbs.dreamstime.com/b/sin-foto-ni-icono-de-imagen-en-blanco-cargar-im%C3%A1genes-o-falta-marca-no-disponible-pr%C3%B3xima-se%C3%B1al-silueta-naturaleza-simple-marco-215973362.jpg");

            }
        }
    }
}
