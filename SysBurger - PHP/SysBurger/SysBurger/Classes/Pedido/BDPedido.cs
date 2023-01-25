/***********************************************************************
 *          Nome: BDPedido
 *          obs.: Representa a classe de Banco de Dados Pedido. 
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
    class BDPedido
    {
        //Destructor da Classe
        ~BDPedido()
        {

        }

        /***********************************************************************
         *        Método: Incluir
         *     Parametro: Objeto Pedido
         *          Obs.: Responsável por incluir um registro na tabela Pedido.
         *   Dt. Criação: 06/07/2022
         * Dt. Alteração: --
         *    Criada por: LuigiGM 
         ***********************************************************************/
        public int Incluir(Pedido pobj_Pedido)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "INSERT INTO TB_PEDIDO " +
                                   "( " +
                                   "I_COD_PESSOA, " +
                                   "I_COD_ENDERECO, " +
                                   "I_COD_PRODUTO, " +
                                   "S_PED_PEDIDO, " +
                                   "I_QNT_PEDIDO, " +
                                   "D_VLRQNT_PEDIDO, " +
                                   "D_VLRTOT_PEDIDO, " +
                                   "DT_COMP_PEDIDO " +
                                   ") " +
                                   "VALUES " +
                                   "( " +
                                   "@I_COD_PESSOA, " +
                                   "@I_COD_ENDERECO, " +
                                   "@I_COD_PRODUTO, " +
                                   "@S_PED_PEDIDO, " +
                                   "@I_QNT_PEDIDO, " +
                                   "@D_VLRQNT_PEDIDO, " +
                                   "@D_VLRTOT_PEDIDO, " +
                                   "@DT_COMP_PEDIDO " +
                                   "); " +
                                   " SELECT MAX(I_COD_PEDIDO) AS 'ID' FROM TB_PEDIDO ";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pedido.Cod_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Pedido.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ENDERECO", pobj_Pedido.Cod_Endereco);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_QNT_PEDIDO", pobj_Pedido.Qnt_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_VLRQNT_PEDIDO", pobj_Pedido.VlrQnt_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_VLRTOT_PEDIDO", pobj_Pedido.VlrTot_Pedido);
            obj_Cmd.Parameters.AddWithValue("@DT_COMP_PEDIDO", pobj_Pedido.Comp_Pedido);


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
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por alterar um registro na tabela Pedido.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Alterar(Pedido pobj_Pedido)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "UPDATE TB_PEDIDO SET " +
                                   "I_COD_PESSOA = @I_COD_PESSOA, " +
                                   "I_COD_ENDERECO = @I_COD_ENDERECO, " +
                                   "I_COD_PRODUTO = @I_COD_PRODUTO, " +
                                   "S_PED_PEDIDO = @S_PED_PEDIDO, " +
                                   "I_QNT_PEDIDO = @I_QNT_PEDIDO, " +
                                   "D_VLRQNT_PEDIDO = @D_VLRQNT_PEDIDO, " +
                                   "D_VLRTOT_PEDIDO = @D_VLRTOT_PEDIDO, " +
                                   "DT_COMP_PEDIDO = @DT_COMP_PEDIDO " +
                                   "WHERE I_COD_PEDIDO = @I_COD_PEDIDO;";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pedido.Cod_Pessoa);
            obj_Cmd.Parameters.AddWithValue("@I_COD_ENDERECO", pobj_Pedido.Cod_Endereco);
            obj_Cmd.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Pedido.Cod_Produto);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
            obj_Cmd.Parameters.AddWithValue("@I_QNT_PEDIDO", pobj_Pedido.Qnt_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_VLRQNT_PEDIDO", pobj_Pedido.VlrQnt_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_VLRTOT_PEDIDO", pobj_Pedido.VlrTot_Pedido);
            obj_Cmd.Parameters.AddWithValue("@DT_COMP_PEDIDO", pobj_Pedido.Comp_Pedido);

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
        *        Método: AlterarValor
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por alterar o Valor Total de um Pedido.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool AlterarValor(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            string s_SQL_Comando = "UPDATE TB_PEDIDO SET " +
                                   "D_VLRTOT_PEDIDO = @D_VLRTOT_PEDIDO " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO;";


            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
            obj_Cmd.Parameters.AddWithValue("@D_VLRTOT_PEDIDO", pobj_Pedido.VlrTot_Pedido);

            try
            {
                obj_Con.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Con.Close();
                return true;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA ALTERAÇÃO DO VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /***********************************************************************
        *        Método: AlterarData
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por alterar a Data da Compra de um Pedido.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool AlterarData(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            string s_SQL_Comando = "UPDATE TB_PEDIDO SET " +
                                   "DT_COMP_PEDIDO = @DT_COMP_PEDIDO " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO;";


            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
            obj_Cmd.Parameters.AddWithValue("@DT_COMP_PEDIDO", pobj_Pedido.Comp_Pedido);

            try
            {
                obj_Con.Open();
                obj_Cmd.ExecuteNonQuery();
                obj_Con.Close();
                return true;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA ALTERAÇÃO DO VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /***********************************************************************
        *        Método: ContaPedido
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por contar quantos Pedidos baseado na string Ped tem 
        *                nos registros na tabela Pedido.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM
        ***********************************************************************/
        public int ContaPedido(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "SELECT COUNT(I_COD_PEDIDO) FROM TB_Pedido " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO AND B_DEL_PEDIDO = 0;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);

            try
            {
                obj_Con.Open();
                int Valor = Convert.ToInt16(obj_Cmd.ExecuteNonQuery());
                obj_Con.Close();
                return Valor;
            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO FATAL NA CONTAGEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /***********************************************************************
        *        Método: Excluir
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por Excluir todos os registros na tabela Pedido
        *                com o string do Pedido igual.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Excluir(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "DELETE FROM TB_PEDIDO " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
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
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por Setar a variável de deletado para 1 na tabela Pedido.
        *   Dt. Criação: 19/08/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public bool Deletar(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());
            string s_SQL_Comando = "UPDATE TB_PEDIDO SET " +
                                   "B_DEL_PEDIDO  = 1 " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO;";
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);
            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);
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
        *        Método: FindByCodPed
        *          Obs.: Responsável por buscar todos os registros baseados no código
        *                do Ped na tabela Ingrediente_Produto.
        *   Dt. Criação: 24/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Pedido> FindByCodPed(Pedido pobj_Pedido)
        {
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            string s_SQL_Comando = "SELECT * FROM TB_PEDIDO " +
                                   "WHERE S_PED_PEDIDO = @S_PED_PEDIDO";

            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            obj_Cmd.Parameters.AddWithValue("@S_PED_PEDIDO", pobj_Pedido.Ped_Pedido);

            try
            {
                obj_Con.Open();

                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                List<Pedido> Lista = new List<Pedido>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Pedido obj_Pedido = new Pedido();
                        obj_Pedido.Cod_Pedido = Convert.ToInt16(obj_Dtr["I_COD_PEDIDO"]);
                        obj_Pedido.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Pedido.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                        obj_Pedido.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                        obj_Pedido.Ped_Pedido = obj_Dtr["S_PED_PEDIDO"].ToString();
                        obj_Pedido.Qnt_Pedido = Convert.ToInt16(obj_Dtr["I_QNT_PEDIDO"]);
                        obj_Pedido.VlrQnt_Pedido = Convert.ToDouble(obj_Dtr["D_VLRQNT_PEDIDO"]);
                        obj_Pedido.VlrTot_Pedido = Convert.ToDouble(obj_Dtr["D_VLRTOT_PEDIDO"]);
                        obj_Pedido.Comp_Pedido = Convert.ToDateTime(obj_Dtr["DT_COMP_PEDIDO"]);
                        obj_Pedido.Del_Pedido = (Convert.ToInt16(obj_Dtr["B_DEL_PEDIDO"]) == 1) ? true : false;
                        Lista.Add(obj_Pedido);
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
                MessageBox.Show(Erro.Message, "ERRO FATAL NA BUSCA DO PED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /***********************************************************************
        *        Método: FindByCodPedido
        *     Parametro: Objeto Pedido
        *          Obs.: Responsável por buscar um registro na tabela Pedido.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public Pedido FindByCodPedido(Pedido pobj_Pedido)
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PEDIDO " +
                                   "WHERE I_COD_PEDIDO = @I_COD_PEDIDO";


            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            //(06/07/2022 - LuigiGM) Passo os parametros dos dados dos atributos para a SQL
            obj_Cmd.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();
                    pobj_Pedido.Cod_Pedido = Convert.ToInt16(obj_Dtr["I_COD_PEDIDO"]);
                    pobj_Pedido.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                    pobj_Pedido.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                    pobj_Pedido.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                    pobj_Pedido.Ped_Pedido = obj_Dtr["S_PED_PEDIDO"].ToString();
                    pobj_Pedido.Qnt_Pedido = Convert.ToInt16(obj_Dtr["I_QNT_PEDIDO"]);
                    pobj_Pedido.VlrQnt_Pedido = Convert.ToDouble(obj_Dtr["D_VLRQNT_PEDIDO"]);
                    pobj_Pedido.VlrTot_Pedido = Convert.ToDouble(obj_Dtr["D_VLRTOT_PEDIDO"]);
                    pobj_Pedido.Comp_Pedido = Convert.ToDateTime(obj_Dtr["DT_COMP_PEDIDO"]);
                    pobj_Pedido.Del_Pedido = (Convert.ToInt16(obj_Dtr["B_DEL_PEDIDO"]) == 1) ? true : false;
                    obj_Con.Close();
                    obj_Dtr.Close();
                    return pobj_Pedido;
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
                MessageBox.Show(Erro.Message, "ERRO FATAL NA BUSCA DO PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        /***********************************************************************
        *        Método: FindAllPedido
        *          Obs.: Responsável por buscar todos os registros na tabela Pedido.
        *   Dt. Criação: 06/07/2022
        * Dt. Alteração: --
        *    Criada por: LuigiGM 
        ***********************************************************************/
        public List<Pedido> FindAllPedido()
        {
            //(06/07/2022 - LuigiGM) Criar o objeto de conexão com o banco.
            MySqlConnection obj_Con = new MySqlConnection(Connection.ConnectionPath());

            //(06/07/2022 - LuigiGM) A instrução de comando da SQL para o BD
            string s_SQL_Comando = "SELECT * FROM TB_PEDIDO WHERE B_DEL_PEDIDO = 0";

            //(06/07/2022 - LuigiGM) Objeto que executará a instrução SQL acima.
            MySqlCommand obj_Cmd = new MySqlCommand(s_SQL_Comando, obj_Con);

            try
            {
                //(06/07/2022 - LuigiGM) Abrir a Conexão
                obj_Con.Open();

                //(06/07/2022 - LuigiGM) Cria o objeto de leitura
                MySqlDataReader obj_Dtr = obj_Cmd.ExecuteReader();

                //(06/07/2022 - LuigiGM) Cria a Lista para receber os alunos da Tabela
                List<Pedido> Lista = new List<Pedido>();

                if (obj_Dtr.HasRows)
                {
                    //(06/07/2022 - LuigiGM) Enquanto tiver linha, faça.
                    while (obj_Dtr.Read())
                    {
                        Pedido obj_Pedido = new Pedido();
                        obj_Pedido.Cod_Pedido = Convert.ToInt16(obj_Dtr["I_COD_PEDIDO"]);
                        obj_Pedido.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"]);
                        obj_Pedido.Cod_Endereco = Convert.ToInt16(obj_Dtr["I_COD_ENDERECO"]);
                        obj_Pedido.Cod_Produto = Convert.ToInt16(obj_Dtr["I_COD_PRODUTO"]);
                        obj_Pedido.Ped_Pedido = obj_Dtr["S_PED_PEDIDO"].ToString();
                        obj_Pedido.Qnt_Pedido = Convert.ToInt16(obj_Dtr["I_QNT_PEDIDO"]);
                        obj_Pedido.VlrQnt_Pedido = Convert.ToDouble(obj_Dtr["D_VLRQNT_PEDIDO"]);
                        obj_Pedido.VlrTot_Pedido = Convert.ToDouble(obj_Dtr["D_VLRTOT_PEDIDO"]);
                        obj_Pedido.Comp_Pedido = Convert.ToDateTime(obj_Dtr["DT_COMP_PEDIDO"]);
                        obj_Pedido.Del_Pedido = (Convert.ToInt16(obj_Dtr["B_DEL_PEDIDO"]) == 1) ? true : false;
                        Lista.Add(obj_Pedido);
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
