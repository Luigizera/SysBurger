/***********************************************************************
 *          Nome: BDProduto
 *          obs.: Representa a classe de Banco de Dados Produto. 
 *                A Classe utiliza o objeto Connection para acessar o BD
 *   Dt. Criação: 06/07/2022
 * Dt. Alteração: --
 *    Criada por: LuigiGM 
 * *********************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Text;

namespace SysBurger
{
    class BDProduto
    {
        //Destructor da Classe
        ~BDProduto()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Produto
         *          Obs.: Responsável por incluir um registro na tabela Produto.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Produto pobj_Produto)
        {
            frm_Produto obj_frm_Produto = new frm_Produto();
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_PRODUTO " +
                                   "( " +
                                   "S_NM_PRODUTO, " +
                                   "D_VLRUNID_PRODUTO, " +
                                   "S_IMG_PRODUTO, " +
                                   "S_DESC_PRODUTO " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@S_NM_PRODUTO, " +
                                   "REPLACE(@D_VLRUNID_PRODUTO, ',', '.'), " +
                                   "@S_IMG_PRODUTO, " +
                                   "@S_DESC_PRODUTO " +
                                   "); " +
                                   " SELECT MAX(I_COD_PRODUTO) AS 'ID' FROM TB_PRODUTO ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@S_NM_PRODUTO", pobj_Produto.Nm_Produto);
            obj_Cmd.Parameters.AddWithValue("@D_VLRUNID_PRODUTO", pobj_Produto.VlrUnid_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_DESC_PRODUTO", pobj_Produto.Desc_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_IMG_PRODUTO", pobj_Produto.Img_Produto);


            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();
                //(06/07/2022 - LuigiGM) Executar o comando de forma escalar
                int ID = Convert.ToInt16(obj_Cmd.ExecuteScalar());
                //(06/07/2022 - LuigiGM) Fechar a Conexão
                obj_Con.Close();
                return ID;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA INCLUSÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

        }

        /***********************************************************************
        *        Método: Alterar
        *     Parametro: Objeto Produto
        *          Obs.: Responsável por alterar um registro na tabela Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Produto pobj_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_PRODUTO SET " +
                                   "S_NM_PRODUTO = @S_NM_PRODUTO, " +
                                   "D_VLRUNID_PRODUTO  = REPLACE(@D_VLRUNID_PRODUTO, ',', '.'), " +
                                   "S_DESC_PRODUTO  = @S_DESC_PRODUTO, " +
                                   "S_IMG_PRODUTO = @S_IMG_PRODUTO " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO AND B_DEL_PRODUTO = 0;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_NM_PRODUTO", pobj_Produto.Nm_Produto);
            obj_Cmd.Parameters.AddWithValue("@D_VLRUNID_PRODUTO", pobj_Produto.VlrUnid_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_DESC_PRODUTO", pobj_Produto.Desc_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_IMG_PRODUTO", pobj_Produto.Img_Produto);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();
                //(06/07/2022 - LuigiGM) Executar o comando de forma escalar
                obj_Cmd.ExecuteNonQuery();
                //(06/07/2022 - LuigiGM) Fechar a Conexão
                obj_Con.Close();
                return true;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA ALTERAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /***********************************************************************
        *        Método: Excluir
        *     Parametro: Objeto Produto
        *          Obs.: Responsável por Excluir um registro na tabela Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Excluir(Produto pobj_Produto)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "DELETE FROM TB_PRODUTO " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            try
            {
                obj_Con.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Con.Close();
                return true;
            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA EXCLUSÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /***********************************************************************
        *        Método: Deletar
        *     Parametro: Objeto Ingrediente
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Produto.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Produto pobj_Produto)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_PRODUTO SET " +
                                   "B_DEL_PRODUTO  = 1 " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            try
            {
                obj_Con.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Con.Close();
                return true;
            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA EXCLUSÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /***********************************************************************
        *        Método: FindByCodProduto
        *     Parametro: Objeto Produto
        *          Obs.: Responsável por buscar um registro na tabela Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Produto FindByCodProduto(Produto pobj_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PRODUTO " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO AND REPLACE(D_VLRUNID_PRODUTO, '.', ',');";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                    pobj_Produto.Nm_Produto = obj_Dtr["S_NM_PRODUTO"].ToString();
                    pobj_Produto.VlrUnid_Produto = Convert.ToDouble(obj_Dtr["D_VLRUNID_PRODUTO"]);
                    pobj_Produto.Desc_Produto = obj_Dtr["S_DESC_PRODUTO"].ToString();
                    pobj_Produto.Img_Produto = Encoding.ASCII.GetString(Convert.FromBase64String(Convert.ToBase64String((byte[])obj_Dtr["S_IMG_PRODUTO"])));
                    pobj_Produto.Del_Produto = (Convert.ToInt16(obj_Dtr["B_DEL_PRODUTO"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Produto;
                }
                else
                {
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return null;
                }

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA BUSCA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }



        /***********************************************************************
        *        Método: FindAllProduto
        *          Obs.: Responsável por buscar todos os registros na tabela Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Produto> FindAllProduto()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PRODUTO";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Produto> Lista = new List<Produto>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Produto obj_Produto = new Produto();
                        obj_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                        obj_Produto.Nm_Produto = obj_Dtr["S_NM_PRODUTO"].ToString();
                        obj_Produto.VlrUnid_Produto = Convert.ToInt16(obj_Dtr["D_VLRUNID_PRODUTO"]);
                        obj_Produto.Desc_Produto = obj_Dtr["S_DESC_PRODUTO"].ToString();
                        obj_Produto.Img_Produto = Encoding.ASCII.GetString(Convert.FromBase64String(Convert.ToBase64String((byte[])obj_Dtr["S_IMG_PRODUTO"])));
                        obj_Produto.Del_Produto = (Convert.ToInt16(obj_Dtr["B_DEL_PRODUTO"]) == 1) ? true : false;
                        Lista.Add(obj_Produto);
                    }
                    //(06/07/2022 - LuigiGM) Fecho a conexão com o BD
                    obj_Con.Close();

                    //(06/07/2022 - LuigiGM) Fecho o DataReader
                    obj_Dtr.Close();

                    return Lista;

                }
                else
                {
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return null;
                }

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA BUSCA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
