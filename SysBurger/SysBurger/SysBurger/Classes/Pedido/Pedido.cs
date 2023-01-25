/***********************************************************************
 *          Nome: Pedido
 *          Obs.: Representa a classe de objetos. Classe com atributos 
 *                privados e métodos (Get/Set) Públicos
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/
using System;

namespace SysBurger
{
    class Pedido
    {
        ~Pedido()
        {

        }

        #region Atributos Privados
        private int v_Cod_Pedido = -1;
        private int v_Cod_Pessoa = -1;
        private int v_Cod_Produto = -1;
        private string v_Ped_Pedido = "";
        private int v_Qnt_Pedido = 0;
        private double v_VlrQnt_Pedido = 0;
        private double v_VlrTot_Pedido = 0;
        private DateTime v_Comp_Pedido = DateTime.MinValue;
        private bool v_Del_Pedido = false;
        #endregion

        #region Métodos Públicos
        public int Cod_Pedido 
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }
        public int Cod_Pessoa 
        { 
            get => v_Cod_Pessoa; 
            set => v_Cod_Pessoa = value; 
        }
        public int Cod_Produto 
        { 
            get => v_Cod_Produto; 
            set => v_Cod_Produto = value; 
        }
        public string Ped_Pedido 
        { 
            get => v_Ped_Pedido; 
            set => v_Ped_Pedido = value; 
        }
        public int Qnt_Pedido 
        { 
            get => v_Qnt_Pedido; 
            set => v_Qnt_Pedido = value; 
        }
        public double VlrQnt_Pedido 
        { 
            get => v_VlrQnt_Pedido; 
            set => v_VlrQnt_Pedido = value; 
        }
        public double VlrTot_Pedido 
        { 
            get => v_VlrTot_Pedido; 
            set => v_VlrTot_Pedido = value; 
        }
        public DateTime Comp_Pedido 
        { 
            get => v_Comp_Pedido; 
            set => v_Comp_Pedido = value; 
        }
        public bool Del_Pedido 
        { 
            get => v_Del_Pedido; 
            set => v_Del_Pedido = value; 
        }
        #endregion
    }
}
