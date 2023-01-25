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
    //ToDo (08/07/2022 - LuigiGM): Fazer pontuação no valor.
    public partial class frm_Produto : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        public Produto obj_Produto_Atual = new Produto();
        Ingrediente_Produto obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();
        BDIngrediente_Produto obj_BDIngrediente_Produto_Atual = new BDIngrediente_Produto();

        public frm_Produto()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.PopulaMask(this);
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Usuario.");
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            tbox_Nm_Produto.Focus();
            obj_FuncGeral.StatusBtn(this, 3);
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                    BDProduto obj_BDProduto = new BDProduto();
                    obj_Produto_Atual = PopulaObjeto();

                    if (obj_Produto_Atual.Cod_Produto != -1)
                    {
                        obj_BDProduto.Alterar(obj_Produto_Atual);
                        obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
                        MessageBox.Show("O produto " + obj_Produto_Atual.Nm_Produto + " foi alterado com sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        obj_Produto_Atual.Cod_Produto = obj_BDProduto.Incluir(obj_Produto_Atual);
                        PopulaTela(obj_Produto_Atual);
                        obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
                        MessageBox.Show("O produto " + obj_Produto_Atual.Nm_Produto + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    PopulaLista();
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 2);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de alterar o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, true);
            tbox_Nm_Produto.Focus();
            obj_FuncGeral.StatusBtn(this, 3);
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //Instância da Classe BD. 
            BDProduto obj_BDProduto = new BDProduto();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de deletar o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                obj_Ingrediente_Produto_Atual.Cod_Produto = obj_Produto_Atual.Cod_Produto;
                obj_BDIngrediente_Produto_Atual.ExcluirProduto(obj_Ingrediente_Produto_Atual);

                if (obj_BDProduto.Deletar(obj_Produto_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deletou o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
                    MessageBox.Show("O produto " + obj_Produto_Atual.Nm_Produto + " foi excluído com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj_FuncGeral.LimpaTela(this);
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 1);
                    PopulaLista();
                }
            }


        }

        /***********************************************************************
        *        Método: PopulaObjeto
        *          Obs.: Responsável por popular o objeto atual com o conteúdo 
        *                do formulário.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private Produto PopulaObjeto()
        {
            Produto obj_Produto = new Produto();

            if (tbox_Cod_Produto.Text != "")
            {
                obj_Produto.Cod_Produto = Convert.ToInt16(tbox_Cod_Produto.Text);
            }

            obj_Produto.Nm_Produto = tbox_Nm_Produto.Text;
            obj_Produto.VlrUnid_Produto = Convert.ToDouble(tbox_VlrUnid_Produto.Text);
            obj_Produto.Desc_Produto = tbox_Desc_Produto.Text;

            return obj_Produto;
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaTela(Produto pobj_Produto)
        {
            if (pobj_Produto.Cod_Produto != -1)
            {
                tbox_Cod_Produto.Text = pobj_Produto.Cod_Produto.ToString();
            }
            tbox_Nm_Produto.Text = pobj_Produto.Nm_Produto.ToString();
            tbox_VlrUnid_Produto.Text = pobj_Produto.VlrUnid_Produto.ToString();
            tbox_Desc_Produto.Text = pobj_Produto.Desc_Produto.ToString();
        }


        /***********************************************************************
        *        Método: PopulaLista
        *          Obs.: Responsável por popular os usuários da tabela na lista 
        *                do formulário.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaLista()
        {
            BDProduto obj_BDProduto = new BDProduto();

            List<Produto> Lista = new List<Produto>();

            ltbox_Produtos.Items.Clear();

            Lista = obj_BDProduto.FindAllProduto();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Del_Produto != true)
                    {
                        ltbox_Produtos.Items.Add(Lista[i].Cod_Produto.ToString() + "- " + Lista[i].Nm_Produto.ToString());
                    }
                }
            }
        }

        private void ltbox_Produtos_Click(object sender, EventArgs e)
        {
            if (ltbox_Produtos.SelectedIndex != -1)
            {
                BDProduto obj_BDProduto = new BDProduto();

                string s_linha = ltbox_Produtos.Items[ltbox_Produtos.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Produto_Atual.Cod_Produto = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Produto_Atual = obj_BDProduto.FindByCodProduto(obj_Produto_Atual);
                PopulaTela(obj_Produto_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);
            if (obj_Produto_Atual.Cod_Produto != -1)
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher no Produto " + obj_Produto_Atual.Cod_Produto.ToString() + ".");
                PopulaTela(obj_Produto_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de criar um Produto.");
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }

        private void tbox_VlrUnid_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this, sender, e);
        }
    }
}
