using CafeteriaApp.Domain;
using CafeteriaApp.Services;

namespace CafeteriaApp
{
    public partial class Form1 : Form
    {
        private readonly ClienteService _clienteService;
        private readonly EstoqueService _estoqueService;
        private readonly VendaService _vendaService;
        private readonly ProdutoService _produtoService;

        public Form1()
        {
            InitializeComponent();
            var context = new AppDbContext();
            _clienteService = new ClienteService(context);
            _estoqueService = new EstoqueService(context);
            _vendaService = new VendaService(context);
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nome = txtNomeCliente.Text,
                    Telefone = txtTelefoneCliente.Text,
                    SaldoDevedor = decimal.Parse(txtSaldoDevedor.Text)
                };

                _clienteService.AdicionarCliente(cliente);
                MessageBox.Show("Cliente adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}");
            }
        }

        private void btnRegistrarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                var produtoId = int.Parse(txtProdutoId.Text);
                var quantidade = int.Parse(txtQuantidade.Text);

                if (_estoqueService.VerificarDisponibilidadeDeEstoque(produtoId, quantidade))
                {
                    var venda = new Venda // depois tenho que revisar essa parte pra fixar esse erro.
                    {
                        ProdutoVendido = _estoqueService.ObterProdutosPorId(produtoId),
                        Cliente = _clienteService.ObterTodosClientes(int.Parse(txtClienteId.Text)),
                        Quantidade = quantidade,
                        DataVenda = DateTime.Now
                    };

                    _vendaService.RegistrarVenda(venda);
                    MessageBox.Show("Venda registrada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Estoque insuficiente!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar Venda: {ex.Message}");
            }
        }
    }
}



