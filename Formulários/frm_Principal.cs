using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysBurger
{
    public partial class frm_Principal : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();

        
        public frm_Principal()
        {
            InitializeComponent();
            //Renderizador da cor dos itens do menustrip
            mnstrip_Principal.Renderer = new MyRenderer();

            //Pega a Largura e Altura do Monitor
            string Monitor_Largura = Screen.PrimaryScreen.Bounds.Width.ToString();
            string Monitor_Altura = Screen.PrimaryScreen.Bounds.Height.ToString();
            tsslb_Resolucao.Text = (Monitor_Largura + "x" + Monitor_Altura);
            
            switch (Monitor_Largura)
            {
                case "800":
                    {
                        //sttstrip_Principal
                        tssl_Separador_Data_Hora.Width = 20; 
                        tssl_Separador_Hora_Criador.Width = 80; 
                        tssl_Separador_Criador_Resolucao.Width = 50;
                        tssl_Separador_Resolucao_Usuario.Width = 20;
                        break;
                    }
                case "1280":
                    {
                        //sttstrip_Principal
                        tssl_Separador_Data_Hora.Width = 118;
                        tssl_Separador_Hora_Criador.Width = 220; 
                        tssl_Separador_Criador_Resolucao.Width = 200; 
                        tssl_Separador_Resolucao_Usuario.Width = 100;
                        break;
                    }
                case "1366":
                    {
                        //sttstrip_Principal
                        tssl_Separador_Data_Hora.Width = 118;
                        tssl_Separador_Hora_Criador.Width = 250; 
                        tssl_Separador_Criador_Resolucao.Width = 250;
                        tssl_Separador_Resolucao_Usuario.Width = 100;
                        break;
                    }
                case "1440":
                    {
                        //sttstrip_Principal
                        tssl_Separador_Data_Hora.Width = 118;
                        tssl_Separador_Hora_Criador.Width = 300; 
                        tssl_Separador_Criador_Resolucao.Width = 300;
                        tssl_Separador_Resolucao_Usuario.Width = 80;
                        break;
                    }
                case "1920":
                    {
                        //sttstrip_Principal
                        tssl_Separador_Data_Hora.Width = 118;
                        tssl_Separador_Hora_Criador.Width = 500; 
                        tssl_Separador_Criador_Resolucao.Width = 520;
                        tssl_Separador_Resolucao_Usuario.Width = 127;
                        break;
                    }
            }

        }

        //TROCAR A COR DOS ITENS DO MENUSTRIP
        private class MyRenderer : ToolStripProfessionalRenderer //Renderizador de cor
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected // Cor de fundo do subitem
            {
                get
                {
                    return Color.SkyBlue;
                }
            }
            public override Color MenuItemSelectedGradientBegin //Cor inicial do gradiente de cima pra baixo
            {
                get
                {
                    return Color.SkyBlue;
                }
            }
            public override Color MenuItemSelectedGradientEnd //Termina o gradiente com essa cor
            {
                get
                {
                    return Color.SkyBlue;
                }
            }
        }

        //EVENTO DA BARRA DE STATUS
        private void tm_Principal_Tick(object sender, EventArgs e)
        {
            tsslb_Data.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            tsslb_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //EVENTO DOS BOTÕES
        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            frm_Usuario obj_frm_Usuario = new frm_Usuario();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Usuario pelo Ícone.");
            obj_frm_Usuario.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Usuario.ShowDialog();
        }

        private void btn_Pessoa_Click(object sender, EventArgs e)
        {
            frm_Pessoa obj_frm_Pessoa = new frm_Pessoa();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Pessoa pelo Ícone.");
            obj_frm_Pessoa.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Pessoa.ShowDialog();
        }

        private void btn_Ingrediente_Click(object sender, EventArgs e)
        {
            frm_Ingrediente obj_frm_Ingrediente = new frm_Ingrediente();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Ingrediente pelo Ícone.");
            obj_frm_Ingrediente.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Ingrediente.ShowDialog();
        }

        private void btn_Produtos_Click(object sender, EventArgs e)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Produto pelo Ícone.");
            obj_frm_Produto.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Produto.ShowDialog();
        }

        private void btn_Ingrediente_Produto_Click(object sender, EventArgs e)
        {
            frm_Ingrediente_Produto obj_frm_Ingrediente_Produto = new frm_Ingrediente_Produto();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Ingrediente do Produto pelo Ícone.");
            obj_frm_Ingrediente_Produto.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Ingrediente_Produto.ShowDialog();
        }

        private void btn_Pedido_Click(object sender, EventArgs e)
        {
            frm_Pedido obj_frm_Pedido = new frm_Pedido();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " abriu o formulário Pedido pelo Ícone.");
            obj_frm_Pedido.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Pedido.ShowDialog();
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deslogou.");
            Application.Exit();
        }

        //EVENTO DO TAB
        private void frm_Principal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                if (mnstrip_Principal.Visible == true)
                {
                    mnstrip_Principal.Visible = false;
                }
                else
                {
                    mnstrip_Principal.Visible = true;
                }
            }
        }

        //TOOL STRIP MENU
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deslogou.");
            Application.Exit();
        }

        //USUÁRIO LOGADO
        private void frm_Principal_Shown(object sender, EventArgs e)
        {
            tssl_Usuario_Logado.Text = obj_Usuario_Logado.Unm_Usuario;
            obj_FuncGeral.StatusPrincipalNvlUser(this, obj_Usuario_Logado);
        }
    }
}
