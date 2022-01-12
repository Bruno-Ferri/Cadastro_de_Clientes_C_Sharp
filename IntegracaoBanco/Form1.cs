using IntegracaoBanco.Banco;
using IntegracaoBanco.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegracaoBanco
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            ClienteBanco cliBanco = new ClienteBanco();
            int gravou;

            cli.nome = txt_nome.Text;
            cli.email = txt_email.Text;
            cli.endereco = txt_endereco.Text;
            try
            {
                gravou = cliBanco.InserirCliente(cli);
                MessageBox.Show("Cliente cadastrado com sucesso", "Incluir Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente\n" + ex.Message, "Inserir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_pesquisa_Click(object sender, EventArgs e)
        {
            ClienteBanco cliBanco = new ClienteBanco();
            DataTable dadosClientes;

            dadosClientes = cliBanco.localizarPorCodigo(Convert.ToInt32(txt_codigo.Text));
            if (dadosClientes.Rows.Count > 0)
            {
                txt_nome.Text = dadosClientes.Rows[0][1].ToString();
                txt_endereco.Text = dadosClientes.Rows[0][2].ToString();
                txt_email.Text = dadosClientes.Rows[0][3].ToString();
            }
            else
            {
                MessageBox.Show("Cliente não localizado");
            }

        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            ClienteBanco cliBanco = new ClienteBanco();
            int gravou, codigo;
            cli.codigo = int.Parse(txt_codigo.Text);
            cli.nome = txt_nome.Text;
            cli.email = txt_email.Text;
            cli.endereco = txt_endereco.Text;
            try
            {
                gravou = cliBanco.atualizarCliente(cli);
                MessageBox.Show("Dados atualizados com sucesso", "Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente\n" + ex.Message, "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            ClienteBanco cliBanco = new ClienteBanco();
            int excluiu;
            cli.codigo = int.Parse(txt_codigo.Text);
            try
            {
                excluiu = cliBanco.excluirCliente(cli);
                MessageBox.Show("Cliente excluido com sucesso", "Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Falha ao cadastrar cliente\n" + ex.Message, "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
