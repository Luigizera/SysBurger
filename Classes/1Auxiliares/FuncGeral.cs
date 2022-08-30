/***********************************************************************
 *          Nome: FuncGeral
 *          obs.: Representa a classe de Funções Gerais. 
 *                A Classe possui metodos públicos que serão utilizados 
 *                por Formulários e Classes
 *   Dt. Criação: 07/07/2022
 * Dt. Alteração: --
 *    Criada por: LuigiGM 
 * *********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace SysBurger
{
    class FuncGeral
    {
        //Pega o diretório do programa - Usado no GravaLog
        string path = Environment.CurrentDirectory;

        /***********************************************************************
        * NOME:            Criptografa        
        * METODO:          Criptografa o Password do usuário e retorna o 
        *                   Password criptografado
        * PARAMETRO:       String sPassWord
        * RETORNO:         String 
        * DT CRIAÇÃO:      07/07/2022    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     LuigiGM
        ***********************************************************************/
        public string Criptografa(string sPassWord)
        {
            try
            {
                if (!string.IsNullOrEmpty(sPassWord))
                {
                    var md5 = MD5.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(sPassWord);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Converte o byte array para uma string hexadecimal (0-9 a-F)
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
                else
                {        
                    return null;
                }
            }
            catch (Exception ex)
            {         
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        /***********************************************************************
        *        Método: GravaLog
        *     Parametro: Formulário Ativo
        *          Obs.: Responsável por Gravar o as ações realizadas por um usuário.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void GravaLog(string s_Txt)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path + "log.txt", true))
                {
                    //Write a line of text
                    sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") + " - " + s_Txt);

                    //Close the file
                    sw.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        /***********************************************************************
        *        Método: VerificaNulos
        *     Parametro: Formulário Ativo
        *          Obs.: Responsável por Verificar se os componentes editáveis 
        *          de texto estão nulos no formulários ativo.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: 03/08/2022 
        *               - Transformado em bool
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool VerificaNulos(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox && ((TextBox)ctrl).Visible != false)
                        {
                            //SE A SENHA DA PESSOA FOR VAZIA, PEGA DO BANCO E POPULA
                            if (ctrl.Enabled != false)
                            {
                                if(((TextBox)ctrl).Name != "tbox_Sen_Pessoa")
                                {
                                    if (((TextBox)ctrl).Text == "")
                                    {

                                        MessageBox.Show("Um campo não foi preenchido.", "ENTRADA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        ((TextBox)ctrl).Focus();
                                        return true;
                                    }
                                }
                                
                            }
                        }

                        if (ctrl is PictureBox)
                        {
                            if (ctrl.Enabled != false)
                            {
                                if (((PictureBox)ctrl).Image == null)
                                {
                                    MessageBox.Show("A imagem não foi preenchida.", "ENTRADA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ((MaskedTextBox)ctrl).Focus();
                                    return true;
                                }
                            }
                        }

                        if (ctrl is MaskedTextBox)
                        {
                            if (ctrl.Enabled != false)
                            {
                                if (((MaskedTextBox)ctrl).MaskCompleted != true)
                                {
                                    MessageBox.Show("Um campo não foi preenchido.", "ENTRADA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ((MaskedTextBox)ctrl).Focus();
                                    return true;
                                }
                            }
                        }

                        if (ctrl is ComboBox)
                        {
                            if (ctrl.Enabled != false)
                            {
                                if (((ComboBox)ctrl).Text == "")
                                {
                                    MessageBox.Show("Um campo não foi preenchido.", "ENTRADA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ((ComboBox)ctrl).Focus();
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        /***********************************************************************
        *        Método: LimpaTela
        *     Parametro: Formulário Ativo
        *          Obs.: Responsável por Limpar os componentes editáveis dos 
        *                formulários.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void LimpaTela(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ((TextBox)ctrl).Clear();
                        }

                        if (ctrl is MaskedTextBox)
                        {
                            ((MaskedTextBox)ctrl).Clear();
                        }

                        if (ctrl is PictureBox)
                        {
                            ((PictureBox)ctrl).Image = null;
                        }

                        if (ctrl is ComboBox)
                        {
                            ((ComboBox)ctrl).SelectedIndex = -1;
                        }

                        if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Checked = false;
                        }

                        if (ctrl is Label && Convert.ToInt16(ctrl.Tag) == 1)
                        {
                            ((Label)ctrl).Text = "";
                        }

                    }
                }
            }
        }

        /****************************************************************************
        * Nome: : DigitaNumero
        * Observações : Digita apenas números no Mask com tag 2
        * Parametro : Formulário
        * Dt. Criação: 20/08/2022
        * Dt. Alteração: --
        * Criada por: LuigiGM
        ****************************************************************************/

        public void DigitaNumero(Form pobj_Form, object sender, KeyPressEventArgs e)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            if (Convert.ToInt16(ctrl.Tag) == 2) //INT
                            {
                                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                                {
                                    e.Handled = true;
                                }
                            }
                            if (Convert.ToInt16(ctrl.Tag) == 3) //DOUBLE
                            {
                                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                                {
                                    e.Handled = true;
                                }

                                // Apenas aceita números decimais
                                if ((e.KeyChar == ',') && ((sender as MaskedTextBox).Text.IndexOf(',') > -1))
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                        if (ctrl is MaskedTextBox)
                        {
                            if (Convert.ToInt16(ctrl.Tag) == 2) //INT
                            {
                                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                                {
                                    e.Handled = true;
                                }
                            }
                            if (Convert.ToInt16(ctrl.Tag) == 3) //DOUBLE
                            {
                                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') )
                                {
                                    e.Handled = true;
                                }

                                // Apenas aceita números decimais
                                if ((e.KeyChar == ',') && ((sender as MaskedTextBox).Text.IndexOf(',') > -1))
                                {
                                    e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }


        /****************************************************************************
        * Nome: : PopulaMask
        * Observações : Popula com uma máscara um MaskTextBox
        * Parametro : Formulário
        * Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        * Criada por: LuigiGM
        ****************************************************************************/

        public void PopulaMask(Form pobj_Form)
        {
            bool TipoValida = true;

            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is MaskedTextBox)
                        {
                            switch (Convert.ToInt16(ctrl.Tag))
                            {
                                case 2:
                                    {
                                        int x = 0;
                                        TipoValida = int.TryParse(ctrl.Text, out x);
                                        break;
                                    }
                                case 3:
                                    {
                                        double x = 0;
                                        TipoValida = double.TryParse(ctrl.Text, out x);
                                        break;
                                    }
                                case 4:
                                    {
                                        //DATA
                                        ((MaskedTextBox)ctrl).Mask = "00/00/0000";
                                        break;
                                    }
                                case 5:
                                    {
                                        //CEP
                                        ((MaskedTextBox)ctrl).Mask = "00000-000";
                                        break;
                                    }

                                case 6:
                                    {
                                        //CPF
                                        ((MaskedTextBox)ctrl).Mask = "000.000.000-00";
                                        break;
                                    }

                                case 7:
                                    {
                                        ((MaskedTextBox)ctrl).Mask = "00.000.000/0000-00";
                                        break;
                                    }
                                case 8:
                                    {
                                        //TELEFONE
                                        ((MaskedTextBox)ctrl).Mask = "(00)0000-0000";
                                        break;
                                    }
                                case 9:
                                    {
                                        //CELULAR
                                        ((MaskedTextBox)ctrl).Mask = "(00)00000-0000";
                                        break;
                                    }
                                case 10:
                                    {
                                        //HORA
                                        ((MaskedTextBox)ctrl).Mask = "00:00";
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
        }

        /***********************************************************************
        *        Método: HabilitaTela
        *     Parametro: Formulário Ativo e Booleano (True ou False)
        *          Obs.: Responsável por Habilitar os componentes editáveis dos 
        *                formulários.
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void HabilitaTela(Form pobj_Form, bool b_Hab)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detail")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox && Convert.ToInt16(ctrl.Tag) != 1)
                        {
                            ((TextBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is MaskedTextBox && Convert.ToInt16(ctrl.Tag) != 1)
                        {
                            ((MaskedTextBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is CheckBox)
                        {
                            ((CheckBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is ComboBox)
                        {
                            ((ComboBox)ctrl).Enabled = b_Hab;
                        }

                        if(ctrl is PictureBox)
                        {
                            ((PictureBox)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is Button)
                        {
                            ((Button)ctrl).Enabled = b_Hab;
                        }

                        if (ctrl is ListView)
                        {
                            ((ListView)ctrl).Enabled = b_Hab;
                        }
                    }
                }
            }
        }

        /***********************************************************************
        *        Método: HabilitaControle
        *     Parametro: Formulário Ativo e Booleano (True ou False)
        *          Obs.: Responsável por Habilitar os componentes editáveis dos 
        *                formulários.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void HabilitaControle(Control ctrl, bool b_Hab)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).Enabled = b_Hab;
            }

            if (ctrl is MaskedTextBox)
            {
                ((MaskedTextBox)ctrl).Enabled = b_Hab;
            }

            if (ctrl is PictureBox)
            {
                ((PictureBox)ctrl).Enabled = b_Hab;
            }

            if (ctrl is CheckBox)
            {
                ((CheckBox)ctrl).Enabled = b_Hab;
            }

            if (ctrl is ComboBox)
            {
                ((ComboBox)ctrl).Enabled = b_Hab;
            }

            if (ctrl is Button)
            {
                ((Button)ctrl).Enabled = b_Hab;
            }

            if (ctrl is ListView)
            {
                ((ListView)ctrl).Enabled = b_Hab;
            }
        }

        /***********************************************************************
        *        Método: StatusBtn
        *     Parametro: Formulário Ativo, uma variável int e um objeto Usuario
        *          Obs.: Responsável por trazer o Status dos botões na tela dos 
        *                formulários.
        *                Status (1, 2 ou 3)
        *                caso 1 -> btn_Novo será true e os demais false. 
        *                caso 2 -> os três primeiros serão true e os demais false.
        *                caso 3 -> os três primeiros serão false e os demais true.
        *                
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void StatusBtn(Form pobj_Form, int pi_Status, Usuario pobj_Usuario)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Button")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        switch (pi_Status)
                        {
                            case 1:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Finalizar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar_Pedido")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    break;
                                }

                            case 2:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        if(pobj_Usuario.Nvl_Usuario == 0)
                                        {
                                            ctrl.Enabled = false;
                                        }
                                        else
                                        {
                                            ctrl.Enabled = true;
                                        }
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        if (pobj_Usuario.Nvl_Usuario == 0 || pobj_Usuario.Nvl_Usuario == 2)
                                        {
                                            ctrl.Enabled = false;
                                        }
                                        else
                                        {
                                            ctrl.Enabled = true;
                                        }
                                    }

                                    if (ctrl.Name == "btn_Finalizar")
                                    {
                                        if (pobj_Usuario.Nvl_Usuario == 2)
                                        {
                                            ctrl.Enabled = false;
                                        }
                                        else
                                        {
                                            ctrl.Enabled = true;
                                        }
                                    }

                                    if (ctrl.Name == "btn_Cancelar_Pedido")
                                    {
                                        if (pobj_Usuario.Nvl_Usuario == 2)
                                        {
                                            ctrl.Enabled = false;
                                        }
                                        else
                                        {
                                            ctrl.Enabled = true;
                                        }
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    break;
                                }

                            case 3:
                                {

                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Cancelar_Pedido")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Finalizar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    break;
                                }
                        }
                    }
                }
            }
        }

        /***********************************************************************
        *        Método: StatusPrincipalNvlUser
        *     Parametro: Formulário Ativo e um objeto Usuario
        *          Obs.: Responsável por trazer o Status dos botões na tela do
        *                formulário Principal baseado no Nível do Usuário.
        *                0  - Estagiário
        *                1  - Funcionário
        *                2  - EStoquista
        *                10 - Administrador
        *   Dt. Criação: 07/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public void StatusPrincipalNvlUser(Form pobj_Form, Usuario pobj_Usuario)
        {
            foreach (Control btn in pobj_Form.Controls) // ENCONTRA OS BOTÕES
            {
                if(btn is Button)
                {
                    switch (pobj_Usuario.Nvl_Usuario)
                    {
                        case 0: //Estagiário
                            {
                                if (btn.Name == "btn_Usuario")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Pessoa")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Produtos")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Ingrediente_Produto")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Pedido")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Sair")
                                {
                                    btn.Enabled = true;
                                }
                                break;
                            }

                        case 1: //Funcionário
                            {
                                if (btn.Name == "btn_Usuario")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Pessoa")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Produtos")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente_Produto")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Pedido")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Sair")
                                {
                                    btn.Enabled = true;
                                }
                                break;
                            }

                        case 2: //Estoquista
                            {
                                if (btn.Name == "btn_Usuario")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Pessoa")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Produtos")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Ingrediente")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente_Produto")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Pedido")
                                {
                                    btn.Enabled = false;
                                }

                                if (btn.Name == "btn_Sair")
                                {
                                    btn.Enabled = true;
                                }
                                break;
                            }

                        case 10: //Administrador
                            {
                                if (btn.Name == "btn_Usuario")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Pessoa")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Produtos")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Ingrediente_Produto")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Pedido")
                                {
                                    btn.Enabled = true;
                                }

                                if (btn.Name == "btn_Sair")
                                {
                                    btn.Enabled = true;
                                }
                                break;
                            }
                    }
                }
            }
        }

        /***********************************************************************
        *        Método: ImageToBase64
        *     Parametro: Formulário Ativo e um objeto Usuario
        *          Obs.: Responsável por transformar a Imagem em texto de Base64
        *   Dt. Criação: 25/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Converte a imagem em byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Converte o byte[] para texto de Base64
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        /***********************************************************************
        *        Método: Base64ToImage
        *     Parametro: Formulário Ativo e um objeto Usuario
        *          Obs.: Responsável por transformar o texto de Base64 em Imagem 
        *   Dt. Criação: 25/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Image Base64ToImage(string base64String)
        {
            // Converte o texto de base64 em byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Converte o byte[] em Imagem
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }


    }
}
