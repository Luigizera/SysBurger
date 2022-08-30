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
    public partial class frm_Pessoa : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        public Pessoa obj_Pessoa_Atual = new Pessoa();
        Endereco obj_Endereco_Atual = new Endereco();

        public frm_Pessoa()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.PopulaMask(this);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Pessoa.");
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.HabilitaControle(tbox_Cod_Endereco, false);
            obj_FuncGeral.LimpaTela(this);
            tbox_Nm_Pessoa.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
            this.Height = 328;
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                BDPessoa obj_BDPessoa = new BDPessoa();
                obj_Pessoa_Atual = PopulaObjeto();

                if (obj_Pessoa_Atual.Cod_Pessoa != -1)
                {
                    obj_BDPessoa.Alterar(obj_Pessoa_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " alterou a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
                    MessageBox.Show("O usuário " + obj_Pessoa_Atual.Nm_Pessoa + " foi alterado com sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    obj_Pessoa_Atual.Cod_Pessoa = obj_BDPessoa.Incluir(obj_Pessoa_Atual);
                    PopulaTela(obj_Pessoa_Atual);
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " criou a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
                    MessageBox.Show("O usuário " + obj_Pessoa_Atual.Nm_Pessoa + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                PopulaLista();
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                this.Height = 400;
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de alterar a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
            obj_FuncGeral.HabilitaTela(this, true);
            tbox_Nm_Pessoa.Focus();
            obj_FuncGeral.StatusBtn(this, 3, obj_Usuario_Logado);
            this.Height = 400;
            tbox_Cod_Endereco.Visible = true;
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            //Instância da Classe BD. 
            BDPessoa obj_BDPessoa = new BDPessoa();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " fez menção de deletar a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                if (obj_BDPessoa.Deletar(obj_Pessoa_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " deletou a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
                    MessageBox.Show("O usuário " + obj_Pessoa_Atual.Nm_Pessoa + " foi excluído com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (obj_Pessoa_Atual.Cod_Pessoa != -1)
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher na Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
                PopulaTela(obj_Pessoa_Atual);
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
            }
            else
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de criar uma Pessoa.");
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1, obj_Usuario_Logado);
            }
            this.Height = 328;
        }

        /***********************************************************************
        *        Método: PopulaObjeto
        *          Obs.: Responsável por popular o objeto atual com o conteúdo 
        *                do formulário.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private Pessoa PopulaObjeto()
        {
            Pessoa obj_Pessoa = new Pessoa();
            Pessoa obj_Pessoa_Senha = new Pessoa();

            

            if (tbox_Cod_Pessoa.Text != "")
            {
                obj_Pessoa.Cod_Pessoa = Convert.ToInt16(tbox_Cod_Pessoa.Text);
            }
            obj_Pessoa.Nm_Pessoa = tbox_Nm_Pessoa.Text;
            obj_Pessoa.Snm_Pessoa = tbox_Snm_Pessoa.Text;
            obj_Pessoa.CPF_Pessoa = mtbox_CPF_Pessoa.Text;
            obj_Pessoa.Cel_Pessoa = mtbox_Cel_Pessoa.Text;
            obj_Pessoa.Mail_Pessoa = tbox_Mail_Pessoa.Text;


            if (tbox_Sen_Pessoa.Text == "" && obj_Pessoa.Cod_Pessoa != -1)
            {
                BDPessoa obj_BDPessoa = new BDPessoa();
                obj_Pessoa_Senha = obj_BDPessoa.FindByCodPessoa(obj_Pessoa);
                obj_Pessoa.Sen_Pessoa = obj_Pessoa_Senha.Sen_Pessoa;
                obj_Pessoa.Nvl_Pessoa = obj_Pessoa_Senha.Nvl_Pessoa;
            }
            else
            {
                if (tbox_Sen_Pessoa.Text == "" && obj_Pessoa.Cod_Pessoa == -1)
                {
                    //CRIA UMA SENHA ALEATÓRIA
                    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    char[] Charsarr = new char[10];
                    Random random = new Random();

                    for (int i = 0; i < Charsarr.Length; i++)
                    {
                        Charsarr[i] = characters[random.Next(characters.Length)];
                    }
                    string x = new String(Charsarr);

                    //"LUIGIZERA" fica em LowerCase, por isso problemas no banco por fazer em UpperCase
                    string Criptografa_Lower = obj_FuncGeral.Criptografa(x + "LUIGIZERA");
                    obj_Pessoa.Sen_Pessoa = Criptografa_Lower.ToLower();
                    obj_Pessoa.Nvl_Pessoa = 0;
                }
                else
                {
                    //"LUIGIZERA" fica em LowerCase, por isso problemas no banco por fazer em UpperCase
                    string Criptografa_Lower = obj_FuncGeral.Criptografa(tbox_Sen_Pessoa.Text + "LUIGIZERA");
                    obj_Pessoa.Sen_Pessoa = Criptografa_Lower.ToLower();
                    obj_Pessoa.Nvl_Pessoa = 0;
                }
            }

            return obj_Pessoa;
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaTela(Pessoa pobj_Pessoa)
        {
            if (pobj_Pessoa.Cod_Pessoa != -1)
            {
                tbox_Cod_Pessoa.Text = pobj_Pessoa.Cod_Pessoa.ToString();
            }
            tbox_Nm_Pessoa.Text = pobj_Pessoa.Nm_Pessoa.ToString();
            tbox_Snm_Pessoa.Text  = pobj_Pessoa.Snm_Pessoa.ToString();
            mtbox_CPF_Pessoa.Text = pobj_Pessoa.CPF_Pessoa.ToString();
            mtbox_Cel_Pessoa.Text = pobj_Pessoa.Cel_Pessoa.ToString();
            tbox_Mail_Pessoa.Text = pobj_Pessoa.Mail_Pessoa.ToString();
            
            BDEndereco obj_BDEndereco = new BDEndereco();
            if(!(obj_Endereco_Atual != null))
            {
                obj_Endereco_Atual = new Endereco();
                obj_Endereco_Atual.Cod_Pessoa = pobj_Pessoa.Cod_Pessoa;
            }
            else
            {
                obj_Endereco_Atual.Cod_Pessoa = pobj_Pessoa.Cod_Pessoa;
            }
            
            List<Endereco> Lista = new List<Endereco>();

            EventArgs e = new EventArgs();

            Lista = obj_BDEndereco.FindAllEnderecoByCodPessoa(obj_Endereco_Atual);
            if (Lista != null)
            {
                tbox_Cod_Endereco.Text = Lista[0].Cod_Endereco.ToString();
                tbox_Cod_Endereco_Leave(tbox_Cod_Endereco, e);
            }
            else
            {
                tbox_Cod_Endereco.Text = "";
                lb_End_Endereco.Text = "";
                lb_Bai_Endereco.Text = "";
                lb_Cid_Endereco.Text = "";
                lb_UF_Endereco.Text = "";
                lb_CEP_Endereco.Text = "";
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
            BDPessoa obj_BDPessoa = new BDPessoa();

            List<Pessoa> Lista = new List<Pessoa>();

            ltbox_Pessoas.Items.Clear();

            Lista = obj_BDPessoa.FindAllPessoa();

            if (Lista != null)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (Lista[i].Del_Pessoa != true)
                    {
                        ltbox_Pessoas.Items.Add(Lista[i].Cod_Pessoa.ToString() + "- " + Lista[i].Nm_Pessoa.ToString() + " " + Lista[i].Snm_Pessoa.ToString());
                    }
                }
            }
        }

        private void ltbox_Pessoas_Click(object sender, EventArgs e)
        {
            if (ltbox_Pessoas.SelectedIndex != -1)
            {
                BDPessoa obj_BDPessoa = new BDPessoa();

                string s_linha = ltbox_Pessoas.Items[ltbox_Pessoas.SelectedIndex].ToString();
                int i_Pos = 0;


                for (int t = 0; t < s_linha.Length; t++)
                {
                    if (s_linha.Substring(t, 1) == "-")
                    {
                        i_Pos = t;
                        break;
                    }
                }

                obj_Pessoa_Atual.Cod_Pessoa = Convert.ToInt16(s_linha.Substring(0, i_Pos));
                obj_Pessoa_Atual = obj_BDPessoa.FindByCodPessoa(obj_Pessoa_Atual);
                PopulaTela(obj_Pessoa_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou a Pessoa " + obj_Pessoa_Atual.Cod_Pessoa.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2, obj_Usuario_Logado);
                obj_FuncGeral.HabilitaTela(this, false);
                this.Height = 400;

            }
        }

        private void btn_Endereco_Click(object sender, EventArgs e)
        {
            frm_Endereco obj_frm_Endereco = new frm_Endereco();

            obj_frm_Endereco.i_Cod_Pessoa = obj_Pessoa_Atual.Cod_Pessoa;
            obj_frm_Endereco.ShowDialog();

            tbox_Cod_Endereco.Text = obj_frm_Endereco.obj_Endereco_Atual.Cod_Endereco.ToString();

            tbox_Cod_Endereco_Leave(tbox_Cod_Endereco, e);
        }

        private void tbox_Cod_Endereco_Leave(object sender, EventArgs e)
        {
            obj_Endereco_Atual = new Endereco();

            if (tbox_Cod_Endereco.Text != "")
            {
                BDEndereco obj_BDEndereco = new BDEndereco();

                obj_Endereco_Atual.Cod_Endereco = Convert.ToInt16(((TextBox)sender).Text);
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
                    tbox_Cod_Endereco.Text = "";
                    lb_End_Endereco.Text = "";
                    lb_Bai_Endereco.Text = "";
                    lb_Cid_Endereco.Text = "";
                    lb_UF_Endereco.Text = "";
                    lb_CEP_Endereco.Text = "";
                }

            }
        }

        private void tbox_Cod_Endereco_KeyPress(object sender, KeyPressEventArgs e)
        {
            obj_FuncGeral.DigitaNumero(this, sender, e);
        }
    }
}
