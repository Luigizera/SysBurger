<?php
    include('conectaBD.php');
    include('seguranca10.php');

    if (!isset($_GET['produto'])) header("Location: listaproduto.php?msg_erro=Produto inválido.");
    $produto = $_GET['produto'];
    if(!$produto)
    {
        header('Location: listaproduto.php?msg_erro=Produto Inválido.');
        exit();
    }
    if ($_SERVER['REQUEST_METHOD'] == "POST") 
    {
        $termo = $_POST['termo'];
        $coluna = $_POST['coluna'];
        $sql = "SELECT * FROM tb_ingrediente_produto WHERE I_COD_PRODUTO = $produto AND $coluna LIKE '%$termo%'";
    } 
    else 
    {
        $sql = "SELECT * FROM tb_ingrediente_produto WHERE I_COD_PRODUTO = $produto";
    }
    $result = mysqli_query($link, $sql);

    
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Lista de Clientes</title>
    <style>
        #msg_erro
        {
            text-align: center;
        }
    </style>
</head>
<body onload="loadTheme()">
    <header>
        <a href="index.php"><img src="img/logo.png" alt="logo" width="120px"></a>
        <nav>
            <ul class="navbar_links">
                <li><a href="index.php">Home</a></li>
                <li><a href="sobre.php">Sobre</a></li>
                <li><a href="produtos.php">Produtos</a></li>
            </ul>
        </nav>
        <form action="produtos.php" method="get">
            <input type="search" name="search" placeholder="Pesquisar..." id="pesquisar">
            <input type="submit" value="&#128269" id="procurar">
        </form>
        <?php
            include('cabecalho.php')
        ?>
    </header>
    <main>
        <h3 id="msg_erro">
            <?php
            if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
            ?>
        </h3>
        <section id="busca">
            <a href="registraringredprod.php?produto=<?=$produto?>"><button>Registrar Ingredinte para Produto</button></a>
        </section>
        <section class="lista">
            <table>
                <tr>
                    <th>Nome do Produto</th>
                    <th>Nome do Ingrediente</th>
                    <th>Quantidade Utilizada</th>
                    <th></th>
                    <th></th>
                </tr>
                <?php
                while ($tbl = mysqli_fetch_array($result)) 
                {
                    $cod_produto = $tbl[1];
                    $cod_ingrediente = $tbl[2];
                    $sql2 = "SELECT S_NM_PRODUTO FROM tb_produto WHERE I_COD_PRODUTO = $cod_produto";
                    $result2 = mysqli_query($link, $sql2);
                    while($tbl2 = mysqli_fetch_array($result2))
                    {
                        $sql3 = "SELECT S_NM_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $cod_ingrediente";
                        $result3 = mysqli_query($link, $sql3);
                        while($tbl3 = mysqli_fetch_array($result3))
                        {
                            echo ("<tr>");
                            echo ("<td>" . $tbl2[0] . "</td>");
                            echo ("<td>" . $tbl3[0] . "</td>");
                            echo ("<td>" . $tbl[3] . "</td>");
                            echo ("<td><a href='alteraringredprod.php?ingredprod=" . $tbl[0] . "'><button id='btnalterar'>Alterar</button></a></td>");
                            echo ("<td><a href='deletaringredprod.php?ingredprod=" . $tbl[0] . "'><button id='btnexcluir'>Excluir</button></a></td>");
                            echo ("</tr>");
                        }
                    }
                    
                }
                ?>
            </table>
        </section>
    </main>
</body>

</html>
<script src="script.js"></script>