/***********************************************************************
 *          Nome: Ingrediente_Produto
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    class Ingrediente_Produto
    {
        ~Ingrediente_Produto()
        {

        }

        #region Atributos Privados
        private int v_Cod_Ingrediente_Produto = -1;
        private int v_Cod_Produto = -1;
        private int v_Cod_Ingrediente = -1;
        private int v_QntUt_Ingrediente_Produto = 0;
        #endregion

        #region Métodos Públicos
        public int Cod_Ingrediente_Produto 
        { 
            get => v_Cod_Ingrediente_Produto; 
            set => v_Cod_Ingrediente_Produto = value; 
        }
        public int Cod_Produto 
        { 
            get => v_Cod_Produto; 
            set => v_Cod_Produto = value; 
        }
        public int Cod_Ingrediente 
        { 
            get => v_Cod_Ingrediente; 
            set => v_Cod_Ingrediente = value; 
        }
        public int QntUt_Ingrediente_Produto 
        { 
            get => v_QntUt_Ingrediente_Produto; 
            set => v_QntUt_Ingrediente_Produto = value; 
        }
        #endregion
    }
}
