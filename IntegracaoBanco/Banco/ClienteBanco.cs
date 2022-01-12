using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using IntegracaoBanco.Negocios;
using System.Data;

namespace IntegracaoBanco.Banco
{
    class ClienteBanco
    {

        public ClienteBanco()
        {
        }

        public int InserirCliente(Cliente cli)
        {
            int gravou;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexaoBanco = new SqlConnection();
            Conexao dadosConexao = new Conexao();

            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "inserirClientes"; //nome da store procedure

            comando.Parameters.AddWithValue("@nome", cli.nome);
            comando.Parameters.AddWithValue("@endereco", cli.endereco);
            comando.Parameters.AddWithValue("@email", cli.email);
            dadosConexao = new Conexao();

            conexaoBanco = dadosConexao.GetConnection();

            comando.Connection = conexaoBanco;

            try
            {
                gravou = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível cadastrar novo cliente\n" + ex.Message);
            }
            finally
            {
                conexaoBanco.Close();
            }

            return gravou;
        }

        public DataTable localizarPorCodigo(int codigo)
        {
            DataTable dadosClientes = new DataTable();
            SqlDataAdapter adptClientes;


            Conexao dadosConexao = new Conexao();
            SqlConnection conexaoBanco = new SqlConnection();
            conexaoBanco = dadosConexao.GetConnection();

            adptClientes = new SqlDataAdapter("clientePorCodigo", conexaoBanco);
            adptClientes.SelectCommand.CommandType = CommandType.StoredProcedure;
            adptClientes.SelectCommand.Parameters.AddWithValue("@id", codigo);
            try
            {
                adptClientes.Fill(dadosClientes);
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao localizar cliente!\n" + ex.Message);
            }
            return dadosClientes;
        }

        public int atualizarCliente(Cliente cli)
        {
            int gravou;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexaoBanco = new SqlConnection();
            Conexao dadosConexao = new Conexao();
            comando.CommandType = CommandType.StoredProcedure;

            comando.CommandText = "alterarClientes"; //nome da store procedure
            comando.Parameters.AddWithValue("@id",  cli.codigo);
            comando.Parameters.AddWithValue("@nome", cli.nome);
            comando.Parameters.AddWithValue("@endereco", cli.endereco);
            comando.Parameters.AddWithValue("@email", cli.email);
            dadosConexao = new Conexao();

            conexaoBanco = dadosConexao.GetConnection();

            comando.Connection = conexaoBanco;

            try
            {
                gravou = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o cliente\n" + ex.Message);
            }
            finally
            {
                conexaoBanco.Close();
            }

            return gravou;
        }
        public int excluirCliente(Cliente cli)
        {
            
                int excluiu;
                SqlCommand comando = new SqlCommand();
                SqlConnection conexaoBanco = new SqlConnection();
                Conexao dadosConexao = new Conexao();
                comando.CommandType = CommandType.StoredProcedure;

                comando.CommandText = "ExcluirClientes"; //nome da store procedure
                comando.Parameters.AddWithValue("@id", cli.codigo);
                dadosConexao = new Conexao();

                conexaoBanco = dadosConexao.GetConnection();

                comando.Connection = conexaoBanco;

                try
                {
                    excluiu = comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possível excluir o cliente\n" + ex.Message);
                }
                finally
                {
                    conexaoBanco.Close();
                }

                return excluiu;
         }
    }
}
