/***********************************************************************
 *          Nome: Usuario
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Usuario
    {
        ~Usuario()
        {

        }

        #region Atributos Privados
        private int v_Cod_Usuario = -1;
        private string v_Unm_Usuario = "";
        private string v_Sen_Usuario = "";
        private bool v_Del_Usuario = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Usuario 
        { 
            get => v_Cod_Usuario; 
            set => v_Cod_Usuario = value; 
        }
        public string Unm_Usuario 
        { 
            get => v_Unm_Usuario;
            set => v_Unm_Usuario = value; 
        }
        public string Sen_Usuario 
        { 
            get => v_Sen_Usuario; 
            set => v_Sen_Usuario = value; 
        }
        public bool Del_Usuario
        {
            get => v_Del_Usuario;
            set => v_Del_Usuario = value;
        }
        #endregion
    }
}
