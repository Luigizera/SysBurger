/***********************************************************************
 *          Nome: BDIngrediente
 *          obs.: Representa a classe de Banco de Dados Ingrediente. 
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
    class BDIngrediente
    {
        //Destructor da Classe
        ~BDIngrediente()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Ingrediente
         *          Obs.: Responsável por incluir um registro na tabela Ingrediente.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Ingrediente pobj_Ingrediente)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_INGREDIENTE " +
                                   "( " +
                                   "S_NM_INGREDIENTE, " +
                                   "I_QNT_INGREDIENTE, " +
                                   "B_ATV_INGREDIENTE " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@S_NM_INGREDIENTE, " +
                                   "@I_QNT_INGREDIENTE, " +
                                   "@B_ATV_INGREDIENTE " +
                                   "); " +
                                   " SELECT MAX(I_COD_INGREDIENTE) AS 'ID' FROM TB_INGREDIENTE ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@S_NM_INGREDIENTE", pobj_Ingrediente.Nm_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@I_QNT_INGREDIENTE", pobj_Ingrediente.Qnt_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@B_ATV_INGREDIENTE", pobj_Ingrediente.Atv_Ingrediente);

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
        *     Parametro: Objeto Ingrediente
        *          Obs.: Responsável por alterar um registro na tabela Ingrediente.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Ingrediente pobj_Ingrediente)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_INGREDIENTE SET " +
                                   "S_NM_INGREDIENTE = @S_NM_INGREDIENTE, " +
                                   "I_QNT_INGREDIENTE  = @I_QNT_INGREDIENTE, " +
                                   "B_ATV_INGREDIENTE  = @B_ATV_INGREDIENTE " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE AND B_DEL_INGREDIENTE = 0;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE", pobj_Ingrediente.Cod_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@S_NM_INGREDIENTE", pobj_Ingrediente.Nm_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@I_QNT_INGREDIENTE", pobj_Ingrediente.Qnt_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@B_ATV_INGREDIENTE", pobj_Ingrediente.Atv_Ingrediente);
            obj_Cmd.Parameters.AddWithValue("@B_DEL_INGREDIENTE", pobj_Ingrediente.Del_Ingrediente);

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
        *     Parametro: Objeto Ingrediente
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Ingrediente.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Ingrediente pobj_Ingrediente)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_INGREDIENTE SET " +
                                   "B_DEL_INGREDIENTE  = 1 " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE", pobj_Ingrediente.Cod_Ingrediente);
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
        *        Método: FindByCodIngrediente
        *     Parametro: Objeto Ingrediente
        *          Obs.: Responsável por buscar um registro na tabela Ingrediente.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Ingrediente FindByCodIngrediente(Ingrediente pobj_Ingrediente)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE " +
                                   "WHERE I_COD_INGREDIENTE = @I_COD_INGREDIENTE";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_INGREDIENTE", pobj_Ingrediente.Cod_Ingrediente);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Ingrediente.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                    pobj_Ingrediente.Nm_Ingrediente = obj_Dtr["S_NM_INGREDIENTE"].ToString();
                    pobj_Ingrediente.Qnt_Ingrediente = Convert.ToInt16(obj_Dtr["I_QNT_INGREDIENTE"]);
                    pobj_Ingrediente.Atv_Ingrediente = (Convert.ToInt16(obj_Dtr["B_ATV_INGREDIENTE"]) == 1) ? true : false;
                    pobj_Ingrediente.Del_Ingrediente = (Convert.ToInt16(obj_Dtr["B_DEL_INGREDIENTE"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Ingrediente;
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
        *        Método: FindAllIngrediente
        *          Obs.: Responsável por buscar todos os registros na tabela Ingrediente.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Ingrediente> FindAllIngrediente()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_INGREDIENTE";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Ingrediente> Lista = new List<Ingrediente>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Ingrediente obj_Ingrediente = new Ingrediente();
                        obj_Ingrediente.Cod_Ingrediente = Convert.ToInt16(obj_Dtr["I_COD_INGREDIENTE"]);
                        obj_Ingrediente.Nm_Ingrediente = obj_Dtr["S_NM_INGREDIENTE"].ToString();
                        obj_Ingrediente.Qnt_Ingrediente = Convert.ToInt16(obj_Dtr["I_QNT_INGREDIENTE"]);
                        obj_Ingrediente.Atv_Ingrediente = (Convert.ToInt16(obj_Dtr["B_ATV_INGREDIENTE"]) == 1) ? true : false;
                        obj_Ingrediente.Del_Ingrediente = (Convert.ToInt16(obj_Dtr["B_DEL_INGREDIENTE"]) == 1) ? true : false;
                        Lista.Add(obj_Ingrediente);
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
