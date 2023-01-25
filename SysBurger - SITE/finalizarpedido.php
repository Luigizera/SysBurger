<?php
    include('conectaBD.php');
    include('seguranca10.php');

    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        if (!isset($_POST['pedido'])) //Se não houver um código de pedido
        {
            if($_SESSION['nivel'] == 10)
            {
                header("Location: listapedido.php?msg_erro=Erro.");
                exit();
            } 
            else
            {
                header("Location: login.php?msg_erro=Erro.");
                exit();
            }
        }
        else //Se houver um código de pedido
        {
            if($_SESSION['nivel'] == 10) //Verifica se a sessão é nvl 10
            {
                $pedido = $_POST['pedido'];
            }
            else //Senão faz uma verificação no banco se o código condiz com a sessão
            {
                $pedido = $_POST['pedido'];
                $sql = "SELECT I_COD_PESSOA FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
                $result = mysqli_query($link, $sql);
                while($tbl=mysqli_fetch_array($result))
                {
                    $cod_pessoa = $tbl[0];
                }
                if($cod_pessoa != $_SESSION['id'])
                {
                    header("Location: login.php?msg_erro=Você não pode deletar esse pedido.");
                    exit();
                }
            }
        }

        $sql = "SELECT I_COD_PESSOA, S_PED_PEDIDO FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $cod_pessoa = $tbl[0];
            $md5pedido = $tbl[1];
        }
        $sql = "UPDATE tb_pedido SET B_DEL_PEDIDO = 1 WHERE S_PED_PEDIDO = '$md5pedido' AND I_COD_PESSOA = $cod_pessoa";
        mysqli_query($link, $sql);
        if($_SESSION['nivel'] == 10)
        {
            header('Location: listapedido.php?msg_erro=Pedido Completo!');
            exit();
        }
        else
        {
            header('Location: usuario.php');
            exit();
        }
    }

    if (!isset($_GET['pedido'])) //Se não houver um código de pedido
    {
        if($_SESSION['nivel'] == 10)
        {
            header("Location: listapedido.php");
            exit();
        } 
        else
        {
            header("Location: usuario.php");
            exit();
        }
    }
    else //Se houver um código de pedido
    {
        if($_SESSION['nivel'] == 10) //Verifica se a sessão é nvl 10
        {
            $pedido = $_GET['pedido'];
        }
        else //Senão faz uma verificação no banco se o código condiz com a sessão
        {
            $pedido = $_GET['pedido'];
            $sql = "SELECT I_COD_PESSOA FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
            $result = mysqli_query($link, $sql);
            while($tbl=mysqli_fetch_array($result))
            {
                $cod_pessoa = $tbl[0];
            }
            if($cod_pessoa != $_SESSION['id'])
            {
                header("Location: login.php?msg_erro=Você não pode deletar esse pedido.");
                exit();
            }
        }
    }
    
    
    $sql = "SELECT I_COD_PESSOA FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
    $result = mysqli_query($link, $sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $cod_pessoa = $tbl[0];
    }
    $sql = "SELECT S_NM_PESSOA, S_SNM_PESSOA FROM tb_pessoa WHERE I_COD_PESSOA = $cod_pessoa";
    $result = mysqli_query($link, $sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $nm_pessoa = $tbl[0];
        $snm_pessoa = $tbl[1];
    }
    
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Finalizar pedido</title>
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
            <h2>Cancelar pedido</h2>
            <form action="finalizarpedido.php" method="post">
                <p>Deseja completar o pedido do CPF: <b><?=$nm_pessoa?> <?=$snm_pessoa?></b>?</p>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <input type="hidden" name="pedido" value=<?=$pedido?>>
                <input type="submit" id="btnSim" value="Sim">
            </form>
            <a href="listapedido.php"><button id="btnNao">Não</button></a>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>