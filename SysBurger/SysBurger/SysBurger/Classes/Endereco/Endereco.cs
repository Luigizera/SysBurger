/***********************************************************************
 *          Nome: Endereco
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Endereco
    {
        ~Endereco()
        {

        }

        #region Atributos Privados
        private int v_Cod_Endereco = -1;
        private int v_Cod_Pessoa = -1;
        private string v_End_Endereco = "";
        private string v_Bai_Endereco = "";
        private string v_Cid_Endereco = "";
        private string v_UF_Endereco = "";
        private string v_CEP_Endereco = "";
        private bool v_Del_Endereco = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Endereco 
        { 
            get => v_Cod_Endereco; 
            set => v_Cod_Endereco = value; 
        }
        public int Cod_Pessoa 
        { 
            get => v_Cod_Pessoa; 
            set => v_Cod_Pessoa = value; 
        }
        public string End_Endereco 
        { 
            get => v_End_Endereco; 
            set => v_End_Endereco = value;
        }
        public string Bai_Endereco 
        { 
            get => v_Bai_Endereco; 
            set => v_Bai_Endereco = value; 
        }
        public string Cid_Endereco 
        {
            get => v_Cid_Endereco; 
            set => v_Cid_Endereco = value; 
        }
        public string UF_Endereco 
        {
            get => v_UF_Endereco; 
            set => v_UF_Endereco = value; 
        }
        public string CEP_Endereco 
        {
            get => v_CEP_Endereco; 
            set => v_CEP_Endereco = value;
        }
        public bool Del_Endereco 
        { 
            get => v_Del_Endereco; 
            set => v_Del_Endereco = value; 
        }
        #endregion
    }
}
