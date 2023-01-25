<?php
    include('conectaBD.php');
    include('seguranca10.php');

    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id = $_SESSION['delingred'];
        unset($_SESSION['delingred']);
        $sql = "DELETE FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE = $id";
        mysqli_query($link, $sql);
        $sql = "UPDATE tb_ingrediente SET B_DEL_INGREDIENTE = 1 WHERE I_COD_INGREDIENTE = $id";
        mysqli_query($link, $sql);
        header('Location: listaingrediente.php');
        exit();
    }

    if (!isset($_GET['ingrediente'])) header("Location: listaingrediente.php?msg_erro=Ingrediente inválido.");
    $id = $_GET['ingrediente'];
    $_SESSION['delingred'] = $_GET['ingrediente'];
    $sql = "SELECT S_NM_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $id";
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
    <title>SysBurger - Deletar ingrediente</title>
</head>
<body onload="loadTheme()">
    <header>
        <a href="index.php"><img src="img/logo.png" alt="logo" width="120px"></a>
        <nav>
            <ul class="navbar_links">
                <li><a href="index.php">Home</a></li>
                <li><a href="sobre.php">Sobre</a></li>
                <li><a href="ingredientes.php">Produtos</a></li>
            </ul>
        </nav>
        <form action="ingredientes.php" method="get">
            <input type="search" name="search" placeholder="Pesquisar..." id="pesquisar">
            <input type="submit" value="&#128269" id="procurar">
        </form>
        <?php
            include('cabecalho.php')
        ?>
    </header>
    <main>
        <div id="deleta">
            <h2>Excluir ingrediente</h2>
            <form action="deletaringrediente.php" method="post">
                <p>Deseja excluir o ingrediente <b><?=$nome?></b>?</p>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <input type="submit" id="btnSim" value="Sim">
            </form>
            <a href="listaingrediente.php"><button id="btnNao">Não</button></a>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>