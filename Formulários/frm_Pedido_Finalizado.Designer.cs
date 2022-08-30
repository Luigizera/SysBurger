
namespace SysBurger
{
    partial class frm_Pedido_Finalizado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Pedido_Finalizado));
            this.pnl_Detail = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.ltview_Produtos = new System.Windows.Forms.ListView();
            this.lbl_Comp_Pedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Ped_Pedido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Nm_Pessoa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_Cod_Pedido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_List = new System.Windows.Forms.Panel();
            this.ltbox_Pedidos = new System.Windows.Forms.ListBox();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_End_Endereco = new System.Windows.Forms.Label();
            this.lbl_Bai_Endereco = new System.Windows.Forms.Label();
            this.lbl_Cid_Endereco = new System.Windows.Forms.Label();
            this.lbl_UF_Endereco = new System.Windows.Forms.Label();
            this.lbl_CEP_Endereco = new System.Windows.Forms.Label();
            this.pnl_Detail.SuspendLayout();
            this.pnl_List.SuspendLayout();
            this.pnl_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detail
            // 
            this.pnl_Detail.BackColor = System.Drawing.Color.Khaki;
            this.pnl_Detail.Controls.Add(this.lbl_CEP_Endereco);
            this.pnl_Detail.Controls.Add(this.lbl_UF_Endereco);
            this.pnl_Detail.Controls.Add(this.lbl_Cid_Endereco);
            this.pnl_Detail.Controls.Add(this.lbl_Bai_Endereco);
            this.pnl_Detail.Controls.Add(this.lbl_End_Endereco);
            this.pnl_Detail.Controls.Add(this.label5);
            this.pnl_Detail.Controls.Add(this.label8);
            this.pnl_Detail.Controls.Add(this.ltview_Produtos);
            this.pnl_Detail.Controls.Add(this.lbl_Comp_Pedido);
            this.pnl_Detail.Controls.Add(this.label2);
            this.pnl_Detail.Controls.Add(this.lbl_Ped_Pedido);
            this.pnl_Detail.Controls.Add(this.label4);
            this.pnl_Detail.Controls.Add(this.lbl_Nm_Pessoa);
            this.pnl_Detail.Controls.Add(this.label1);
            this.pnl_Detail.Controls.Add(this.tbox_Cod_Pedido);
            this.pnl_Detail.Controls.Add(this.label7);
            this.pnl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detail.Location = new System.Drawing.Point(182, 31);
            this.pnl_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Detail.Name = "pnl_Detail";
            this.pnl_Detail.Size = new System.Drawing.Size(324, 420);
            this.pnl_Detail.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Itens da Compra:";
            // 
            // ltview_Produtos
            // 
            this.ltview_Produtos.HideSelection = false;
            this.ltview_Produtos.Location = new System.Drawing.Point(23, 243);
            this.ltview_Produtos.Name = "ltview_Produtos";
            this.ltview_Produtos.Size = new System.Drawing.Size(286, 151);
            this.ltview_Produtos.TabIndex = 10;
            this.ltview_Produtos.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_Comp_Pedido
            // 
            this.lbl_Comp_Pedido.AutoSize = true;
            this.lbl_Comp_Pedido.Location = new System.Drawing.Point(133, 98);
            this.lbl_Comp_Pedido.Name = "lbl_Comp_Pedido";
            this.lbl_Comp_Pedido.Size = new System.Drawing.Size(110, 13);
            this.lbl_Comp_Pedido.TabIndex = 7;
            this.lbl_Comp_Pedido.Text = "00/00/0000 00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data da Compra:";
            // 
            // lbl_Ped_Pedido
            // 
            this.lbl_Ped_Pedido.AutoSize = true;
            this.lbl_Ped_Pedido.Location = new System.Drawing.Point(133, 73);
            this.lbl_Ped_Pedido.Name = "lbl_Ped_Pedido";
            this.lbl_Ped_Pedido.Size = new System.Drawing.Size(40, 13);
            this.lbl_Ped_Pedido.TabIndex = 5;
            this.lbl_Ped_Pedido.Text = "Pedido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Código do Pedido:";
            // 
            // lbl_Nm_Pessoa
            // 
            this.lbl_Nm_Pessoa.AutoSize = true;
            this.lbl_Nm_Pessoa.Location = new System.Drawing.Point(133, 49);
            this.lbl_Nm_Pessoa.Name = "lbl_Nm_Pessoa";
            this.lbl_Nm_Pessoa.Size = new System.Drawing.Size(58, 13);
            this.lbl_Nm_Pessoa.TabIndex = 3;
            this.lbl_Nm_Pessoa.Text = "Comprador";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do Comprador:";
            // 
            // tbox_Cod_Pedido
            // 
            this.tbox_Cod_Pedido.Enabled = false;
            this.tbox_Cod_Pedido.Location = new System.Drawing.Point(67, 11);
            this.tbox_Cod_Pedido.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cod_Pedido.Name = "tbox_Cod_Pedido";
            this.tbox_Cod_Pedido.Size = new System.Drawing.Size(76, 20);
            this.tbox_Cod_Pedido.TabIndex = 1;
            this.tbox_Cod_Pedido.Tag = "1";
            this.tbox_Cod_Pedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Código:";
            // 
            // pnl_List
            // 
            this.pnl_List.BackColor = System.Drawing.Color.Khaki;
            this.pnl_List.Controls.Add(this.ltbox_Pedidos);
            this.pnl_List.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_List.Location = new System.Drawing.Point(0, 31);
            this.pnl_List.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_List.Name = "pnl_List";
            this.pnl_List.Size = new System.Drawing.Size(182, 420);
            this.pnl_List.TabIndex = 27;
            // 
            // ltbox_Pedidos
            // 
            this.ltbox_Pedidos.BackColor = System.Drawing.Color.LemonChiffon;
            this.ltbox_Pedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltbox_Pedidos.FormattingEnabled = true;
            this.ltbox_Pedidos.Location = new System.Drawing.Point(0, 0);
            this.ltbox_Pedidos.Margin = new System.Windows.Forms.Padding(2);
            this.ltbox_Pedidos.Name = "ltbox_Pedidos";
            this.ltbox_Pedidos.Size = new System.Drawing.Size(182, 420);
            this.ltbox_Pedidos.TabIndex = 0;
            // 
            // pnl_Title
            // 
            this.pnl_Title.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_Title.Controls.Add(this.label3);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(506, 31);
            this.pnl_Title.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.label3.ForeColor = System.Drawing.Color.Khaki;
            this.label3.Location = new System.Drawing.Point(30, -7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 47);
            this.label3.TabIndex = 1;
            this.label3.Text = "PEDIDOS FINALIZADOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Endereço:";
            // 
            // lbl_End_Endereco
            // 
            this.lbl_End_Endereco.AutoSize = true;
            this.lbl_End_Endereco.Location = new System.Drawing.Point(79, 124);
            this.lbl_End_Endereco.Name = "lbl_End_Endereco";
            this.lbl_End_Endereco.Size = new System.Drawing.Size(53, 13);
            this.lbl_End_Endereco.TabIndex = 13;
            this.lbl_End_Endereco.Text = "Endereço";
            // 
            // lbl_Bai_Endereco
            // 
            this.lbl_Bai_Endereco.AutoSize = true;
            this.lbl_Bai_Endereco.Location = new System.Drawing.Point(79, 146);
            this.lbl_Bai_Endereco.Name = "lbl_Bai_Endereco";
            this.lbl_Bai_Endereco.Size = new System.Drawing.Size(34, 13);
            this.lbl_Bai_Endereco.TabIndex = 14;
            this.lbl_Bai_Endereco.Text = "Bairro";
            // 
            // lbl_Cid_Endereco
            // 
            this.lbl_Cid_Endereco.AutoSize = true;
            this.lbl_Cid_Endereco.Location = new System.Drawing.Point(79, 169);
            this.lbl_Cid_Endereco.Name = "lbl_Cid_Endereco";
            this.lbl_Cid_Endereco.Size = new System.Drawing.Size(40, 13);
            this.lbl_Cid_Endereco.TabIndex = 15;
            this.lbl_Cid_Endereco.Text = "Cidade";
            // 
            // lbl_UF_Endereco
            // 
            this.lbl_UF_Endereco.AutoSize = true;
            this.lbl_UF_Endereco.Location = new System.Drawing.Point(152, 189);
            this.lbl_UF_Endereco.Name = "lbl_UF_Endereco";
            this.lbl_UF_Endereco.Size = new System.Drawing.Size(21, 13);
            this.lbl_UF_Endereco.TabIndex = 16;
            this.lbl_UF_Endereco.Text = "UF";
            // 
            // lbl_CEP_Endereco
            // 
            this.lbl_CEP_Endereco.AutoSize = true;
            this.lbl_CEP_Endereco.Location = new System.Drawing.Point(79, 189);
            this.lbl_CEP_Endereco.Name = "lbl_CEP_Endereco";
            this.lbl_CEP_Endereco.Size = new System.Drawing.Size(28, 13);
            this.lbl_CEP_Endereco.TabIndex = 17;
            this.lbl_CEP_Endereco.Text = "CEP";
            // 
            // frm_Pedido_Finalizado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 451);
            this.Controls.Add(this.pnl_Detail);
            this.Controls.Add(this.pnl_List);
            this.Controls.Add(this.pnl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Pedido_Finalizado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnl_Detail.ResumeLayout(false);
            this.pnl_Detail.PerformLayout();
            this.pnl_List.ResumeLayout(false);
            this.pnl_Title.ResumeLayout(false);
            this.pnl_Title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detail;
        private System.Windows.Forms.TextBox tbox_Cod_Pedido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnl_List;
        private System.Windows.Forms.ListBox ltbox_Pedidos;
        private System.Windows.Forms.Panel pnl_Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Nm_Pessoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Ped_Pedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Comp_Pedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView ltview_Produtos;
        private System.Windows.Forms.Label lbl_End_Endereco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_CEP_Endereco;
        private System.Windows.Forms.Label lbl_UF_Endereco;
        private System.Windows.Forms.Label lbl_Cid_Endereco;
        private System.Windows.Forms.Label lbl_Bai_Endereco;
    }
}