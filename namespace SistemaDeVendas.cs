namespace SistemaDeVendas
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> usuarios = new Dictionary<string, string>();
        private List<Produto> produtos = new List<Produto>();
        private List<ItemVenda> itensVenda = new List<ItemVenda>();
        private double totalVenda = 0;

        public MainForm()
        {
            InitializeComponent();

            // Adicione alguns dados de exemplo
            usuarios.Add("usuario", "senha");

            produtos.Add(new Produto("Produto1", 10.0));
            produtos.Add(new Produto("Produto2", 15.0));
            produtos.Add(new Produto("Produto3", 20.0));
            produtos.Add(new Produto("Produto4", 25.0));
            produtos.Add(new Produto("Produto5", 30.0));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (usuarios.ContainsKey(usuario) && usuarios[usuario] == senha)
            {
                HabilitarControles(true);
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para cadastrar um novo usuário
            // Você pode abrir um novo formulário para isso
        }

        private void btnSelecionarProduto_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para selecionar produtos
            // Pode ser outro formulário, um DataGridView, ListBox, etc.
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para finalizar a compra
            // Pode ser outro formulário ou uma mensagem com os detalhes da compra
            MostrarRelatorio();
        }

        private void MostrarRelatorio()
        {
            // Implemente a lógica para mostrar o relatório da compra
            // Pode ser outro formulário ou uma mensagem com os detalhes da compra
            string relatorio = "Relatório da Compra:\n";

            foreach (var item in itensVenda)
            {
                relatorio += $"{item.Produto.Nome} - Quantidade: {item.Quantidade} - Subtotal: R${item.Subtotal:F2}\n";
            }

            relatorio += $"\nTotal da Compra: R${totalVenda:F2}";

            MessageBox.Show(relatorio, "Relatório de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HabilitarControles(bool habilitar)
        {
            btnCadastrar.Enabled = habilitar;
            btnSelecionarProduto.Enabled = habilitar;
            btnFinalizarCompra.Enabled = habilitar;
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"{Nome} - R${Preco:F2}";
        }
    }

    public class ItemVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public double Subtotal => Produto.Preco * Quantidade;
    }
}
