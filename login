using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginCadastroApp
{
    public partial class FormLoginCadastro : Form
    {
        private Dictionary<string, string> usuariosCadastrados = new Dictionary<string, string>();

        public FormLoginCadastro()
        {
            InitializeComponent();
            InicializarUsuariosCadastrados();
        }

        private void InicializarUsuariosCadastrados()
        {
            // Adicione alguns usuários iniciais (normalmente você usaria um banco de dados)
            usuariosCadastrados.Add("admin", "senha123");
            usuariosCadastrados.Add("usuario1", "senha456");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (AutenticarUsuario(usuario, senha))
            {
                MessageBox.Show("Login bem-sucedido!");
                // Aqui você pode abrir a próxima tela ou realizar outras ações após o login
            }
            else
            {
                MessageBox.Show("Nome de usuário ou senha incorretos. Tente novamente.");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string usuario = txtNovoUsuario.Text;
            string senha = txtNovaSenha.Text;

            if (!usuariosCadastrados.ContainsKey(usuario))
            {
                usuariosCadastrados.Add(usuario, senha);
                LimparCamposCadastro();
                MessageBox.Show("Cadastro bem-sucedido! Agora você pode fazer login.");
            }
            else
            {
                MessageBox.Show("O nome de usuário já está em uso. Escolha outro nome de usuário.");
            }
        }

        private bool AutenticarUsuario(string usuario, string senha)
        {
            return usuariosCadastrados.ContainsKey(usuario) && usuariosCadastrados[usuario] == senha;
        }

        private void LimparCamposCadastro()
        {
            txtNovoUsuario.Clear();
            txtNovaSenha.Clear();
        }
    }
}
