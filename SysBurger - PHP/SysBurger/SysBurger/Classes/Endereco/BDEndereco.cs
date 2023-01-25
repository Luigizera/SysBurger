/***********************************************************************
 *          Nome: BDEndereco
 *          obs.: Representa a classe de Banco de Dados Endereco. 
 *                A Classe utiliza o objeto Connection para acessar o BD
 *   Dt. Criação: 06/07/2022
 * Dt. Alteração: --
 *    Criada por: LuigiGM 
 * *********************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SysBurger
{
    class BDEndereco
    {
        //Destructor da Classe
        ~BDEndereco()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Endereco
         *          Obs.: Responsável por incluir um registro na tabela Endereco.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Endereco pobj_Endereco)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_ENDERECO " +
                                   "( " +
                                   "I_COD_PESSOA, " +
                                   "B_DEL_ENDERECO, " +
                                   "S_END_ENDERECO, " +
                                   "S_BAI_ENDERECO, " +
                                   "S_CID_ENDERECO, " +
                                   "S_UF_ENDERECO, " +
                                   "S_CEP_ENDERECO " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@I_COD_PESSOA, " +
                                   "@B_DEL_ENDERECO, " +
                                   "@S_END_ENDERECO, " +
                                   "@S_BAI_ENDERECO, " +
                                   "@S_CID_ENDERECO, " +
                                   "@S_UF_ENDERECO, " +
                                   "@S_CEP_ENDERECO " +
                                   "); " +
                                   " SELECT MAX(I_COD_ENDERECO) AS 'ID' FROM TB_ENDERECO ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Endereco.Cod_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_END_ENDERECO", pobj_Endereco.End_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_BAI_ENDERECO", pobj_Endereco.Bai_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_CID_ENDERECO", pobj_Endereco.Cid_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_UF_ENDERECO", pobj_Endereco.UF_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_CEP_ENDERECO", pobj_Endereco.CEP_Endereco);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_ENDERECO", pobj_Endereco.Del_Endereco);


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
        *     Parametro: Objeto Endereco
        *          Obs.: Responsável por alterar um registro na tabela Endereco.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Endereco pobj_Endereco)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_ENDERECO SET " +
                                   "I_COD_PESSOA = @I_COD_PESSOA, " +
                                   "S_END_ENDERECO = @S_END_ENDERECO, " +
                                   "S_BAI_ENDERECO = @S_BAI_ENDERECO, " +
                                   "S_CID_ENDERECO = @S_CID_ENDERECO, " +
                                   "S_UF_ENDERECO = @S_UF_ENDERECO, " +
                                   "B_DEL_ENDERECO = @B_DEL_ENDERECO, " +
                                   "S_CEP_ENDERECO = @S_CEP_ENDERECO " +
                                   "WHERE I_COD_ENDERECO = @I_COD_ENDERECO AND B_DEL_ENDERECO = 0;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_ENDERECO", pobj_Endereco.Cod_Endereco);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Endereco.Cod_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@S_END_ENDERECO", pobj_Endereco.End_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_BAI_ENDERECO", pobj_Endereco.Bai_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_CID_ENDERECO", pobj_Endereco.Cid_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_UF_ENDERECO", pobj_Endereco.UF_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_CEP_ENDERECO", pobj_Endereco.CEP_Endereco);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_ENDERECO", pobj_Endereco.Del_Endereco);

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
        *     Parametro: Objeto Endereco
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Endereco.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Endereco pobj_Endereco)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_ENDERECO SET " +
                                   "B_DEL_ENDERECO = 1 " +
                                   "WHERE I_COD_ENDERECO = @I_COD_ENDERECO;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ENDERECO", pobj_Endereco.Cod_Endereco);
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
        *        Método: FindAllEnderecoByCodPessoa
        *          Obs.: Responsável por buscar todos os registros na tabela 
        *                endereco com o código da pessoa.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Endereco> FindAllEnderecoByCodPessoa(Endereco pobj_Endereco)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_ENDERECO " +
                                   " WHERE I_COD_PESSOA = @I_COD_PESSOA";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Endereco.Cod_Pessoa);


            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Endereco> Lista = new List<Endereco>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Endereco obj_Endereco = new Endereco();
                        obj_Endereco.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                        obj_Endereco.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Endereco.End_Endereco = obj_Dtr["S_END_ENDERECO"].ToString();
                        obj_Endereco.Bai_Endereco = obj_Dtr["S_BAI_ENDERECO"].ToString();
                        obj_Endereco.Cid_Endereco = obj_Dtr["S_CID_ENDERECO"].ToString();
                        obj_Endereco.UF_Endereco = obj_Dtr["S_UF_ENDERECO"].ToString();
                        obj_Endereco.CEP_Endereco = obj_Dtr["S_CEP_ENDERECO"].ToString();
                        obj_Endereco.Del_Endereco = (Convert.ToInt16(obj_Dtr["B_DEL_ENDERECO"]) == 1) ? true : false;
                        Lista.Add(obj_Endereco);
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
        *        Método: FindByCodEndereco
        *     Parametro: Objeto Endereco
        *          Obs.: Responsável por buscar um registro na tabela Endereco.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Endereco FindByCodEndereco(Endereco pobj_Endereco)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_ENDERECO " +
                                   "WHERE I_COD_ENDERECO = @I_COD_ENDERECO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_ENDERECO", pobj_Endereco.Cod_Endereco);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Endereco.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                    pobj_Endereco.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                    pobj_Endereco.End_Endereco = obj_Dtr["S_END_ENDERECO"].ToString();
                    pobj_Endereco.Bai_Endereco = obj_Dtr["S_BAI_ENDERECO"].ToString();
                    pobj_Endereco.Cid_Endereco = obj_Dtr["S_CID_ENDERECO"].ToString();
                    pobj_Endereco.UF_Endereco = obj_Dtr["S_UF_ENDERECO"].ToString();
                    pobj_Endereco.CEP_Endereco = obj_Dtr["S_CEP_ENDERECO"].ToString();
                    pobj_Endereco.Del_Endereco = (Convert.ToInt16(obj_Dtr["B_DEL_ENDERECO"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Endereco;
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
        *        Método: FindAllEndereco
        *          Obs.: Responsável por buscar todos os registros na tabela Endereco.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Endereco> FindAllEndereco()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_ENDERECO";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Endereco> Lista = new List<Endereco>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Endereco obj_Endereco = new Endereco();
                        obj_Endereco.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                        obj_Endereco.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Endereco.End_Endereco = obj_Dtr["S_END_ENDERECO"].ToString();
                        obj_Endereco.Bai_Endereco = obj_Dtr["S_BAI_ENDERECO"].ToString();
                        obj_Endereco.Cid_Endereco = obj_Dtr["S_CID_ENDERECO"].ToString();
                        obj_Endereco.UF_Endereco = obj_Dtr["S_UF_ENDERECO"].ToString();
                        obj_Endereco.CEP_Endereco = obj_Dtr["S_CEP_ENDERECO"].ToString();
                        obj_Endereco.Del_Endereco = (Convert.ToInt16(obj_Dtr["B_DEL_ENDERECO"]) == 1) ? true : false;
                        Lista.Add(obj_Endereco);
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
