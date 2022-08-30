
namespace SysBurger
{
    partial class frm_Endereco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Endereco));
            this.pnl_Detail = new System.Windows.Forms.Panel();
            this.mtbox_CEP_Endereco = new System.Windows.Forms.MaskedTextBox();
            this.cbox_UF_Endereco = new System.Windows.Forms.ComboBox();
            this.tbox_Cod_Pessoa = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_Cid_Endereco = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbox_Bai_Endereco = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbox_End_Endereco = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.lb_Mail_Pessoa = new System.Windows.Forms.Label();
            this.lb_Cel_Pessoa = new System.Windows.Forms.Label();
            this.lb_CPF_Pessoa = new System.Windows.Forms.Label();
            this.lb_Snm_Pessoa = new System.Windows.Forms.Label();
            this.lb_Nm_Pessoa = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbox_Cod_Endereco = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_List = new System.Windows.Forms.Panel();
            this.ltbox_Enderecos = new System.Windows.Forms.ListBox();
            this.pnl_Button = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Detail.SuspendLayout();
            this.pnl_List.SuspendLayout();
            this.pnl_Button.SuspendLayout();
            this.pnl_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detail
            // 
            this.pnl_Detail.BackColor = System.Drawing.Color.Khaki;
            this.pnl_Detail.Controls.Add(this.mtbox_CEP_Endereco);
            this.pnl_Detail.Controls.Add(this.cbox_UF_Endereco);
            this.pnl_Detail.Controls.Add(this.tbox_Cod_Pessoa);
            this.pnl_Detail.Controls.Add(this.label13);
            this.pnl_Detail.Controls.Add(this.label1);
            this.pnl_Detail.Controls.Add(this.tbox_Cid_Endereco);
            this.pnl_Detail.Controls.Add(this.label11);
            this.pnl_Detail.Controls.Add(this.tbox_Bai_Endereco);
            this.pnl_Detail.Controls.Add(this.label9);
            this.pnl_Detail.Controls.Add(this.tbox_End_Endereco);
            this.pnl_Detail.Controls.Add(this.Label10);
            this.pnl_Detail.Controls.Add(this.lb_Mail_Pessoa);
            this.pnl_Detail.Controls.Add(this.lb_Cel_Pessoa);
            this.pnl_Detail.Controls.Add(this.lb_CPF_Pessoa);
            this.pnl_Detail.Controls.Add(this.lb_Snm_Pessoa);
            this.pnl_Detail.Controls.Add(this.lb_Nm_Pessoa);
            this.pnl_Detail.Controls.Add(this.label12);
            this.pnl_Detail.Controls.Add(this.tbox_Cod_Endereco);
            this.pnl_Detail.Controls.Add(this.label7);
            this.pnl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detail.Location = new System.Drawing.Point(150, 34);
            this.pnl_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Detail.Name = "pnl_Detail";
            this.pnl_Detail.Size = new System.Drawing.Size(455, 295);
            this.pnl_Detail.TabIndex = 24;
            // 
            // mtbox_CEP_Endereco
            // 
            this.mtbox_CEP_Endereco.Location = new System.Drawing.Point(24, 241);
            this.mtbox_CEP_Endereco.Mask = "_____-___";
            this.mtbox_CEP_Endereco.Name = "mtbox_CEP_Endereco";
            this.mtbox_CEP_Endereco.Size = new System.Drawing.Size(75, 20);
            this.mtbox_CEP_Endereco.TabIndex = 5;
            this.mtbox_CEP_Endereco.Tag = "5";
            // 
            // cbox_UF_Endereco
            // 
            this.cbox_UF_Endereco.FormattingEnabled = true;
            this.cbox_UF_Endereco.Items.AddRange(new object[] {
            "SP",
            "RO",
            "AC",
            "AM",
            "PA",
            "AP",
            "TO",
            "MA",
            "PI",
            "CE",
            "RN",
            "PB",
            "PE",
            "AL",
            "SE",
            "BA",
            "MG",
            "ES",
            "RJ",
            "PR",
            "SC",
            "RS",
            "MS",
            "MT",
            "GO",
            "DF"});
            this.cbox_UF_Endereco.Location = new System.Drawing.Point(249, 240);
            this.cbox_UF_Endereco.MaxLength = 2;
            this.cbox_UF_Endereco.Name = "cbox_UF_Endereco";
            this.cbox_UF_Endereco.Size = new System.Drawing.Size(51, 21);
            this.cbox_UF_Endereco.TabIndex = 6;
            // 
            // tbox_Cod_Pessoa
            // 
            this.tbox_Cod_Pessoa.Enabled = false;
            this.tbox_Cod_Pessoa.Location = new System.Drawing.Point(23, 81);
            this.tbox_Cod_Pessoa.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cod_Pessoa.Name = "tbox_Cod_Pessoa";
            this.tbox_Cod_Pessoa.Size = new System.Drawing.Size(76, 20);
            this.tbox_Cod_Pessoa.TabIndex = 1;
            this.tbox_Cod_Pessoa.Tag = "1";
            this.tbox_Cod_Pessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbox_Cod_Pessoa.Leave += new System.EventHandler(this.tbox_Cod_Pessoa_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 222);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 13);
            this.label13.TabIndex = 44;
            this.label13.Text = "CEP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "UF";
            // 
            // tbox_Cid_Endereco
            // 
            this.tbox_Cid_Endereco.Location = new System.Drawing.Point(249, 197);
            this.tbox_Cid_Endereco.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cid_Endereco.MaxLength = 25;
            this.tbox_Cid_Endereco.Name = "tbox_Cid_Endereco";
            this.tbox_Cid_Endereco.Size = new System.Drawing.Size(188, 20);
            this.tbox_Cid_Endereco.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(247, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Cidade";
            // 
            // tbox_Bai_Endereco
            // 
            this.tbox_Bai_Endereco.Location = new System.Drawing.Point(23, 197);
            this.tbox_Bai_Endereco.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Bai_Endereco.MaxLength = 25;
            this.tbox_Bai_Endereco.Name = "tbox_Bai_Endereco";
            this.tbox_Bai_Endereco.Size = new System.Drawing.Size(184, 20);
            this.tbox_Bai_Endereco.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 180);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Bairro";
            // 
            // tbox_End_Endereco
            // 
            this.tbox_End_Endereco.Location = new System.Drawing.Point(22, 152);
            this.tbox_End_Endereco.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_End_Endereco.MaxLength = 30;
            this.tbox_End_Endereco.Name = "tbox_End_Endereco";
            this.tbox_End_Endereco.Size = new System.Drawing.Size(417, 20);
            this.tbox_End_Endereco.TabIndex = 2;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(20, 135);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(53, 13);
            this.Label10.TabIndex = 36;
            this.Label10.Text = "Endereço";
            // 
            // lb_Mail_Pessoa
            // 
            this.lb_Mail_Pessoa.BackColor = System.Drawing.Color.SteelBlue;
            this.lb_Mail_Pessoa.ForeColor = System.Drawing.Color.Khaki;
            this.lb_Mail_Pessoa.Location = new System.Drawing.Point(301, 108);
            this.lb_Mail_Pessoa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Mail_Pessoa.Name = "lb_Mail_Pessoa";
            this.lb_Mail_Pessoa.Size = new System.Drawing.Size(138, 13);
            this.lb_Mail_Pessoa.TabIndex = 35;
            this.lb_Mail_Pessoa.Tag = "1";
            // 
            // lb_Cel_Pessoa
            // 
            this.lb_Cel_Pessoa.BackColor = System.Drawing.Color.SteelBlue;
            this.lb_Cel_Pessoa.ForeColor = System.Drawing.Color.Khaki;
            this.lb_Cel_Pessoa.Location = new System.Drawing.Point(156, 108);
            this.lb_Cel_Pessoa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Cel_Pessoa.Name = "lb_Cel_Pessoa";
            this.lb_Cel_Pessoa.Size = new System.Drawing.Size(131, 13);
            this.lb_Cel_Pessoa.TabIndex = 25;
            this.lb_Cel_Pessoa.Tag = "1";
            // 
            // lb_CPF_Pessoa
            // 
            this.lb_CPF_Pessoa.BackColor = System.Drawing.Color.SteelBlue;
            this.lb_CPF_Pessoa.ForeColor = System.Drawing.Color.Khaki;
            this.lb_CPF_Pessoa.Location = new System.Drawing.Point(24, 108);
            this.lb_CPF_Pessoa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CPF_Pessoa.Name = "lb_CPF_Pessoa";
            this.lb_CPF_Pessoa.Size = new System.Drawing.Size(123, 13);
            this.lb_CPF_Pessoa.TabIndex = 23;
            this.lb_CPF_Pessoa.Tag = "1";
            // 
            // lb_Snm_Pessoa
            // 
            this.lb_Snm_Pessoa.BackColor = System.Drawing.Color.SteelBlue;
            this.lb_Snm_Pessoa.ForeColor = System.Drawing.Color.Khaki;
            this.lb_Snm_Pessoa.Location = new System.Drawing.Point(266, 85);
            this.lb_Snm_Pessoa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Snm_Pessoa.Name = "lb_Snm_Pessoa";
            this.lb_Snm_Pessoa.Size = new System.Drawing.Size(173, 13);
            this.lb_Snm_Pessoa.TabIndex = 22;
            this.lb_Snm_Pessoa.Tag = "1";
            // 
            // lb_Nm_Pessoa
            // 
            this.lb_Nm_Pessoa.BackColor = System.Drawing.Color.SteelBlue;
            this.lb_Nm_Pessoa.ForeColor = System.Drawing.Color.Khaki;
            this.lb_Nm_Pessoa.Location = new System.Drawing.Point(114, 85);
            this.lb_Nm_Pessoa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Nm_Pessoa.Name = "lb_Nm_Pessoa";
            this.lb_Nm_Pessoa.Size = new System.Drawing.Size(143, 13);
            this.lb_Nm_Pessoa.TabIndex = 17;
            this.lb_Nm_Pessoa.Tag = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 64);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Código da Pessoa:";
            // 
            // tbox_Cod_Endereco
            // 
            this.tbox_Cod_Endereco.Enabled = false;
            this.tbox_Cod_Endereco.Location = new System.Drawing.Point(22, 32);
            this.tbox_Cod_Endereco.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cod_Endereco.Name = "tbox_Cod_Endereco";
            this.tbox_Cod_Endereco.Size = new System.Drawing.Size(76, 20);
            this.tbox_Cod_Endereco.TabIndex = 0;
            this.tbox_Cod_Endereco.Tag = "1";
            this.tbox_Cod_Endereco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.pnl_List.Controls.Add(this.ltbox_Enderecos);
            this.pnl_List.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_List.Location = new System.Drawing.Point(0, 34);
            this.pnl_List.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_List.Name = "pnl_List";
            this.pnl_List.Size = new System.Drawing.Size(150, 295);
            this.pnl_List.TabIndex = 23;
            // 
            // ltbox_Enderecos
            // 
            this.ltbox_Enderecos.BackColor = System.Drawing.Color.LemonChiffon;
            this.ltbox_Enderecos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltbox_Enderecos.FormattingEnabled = true;
            this.ltbox_Enderecos.Location = new System.Drawing.Point(0, 0);
            this.ltbox_Enderecos.Margin = new System.Windows.Forms.Padding(2);
            this.ltbox_Enderecos.Name = "ltbox_Enderecos";
            this.ltbox_Enderecos.Size = new System.Drawing.Size(150, 295);
            this.ltbox_Enderecos.TabIndex = 0;
            this.ltbox_Enderecos.Click += new System.EventHandler(this.ltbox_Enderecos_Click);
            // 
            // pnl_Button
            // 
            this.pnl_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_Button.Controls.Add(this.btn_Cancelar);
            this.pnl_Button.Controls.Add(this.btn_Confirmar);
            this.pnl_Button.Controls.Add(this.btn_Excluir);
            this.pnl_Button.Controls.Add(this.btn_Alterar);
            this.pnl_Button.Controls.Add(this.btn_Novo);
            this.pnl_Button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Button.Location = new System.Drawing.Point(0, 329);
            this.pnl_Button.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Button.Name = "pnl_Button";
            this.pnl_Button.Size = new System.Drawing.Size(605, 50);
            this.pnl_Button.TabIndex = 22;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Khaki;
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Location = new System.Drawing.Point(502, 18);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(74, 21);
            this.btn_Cancelar.TabIndex = 4;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.BackColor = System.Drawing.Color.Khaki;
            this.btn_Confirmar.FlatAppearance.BorderSize = 0;
            this.btn_Confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirmar.Location = new System.Drawing.Point(416, 18);
            this.btn_Confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(71, 21);
            this.btn_Confirmar.TabIndex = 3;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = false;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.BackColor = System.Drawing.Color.Khaki;
            this.btn_Excluir.FlatAppearance.BorderSize = 0;
            this.btn_Excluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excluir.Location = new System.Drawing.Point(135, 18);
            this.btn_Excluir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(56, 21);
            this.btn_Excluir.TabIndex = 2;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = false;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.BackColor = System.Drawing.Color.Khaki;
            this.btn_Alterar.FlatAppearance.BorderSize = 0;
            this.btn_Alterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Alterar.Location = new System.Drawing.Point(74, 18);
            this.btn_Alterar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(56, 21);
            this.btn_Alterar.TabIndex = 1;
            this.btn_Alterar.Text = "Alterar";
            this.btn_Alterar.UseVisualStyleBackColor = false;
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Novo
            // 
            this.btn_Novo.BackColor = System.Drawing.Color.Khaki;
            this.btn_Novo.FlatAppearance.BorderSize = 0;
            this.btn_Novo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Novo.Location = new System.Drawing.Point(14, 18);
            this.btn_Novo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(56, 21);
            this.btn_Novo.TabIndex = 0;
            this.btn_Novo.Text = "Novo";
            this.btn_Novo.UseVisualStyleBackColor = false;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // pnl_Title
            // 
            this.pnl_Title.BackColor = System.Drawing.Color.SteelBlue;
            this.pnl_Title.Controls.Add(this.label2);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(605, 34);
            this.pnl_Title.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(331, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 47);
            this.label2.TabIndex = 2;
            this.label2.Text = "ENDEREÇO";
            // 
            // frm_Endereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 379);
            this.Controls.Add(this.pnl_Detail);
            this.Controls.Add(this.pnl_List);
            this.Controls.Add(this.pnl_Button);
            this.Controls.Add(this.pnl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Endereco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.frm_Endereco_Shown);
            this.pnl_Detail.ResumeLayout(false);
            this.pnl_Detail.PerformLayout();
            this.pnl_List.ResumeLayout(false);
            this.pnl_Button.ResumeLayout(false);
            this.pnl_Title.ResumeLayout(false);
            this.pnl_Title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detail;
        private System.Windows.Forms.Panel pnl_List;
        private System.Windows.Forms.ListBox ltbox_Enderecos;
        private System.Windows.Forms.Panel pnl_Button;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.Panel pnl_Title;
        private System.Windows.Forms.TextBox tbox_Cod_Pessoa;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_Cid_Endereco;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbox_Bai_Endereco;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbox_End_Endereco;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Label lb_Mail_Pessoa;
        private System.Windows.Forms.Label lb_Cel_Pessoa;
        private System.Windows.Forms.Label lb_CPF_Pessoa;
        private System.Windows.Forms.Label lb_Snm_Pessoa;
        private System.Windows.Forms.Label lb_Nm_Pessoa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbox_Cod_Endereco;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbox_UF_Endereco;
        private System.Windows.Forms.MaskedTextBox mtbox_CEP_Endereco;
    }
}