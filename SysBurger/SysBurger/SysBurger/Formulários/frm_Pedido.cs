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
    public partial class frm_Pedido : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Usuario obj_Usuario_Logado = new Usuario();
        Pedido obj_Pedido_Atual = new Pedido();
        Produto obj_Produto_Atual = new Produto();
        Pessoa obj_Pessoa_Atual = new Pessoa();
        Ingrediente_Produto obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();
        
        //Cria um "número" de pedido
        string s_cod_pedido = "";
        Random random = new Random();
        //StreamWriter Pedido
        int sw_pedido = 0;
        

        public frm_Pedido()
        {
            InitializeComponent();
            PopulaLista();
            obj_FuncGeral.PopulaMask(this);
            obj_FuncGeral.StatusBtn(this, 1);
            obj_FuncGeral.HabilitaTela(this, false);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " clicou no botão Novo no formulário Pedido.");
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.LimpaTela(this);
            mtbox_Cod_Pessoa.Focus();
            obj_FuncGeral.StatusBtn(this, 3);
            if(s_cod_pedido != "")
            {
                s_cod_pedido = "";
            }
            s_cod_pedido = obj_FuncGeral.Criptografa(random.Next(int.MinValue, int.MaxValue) + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + random.Next(int.MinValue, int.MaxValue)).Substring(0, 7);
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (obj_FuncGeral.VerificaNulos(this) != true)
            {
                    BDPedido obj_BDPedido = new BDPedido();
                    PopulaObjeto(obj_Pedido_Atual, obj_Produto_Atual, obj_Pessoa_Atual);

                    if (!(obj_Pedido_Atual.Cod_Pedido != -1))
                    {
                        BDIngrediente_Produto obj_BDIngrediente_Produto_Atual = new BDIngrediente_Produto();
                        List<Ingrediente_Produto> ListaProdutos = new List<Ingrediente_Produto>();
                        obj_Ingrediente_Produto_Atual.Cod_Produto = obj_Produto_Atual.Cod_Produto;
                        ListaProdutos = obj_BDIngrediente_Produto_Atual.FindByCodProduto(obj_Ingrediente_Produto_Atual);

                        if (ListaProdutos != null)
                        {
                            for (int i = 0; i < ListaProdutos.Count; i++)
                            {
                                Ingrediente_Produto obj_Ingrediente_Produto = new Ingrediente_Produto();
                                BDIngrediente_Produto obj_BDIngrediente_Produto = new BDIngrediente_Produto();
                                obj_Ingrediente_Produto.Cod_Ingrediente_Produto = ListaProdutos[i].Cod_Ingrediente_Produto;
                                obj_Ingrediente_Produto = obj_BDIngrediente_Produto.FindByCodIngrediente_Produto(obj_Ingrediente_Produto);

                                Ingrediente obj_Ingrediente = new Ingrediente();
                                BDIngrediente obj_BDIngrediente = new BDIngrediente();
                                obj_Ingrediente.Cod_Ingrediente = ListaProdutos[i].Cod_Ingrediente;
                                obj_Ingrediente = obj_BDIngrediente.FindByCodIngrediente(obj_Ingrediente);

                                obj_Ingrediente.Qnt_Ingrediente = obj_Ingrediente.Qnt_Ingrediente - (obj_Ingrediente_Produto.QntUt_Ingrediente_Produto * obj_Pedido_Atual.Qnt_Pedido);
                                if (obj_Ingrediente.Qnt_Ingrediente < 10)
                                {
                                    if (!(obj_Ingrediente.Qnt_Ingrediente != 0))
                                    {
                                        obj_Ingrediente.Qnt_Ingrediente = 0;
                                    }
                                    obj_Ingrediente.Atv_Ingrediente = false;
                                    MessageBox.Show("O Ingrediente " + obj_Ingrediente.Nm_Ingrediente + " está em FALTA", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    obj_Ingrediente.Atv_Ingrediente = true;
                                }
                                obj_BDIngrediente.Alterar(obj_Ingrediente);
                            }
                        }
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " criou o Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
                    obj_Pedido_Atual.Cod_Pedido = obj_BDPedido.Incluir(obj_Pedido_Atual);
                        PopulaTela(obj_Pedido_Atual, obj_Produto_Atual, obj_Pessoa_Atual);
                        MessageBox.Show("A Pessoa " + obj_Pessoa_Atual.Nm_Pessoa + " com pedido do Produto " + obj_Produto_Atual.Nm_Produto + " foi inserido com sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    }

                    //ADICIONAR MAIS
                    DialogResult vResp = MessageBox.Show("Deseja adicionar mais produtos?", "Adicionar mais", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (vResp == DialogResult.Yes)
                    {
                        obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " quis adicionar mais Produtos no Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
                        obj_FuncGeral.HabilitaControle(mtbox_Cod_Pessoa, false);
                        obj_FuncGeral.HabilitaControle(btn_Pessoa, false);
                        tbox_Cod_Pedido.Text = "";

                        obj_Pedido_Atual = new Pedido();
                        obj_Produto_Atual = new Produto();
                        obj_Pessoa_Atual = new Pessoa();
                        obj_Ingrediente_Produto_Atual = new Ingrediente_Produto();

                        obj_FuncGeral.StatusBtn(this, 3);
                        PopulaLista();
                    }
                    else
                    {
                        obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " terminou de adicionar Produtos no Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
                        StreamWriter sw = new StreamWriter(Connection.StreamWriterPath() + "\\Pedido_" + sw_pedido + ".txt");
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.WriteLine("                      RELATÓRIO GERENCIAL");
                        sw.WriteLine("                        CONF. DE CONTA");
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.WriteLine("                      CONFERÊNCIA DE CONTA");
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.WriteLine("Data da compra: {0}", obj_Pedido_Atual.Comp_Pedido);
                        sw.WriteLine("Nome do comprador: {0} {1}", obj_Pessoa_Atual.Nm_Pessoa, obj_Pessoa_Atual.Snm_Pessoa);
                        sw.WriteLine("Código da venda: {0}", obj_Pedido_Atual.Ped_Pedido);
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.WriteLine("Produto           Quantidade          Vlr.Unid            Vlr.Item");
                        sw.WriteLine("------------------------------------------------------------------");

                        BDPedido obj_BDPedido_Atual = new BDPedido();
                        List<Pedido> ListaPedido = new List<Pedido>();
                        ListaPedido = obj_BDPedido_Atual.FindByCodPed(obj_Pedido_Atual);
                        if (ListaPedido != null)
                        {
                            for (int i = 0; i < ListaPedido.Count; i++)
                            {
                                Produto obj_Produto = new Produto();
                                BDProduto obj_BDProduto = new BDProduto();
                                obj_Produto.Cod_Produto = ListaPedido[i].Cod_Produto;
                                obj_Produto = obj_BDProduto.FindByCodProduto(obj_Produto);

                                Pedido obj_Pedido = new Pedido();
                                BDPedido obj_BDPedido1 = new BDPedido();
                                obj_Pedido.Cod_Pedido = ListaPedido[i].Cod_Pedido;
                                obj_Pedido = obj_BDPedido1.FindByCodPedido(obj_Pedido);
                                sw.WriteLine("{0}               {1}             R$ {2}      =      R$ {3}",
                                obj_Produto.Nm_Produto,
                                obj_Pedido.Qnt_Pedido,
                                obj_Produto.VlrUnid_Produto,
                                obj_Pedido.VlrQnt_Pedido);
                            }
                        }
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.WriteLine("                  Valor Total: R$ {0}", obj_Pedido_Atual.VlrTot_Pedido);
                        sw.WriteLine("------------------------------------------------------------------");
                        sw.Close();
                        sw_pedido += 1;
                        obj_FuncGeral.HabilitaTela(this, false);
                        obj_FuncGeral.StatusBtn(this, 2);
                        PopulaLista();
                    
                }
            }
        }

        private void btn_Finalizar_Click(object sender, EventArgs e)
        {
            BDPedido obj_BDPedido = new BDPedido();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " Fez menção de finalizar o Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Finalização do Pedido?", "Finalizar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                if (obj_BDPedido.Deletar(obj_Pedido_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " finalizou o Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
                    obj_FuncGeral.LimpaTela(this);
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 1);
                    PopulaLista();
                }
            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDPedido obj_BDPedido = new BDPedido();
            obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " Fez menção de cancelar o Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
            DialogResult vResp = MessageBox.Show("Confirma a Finalização do Pedido?", "Finalizar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (vResp == DialogResult.Yes)
            {
                if (obj_BDPedido.Excluir(obj_Pedido_Atual))
                {
                    obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " cancelou o Pedido " + obj_Pedido_Atual.Ped_Pedido.ToString() + ".");
                    MessageBox.Show("Os pedidos da Pessoa " + obj_Pessoa_Atual.Nm_Pessoa + " foram finalizados com sucesso.", "Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    obj_FuncGeral.LimpaTela(this);
                    obj_FuncGeral.HabilitaTela(this, false);
                    obj_FuncGeral.StatusBtn(this, 1);
                    PopulaLista();
                }
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, false);
            if (obj_Pedido_Atual.Cod_Pedido != -1)
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de mecher no Pedido " + obj_Pedido_Atual.Cod_Pedido.ToString() + ".");
                PopulaTela(obj_Pedido_Atual, obj_Produto_Atual, obj_Pessoa_Atual);
                obj_FuncGeral.StatusBtn(this, 2);
            }
            else
            {
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " desistiu de criar um Pedido.");
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }

        /***********************************************************************
        *        Método: PopulaObjeto
        *          Obs.: Responsável por popular o objeto atual com o conteúdo 
        *                do formulário.
        *   Dt. Criação: 22/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        private void PopulaObjeto(Pedido pobj_Pedido, Produto pobj_Produto, Pessoa pobj_Pessoa)
        {
            if (tbox_Cod_Pedido.Text != "")
            {
                pobj_Pedido.Cod_Pedido = Convert.ToInt16(tbox_Cod_Pedido.Text);
            }
            else
            {
                pobj_Pedido.Cod_Pedido = -1;
            }
            pobj_Pedido.Cod_Produto = Convert.ToInt16(tbox_Cod_Produto.Text);
            pobj_Pedido.Cod_Pessoa = Convert.ToInt16(mtbox_Cod_Pessoa.Text);
            pobj_Pedido.Qnt_Pedido = Convert.ToInt16(tbox_Qnt_Pedido.Text);
            pobj_Pedido.Comp_Pedido = DateTime.Now;
            pobj_Pedido.Ped_Pedido = s_cod_pedido;

            //Produto
            BDProduto obj_BDProduto = new BDProduto();
            pobj_Produto.Cod_Produto = obj_Produto_Atual.Cod_Produto;
            pobj_Produto = obj_BDProduto.FindByCodProduto(pobj_Produto);

            pobj_Pedido.VlrQnt_Pedido = pobj_Produto.VlrUnid_Produto * Convert.ToDouble(pobj_Pedido.Qnt_Pedido);

            //Valor Total
            BDPedido obj_BDPedido_Atual = new BDPedido();
            Pedido FindByCodPed = new Pedido();
            List<Pedido> ListaPedido = new List<Pedido>();

            FindByCodPed.Ped_Pedido = pobj_Pedido.Ped_Pedido;
            ListaPedido = obj_BDPedido_Atual.FindByCodPed(FindByCodPed);
            if (ListaPedido != null)
            {
                pobj_Pedido.VlrTot_Pedido = pobj_Pedido.VlrQnt_Pedido;
                for (int i = 0; i < ListaPedido.Count; i++)
                {
                    Pedido obj_Pedido = new Pedido();
                    BDPedido obj_BDPedido = new BDPedido();
                    obj_Pedido.Cod_Pedido = ListaPedido[i].Cod_Pedido;
                    obj_Pedido = obj_BDPedido.FindByCodPedido(obj_Pedido);

                    pobj_Pedido.VlrTot_Pedido += obj_Pedido.VlrQnt_Pedido;
                    pobj_Pedido.Comp_Pedido = obj_Pedido.Comp_Pedido;
                    obj_BDPedido.AlterarValor(pobj_Pedido);
                    obj_BDPedido.AlterarData(pobj_Pedido);
                }
            }
            else
            {
                pobj_Pedido.Comp_Pedido = DateTime.Now;
                pobj_Pedido.VlrTot_Pedido = pobj_Pedido.VlrQnt_Pedido;
            }

            //Pessoa
            BDPessoa obj_BDPessoa = new BDPessoa();
            pobj_Pessoa.Cod_Pessoa = obj_Pessoa_Atual.Cod_Pessoa;
            pobj_Pessoa = obj_BDPessoa.FindByCodPessoa(pobj_Pessoa);
        }

        /***********************************************************************
        *        Método: PopulaTela
        *          Obs.: Responsável por popular o formulário com o conteúdo 
        *                do objeto atual.
        *   Dt. Criação: 22/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        private void PopulaTela(Pedido pobj_Pedido, Produto pobj_Produto, Pessoa pobj_Pessoa)
        {
            if (pobj_Pedido.Cod_Pedido != -1)
            {
                tbox_Cod_Pedido.Text = pobj_Pedido.Cod_Pedido.ToString();
            }
            tbox_Cod_Produto.Text = pobj_Pedido.Cod_Produto.ToString();
            mtbox_Cod_Pessoa.Text = pobj_Pedido.Cod_Pessoa.ToString();
            tbox_Qnt_Pedido.Text = pobj_Pedido.Qnt_Pedido.ToString();
            lb_Ped_Pedido.Text = pobj_Pedido.Ped_Pedido.ToString();
            lb_VlrTot_Pedido.Text = pobj_Pedido.VlrTot_Pedido.ToString();
            lb_Comp_Pedido.Text = pobj_Pedido.Comp_Pedido.ToString();

            EventArgs e = new EventArgs();
            tbox_Cod_Produto_Leave(tbox_Cod_Produto, e);
            mtbox_Cod_Pessoa_Leave(mtbox_Cod_Pessoa, e);
        }


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
                    
                    if (Lista[i].Del_Pedido != true)
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
                PopulaTela(obj_Pedido_Atual, obj_Produto_Atual, obj_Pessoa_Atual);
                obj_FuncGeral.GravaLog("O Usuário " + obj_Usuario_Logado.Cod_Usuario.ToString() + " selecionou o Pedido " + obj_Pedido_Atual.Cod_Pedido.ToString() + ".");
                obj_FuncGeral.StatusBtn(this, 2);
                obj_FuncGeral.HabilitaTela(this, false);

            }
        }

        private void btn_Produto_Click(object sender, EventArgs e)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            obj_frm_Produto.ShowDialog();
            tbox_Cod_Produto.Text = obj_frm_Produto.obj_Produto_Atual.Cod_Produto.ToString();
            tbox_Cod_Produto_Leave(tbox_Cod_Produto, e);
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
                }
                else
                {
                    tbox_Cod_Produto.Text = null;
                    lb_Nm_Produto.Text = "";
                    lb_VlrUnid_Produto.Text = "";
                }
            }
        }

        private void btn_Pessoa_Click(object sender, EventArgs e)
        {
            frm_Pessoa obj_frm_Pessoa = new frm_Pessoa();
            obj_frm_Pessoa.ShowDialog();
            mtbox_Cod_Pessoa.Text = obj_frm_Pessoa.obj_Pessoa_Atual.Cod_Pessoa.ToString();
            mtbox_Cod_Pessoa_Leave(mtbox_Cod_Pessoa, e);
        }

        private void mtbox_Cod_Pessoa_Leave(object sender, EventArgs e)
        {
            obj_Pessoa_Atual = new Pessoa();

            if (mtbox_Cod_Pessoa.Text != "")
            {
                BDPessoa obj_BDPessoa = new BDPessoa();
                obj_Pessoa_Atual.Cod_Pessoa = Convert.ToInt16(((MaskedTextBox)sender).Text);
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
                    mtbox_Cod_Pessoa = null;
                    lb_Nm_Pessoa.Text = "";
                    lb_Snm_Pessoa.Text = "";
                    lb_CPF_Pessoa.Text = "";
                    lb_Cel_Pessoa.Text = "";
                    lb_Mail_Pessoa.Text = "";
                }
            }
        }

        
    }
}
