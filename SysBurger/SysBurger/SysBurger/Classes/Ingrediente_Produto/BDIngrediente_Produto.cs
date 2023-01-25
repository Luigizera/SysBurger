/***********************************************************************
 *          Nome: BDIngrediente_Produto
 *          obs.: Representa a classe de Banco de Dados Ingrediente_Produto. 
 *                A Classe utiliza o objeto Connection para acessar o BD
 *   Dt. Criação: 06/07/2022
 * Dt. Alteração: --
 *    Criada por: LuigiGM 
 * *********************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SysBurger
{
    class BDIngrediente_Produto
    {
        //Destructor da Classe
        ~BDIngrediente_Produto()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Ingrediente_Produto
         *          Obs.: Responsável por incluir um registro na tabela Ingrediente_Produto.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_INGREDIENTE_PRODUTO " +
                                   "( " +
                                   "I_COD_PRODUTO, " +
                                   "I_COD_INGREDIENTE, " +
                                   "I_QNTUT_INGREDIENTE_PRODUTO " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@I_COD_PRODUTO, " +
                                   "@I_COD_INGREDIENTE, " +
                                   "@I_QNTUT_INGREDIENTE_PRODUTO " +
                                   "); " +
                                   " SELECT IDENT_CURRENT('TB_INGREDIENTE_PRODUTO') AS 'ID' ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Ingrediente_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE", pobj_Ingrediente_Produto.Cod_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@I_QNTUT_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto);

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
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por alterar um registro na tabela Ingrediente_Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_INGREDIENTE_PRODUTO SET " +
                                   "I_COD_PRODUTO = @I_COD_PRODUTO, " +
                                   "I_COD_INGREDIENTE  = @I_COD_INGREDIENTE, " +
                                   "I_QNTUT_INGREDIENTE_PRODUTO  = @I_QNTUT_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE " +
                                   "AND I_COD_PRODUTO = @I_COD_PRODUTO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Ingrediente_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Ingrediente_Produto.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE", pobj_Ingrediente_Produto.Cod_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@I_QNTUT_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto);

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
        *        Método: ExcluirProduto
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por Excluir os registros na tabela Ingrediente_Produto.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        public bool ExcluirProduto(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "DELETE FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Produto);
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
        *        Método: ExcluirIngrediente
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por Excluir os registros na tabela Ingrediente_Produto.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        public bool ExcluirIngrediente(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "DELETE FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Ingrediente);
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
        *        Método: Excluir
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por Excluir os registros na tabela Ingrediente_Produto.
        *   Dt. Criação: 11/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        public bool Excluir(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "DELETE FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_INGREDIENTE_PRODUTO = @I_COD_INGREDIENTE_PRODUTO;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Ingrediente_Produto);
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
        *          Obs.: Responsável por buscar todos os registros baseados no código
        *                do Produto na tabela Ingrediente_Produto.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Ingrediente_Produto> FindByCodProduto(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_PRODUTO = @I_COD_PRODUTO";

            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Ingrediente_Produto.Cod_Produto);

            try
            {
                obj_Con.Open();

                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Ingrediente_Produto> Lista = new List<Ingrediente_Produto>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Ingrediente_Produto obj_Ingrediente_Produto = new Ingrediente_Produto();
                        obj_Ingrediente_Produto.Cod_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE_PRODUTO"]);
                        obj_Ingrediente_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                        obj_Ingrediente_Produto.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                        obj_Ingrediente_Produto.QntUt_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_QNTUT_INGREDIENTE_PRODUTO"]);
                        Lista.Add(obj_Ingrediente_Produto);
                    }
                    obj_Con.Close();

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


        /***********************************************************************
        *        Método: FindByCodIngrediente_Produto
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por buscar um registro na tabela Ingrediente_Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Ingrediente_Produto FindByCodIngrediente_Produto(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_INGREDIENTE_PRODUTO = @I_COD_INGREDIENTE_PRODUTO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Ingrediente_Produto);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Ingrediente_Produto.Cod_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE_PRODUTO"]);
                    pobj_Ingrediente_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                    pobj_Ingrediente_Produto.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                    pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_QNTUT_INGREDIENTE_PRODUTO"]);
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Ingrediente_Produto;
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
        *        Método: FindByCodIngrediente
        *     Parametro: Objeto Ingrediente_Produto
        *          Obs.: Responsável por buscar um registro de um produto
        *                na tabela Ingrediente_Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/

        public Ingrediente_Produto FindByCodIngrediente(Ingrediente_Produto pobj_Ingrediente_Produto)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE_PRODUTO " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE_PRODUTO", pobj_Ingrediente_Produto.Cod_Ingrediente_Produto);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Ingrediente_Produto.Cod_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE_PRODUTO"]);
                    pobj_Ingrediente_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                    pobj_Ingrediente_Produto.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                    pobj_Ingrediente_Produto.QntUt_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_QNTUT_INGREDIENTE_PRODUTO"]);
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Ingrediente_Produto;
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
        *        Método: FindAllIngrediente_Produto
        *          Obs.: Responsável por buscar todos os registros na tabela Ingrediente_Produto.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Ingrediente_Produto> FindAllIngrediente_Produto()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE_PRODUTO ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Ingrediente_Produto> Lista = new List<Ingrediente_Produto>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Ingrediente_Produto obj_Ingrediente_Produto = new Ingrediente_Produto();
                        obj_Ingrediente_Produto.Cod_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE_PRODUTO"]);
                        obj_Ingrediente_Produto.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                        obj_Ingrediente_Produto.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                        obj_Ingrediente_Produto.QntUt_Ingrediente_Produto = Convert.ToInt16(obj_Dtr["I_QNTUT_INGREDIENTE_PRODUTO"]);
                        Lista.Add(obj_Ingrediente_Produto);
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
