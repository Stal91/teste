using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProvaA1
{
    public partial class Form1 : Form
    {
        private List<Produto> produtos = new List<Produto>();
        private List<ItemVenda> itensVenda = new List<ItemVenda>();
        private double totalVenda = 0;

        private ListBox lstProdutos;
        private ListBox lstItensVenda;
        private Label lblTotalVenda;
        private Button btnAdicionarProduto;
        private Button btnFinalizarCompra;

        public Form1()
        {
            InitializeComponent();

            produtos.Add(new Produto("Produto1", 10.0));
            produtos.Add(new Produto("Produto2", 15.0));
            produtos.Add(new Produto("Produto3", 20.0));
            produtos.Add(new Produto("Produto4", 25.0));
            produtos.Add(new Produto("Produto5", 30.0));

            // Interface do Usuário
            lstProdutos = new ListBox();
            lstProdutos.Size = new System.Drawing.Size(200, 120);
            lstProdutos.Location = new System.Drawing.Point(10, 10);

            // Adicione os produtos à ListBox lstProdutos
            foreach (var produto in produtos)
            {
                lstProdutos.Items.Add(produto.Nome); // Adiciona apenas o nome do produto
            }

            lstItensVenda = new ListBox();
            lstItensVenda.Size = new System.Drawing.Size(200, 120);
            lstItensVenda.Location = new System.Drawing.Point(250, 10);

            lblTotalVenda = new Label();
            lblTotalVenda.Text = "Total da Venda: R$0.00";
            lblTotalVenda.Location = new System.Drawing.Point(10, 150);

            btnAdicionarProduto = new Button();
            btnAdicionarProduto.Text = "Adicionar Produto";
            btnAdicionarProduto.Location = new System.Drawing.Point(250, 150);
            btnAdicionarProduto.Click += btnAdicionarProduto_Click;

            btnFinalizarCompra = new Button();
            btnFinalizarCompra.Text = "Finalizar Compra";
            btnFinalizarCompra.Location = new System.Drawing.Point(350, 150);
            btnFinalizarCompra.Click += btnFinalizarCompra_Click;

            this.Controls.Add(lstProdutos);
            this.Controls.Add(lstItensVenda);
            this.Controls.Add(lblTotalVenda);
            this.Controls.Add(btnAdicionarProduto);
            this.Controls.Add(btnFinalizarCompra);
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (lstProdutos.SelectedIndex != -1)
            {
                Produto produtoSelecionado = produtos[lstProdutos.SelectedIndex];
                int quantidade = SolicitarQuantidade(produtoSelecionado.Nome);

                AdicionarItemVenda(produtoSelecionado, quantidade);
                AtualizarExibicaoVenda();
            }
            else
            {
                MessageBox.Show("Selecione um produto para adicionar à venda.");
            }
        }

        private int SolicitarQuantidade(string nomeProduto)
        {
            // Implemente a lógica para solicitar a quantidade desejada
            // Aqui você pode usar um InputBox personalizado ou outro método para obter a quantidade
            return 1;
        }

        private void AdicionarItemVenda(Produto produto, int quantidade)
        {
            itensVenda.Add(new ItemVenda { Produto = produto, Quantidade = quantidade });
            totalVenda += produto.Preco * quantidade;
        }

        private void AtualizarExibicaoVenda()
        {
            lstItensVenda.Items.Clear();
            foreach (var item in itensVenda)
            {
                lstItensVenda.Items.Add($"{item.Produto.Nome} - Quantidade: {item.Quantidade} - Subtotal: R${item.Subtotal:F2}");
            }

            lblTotalVenda.Text = $"Total da Venda: R${totalVenda:F2}";
        }

        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            // Implemente a lógica para escolher o método de pagamento e finalizar a compra
            MessageBox.Show($"Compra finalizada! Total: R${totalVenda:F2}", "Compra Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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