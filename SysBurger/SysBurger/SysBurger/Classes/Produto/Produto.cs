/***********************************************************************
 *          Nome: Produto
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Produto
    {
        ~Produto()
        {

        }

        #region Atributos Privados
        private int v_Cod_Produto = -1;
        private string v_Nm_Produto = "";
        private double v_VlrUnid_Produto = 0;
        private string v_Desc_Produto = "";
        private bool v_Del_Produto = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Produto 
        { 
            get => v_Cod_Produto; 
            set => v_Cod_Produto = value; 
        }
        public string Nm_Produto 
        { 
            get => v_Nm_Produto; 
            set => v_Nm_Produto = value; 
        }
        public double VlrUnid_Produto 
        { 
            get => v_VlrUnid_Produto; 
            set => v_VlrUnid_Produto = value; 
        }
        public string Desc_Produto 
        { 
            get => v_Desc_Produto; 
            set => v_Desc_Produto = value; 
        }
        public bool Del_Produto 
        { 
            get => v_Del_Produto; 
            set => v_Del_Produto = value; 
        }
        #endregion
    }
}
