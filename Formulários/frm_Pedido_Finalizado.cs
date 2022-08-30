using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SysBurger
{
    public partial class frm_Pedido_Finalizado : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        Pedido obj_Pedido_Atual = new Pedido();
        Produto obj_Produto_Atual = new Produto();
        Pessoa obj_Pessoa_Atual = new Pessoa();
        Endereco obj_Endereco_Atual = new Endereco();
        Ingrediente_Produto obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();

        //Cria um "número" de pedido
        string s_cod_pedido = "";
        Random random = new Random();


        public frm_Pedido_Finalizado()
        {
            InitializeComponent();
            PopulaLista();
            TitulosLView();
            obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.PopulaMask(this);
        }
        /*
        /***********************************************************************
       *        Método: TitulosLView
       *          Obs.: Responsável por Titular a List View
       *   Dt. Criação: 02/06/2022
       * Dt. Alteração: --
       *    Criada por: mFacine (Monstro)
       ***********************************************************************/
        private void TitulosLView()
        {
            ltview_Produtos.View = View.Details;
            ltview_Produtos.Columns.Add("Código", 50);
            ltview_Produtos.Columns.Add("Nome", 65);
            ltview_Produtos.Columns.Add("Valor", 75);
            ltview_Produtos.Columns.Add("Descrição", 203);
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 22/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        /*
        private void PopulaTela(Pedido pobj_Pedido, Produto pobj_Produto, Pessoa pobj_Pessoa)
        {
            if (pobj_Pedido.Cod_Pedido != -1)
            {
                tbox_Cod_Pedido.Text = pobj_Pedido.Cod_Pedido.ToString();
                mtbox_Cod_Produto.Text = pobj_Pedido.Cod_Produto.ToString();
                tbox_Cod_Pessoa.Text = pobj_Pedido.Cod_Pessoa.ToString();
                mtbox_Cod_Endereco.Text = pobj_Pedido.Cod_Endereco.ToString();
                mtbox_Qnt_Pedido.Text = pobj_Pedido.Qnt_Pedido.ToString();
                lb_Ped_Pedido.Text = pobj_Pedido.Ped_Pedido.ToString();
                lb_VlrTot_Pedido.Text = pobj_Pedido.VlrTot_Pedido.ToString();
                lb_Comp_Pedido.Text = pobj_Pedido.Comp_Pedido.ToString();

                EventArgs e = new EventArgs();
                mtbox_Cod_Produto_Leave(mtbox_Cod_Produto, e);
                tbox_Cod_Pessoa_Leave(tbox_Cod_Pessoa, e);
            }
            
        }
        */

        /***********************************************************************
        *        Método: PopulaLista
        *          Obs.: Responsável por popular os usuários da tabela na lista 
        *                do formulário.
        *   Dt. Criação: 22/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        private void PopulaLista()
        {
            BDPedido obj_BDPedido = new BDPedido();

            List<Pedido> Lista = new List<Pedido>();

            ltbox_Pedidos.Items.Clear();

            Lista = obj_BDPedido.FindAllPedido();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    Produto obj_Produto = new Produto();
                    BDProduto obj_BDProduto = new BDProduto();
                    obj_Produto.Cod_Produto = Lista[i].Cod_Produto;
                    obj_Produto = obj_BDProduto.FindByCodProduto(obj_Produto);

                    Pessoa obj_Pessoa = new Pessoa();
                    BDPessoa obj_BDPessoa = new BDPessoa();
                    obj_Pessoa.Cod_Pessoa = Lista[i].Cod_Pessoa;
                    obj_Pessoa = obj_BDPessoa.FindByCodPessoa(obj_Pessoa);

                    if (Lista[i].Del_Pedido != false)
                    {
                        ltbox_Pedidos.Items.Add(Lista[i].Cod_Pedido.ToString() + "- " + obj_Pessoa.Nm_Pessoa.ToString() + " - " + obj_Produto.Nm_Produto.ToString());
                    }
                }
            }
        }


        private void ltbox_Pedidos_Click(object sender, EventArgs e)
        {
            if (ltbox_Pedidos.SelectedIndex != -1)
            {
                BDPedido obj_BDPedido = new BDPedido();

                string s_linha = ltbox_Pedidos.Items[ltbox_Pedidos.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Pedido_Atual.Cod_Pedido = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Pedido_Atual = obj_BDPedido.FindByCodPedido(obj_Pedido_Atual);
                //PopulaTela(obj_Pedido_Atual, obj_Produto_Atual, obj_Pessoa_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Pedido " + obj_Pedido_Atual.Cod_Pedido.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }
        /*
        private void mtbox_Cod_Produto_Leave(object sender, EventArgs e)
        {
            obj_Produto_Atual = new Produto();

            if (mtbox_Cod_Produto.Text != "")
            {
                BDProduto obj_BDProduto = new BDProduto();
                obj_Produto_Atual.Cod_Produto = Convert.ToInt16(((MaskedTextBox)sender).Text);
                obj_Produto_Atual = obj_BDProduto.FindByCodProduto(obj_Produto_Atual);
                if (obj_Produto_Atual != null)
                {
                    lb_Nm_Produto.Text = obj_Produto_Atual.Nm_Produto;
                    lb_VlrUnid_Produto.Text = obj_Produto_Atual.VlrUnid_Produto.ToString();
                }
                else
                {
                    mtbox_Cod_Produto.Text = null;
                    lb_Nm_Produto.Text = "";
                    lb_VlrUnid_Produto.Text = "";
                }
            }
        }

        private void tbox_Cod_Pessoa_Leave(object sender, EventArgs e)
        {
            obj_Pessoa_Atual = new Pessoa();

            if (tbox_Cod_Pessoa.Text != "")
            {
                BDPessoa obj_BDPessoa = new BDPessoa();
                obj_Pessoa_Atual.Cod_Pessoa = Convert.ToInt16(((TextBox)sender).Text);
                obj_Pessoa_Atual = obj_BDPessoa.FindByCodPessoa(obj_Pessoa_Atual);
                if (obj_Pessoa_Atual != null)
                {
                    lb_Nm_Pessoa.Text = obj_Pessoa_Atual.Nm_Pessoa;
                    lb_Snm_Pessoa.Text = obj_Pessoa_Atual.Snm_Pessoa;
                    lb_CPF_Pessoa.Text = obj_Pessoa_Atual.CPF_Pessoa;
                    lb_Cel_Pessoa.Text = obj_Pessoa_Atual.Cel_Pessoa;
                    lb_Mail_Pessoa.Text = obj_Pessoa_Atual.Mail_Pessoa;
                }
                else
                {
                    tbox_Cod_Pessoa.Text = "";
                    lb_Nm_Pessoa.Text = "";
                    lb_Snm_Pessoa.Text = "";
                    lb_CPF_Pessoa.Text = "";
                    lb_Cel_Pessoa.Text = "";
                    lb_Mail_Pessoa.Text = "";
                }
            }
        }

        private void mtbox_Cod_Endereco_Leave(object sender, EventArgs e)
        {
            obj_Endereco_Atual = new Endereco();

            if (mtbox_Cod_Endereco.Text != "")
            {
                BDEndereco obj_BDEndereco = new BDEndereco();

                obj_Endereco_Atual.Cod_Endereco = Convert.ToInt16(((MaskedTextBox)sender).Text);
                obj_Endereco_Atual = obj_BDEndereco.FindByCodEndereco(obj_Endereco_Atual);
                if (obj_Endereco_Atual != null)
                {
                    lb_End_Endereco.Text = obj_Endereco_Atual.End_Endereco;
                    lb_Bai_Endereco.Text = obj_Endereco_Atual.Bai_Endereco;
                    lb_Cid_Endereco.Text = obj_Endereco_Atual.Cid_Endereco;
                    lb_UF_Endereco.Text = obj_Endereco_Atual.UF_Endereco;
                    lb_CEP_Endereco.Text = obj_Endereco_Atual.CEP_Endereco;

                }
                else
                {
                    mtbox_Cod_Endereco.Text = "";
                    lb_End_Endereco.Text = "";
                    lb_Bai_Endereco.Text = "";
                    lb_Cid_Endereco.Text = "";
                    lb_UF_Endereco.Text = "";
                    lb_CEP_Endereco.Text = "";
                }

            }
        }
        */
        
    }
}
