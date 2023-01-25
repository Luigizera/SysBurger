
namespace SysBurger
{
    partial class frm_Ingrediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Ingrediente));
            this.pnl_Detail = new System.Windows.Forms.Panel();
            this.mtbox_Qnt_Ingrediente = new System.Windows.Forms.MaskedTextBox();
            this.lbl_Atv_Ingrediente = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbox_Nm_Ingrediente = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.tbox_Cod_Ingrediente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_List = new System.Windows.Forms.Panel();
            this.ltbox_Ingredientes = new System.Windows.Forms.ListBox();
            this.pnl_Button = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Detail.SuspendLayout();
            this.pnl_List.SuspendLayout();
            this.pnl_Button.SuspendLayout();
            this.pnl_Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detail
            // 
            this.pnl_Detail.BackColor = System.Drawing.Color.Khaki;
            this.pnl_Detail.Controls.Add(this.mtbox_Qnt_Ingrediente);
            this.pnl_Detail.Controls.Add(this.lbl_Atv_Ingrediente);
            this.pnl_Detail.Controls.Add(this.label12);
            this.pnl_Detail.Controls.Add(this.tbox_Nm_Ingrediente);
            this.pnl_Detail.Controls.Add(this.Label10);
            this.pnl_Detail.Controls.Add(this.tbox_Cod_Ingrediente);
            this.pnl_Detail.Controls.Add(this.label7);
            this.pnl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detail.Location = new System.Drawing.Point(150, 32);
            this.pnl_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Detail.Name = "pnl_Detail";
            this.pnl_Detail.Size = new System.Drawing.Size(365, 196);
            this.pnl_Detail.TabIndex = 28;
            // 
            // mtbox_Qnt_Ingrediente
            // 
            this.mtbox_Qnt_Ingrediente.Location = new System.Drawing.Point(22, 123);
            this.mtbox_Qnt_Ingrediente.Name = "mtbox_Qnt_Ingrediente";
            this.mtbox_Qnt_Ingrediente.Size = new System.Drawing.Size(57, 20);
            this.mtbox_Qnt_Ingrediente.TabIndex = 3;
            this.mtbox_Qnt_Ingrediente.Tag = "2";
            this.mtbox_Qnt_Ingrediente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbox_Qnt_Ingrediente_KeyPress);
            // 
            // lbl_Atv_Ingrediente
            // 
            this.lbl_Atv_Ingrediente.AutoSize = true;
            this.lbl_Atv_Ingrediente.ForeColor = System.Drawing.Color.Red;
            this.lbl_Atv_Ingrediente.Location = new System.Drawing.Point(85, 125);
            this.lbl_Atv_Ingrediente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Atv_Ingrediente.Name = "lbl_Atv_Ingrediente";
            this.lbl_Atv_Ingrediente.Size = new System.Drawing.Size(65, 13);
            this.lbl_Atv_Ingrediente.TabIndex = 16;
            this.lbl_Atv_Ingrediente.Text = "Indisponível";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 107);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Quantidade";
            // 
            // tbox_Nm_Ingrediente
            // 
            this.tbox_Nm_Ingrediente.Location = new System.Drawing.Point(22, 76);
            this.tbox_Nm_Ingrediente.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Nm_Ingrediente.MaxLength = 30;
            this.tbox_Nm_Ingrediente.Name = "tbox_Nm_Ingrediente";
            this.tbox_Nm_Ingrediente.Size = new System.Drawing.Size(206, 20);
            this.tbox_Nm_Ingrediente.TabIndex = 2;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(20, 59);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(35, 13);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Nome";
            // 
            // tbox_Cod_Ingrediente
            // 
            this.tbox_Cod_Ingrediente.Enabled = false;
            this.tbox_Cod_Ingrediente.Location = new System.Drawing.Point(22, 32);
            this.tbox_Cod_Ingrediente.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_Cod_Ingrediente.Name = "tbox_Cod_Ingrediente";
            this.tbox_Cod_Ingrediente.Size = new System.Drawing.Size(76, 20);
            this.tbox_Cod_Ingrediente.TabIndex = 1;
            this.tbox_Cod_Ingrediente.Tag = "1";
            this.tbox_Cod_Ingrediente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Código";
            // 
            // pnl_List
            // 
            this.pnl_List.BackColor = System.Drawing.Color.Khaki;
            this.pnl_List.Controls.Add(this.ltbox_Ingredientes);
            this.pnl_List.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_List.Location = new System.Drawing.Point(0, 32);
            this.pnl_List.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_List.Name = "pnl_List";
            this.pnl_List.Size = new System.Drawing.Size(150, 196);
            this.pnl_List.TabIndex = 27;
            // 
            // ltbox_Ingredientes
            // 
            this.ltbox_Ingredientes.BackColor = System.Drawing.Color.LemonChiffon;
            this.ltbox_Ingredientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ltbox_Ingredientes.FormattingEnabled = true;
            this.ltbox_Ingredientes.Location = new System.Drawing.Point(0, 0);
            this.ltbox_Ingredientes.Margin = new System.Windows.Forms.Padding(2);
            this.ltbox_Ingredientes.Name = "ltbox_Ingredientes";
            this.ltbox_Ingredientes.Size = new System.Drawing.Size(150, 196);
            this.ltbox_Ingredientes.TabIndex = 0;
            this.ltbox_Ingredientes.Click += new System.EventHandler(this.ltbox_Ingredientes_Click);
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
            this.pnl_Button.Location = new System.Drawing.Point(0, 228);
            this.pnl_Button.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Button.Name = "pnl_Button";
            this.pnl_Button.Size = new System.Drawing.Size(515, 50);
            this.pnl_Button.TabIndex = 26;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Khaki;
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LemonChiffon;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Location = new System.Drawing.Point(425, 18);
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
            this.btn_Confirmar.Location = new System.Drawing.Point(349, 18);
            this.btn_Confirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(72, 21);
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
            this.pnl_Title.Controls.Add(this.label1);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(515, 32);
            this.pnl_Title.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(210, -7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "INGREDIENTE";
            // 
            // frm_Ingrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 278);
            this.Controls.Add(this.pnl_Detail);
            this.Controls.Add(this.pnl_List);
            this.Controls.Add(this.pnl_Button);
            this.Controls.Add(this.pnl_Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Ingrediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbox_Nm_Ingrediente;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.TextBox tbox_Cod_Ingrediente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnl_List;
        private System.Windows.Forms.ListBox ltbox_Ingredientes;
        private System.Windows.Forms.Panel pnl_Button;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.Panel pnl_Title;
        private System.Windows.Forms.Label lbl_Atv_Ingrediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbox_Qnt_Ingrediente;
    }
}