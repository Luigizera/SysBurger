/***********************************************************************
 *          Nome: BDUsuario
 *          obs.: Representa a classe de Banco de Dados Usuario. 
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
    class BDUsuario
    {
        //Destructor da Classe
        ~BDUsuario()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Usuario
         *          Obs.: Responsável por incluir um registro na tabela Usuario.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Usuario pobj_Usuario)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_USUARIO " +
                                   "( " +
                                   "S_UNM_USUARIO, " +
                                   "S_SEN_USUARIO, " +
                                   "B_DEL_USUARIO " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@S_UNM_USUARIO, " +
                                   "@S_SEN_USUARIO, " +
                                   "@B_DEL_USUARIO " +
                                   "); " +
                                   " SELECT IDENT_CURRENT('TB_USUARIO') AS 'ID' ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.Unm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_SEN_USUARIO", pobj_Usuario.Sen_Usuario);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_USUARIO", pobj_Usuario.Del_Usuario);

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
        *     Parametro: Objeto Usuario
        *          Obs.: Responsável por alterar um registro na tabela Usuario.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Usuario pobj_Usuario)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_USUARIO SET " +
                                   "S_UNM_USUARIO = @S_UNM_USUARIO, " +
                                   "S_SEN_USUARIO  = @S_SEN_USUARIO, " +
                                   "B_DEL_USUARIO = @B_DEL_USUARIO " +
                                   "WHERE I_COD_USUARIO = @I_COD_USUARIO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.Unm_Usuario);
            obj_Cmd.Parameters.AddWithValue("@S_SEN_USUARIO", pobj_Usuario.Sen_Usuario);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_USUARIO", pobj_Usuario.Del_Usuario);

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
        *        Método: Deletar
        *     Parametro: Objeto Usuario
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Usuario.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Usuario pobj_Usuario)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_USUARIO SET " +
                                   "B_DEL_USUARIO  = 1 " +
                                   "WHERE I_COD_USUARIO = @I_COD_USUARIO;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);
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
        *     Parametro: Objeto Usuario
        *          Obs.: Responsável por Excluir um registro na tabela Usuario.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Excluir(Usuario pobj_Usuario)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_USUARIO " +
                                   "SET B_DEL_USUARIO = 1 " +
                                   "WHERE I_COD_USUARIO = @I_COD_USUARIO;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);
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
        *        Método: FindByUnmUsuario
        *     Parametro: Objeto Usuario
        *          Obs.: Responsável por buscar um registro na tabela Usuario.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Usuario FindByUnmUsuario(Usuario pobj_Usuario)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_USUARIO " +
                                   "WHERE S_UNM_USUARIO = @S_UNM_USUARIO AND B_DEL_USUARIO = 0";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.Unm_Usuario);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"]);
                    pobj_Usuario.Unm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.Sen_Usuario = obj_Dtr["S_SEN_USUARIO"].ToString();
                    pobj_Usuario.Del_Usuario = (Convert.ToInt16(obj_Dtr["B_DEL_USUARIO"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Usuario;
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
        *        Método: FindByCodUsuario
        *     Parametro: Objeto Usuario
        *          Obs.: Responsável por buscar um registro na tabela Usuario.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Usuario FindByCodUsuario(Usuario pobj_Usuario)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_USUARIO " +
                                   "WHERE I_COD_USUARIO = @I_COD_USUARIO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"]);
                    pobj_Usuario.Unm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.Sen_Usuario = obj_Dtr["S_SEN_USUARIO"].ToString();
                    pobj_Usuario.Del_Usuario = (Convert.ToInt16(obj_Dtr["B_DEL_USUARIO"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Usuario;
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
        *        Método: FindAllUsuario
        *          Obs.: Responsável por buscar todos os registros na tabela Usuario.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Usuario> FindAllUsuario()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_USUARIO ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Usuario> Lista = new List<Usuario>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Usuario obj_Usuario = new Usuario();
                        obj_Usuario.Cod_Usuario = Convert.ToInt16(obj_Dtr["I_COD_USUARIO"]);
                        obj_Usuario.Unm_Usuario = obj_Dtr["S_UNM_USUARIO"].ToString();
                        obj_Usuario.Sen_Usuario = obj_Dtr["S_SEN_USUARIO"].ToString();
                        obj_Usuario.Del_Usuario = (Convert.ToInt16(obj_Dtr["B_DEL_USUARIO"]) == 1) ? true : false;
                        Lista.Add(obj_Usuario);
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
