using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace IntegracaoBanco
{
    public class Conexao
    {
        string strCon;
        SqlConnection con;

        public Conexao()
        {
            strCon = "Data Source=WINAPS80NHHTZTG\\SQLEXPRESS;" +
                    "Initial Catalog=conexao;" + //Banco que será conectado
                    "Integrated Security=True; Encrypt=False";

        }

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(strCon);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao conectar o banco\n" + ex.Message);
            }
            return con;
        }

    }


}
