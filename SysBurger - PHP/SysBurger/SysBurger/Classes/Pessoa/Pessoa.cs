/***********************************************************************
 *          Nome: Pessoa
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Pessoa
    {
        ~Pessoa()
        {

        }

        #region Atributos Privados
        private int v_Cod_Pessoa = -1;
        private string v_Nm_Pessoa = "";
        private string v_Snm_Pessoa = "";
        private string v_CPF_Pessoa = "";
        private string v_Cel_Pessoa = "";
        private string v_Mail_Pessoa = "";
        private string v_Sen_Pessoa = "";
        private int v_Nvl_Pessoa = 0; //O NÍVEL DA PESSOA É UTILIZADO NO SITE
        private bool v_Del_Pessoa = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Pessoa 
        { 
            get => v_Cod_Pessoa; 
            set => v_Cod_Pessoa = value; 
        }
        public string Nm_Pessoa 
        { 
            get => v_Nm_Pessoa; 
            set => v_Nm_Pessoa = value; 
        }
        public string Snm_Pessoa 
        { 
            get => v_Snm_Pessoa; 
            set => v_Snm_Pessoa = value; 
        }
        public string CPF_Pessoa 
        { 
            get => v_CPF_Pessoa; 
            set => v_CPF_Pessoa = value; 
        }
        public string Cel_Pessoa 
        { 
            get => v_Cel_Pessoa; 
            set => v_Cel_Pessoa = value; 
        }
        public string Mail_Pessoa 
        { 
            get => v_Mail_Pessoa; 
            set => v_Mail_Pessoa = value; 
        }
        public bool Del_Pessoa 
        { 
            get => v_Del_Pessoa; 
            set => v_Del_Pessoa = value; 
        }
        public int Nvl_Pessoa 
        { 
            get => v_Nvl_Pessoa; 
            set => v_Nvl_Pessoa = value; 
        }
        public string Sen_Pessoa 
        { 
            get => v_Sen_Pessoa; 
            set => v_Sen_Pessoa = value; 
        }
        #endregion
    }
}
