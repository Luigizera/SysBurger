﻿
namespace SysBurger
{
    partial class frm_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Principal));
            this.sttstrip_Principal = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Data = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Separador_Data_Hora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Hora = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Separador_Hora_Criador = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Separador_Criador_Resolucao = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Resolucao = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Separador_Resolucao_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Usuario_Logado = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnstrip_Principal = new System.Windows.Forms.MenuStrip();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredienteDoProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tm_Principal = new System.Windows.Forms.Timer(this.components);
            this.btn_Sair = new System.Windows.Forms.Button();
            this.btn_Ingrediente_Produto = new System.Windows.Forms.Button();
            this.btn_Pedido = new System.Windows.Forms.Button();
            this.btn_Produtos = new System.Windows.Forms.Button();
            this.btn_Ingrediente = new System.Windows.Forms.Button();
            this.btn_Pessoa = new System.Windows.Forms.Button();
            this.btn_Usuario = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sttstrip_Principal.SuspendLayout();
            this.mnstrip_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sttstrip_Principal
            // 
            this.sttstrip_Principal.BackColor = System.Drawing.Color.SteelBlue;
            this.sttstrip_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslb_Data,
            this.tssl_Separador_Data_Hora,
            this.toolStripStatusLabel4,
            this.tsslb_Hora,
            this.tssl_Separador_Hora_Criador,
            this.toolStripStatusLabel5,
            this.tssl_Separador_Criador_Resolucao,
            this.toolStripStatusLabel7,
            this.tsslb_Resolucao,
            this.tssl_Separador_Resolucao_Usuario,
            this.toolStripStatusLabel2,
            this.tssl_Usuario_Logado});
            this.sttstrip_Principal.Location = new System.Drawing.Point(0, 428);
            this.sttstrip_Principal.Name = "sttstrip_Principal";
            this.sttstrip_Principal.Size = new System.Drawing.Size(1924, 22);
            this.sttstrip_Principal.TabIndex = 0;
            this.sttstrip_Principal.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "Data:";
            // 
            // tsslb_Data
            // 
            this.tsslb_Data.ForeColor = System.Drawing.Color.Khaki;
            this.tsslb_Data.Name = "tsslb_Data";
            this.tsslb_Data.Size = new System.Drawing.Size(73, 17);
            this.tsslb_Data.Text = "99/99/9999";
            // 
            // tssl_Separador_Data_Hora
            // 
            this.tssl_Separador_Data_Hora.AutoSize = false;
            this.tssl_Separador_Data_Hora.Name = "tssl_Separador_Data_Hora";
            this.tssl_Separador_Data_Hora.Size = new System.Drawing.Size(118, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel4.Text = "Hora:";
            // 
            // tsslb_Hora
            // 
            this.tsslb_Hora.ForeColor = System.Drawing.Color.Khaki;
            this.tsslb_Hora.Name = "tsslb_Hora";
            this.tsslb_Hora.Size = new System.Drawing.Size(55, 17);
            this.tsslb_Hora.Text = "99:99:99";
            // 
            // tssl_Separador_Hora_Criador
            // 
            this.tssl_Separador_Hora_Criador.AutoSize = false;
            this.tssl_Separador_Hora_Criador.Name = "tssl_Separador_Hora_Criador";
            this.tssl_Separador_Hora_Criador.Size = new System.Drawing.Size(300, 17);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.ForeColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(181, 17);
            this.toolStripStatusLabel5.Text = "SysBurger - Criado por LuigiGM";
            // 
            // tssl_Separador_Criador_Resolucao
            // 
            this.tssl_Separador_Criador_Resolucao.AutoSize = false;
            this.tssl_Separador_Criador_Resolucao.Name = "tssl_Separador_Criador_Resolucao";
            this.tssl_Separador_Criador_Resolucao.Size = new System.Drawing.Size(500, 17);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel7.Text = "Resolução:";
            // 
            // tsslb_Resolucao
            // 
            this.tsslb_Resolucao.ForeColor = System.Drawing.Color.Khaki;
            this.tsslb_Resolucao.Name = "tsslb_Resolucao";
            this.tsslb_Resolucao.Size = new System.Drawing.Size(14, 17);
            this.tsslb_Resolucao.Text = "0";
            // 
            // tssl_Separador_Resolucao_Usuario
            // 
            this.tssl_Separador_Resolucao_Usuario.AutoSize = false;
            this.tssl_Separador_Resolucao_Usuario.Name = "tssl_Separador_Resolucao_Usuario";
            this.tssl_Separador_Resolucao_Usuario.Size = new System.Drawing.Size(127, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Khaki;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel2.Text = "Usuário:";
            // 
            // tssl_Usuario_Logado
            // 
            this.tssl_Usuario_Logado.ForeColor = System.Drawing.Color.Khaki;
            this.tssl_Usuario_Logado.Name = "tssl_Usuario_Logado";
            this.tssl_Usuario_Logado.Size = new System.Drawing.Size(33, 17);
            this.tssl_Usuario_Logado.Text = "User";
            // 
            // mnstrip_Principal
            // 
            this.mnstrip_Principal.BackColor = System.Drawing.Color.SteelBlue;
            this.mnstrip_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem,
            this.produtosToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.mnstrip_Principal.Location = new System.Drawing.Point(0, 0);
            this.mnstrip_Principal.Name = "mnstrip_Principal";
            this.mnstrip_Principal.Size = new System.Drawing.Size(922, 24);
            this.mnstrip_Principal.TabIndex = 1;
            this.mnstrip_Principal.Text = "menuStrip1";
            this.mnstrip_Principal.Visible = false;
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuárioToolStripMenuItem1,
            this.pessoaToolStripMenuItem});
            this.usuárioToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.usuárioToolStripMenuItem.Text = "Pessoas";
            // 
            // usuárioToolStripMenuItem1
            // 
            this.usuárioToolStripMenuItem1.BackColor = System.Drawing.Color.SteelBlue;
            this.usuárioToolStripMenuItem1.ForeColor = System.Drawing.Color.Khaki;
            this.usuárioToolStripMenuItem1.Name = "usuárioToolStripMenuItem1";
            this.usuárioToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.usuárioToolStripMenuItem1.Text = "Usuário";
            this.usuárioToolStripMenuItem1.Click += new System.EventHandler(this.usuárioToolStripMenuItem1_Click);
            // 
            // pessoaToolStripMenuItem
            // 
            this.pessoaToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.pessoaToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.pessoaToolStripMenuItem.Name = "pessoaToolStripMenuItem";
            this.pessoaToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.pessoaToolStripMenuItem.Text = "Pessoa";
            this.pessoaToolStripMenuItem.Click += new System.EventHandler(this.pessoaToolStripMenuItem_Click);
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtoToolStripMenuItem,
            this.ingredienteToolStripMenuItem,
            this.ingredienteDoProdutoToolStripMenuItem});
            this.produtosToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // produtoToolStripMenuItem
            // 
            this.produtoToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.produtoToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            this.produtoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.produtoToolStripMenuItem.Text = "Produto";
            this.produtoToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            // 
            // ingredienteToolStripMenuItem
            // 
            this.ingredienteToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.ingredienteToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.ingredienteToolStripMenuItem.Name = "ingredienteToolStripMenuItem";
            this.ingredienteToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ingredienteToolStripMenuItem.Text = "Ingrediente";
            this.ingredienteToolStripMenuItem.Click += new System.EventHandler(this.ingredienteToolStripMenuItem_Click);
            // 
            // ingredienteDoProdutoToolStripMenuItem
            // 
            this.ingredienteDoProdutoToolStripMenuItem.BackColor = System.Drawing.Color.SteelBlue;
            this.ingredienteDoProdutoToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.ingredienteDoProdutoToolStripMenuItem.Name = "ingredienteDoProdutoToolStripMenuItem";
            this.ingredienteDoProdutoToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.ingredienteDoProdutoToolStripMenuItem.Text = "Ingrediente do Produto";
            this.ingredienteDoProdutoToolStripMenuItem.Click += new System.EventHandler(this.ingredienteDoProdutoToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.ForeColor = System.Drawing.Color.Khaki;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // tm_Principal
            // 
            this.tm_Principal.Enabled = true;
            this.tm_Principal.Tick += new System.EventHandler(this.tm_Principal_Tick);
            // 
            // btn_Sair
            // 
            this.btn_Sair.BackColor = System.Drawing.Color.Khaki;
            this.btn_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Sair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sair.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sair.Image")));
            this.btn_Sair.Location = new System.Drawing.Point(518, 35);
            this.btn_Sair.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(99, 100);
            this.btn_Sair.TabIndex = 7;
            this.btn_Sair.TabStop = false;
            this.btn_Sair.UseVisualStyleBackColor = false;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // btn_Ingrediente_Produto
            // 
            this.btn_Ingrediente_Produto.BackColor = System.Drawing.Color.Khaki;
            this.btn_Ingrediente_Produto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Ingrediente_Produto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Ingrediente_Produto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingrediente_Produto.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ingrediente_Produto.Image")));
            this.btn_Ingrediente_Produto.Location = new System.Drawing.Point(182, 285);
            this.btn_Ingrediente_Produto.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Ingrediente_Produto.Name = "btn_Ingrediente_Produto";
            this.btn_Ingrediente_Produto.Size = new System.Drawing.Size(99, 100);
            this.btn_Ingrediente_Produto.TabIndex = 5;
            this.btn_Ingrediente_Produto.TabStop = false;
            this.btn_Ingrediente_Produto.UseVisualStyleBackColor = false;
            this.btn_Ingrediente_Produto.Click += new System.EventHandler(this.btn_Ingrediente_Produto_Click);
            // 
            // btn_Pedido
            // 
            this.btn_Pedido.BackColor = System.Drawing.Color.Khaki;
            this.btn_Pedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Pedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pedido.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pedido.Image")));
            this.btn_Pedido.Location = new System.Drawing.Point(350, 35);
            this.btn_Pedido.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Pedido.Name = "btn_Pedido";
            this.btn_Pedido.Size = new System.Drawing.Size(99, 100);
            this.btn_Pedido.TabIndex = 6;
            this.btn_Pedido.TabStop = false;
            this.btn_Pedido.UseVisualStyleBackColor = false;
            this.btn_Pedido.Click += new System.EventHandler(this.btn_Pedido_Click);
            // 
            // btn_Produtos
            // 
            this.btn_Produtos.BackColor = System.Drawing.Color.Khaki;
            this.btn_Produtos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Produtos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Produtos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Produtos.Image = ((System.Drawing.Image)(resources.GetObject("btn_Produtos.Image")));
            this.btn_Produtos.Location = new System.Drawing.Point(182, 35);
            this.btn_Produtos.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Produtos.Name = "btn_Produtos";
            this.btn_Produtos.Size = new System.Drawing.Size(99, 100);
            this.btn_Produtos.TabIndex = 3;
            this.btn_Produtos.TabStop = false;
            this.btn_Produtos.UseVisualStyleBackColor = false;
            this.btn_Produtos.Click += new System.EventHandler(this.btn_Produtos_Click);
            // 
            // btn_Ingrediente
            // 
            this.btn_Ingrediente.BackColor = System.Drawing.Color.Khaki;
            this.btn_Ingrediente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Ingrediente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Ingrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingrediente.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ingrediente.Image")));
            this.btn_Ingrediente.Location = new System.Drawing.Point(182, 160);
            this.btn_Ingrediente.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Ingrediente.Name = "btn_Ingrediente";
            this.btn_Ingrediente.Size = new System.Drawing.Size(99, 100);
            this.btn_Ingrediente.TabIndex = 4;
            this.btn_Ingrediente.TabStop = false;
            this.btn_Ingrediente.UseVisualStyleBackColor = false;
            this.btn_Ingrediente.Click += new System.EventHandler(this.btn_Ingrediente_Click);
            // 
            // btn_Pessoa
            // 
            this.btn_Pessoa.BackColor = System.Drawing.Color.Khaki;
            this.btn_Pessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pessoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Pessoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pessoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pessoa.Image")));
            this.btn_Pessoa.Location = new System.Drawing.Point(9, 160);
            this.btn_Pessoa.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Pessoa.Name = "btn_Pessoa";
            this.btn_Pessoa.Size = new System.Drawing.Size(99, 100);
            this.btn_Pessoa.TabIndex = 2;
            this.btn_Pessoa.TabStop = false;
            this.btn_Pessoa.UseVisualStyleBackColor = false;
            this.btn_Pessoa.Click += new System.EventHandler(this.btn_Pessoa_Click);
            // 
            // btn_Usuario
            // 
            this.btn_Usuario.BackColor = System.Drawing.Color.Khaki;
            this.btn_Usuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Usuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Usuario.Image = ((System.Drawing.Image)(resources.GetObject("btn_Usuario.Image")));
            this.btn_Usuario.Location = new System.Drawing.Point(9, 35);
            this.btn_Usuario.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Usuario.Name = "btn_Usuario";
            this.btn_Usuario.Size = new System.Drawing.Size(99, 100);
            this.btn_Usuario.TabIndex = 1;
            this.btn_Usuario.TabStop = false;
            this.btn_Usuario.UseVisualStyleBackColor = false;
            this.btn_Usuario.Click += new System.EventHandler(this.btn_Usuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Khaki;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1924, 428);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 450);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Ingrediente_Produto);
            this.Controls.Add(this.btn_Pedido);
            this.Controls.Add(this.btn_Produtos);
            this.Controls.Add(this.btn_Ingrediente);
            this.Controls.Add(this.btn_Pessoa);
            this.Controls.Add(this.btn_Usuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sttstrip_Principal);
            this.Controls.Add(this.mnstrip_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnstrip_Principal;
            this.Name = "frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.frm_Principal_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_Principal_KeyPress);
            this.sttstrip_Principal.ResumeLayout(false);
            this.sttstrip_Principal.PerformLayout();
            this.mnstrip_Principal.ResumeLayout(false);
            this.mnstrip_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttstrip_Principal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Data;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Separador_Data_Hora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Hora;
        private System.Windows.Forms.MenuStrip mnstrip_Principal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tm_Principal;
        private System.Windows.Forms.Button btn_Usuario;
        private System.Windows.Forms.Button btn_Pessoa;
        private System.Windows.Forms.Button btn_Ingrediente;
        private System.Windows.Forms.Button btn_Produtos;
        private System.Windows.Forms.Button btn_Pedido;
        private System.Windows.Forms.Button btn_Ingrediente_Produto;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pessoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredienteDoProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Separador_Hora_Criador;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Separador_Criador_Resolucao;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Resolucao;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Separador_Resolucao_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Usuario_Logado;
    }
}