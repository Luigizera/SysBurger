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
    public partial class frm_Endereco : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        public Endereco obj_Endereco_Atual = new Endereco();
        public int i_Cod_Pessoa = -1;

        public frm_Endereco()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.PopulaMask(this);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Endereço.");
            tbox_Cod_Pessoa.Text = i_Cod_Pessoa.ToString();
            tbox_Cid_Endereco.Text = "Ribeirão Preto";
            cbox_UF_Endereco.Text = "SP";
            tbox_End_Endereco.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                BDEndereco obj_BDEndereco = new BDEndereco();
                obj_Endereco_Atual = PopulaObjeto();
                obj_FuncGeral.GravaLog("");

                if (obj_Endereco_Atual.Cod_Endereco != -1)
                {
                    obj_BDEndereco.Alterar(obj_Endereco_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou o Endereço "+ obj_Endereco_Atual.Cod_Endereco.ToString() +".");
                    MessageBox.Show("O endereço " + obj_Endereco_Atual.End_Endereco + " foi alterado com sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj_Endereco_Atual.Cod_Endereco = obj_BDEndereco.Incluir(obj_Endereco_Atual);
                    PopulaTela(obj_Endereco_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " criou o Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
                    MessageBox.Show("O endereço " + obj_Endereco_Atual.End_Endereco + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PopulaLista();
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                this.Close();
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de alterar o Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, true);
            tbox_End_Endereco.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //Instância da Classe BD. 
            BDEndereco obj_BDEndereco = new BDEndereco();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de deletar o Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                if (obj_BDEndereco.Deletar(obj_Endereco_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deletou o Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
                    MessageBox.Show("O endereço " + obj_Endereco_Atual.End_Endereco + " foi deletado com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj_FuncGeral.LimpaTela(this);
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
                    PopulaLista();
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher no Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, false);
            this.Close();
        }

        /***********************************************************************
        *        Método: PopulaObjeto
        *          Obs.: Responsável por popular o objeto atual com o conteúdo 
        *                do formulário.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private Endereco PopulaObjeto()
        {
            Endereco obj_Endereco = new Endereco();

            if (tbox_Cod_Endereco.Text != "")
            {
                obj_Endereco.Cod_Endereco = Convert.ToInt16(tbox_Cod_Endereco.Text);
            }
            obj_Endereco.Cod_Pessoa = Convert.ToInt16(tbox_Cod_Pessoa.Text);
            obj_Endereco.End_Endereco = tbox_End_Endereco.Text;
            obj_Endereco.Bai_Endereco = tbox_Bai_Endereco.Text;
            obj_Endereco.Cid_Endereco = tbox_Cid_Endereco.Text;
            obj_Endereco.CEP_Endereco = mtbox_CEP_Endereco.Text;
            obj_Endereco.UF_Endereco = cbox_UF_Endereco.Text;

            return obj_Endereco;
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaTela(Endereco pobj_Endereco)
        {
            if (pobj_Endereco.Cod_Endereco != -1)
            {
                tbox_Cod_Endereco.Text = pobj_Endereco.Cod_Endereco.ToString();
            }
            tbox_Cod_Pessoa.Text = pobj_Endereco.Cod_Pessoa.ToString();
            tbox_End_Endereco.Text = pobj_Endereco.End_Endereco.ToString();
            tbox_Bai_Endereco.Text = pobj_Endereco.Bai_Endereco.ToString();
            tbox_Cid_Endereco.Text = pobj_Endereco.Cid_Endereco.ToString();
            mtbox_CEP_Endereco.Text = pobj_Endereco.CEP_Endereco.ToString();
            cbox_UF_Endereco.Text = pobj_Endereco.UF_Endereco.ToString();

            EventArgs e = new EventArgs();
            tbox_Cod_Pessoa_Leave(tbox_Cod_Pessoa, e);
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
            BDEndereco obj_BDEndereco = new BDEndereco();

            List<Endereco> Lista = new List<Endereco>();

            ltbox_Enderecos.Items.Clear();

            Lista = obj_BDEndereco.FindAllEnderecoByCodPessoa(obj_Endereco_Atual);

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Del_Endereco != true)
                    {
                        ltbox_Enderecos.Items.Add(Lista[i].Cod_Endereco.ToString() + "- " + Lista[i].End_Endereco.ToString());
                    }
                }
            }
        }

        private void ltbox_Enderecos_Click(object sender, EventArgs e)
        {
            if (ltbox_Enderecos.SelectedIndex != -1)
            {
                BDEndereco obj_BDEndereco = new BDEndereco();

                string s_linha = ltbox_Enderecos.Items[ltbox_Enderecos.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Endereco_Atual.Cod_Endereco = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Endereco_Atual = obj_BDEndereco.FindByCodEndereco(obj_Endereco_Atual);
                PopulaTela(obj_Endereco_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Endereço " + obj_Endereco_Atual.Cod_Endereco.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void tbox_Cod_Pessoa_Leave(object sender, EventArgs e)
        {
            if (tbox_Cod_Pessoa.Text != "")
            {
                BDPessoa obj_BDPessoa = new BDPessoa();
                Pessoa obj_Pessoa = new Pessoa();
                obj_Pessoa.Cod_Pessoa = Convert.ToInt16(((TextBox)sender).Text);
                obj_Pessoa = obj_BDPessoa.FindByCodPessoa(obj_Pessoa);
                if (obj_Pessoa != null)
                {
                    lb_Nm_Pessoa.Text = obj_Pessoa.Nm_Pessoa;
                    lb_Snm_Pessoa.Text = obj_Pessoa.Snm_Pessoa;
                    lb_CPF_Pessoa.Text = obj_Pessoa.CPF_Pessoa;
                    lb_Cel_Pessoa.Text = obj_Pessoa.Cel_Pessoa;
                    lb_Mail_Pessoa.Text = obj_Pessoa.Mail_Pessoa;
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

        private void frm_Endereco_Shown(object sender, EventArgs e)
        {
            btn_Novo_Click(btn_Novo, e);
            obj_Endereco_Atual.Cod_Pessoa = i_Cod_Pessoa;
            PopulaTela(obj_Endereco_Atual);
            tbox_Cid_Endereco.Text = "Ribeirão Preto";
            cbox_UF_Endereco.Text = "SP";
            PopulaLista();
        }
    }
}
