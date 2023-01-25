/***********************************************************************
 *          Nome: BDPessoa
 *          obs.: Representa a classe de Banco de Dados Pessoa. 
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
    class BDPessoa
    {
        //Destructor da Classe
        ~BDPessoa()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Pessoa
         *          Obs.: Responsável por incluir um registro na tabela Pessoa.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Pessoa pobj_Pessoa)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_PESSOA " +
                                   "( " +
                                   "S_NM_PESSOA, " +
                                   "S_SNM_PESSOA, " +
                                   "S_CPF_PESSOA, " +
                                   "S_CEL_PESSOA, " +
                                   "S_MAIL_PESSOA, " +
                                   "B_DEL_PESSOA " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@S_NM_PESSOA, " +
                                   "@S_SNM_PESSOA, " +
                                   "@S_CPF_PESSOA, " +
                                   "@S_CEL_PESSOA, " +
                                   "@S_MAIL_PESSOA, " +
                                   "@B_DEL_PESSOA " +
                                   "); " +
                                   " SELECT IDENT_CURRENT('TB_PESSOA') AS 'ID' ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@S_NM_PESSOA", pobj_Pessoa.Nm_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_SNM_PESSOA", pobj_Pessoa.Snm_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_PESSOA", pobj_Pessoa.CPF_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_PESSOA", pobj_Pessoa.Cel_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_PESSOA", pobj_Pessoa.Mail_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_PESSOA", pobj_Pessoa.Del_Pessoa);


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
        *     Parametro: Objeto Pessoa
        *          Obs.: Responsável por alterar um registro na tabela Pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Pessoa pobj_Pessoa)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_PESSOA SET " +
                                   "S_NM_PESSOA = @S_NM_PESSOA, " +
                                   "S_SNM_PESSOA = @S_SNM_PESSOA, " +
                                   "S_CPF_PESSOA = @S_CPF_PESSOA, " +
                                   "S_CEL_PESSOA = @S_CEL_PESSOA, " +
                                   "S_MAIL_PESSOA = @S_MAIL_PESSOA, " +
                                   "B_DEL_PESSOA = @B_DEL_PESSOA " +
                                   "WHERE I_COD_PESSOA = @I_COD_PESSOA;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_NM_PESSOA", pobj_Pessoa.Nm_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_SNM_PESSOA", pobj_Pessoa.Snm_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_CPF_PESSOA", pobj_Pessoa.CPF_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_CEL_PESSOA", pobj_Pessoa.Cel_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_MAIL_PESSOA", pobj_Pessoa.Mail_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_PESSOA", pobj_Pessoa.Del_Pessoa);

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
        *     Parametro: Objeto Pessoa
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Pessoa.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Pessoa pobj_Pessoa)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_PESSOA SET " +
                                   "B_DEL_PESSOA  = 1 " +
                                   "WHERE I_COD_PESSOA = @I_COD_PESSOA;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);
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
        *     Parametro: Objeto Pessoa
        *          Obs.: Responsável por Excluir um registro na tabela Pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Excluir(Pessoa pobj_Pessoa)
        {
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_PESSOA " +
                                   "SET B_DEL_PESSOA = 1 " +
                                   "WHERE I_COD_PESSOA = @I_COD_PESSOA;";
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);
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
        *        Método: FindAllPessoaByCodPessoa
        *          Obs.: Responsável por buscar todos os registros na tabela 
        *                endereco com o código da pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Pessoa> FindAllPessoaByCodPessoa(Pessoa pobj_Pessoa)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PESSOA " +
                                   " WHERE I_COD_PESSOA = @I_COD_PESSOA ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);


            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Pessoa> Lista = new List<Pessoa>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Pessoa obj_Pessoa = new Pessoa();
                        obj_Pessoa.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Pessoa.Nm_Pessoa = obj_Dtr["S_NM_PESSOA"].ToString();
                        obj_Pessoa.Snm_Pessoa = obj_Dtr["S_SNM_PESSOA"].ToString();
                        obj_Pessoa.CPF_Pessoa = obj_Dtr["S_CPF_PESSOA"].ToString();
                        obj_Pessoa.Cel_Pessoa = obj_Dtr["S_CEL_PESSOA"].ToString();
                        obj_Pessoa.Mail_Pessoa = obj_Dtr["S_MAIL_PESSOA"].ToString();
                        pobj_Pessoa.Del_Pessoa = (Convert.ToInt16(obj_Dtr["B_DEL_PESSOA"]) == 1) ? true : false;
                        Lista.Add(obj_Pessoa);
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





        /***********************************************************************
        *        Método: FindByCodPessoa
        *     Parametro: Objeto Pessoa
        *          Obs.: Responsável por buscar um registro na tabela Pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Pessoa FindByCodPessoa(Pessoa pobj_Pessoa)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PESSOA " +
                                   "WHERE I_COD_PESSOA = @I_COD_PESSOA;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Pessoa.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                    pobj_Pessoa.Nm_Pessoa = obj_Dtr["S_NM_PESSOA"].ToString();
                    pobj_Pessoa.Snm_Pessoa = obj_Dtr["S_SNM_PESSOA"].ToString();
                    pobj_Pessoa.CPF_Pessoa = obj_Dtr["S_CPF_PESSOA"].ToString();
                    pobj_Pessoa.Cel_Pessoa = obj_Dtr["S_CEL_PESSOA"].ToString();
                    pobj_Pessoa.Mail_Pessoa = obj_Dtr["S_MAIL_PESSOA"].ToString();
                    pobj_Pessoa.Del_Pessoa = (Convert.ToInt16(obj_Dtr["B_DEL_PESSOA"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Pessoa;
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
        *        Método: FindAllPessoa
        *          Obs.: Responsável por buscar todos os registros na tabela Pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Pessoa> FindAllPessoa()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            SqlConnection obj_Con = new SqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PESSOA ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            SqlCommand obj_Cmd = new SqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                SqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Pessoa> Lista = new List<Pessoa>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Pessoa obj_Pessoa = new Pessoa();
                        obj_Pessoa.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Pessoa.Nm_Pessoa = obj_Dtr["S_NM_PESSOA"].ToString();
                        obj_Pessoa.Snm_Pessoa = obj_Dtr["S_SNM_PESSOA"].ToString();
                        obj_Pessoa.CPF_Pessoa = obj_Dtr["S_CPF_PESSOA"].ToString();
                        obj_Pessoa.Cel_Pessoa = obj_Dtr["S_CEL_PESSOA"].ToString();
                        obj_Pessoa.Mail_Pessoa = obj_Dtr["S_MAIL_PESSOA"].ToString();
                        obj_Pessoa.Del_Pessoa = (Convert.ToInt16(obj_Dtr["B_DEL_PESSOA"]) == 1) ? true : false;
                        Lista.Add(obj_Pessoa);
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
