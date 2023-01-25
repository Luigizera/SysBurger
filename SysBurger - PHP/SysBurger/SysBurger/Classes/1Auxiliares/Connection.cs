/***********************************************************************
 *          Nome: Connection
 *          Obs.: Representa a classe de Conexão dom o Banco de Dados. 
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

namespace SysBurger
{
    public class Connection
    {
        //(06/07/2022 - LuigiGM) Metodo da classe que retorna o caminho do BD.
        public static string ConnectionPath()
        {
            return @"Data Source= 127.0.0.1; username = admin; password = 123; database = bd_sysburger";
        }
    }
}
