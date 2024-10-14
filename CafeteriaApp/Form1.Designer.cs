namespace CafeteriaApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAdicionarCliente;
        private System.Windows.Forms.Button btnRegistrarVenda;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtTelefoneCliente;
        private System.Windows.Forms.TextBox txtSaldoDevedor;
        private System.Windows.Forms.TextBox txtProdutoId;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtClienteId;

        private void InitializeComponent()
        {
            this.btnAdicionarCliente = new System.Windows.Forms.Button();
            this.btnRegistrarVenda = new System.Windows.Forms.Button();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtTelefoneCliente = new System.Windows.Forms.TextBox();
            this.txtSaldoDevedor = new System.Windows.Forms.TextBox();
            this.txtProdutoId = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            
            
            this.btnAdicionarCliente.Location = new System.Drawing.Point(100, 200);
            this.btnAdicionarCliente.Name = "btnAdicionarCliente";
            this.btnAdicionarCliente.Size = new System.Drawing.Size(150, 23);
            this.btnAdicionarCliente.TabIndex = 0;
            this.btnAdicionarCliente.Text = "Adicionar Cliente";
            this.btnAdicionarCliente.UseVisualStyleBackColor = true;
            this.btnAdicionarCliente.Click += new System.EventHandler(this.btnAdicionarCliente_Click);
            
       
            this.btnRegistrarVenda.Location = new System.Drawing.Point(100, 300);
            this.btnRegistrarVenda.Name = "btnRegistrarVenda";
            this.btnRegistrarVenda.Size = new System.Drawing.Size(150, 23);
            this.btnRegistrarVenda.TabIndex = 1;
            this.btnRegistrarVenda.Text = "Registrar Venda";
            this.btnRegistrarVenda.UseVisualStyleBackColor = true;
            this.btnRegistrarVenda.Click += new System.EventHandler(this.btnRegistrarVenda_Click);
            
      
            this.txtNomeCliente.Location = new System.Drawing.Point(100, 50);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(150, 20);
            this.txtNomeCliente.TabIndex = 2;
            this.txtNomeCliente.PlaceholderText = "Nome do Cliente";
            
      
            this.txtTelefoneCliente.Location = new System.Drawing.Point(100, 80);
            this.txtTelefoneCliente.Name = "txtTelefoneCliente";
            this.txtTelefoneCliente.Size = new System.Drawing.Size(150, 20);
            this.txtTelefoneCliente.TabIndex = 3;
            this.txtTelefoneCliente.PlaceholderText = "Telefone do Cliente";
            

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
