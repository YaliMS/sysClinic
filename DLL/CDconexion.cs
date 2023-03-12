using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DLL
{ 
        public class CDconexion
        {

            private SqlConnection Conexion = new SqlConnection("server=(local);database=sysClinic;integrated security=tru");

                public SqlConnection AbrirConexion()
                {
                    if (Conexion.State == ConnectionState.Closed)
                        Conexion.Open();
                    return Conexion;
                }

            public SqlConnection CerrarConexion()
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
                return Conexion;
            }



        }
}
