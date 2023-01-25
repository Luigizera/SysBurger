/***********************************************************************
 *          Nome: Ingrediente
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Ingrediente
    {
        ~Ingrediente()
        {

        }

        #region Atributos Privados
        private int v_Cod_Ingrediente = -1;
        private string v_Nm_Ingrediente = "";
        private int v_Qnt_Ingrediente = 0;
        private bool v_Atv_Ingrediente = false;
        private bool v_Del_Ingrediente = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Ingrediente 
        { 
            get => v_Cod_Ingrediente; 
            set => v_Cod_Ingrediente = value; 
        }
        public string Nm_Ingrediente 
        { 
            get => v_Nm_Ingrediente; 
            set => v_Nm_Ingrediente = value; 
        }
        public int Qnt_Ingrediente 
        { 
            get => v_Qnt_Ingrediente; 
            set => v_Qnt_Ingrediente = value; 
        }
        public bool Atv_Ingrediente 
        { 
            get => v_Atv_Ingrediente; 
            set => v_Atv_Ingrediente = value; 
        }
        public bool Del_Ingrediente
        { 
            get => v_Del_Ingrediente;
            set => v_Del_Ingrediente = value;
        }
        #endregion
    }
}
