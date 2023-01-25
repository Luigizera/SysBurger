/***********************************************************************
 *          Nome: Connection
 *          Obs.: Representa a classe de Conexão dom o Banco de Dados. 
 *          Dt. Criação: 06/07/2022
 *          Dt. Alteração: --
 *          Criada por: LuigiGM
 * *********************************************************************/

using System;

namespace SysBurger
{
    public class Connection
    {
        //(06/07/2022 - LuigiGM) Metodo da classe que retorna o caminho do BD.
        public static string ConnectionPath()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB; 
            AttachDBFilename=C:\Users\Luigi\Desktop\SysBurger\SysBurger\SysBurger\BD_SysBurger.mdf;
            Integrated Security = True; 
            Connect Timeout = 15";
        }
        
        //(29/07/2022 - LuigiGM) Caminho para criação dos Comprovantes de Compra.
        public static string StreamWriterPath()
        {
            return "C:\\Users\\luigi.gmechi\\Desktop\\PEDIDOS";
        }
    }
}
