using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


 namespace DLL 
{
    public class CD_NEmpleado : ConnectionToSql
    {

        /****************************************
                 MEDTODO INSERTAR PRODUCTOS
        *****************************************/
        public void cd_Nempleado(
            string no_cedula,
            string nombres,
            string apellidos,
            string direccion,
            int  telf1,
            int  telf2,
            DateTime fecha_nacimiento,
            string correo
            //int genero,
            //int estado,

            )
        {
            using (var connection = getc )
            {
                connection.Open();

                using (var command= new SqlCommand())
                {

                }
            }
        }
    }
}
