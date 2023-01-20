using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class PokemonDatos
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try

            {


                conexion.ConnectionString = "server =.\\SQLEXPRESS;database=Pokedex_DB;integrated security=true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select P.Numero,P.Nombre,P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad,  P.IdTipo, P.IdDebilidad, P.Id  from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and D.Id = P.IdDebilidad and P.Activo = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())

                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Id = (int)lector["Id"];

                    // Validacion de columnas DBnull
                    
                    //if (!lector.IsDBNull(lector.GetOrdinal("UrlImagen")))
                    //aux.UrlImagen = (string)lector["UrlImagen"];

                    if (!(lector["UrlImagen"] is DBNull))
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    
                    //
                    
                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    lista.Add(aux);

                }
                conexion.Close();

                return lista;

            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.SetearComando("insert into POKEMONS (Numero,Nombre,Descripcion,Activo,idTipo,idDebilidad, UrlImagen) values (" + nuevo.Numero + ",'" + nuevo.Nombre + "','" + nuevo.Descripcion + "',1, @idTipo, @idDebilidad, @UrlImagen)");
                datos.SetearParametro("@idTipo", nuevo.Tipo.Id);
                datos.SetearParametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.SetearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();  
            }
        }

        public void Modificar(Pokemon modificar) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearComando("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, UrlImagen = @urlImagen, IdTipo = @idTipo , IdDebilidad = @idDebilidad where Id = @Id");
                
                datos.SetearParametro("@numero", modificar.Numero);                
                datos.SetearParametro("@nombre", modificar.Nombre);               
                datos.SetearParametro("@descripcion", modificar.Descripcion);                
                datos.SetearParametro("@urlImagen", modificar.UrlImagen);                
                datos.SetearParametro("@idTipo", modificar.Tipo.Id);  
                datos.SetearParametro("@idDebilidad", modificar.Debilidad.Id);
                datos.SetearParametro("@Id", modificar.Id);

                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

            public void Eliminar (int id)
        {
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.SetearComando("delete from POKEMONS where id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();

                datos.CerrarConexion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select P.Numero,P.Nombre,P.Descripcion, P.UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where P.IdTipo = E.Id and D.Id = P.IdDebilidad and P.Activo = 1 and ";

                switch (campo)

                {
                    case "Numero":

                       
                            switch (criterio)
                            {

                                case "Mayor a":
                                    consulta += "Numero > " + filtro;
                                    break;
                                case "Menor a":
                                    consulta += "Numero < " + filtro;
                                    break;

                                default:
                                    consulta += "Numero == " + filtro;
                                    break;
                            }
                            break;
                      
                    case "Nombre":
                        
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";

                                break;

                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "P.Descripcion like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "P.Descripcion like '%" + filtro + "'";

                                break;

                            default:
                                consulta += "P.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                }
                datos.SetearComando(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read())

                {
                    Pokemon aux = new Pokemon();
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Id = (int)datos.Lector["Id"];



                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];


                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    lista.Add(aux);
                }
            }


            catch (Exception ex)
            {

                throw ex;
            }
            return lista;
        }

        public void EliminarLogico(int id)
        {
               AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.SetearComando("update POKEMONS set Activo = 0 where id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }  
}
