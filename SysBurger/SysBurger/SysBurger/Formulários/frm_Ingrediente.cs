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
    public partial class frm_Ingrediente : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        public Ingrediente obj_Ingrediente_Atual = new Ingrediente();
        Ingrediente_Produto obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();
        BDIngrediente_Produto obj_BDIngrediente_Produto_Atual = new BDIngrediente_Produto();

        public frm_Ingrediente()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.PopulaMask(this);
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Ingrediente.");
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            tbox_Nm_Ingrediente.Focus();
            obj_FuncGeral.StatusBtn(this, 3);
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                    BDIngrediente obj_BDIngrediente = new BDIngrediente();
                    obj_Ingrediente_Atual = PopulaObjeto();

                    if (obj_Ingrediente_Atual.Cod_Ingrediente != -1)
                    {
                        obj_BDIngrediente.Alterar(obj_Ingrediente_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
                    MessageBox.Show("O ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " foi alterado com sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        obj_Ingrediente_Atual.Cod_Ingrediente = obj_BDIngrediente.Incluir(obj_Ingrediente_Atual);
                        PopulaTela(obj_Ingrediente_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " criou o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
                    MessageBox.Show("O ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    PopulaLista();
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 2);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de alterar o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, true);
            tbox_Nm_Ingrediente.Focus();
            obj_FuncGeral.StatusBtn(this, 3);
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDIngrediente obj_BDIngrediente = new BDIngrediente();
            
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de deletar o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                obj_Ingrediente_Produto_Atual.Cod_Ingrediente = obj_Ingrediente_Atual.Cod_Ingrediente;
                obj_BDIngrediente_Produto_Atual.ExcluirIngrediente(obj_Ingrediente_Produto_Atual);

                if (obj_BDIngrediente.Deletar(obj_Ingrediente_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deletou o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
                    MessageBox.Show("O ingrediente " + obj_Ingrediente_Atual.Nm_Ingrediente + " foi excluído com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private Ingrediente PopulaObjeto()
        {
            Ingrediente obj_Ingrediente = new Ingrediente();

            if (tbox_Cod_Ingrediente.Text != "")
            {
                obj_Ingrediente.Cod_Ingrediente = Convert.ToInt16(tbox_Cod_Ingrediente.Text);
            }

            obj_Ingrediente.Nm_Ingrediente = tbox_Nm_Ingrediente.Text;
            obj_Ingrediente.Qnt_Ingrediente = Convert.ToInt16(mtbox_Qnt_Ingrediente.Text);

            if (obj_Ingrediente.Qnt_Ingrediente > 0)
            {
                obj_Ingrediente.Atv_Ingrediente = true;
            }
            else
            {
                obj_Ingrediente.Atv_Ingrediente = false;
            }

            return obj_Ingrediente;
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaTela(Ingrediente pobj_Ingrediente)
        {
            if (pobj_Ingrediente.Cod_Ingrediente != -1)
            {
                tbox_Cod_Ingrediente.Text = pobj_Ingrediente.Cod_Ingrediente.ToString();
            }

            tbox_Nm_Ingrediente.Text = pobj_Ingrediente.Nm_Ingrediente.ToString();
            mtbox_Qnt_Ingrediente.Text = pobj_Ingrediente.Qnt_Ingrediente.ToString();
            
            if (pobj_Ingrediente.Atv_Ingrediente != false)
            {
                lbl_Atv_Ingrediente.Text = "Disponível";
                lbl_Atv_Ingrediente.ForeColor = Color.Green;
            }
            else
            {
                lbl_Atv_Ingrediente.Text = "Indisponível";
                lbl_Atv_Ingrediente.ForeColor = Color.Red;
            }
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
            BDIngrediente obj_BDIngrediente = new BDIngrediente();

            List<Ingrediente> Lista = new List<Ingrediente>();

            ltbox_Ingredientes.Items.Clear();

            Lista = obj_BDIngrediente.FindAllIngrediente();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Del_Ingrediente != true)
                    {
                        if (Lista[i].Del_Ingrediente != true)
                        {
                            ltbox_Ingredientes.Items.Add(Lista[i].Cod_Ingrediente.ToString() + "- " + Lista[i].Nm_Ingrediente.ToString());
                        }
                    }
                }
            }
        }

        private void ltbox_Ingredientes_Click(object sender, EventArgs e)
        {
            if (ltbox_Ingredientes.SelectedIndex != -1)
            {
                BDIngrediente obj_BDIngrediente = new BDIngrediente();

                string s_linha = ltbox_Ingredientes.Items[ltbox_Ingredientes.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Ingrediente_Atual.Cod_Ingrediente = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Ingrediente_Atual = obj_BDIngrediente.FindByCodIngrediente(obj_Ingrediente_Atual);
                PopulaTela(obj_Ingrediente_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);
            if (obj_Ingrediente_Atual.Cod_Ingrediente != -1)
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher no Ingrediente " + obj_Ingrediente_Atual.Cod_Ingrediente.ToString() + ".");
                
                PopulaTela(obj_Ingrediente_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de criar um Ingrediente.");
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }

        private void mtbox_Qnt_Ingrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this,sender,e);
        }
    }
}
