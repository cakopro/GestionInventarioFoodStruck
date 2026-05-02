using GestionInventarioFoodStruck.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionInventarioFoodStruck.Dao
{
    public class InsumosDao
    {
        public List<Insumos> traerTodo()
        {
            List<Insumos> lista = new List<Insumos>();
            Conexion instancia = Conexion.getInstance();
            SqlConnection conectarse = instancia.Conectarse();
            try
            {
                string query = "SELECT * FROM Insumos";
                SqlCommand comando = new SqlCommand(query, conectarse);

                conectarse.Open();
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Insumos insumo = new Insumos();
                    insumo.Id = int.Parse(reader["Id"].ToString());
                    insumo.Nombre1 = (reader["Nombre"].ToString());
                    insumo.StockActual1 = float.Parse(reader["StockActual"].ToString());
                    insumo.UnidadMedida1 = reader["UnidadMedida"].ToString();
                    insumo.PrecioUnitario1 = float.Parse(reader["PrecioUnitario"].ToString());
                    insumo.FechaCaducidad1 = DateTime.Parse(reader["FechaCaducidad"].ToString());
                    insumo.Id_Proveedor1 = int.Parse(reader["Id_Proveedor"].ToString());

                    lista.Add(insumo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error:{e.Message}");
            }
            finally { conectarse.Close(); }
            return lista;
        }
    

    }
}
