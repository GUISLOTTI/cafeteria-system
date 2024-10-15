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
            _produtoService = new ProdutoService(context);
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            btnAdicionarCliente.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(txtNomeCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefoneCliente.Text) ||
                    string.IsNullOrWhiteSpace(txtSaldoDevedor.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos.");
                    return;
                }

                var cliente = new Cliente
                {
                    Nome = txtNomeCliente.Text,
                    Telefone = txtTelefoneCliente.Text,
                    SaldoDevedor = decimal.Parse(txtSaldoDevedor.Text)
                };

                _clienteService.AdicionarCliente(cliente);
                MessageBox.Show("Cliente adicionado com sucesso!");

                txtNomeCliente.Clear();
                txtTelefoneCliente.Clear();
                txtSaldoDevedor.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira um valor numérico válido no saldo devedor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar cliente: {ex.Message}");
            }
            finally
            {
                btnAdicionarCliente.Enabled = true;
            }
        }

            private void btnRegistrarVenda_Click(object sender, EventArgs e)
        {
            btnRegistrarVenda.Enabled = false;
            
            try
            {
                var produtoId = int.Parse(txtProdutoId.Text);
                var quantidade = int.Parse(txtQuantidade.Text);
                var clienteId = int.Parse(txtClienteId.Text);

                if (string.IsNullOrWhiteSpace(txtProdutoId.Text) || string.IsNullOrWhiteSpace(txtQuantidade.Text) ||
                    string.IsNullOrWhiteSpace(txtClienteId.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos necessários.");
                    return;
                }

                if (quantidade <= 0)
                {
                    MessageBox.Show("A quantidade deve ser maior que zero.");
                    return;
                }

                if (_estoqueService.VerificarDisponibilidadeDeEstoque(produtoId, quantidade))
                {
                    var venda = new Venda
                    {
                        ProdutoVendido = _produtoService.ObterProdutoPorId(produtoId),
                        Cliente = _clienteService.ObterClientePorId(clienteId),
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
            catch (FormatException)
            {
                MessageBox.Show("Por favor, insira números válidos nos campos de ID e Quantidade.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar venda: {ex.Message}");
            }
            finally
            {
                btnRegistrarVenda.Enabled = true;
            }
        }
    }
}



