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

        // <SUMMARY>
        /// Vetor de byte utilizados para a criptografia (chave externa)
        /// </SUMMARY>
        private static byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>
        /// Representação de valor em base 64 (chave interna)
        /// O valor represanta a transformação para base64 de 
        /// um conjunto de 32 caracteres (8 * 32 - 256 bits)
        /// a chave é: "Criptografia com Rijndael / AES"
        /// </summary>
        private const string cryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        /***********************************************************************
        * NOME:            Criptografa        
        * METODO:          Criptografa o Password do usuário e retorna o 
        *                   Password criptografado
        * PARAMETRO:       String sPassWord
        * RETORNO:         String 
        * DT CRIAÇÃO:      27/05/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Monstro (mFacine) 
        ***********************************************************************/
        public string Criptografa(string sPassWord)
        {
            try
            {
                //(27/05/2019-mfacine) Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(sPassWord))
                {
                    //(27/05/2019-mfacine) Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(sPassWord);

                    //(27/05/2019-mfacine) Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    //(27/05/2019 - mfacine)
                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    //(27/05/2019 - mfacine)
                    // Cria o espaço de memória para guardar o valor criptografado:                
                    MemoryStream mStream = new MemoryStream();
                    // Instancia o encriptador                 
                    CryptoStream encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //(27/05/2019-mfacine)
                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    encryptor.FlushFinalBlock();
                    // Pega o vetor de bytes da memória e gera a string criptografada                
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    //(27/05/2019-mfacine) Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                //(27/05/2019-mfacine) Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }



        /*****************************************************************************
        * Nome           : DesCriptografa
        * Procedimento   : Descriptografa o password do usuário e retorna o 
        *                  pass descriptografado
        * Parametros     : sCriptoPassWord
        * Data  Criação  : 27/05/2018
        * Data Alteração : -
        * Escrito por    : mfacine
        * ***************************************************************************/
        public string DesCriptografa(string sCriptoPassWord)
        {
            try
            {
                //(27/05/2019-mfacine) Se a string não está vazia, executa a criptografia           
                if (!string.IsNullOrEmpty(sCriptoPassWord))
                {
                    //(27/05/2019-mfacine) Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(cryptoKey);
                    byte[] bText = Convert.FromBase64String(sCriptoPassWord);

                    // Instancia a classe de criptografia Rijndael                
                    Rijndael rijndael = new RijndaelManaged();

                    //(27/05/2019-mfacine)
                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    //(27/05/2019-mfacine) Cria o espaço de memória para guardar o valor DEScriptografado:               
                    MemoryStream mStream = new MemoryStream();

                    //(27/05/2019-mfacine) Instancia o Decriptador                 
                    CryptoStream decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    //(27/05/2019-mfacine)
                    // Faz a escrita dos dados criptografados no espaço de memória   
                    decryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    decryptor.FlushFinalBlock();
                    // Instancia a classe de codificação para que a string venha de forma correta         
                    UTF8Encoding utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    //(27/05/2019-mfacine) Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                //(27/05/2019-mfacine) Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao descriptografar", ex);
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
                        if (ctrl is TextBox)
                        {
                            //SE A SENHA DA PESSOA FOR VAZIA, PEGA DO BANCO E POPULA
                            if (ctrl.Enabled != false || ((TextBox)ctrl).Name.Equals("tbox_Sen_Pessoa"))
                            {
                                if (((TextBox)ctrl).Text == "")
                                {
                                    MessageBox.Show("Um campo não foi preenchido.", "ENTRADA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    ((TextBox)ctrl).Focus();
                                    return true;
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
                                if (((MaskedTextBox)ctrl).Text == "" || ((MaskedTextBox)ctrl).Text == ((MaskedTextBox)ctrl).MaskedTextProvider.ToString())
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
                            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
                            {
                                e.Handled = true;
                            }

                            // Apenas aceita números decimais
                            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                            {
                                e.Handled = true;
                            }
                        }
                        if (ctrl is MaskedTextBox)
                        {
                            if (Convert.ToInt16(ctrl.Tag) == 2)
                            {
                                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                                {
                                    e.Handled = true;
                                }
                            }
                            if (Convert.ToInt16(ctrl.Tag) == 3)
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

                        if (ctrl is PictureBox)
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
        public void StatusBtn(Form pobj_Form, int pi_Status)
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
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Finalizar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    if (ctrl.Name == "btn_Cancelar_Pedido")
                                    {
                                        ctrl.Enabled = true;
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


    }
}
