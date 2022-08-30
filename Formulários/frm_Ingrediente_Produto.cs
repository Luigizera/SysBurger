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
    public partial class frm_Ingrediente_Produto : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado;
        Ingrediente_Produto obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();
        Produto obj_Produto_Atual = new Produto();
        Ingrediente obj_Ingrediente_Atual = new Ingrediente();

        public frm_Ingrediente_Produto()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.PopulaMask(this);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Ingrediente do Produto.");
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            tbox_Cod_Produto.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                BDIngrediente_Produto obj_BDIngrediente_Produto = new BDIngrediente_Produto();
                PopulaObjeto(obj_Ingrediente_Produto_Atual, obj_Produto_Atual, obj_Ingrediente_Atual);

                if (obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto != -1)
                {
                    obj_BDIngrediente_Produto.Alterar(obj_Ingrediente_Produto_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
                    MessageBox.Show("O Ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " do Produto " + obj_Produto_Atual.Nm_Produto + " foi alterado com sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto = obj_BDIngrediente_Produto.Incluir(obj_Ingrediente_Produto_Atual);
                    PopulaTela(obj_Ingrediente_Produto_Atual, obj_Produto_Atual, obj_Ingrediente_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " criou o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
                    MessageBox.Show("O Ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " do Produto " + obj_Produto_Atual.Nm_Produto + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                }
                PopulaLista();
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de alterar o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, true);
            tbox_Cod_Produto.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDIngrediente_Produto obj_BDIngrediente_Produto = new BDIngrediente_Produto();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de deletar o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                if (obj_BDIngrediente_Produto.Excluir(obj_Ingrediente_Produto_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deletou o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
                    MessageBox.Show("O Ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " do Produto " + obj_Produto_Atual.Nm_Produto + "foi excluído com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj_FuncGeral.LimpaTela(this);
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
                    PopulaLista();
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            
            obj_FuncGeral.HabilitaTela(this, false);
            if (obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto != -1)
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher no Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
                PopulaTela(obj_Ingrediente_Produto_Atual, obj_Produto_Atual, obj_Ingrediente_Atual);
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
            }
            else
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de criar um no Ingrediente_Produto.");
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            }
        }

        /***********************************************************************
        *        Método: PopulaObjeto
        *          Obs.: Responsável por popular o objeto atual com o conteúdo 
        *                do formulário.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaObjeto(Ingrediente_Produto pobj_Ingrediente_Produto, Produto pobj_Produto, Ingrediente pobj_Ingrediente)
        {
            if (tbox_Cod_Ingrediente_Produto.Text != "")
            {
                pobj_Ingrediente_Produto.Cod_Ingrediente_Produto = Convert.ToInt16(tbox_Cod_Ingrediente_Produto.Text);
            }
            else
            {
                pobj_Ingrediente_Produto.Cod_Ingrediente_Produto = -1;
            }
            pobj_Ingrediente_Produto.Cod_Produto = Convert.ToInt16(tbox_Cod_Produto.Text);
            pobj_Ingrediente_Produto.Cod_Ingrediente = Convert.ToInt16(tbox_Cod_Ingrediente.Text);
            pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto = Convert.ToInt16(tbox_QntUt_Ingrediente_Produto.Text);

            //Produto
            BDProduto obj_BDProduto = new BDProduto();
            pobj_Produto.Cod_Produto = obj_Produto_Atual.Cod_Produto;
            pobj_Produto = obj_BDProduto.FindByCodProduto(pobj_Produto);

            //Ingrediente
            BDIngrediente obj_BDIngrediente = new BDIngrediente();
            pobj_Ingrediente.Cod_Ingrediente = obj_Ingrediente_Atual.Cod_Ingrediente;
            pobj_Ingrediente = obj_BDIngrediente.FindByCodIngrediente(pobj_Ingrediente);
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        private void PopulaTela(Ingrediente_Produto pobj_Ingrediente_Produto, Produto pobj_Produto, Ingrediente pobj_Ingrediente)
        {
            if (pobj_Ingrediente_Produto.Cod_Ingrediente_Produto != -1)
            {
                tbox_Cod_Ingrediente_Produto.Text = pobj_Ingrediente_Produto.Cod_Ingrediente_Produto.ToString();
            }
            tbox_Cod_Produto.Text = pobj_Ingrediente_Produto.Cod_Produto.ToString();
            tbox_Cod_Ingrediente.Text = pobj_Ingrediente_Produto.Cod_Ingrediente.ToString();
            tbox_QntUt_Ingrediente_Produto.Text = pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto.ToString();

            EventArgs e = new EventArgs();
            tbox_Cod_Produto_Leave(tbox_Cod_Produto, e);
            tbox_Cod_Ingrediente_Leave(tbox_Cod_Ingrediente, e);
        }


        /***********************************************************************
        *        Método: PopulaLista
        *          Obs.: Responsável por popular os usuários da tabela na lista 
        *                do formulário.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        private void PopulaLista()
        {
            BDIngrediente_Produto obj_BDIngrediente_Produto = new BDIngrediente_Produto();

            List<Ingrediente_Produto> Lista = new List<Ingrediente_Produto>();

            ltbox_Ingrediente_Produtos.Items.Clear();

            Lista = obj_BDIngrediente_Produto.FindAllIngrediente_Produto();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    Produto obj_Produto = new Produto();
                    BDProduto obj_BDProduto = new BDProduto();
                    obj_Produto.Cod_Produto = Lista[i].Cod_Produto;
                    obj_Produto = obj_BDProduto.FindByCodProduto(obj_Produto);

                    Ingrediente obj_Ingrediente = new Ingrediente();
                    BDIngrediente obj_BDIngrediente = new BDIngrediente();
                    obj_Ingrediente.Cod_Ingrediente = Lista[i].Cod_Ingrediente;
                    obj_Ingrediente = obj_BDIngrediente.FindByCodIngrediente(obj_Ingrediente);
                    
                    ltbox_Ingrediente_Produtos.Items.Add(Lista[i].Cod_Ingrediente_Produto.ToString() + "- " + obj_Produto.Nm_Produto.ToString() + " - " + obj_Ingrediente.Nm_Ingrediente.ToString());
                    
                }
            }
        }


        private void ltbox_Ingrediente_Produtos_Click(object sender, EventArgs e)
        {
            if (ltbox_Ingrediente_Produtos.SelectedIndex != -1)
            {
                BDIngrediente_Produto obj_BDIngrediente_Produto = new BDIngrediente_Produto();

                string s_linha = ltbox_Ingrediente_Produtos.Items[ltbox_Ingrediente_Produtos.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Ingrediente_Produto_Atual = obj_BDIngrediente_Produto.FindByCodIngrediente_Produto(obj_Ingrediente_Produto_Atual);
                PopulaTela(obj_Ingrediente_Produto_Atual, obj_Produto_Atual, obj_Ingrediente_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Ingrediente_Produto " + obj_Ingrediente_Produto_Atual.Cod_Ingrediente_Produto.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void tbox_Cod_Produto_Leave(object sender, EventArgs e)
        {
            obj_Produto_Atual = new Produto();

            if (tbox_Cod_Produto.Text != "")
            {
                BDProduto obj_BDProduto = new BDProduto();
                obj_Produto_Atual.Cod_Produto = Convert.ToInt16(((TextBox)sender).Text);
                obj_Produto_Atual = obj_BDProduto.FindByCodProduto(obj_Produto_Atual);
                if (obj_Produto_Atual != null)
                {
                    lb_Nm_Produto.Text = obj_Produto_Atual.Nm_Produto;
                    lb_VlrUnid_Produto.Text = obj_Produto_Atual.VlrUnid_Produto.ToString();
                    lb_Desc_Produto.Text = obj_Produto_Atual.Desc_Produto;
                }
                else
                {
                    tbox_Cod_Produto.Text = null;
                    lb_Nm_Produto.Text = "";
                    lb_VlrUnid_Produto.Text = "";
                    lb_Desc_Produto.Text = "";
                }
            }
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            obj_frm_Produto.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Produto.ShowDialog();
            tbox_Cod_Produto.Text = obj_frm_Produto.obj_Produto_Atual.Cod_Produto.ToString();
            tbox_Cod_Produto_Leave(tbox_Cod_Produto, e);
        }

        private void btn_Ingrediente_Click(object sender, EventArgs e)
        {
            frm_Ingrediente obj_frm_Ingrediente = new frm_Ingrediente();
            obj_frm_Ingrediente.obj_Usuario_Logado = obj_Usuario_Logado;
            obj_frm_Ingrediente.ShowDialog();
            tbox_Cod_Ingrediente.Text = obj_frm_Ingrediente.obj_Ingrediente_Atual.Cod_Ingrediente.ToString();
            tbox_Cod_Ingrediente_Leave(tbox_Cod_Ingrediente, e);
        }

        private void tbox_Cod_Ingrediente_Leave(object sender, EventArgs e)
        {
            obj_Ingrediente_Atual = new Ingrediente();

            if (tbox_Cod_Ingrediente.Text != "")
            {
                BDIngrediente obj_BDIngrediente = new BDIngrediente();
                obj_Ingrediente_Atual.Cod_Ingrediente = Convert.ToInt16(((TextBox)sender).Text);
                obj_Ingrediente_Atual = obj_BDIngrediente.FindByCodIngrediente(obj_Ingrediente_Atual);
                if (obj_Ingrediente_Atual != null)
                {
                    lb_Nm_Ingrediente.Text = obj_Ingrediente_Atual.Nm_Ingrediente;
                }
                else
                {
                    tbox_Cod_Ingrediente.Text = null;
                    lb_Nm_Ingrediente.Text = "";
                }
            }
        }

        private void tbox_Cod_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this, sender, e);
        }

        private void tbox_Cod_Ingrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this, sender, e);
        }

        private void tbox_QntUt_Ingrediente_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this, sender, e);
        }
    }
}
