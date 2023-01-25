<?php
    include('conectaBD.php');
    include('seguranca10.php');

    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id = $_SESSION['ingredprod'];
        unset($_SESSION['ingredprod']);
        $sql = "SELECT I_COD_PRODUTO FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE_PRODUTO = $id";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $produto = $tbl[0];
        }
        $sql = "DELETE FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE_PRODUTO = $id";
        mysqli_query($link, $sql);
        header('Location: listaingredprod.php?produto='.$produto.'&msg_erro=Sucesso!');
        exit();
    }

    if (!isset($_GET['ingredprod'])) header("Location: listaingredprod.php");
    $id = $_GET['ingredprod'];
    $_SESSION['ingredprod'] = $id;
    $sql = "SELECT I_COD_PRODUTO FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE_PRODUTO = $id";
    $result = mysqli_query($link, $sql);
    while($tbl=mysqli_fetch_array($result))
    {
        $prod = $tbl[0];
    }
    $sql="SELECT S_NM_PRODUTO FROM tb_produto WHERE I_COD_PRODUTO = $prod";
    $result = mysqli_query($link, $sql);
    while($tbl=mysqli_fetch_array($result))
    {
        $nome = $tbl[0];
    }
    
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>DrogaZilla - Deletar produto</title>
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
        <div id="deleta">
            <h2>Excluir ingrediente do produto</h2>
            <form action="deletaringredprod.php" method="post">
                <p>Deseja excluir o ingrediente do produto: <b><?=$nome?></b>?</p>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <input type="submit" id="btnSim" value="Sim">
            </form>
            <a href="listaproduto.php"><button id="btnNao">Não</button></a>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>