<?php
    include('conectaBD.php');
    include('seguranca0.php');

    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        if($_SESSION['nivel'] == 10)
        {
            $id = $_SESSION['cliente'];
            unset($_SESSION['cliente']);
        } 
        else
        {
            $id = $_SESSION['id'];
        }
        $sql = "UPDATE tb_pessoa SET B_DEL_PESSOA = 1 WHERE I_COD_PESSOA = $id";
        mysqli_query($link, $sql);
        if($_SESSION['nivel'] == 10 && $_SESSION['id'] != $id)
        {
            header("Location: listapessoa.php?msg_erro=Sucesso!");
            exit();
        } 
        else
        {
            header("Location: login.php?msg_erro=Sucesso!");
            exit();
        }
    }
    
    if (!isset($_GET['cliente']))
    {
        if($_SESSION['nivel'] == 10)
        {
            header("Location: listapessoa.php");
            exit();
        } 
        else
        {
            header("Location: usuario.php");
            exit();
        }
    }
    else
    {
        if($_SESSION['nivel'] == 10)
        {
            $id = $_GET['cliente'];
            $_SESSION['cliente'] = $id;
        } 
        else
        {
            $id = $_SESSION['id'];
        }
    }

    
    $sql = "SELECT S_NM_PESSOA, S_SNM_PESSOA FROM tb_pessoa WHERE I_COD_PESSOA = $id";
    $result = mysqli_query($link, $sql);
    while($tbl=mysqli_fetch_array($result))
    {
        $nome = $tbl[0];
        $snome = $tbl[1];
    }

    
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Deletar conta</title>
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
            <h2>Excluir conta</h2>
            <form action="deletarpessoa.php" method="post">
                <p>Deseja excluir a conta de <b><?=$nome?> <?=$snome?></b>?</p>
                <h3 id="msg_erro">
                    <?php
                        if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <input type="submit" id="btnSim" value="Sim">
            </form>
            <a href="listapessoa.php"><button id="btnNao">Não</button></a>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>