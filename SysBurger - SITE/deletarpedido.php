<?php
    include('conectaBD.php');
    include('seguranca0.php');

    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        if($_SESSION['nivel'] == 10)
        {
            $pedido = $_SESSION['pedido'];
        }
        else
        {
            $pedido = $_SESSION['pedido'];
            $_SESSION['pedido'] = $pedido;
            $sql = "SELECT I_COD_PESSOA FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
            $result = mysqli_query($link, $sql);
            while($tbl=mysqli_fetch_array($result))
            {
                $cod_pessoa = $tbl[0];
            }
            if($cod_pessoa != $_SESSION['id'])
            {
                header("Location: login.php?msg_erro=Você não pode cancelar esse pedido.");
                exit();
            }
        }

        $sql = "SELECT I_COD_PESSOA, S_PED_PEDIDO FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $cod_pessoa = $tbl[0];
            $md5pedido = $tbl[1];
        }
        $sql = "SELECT I_COD_PRODUTO, I_QNT_PEDIDO FROM tb_pedido WHERE S_PED_PEDIDO = '$md5pedido'";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $cod_produto = $tbl[0];
            $qnt_pedido = $tbl[1];
            $sql1 = "SELECT I_COD_INGREDIENTE, I_QNTUT_INGREDIENTE_PRODUTO FROM tb_ingrediente_produto WHERE I_COD_PRODUTO = $cod_produto";
            $result1 = mysqli_query($link, $sql1);
            while($tbl1 = mysqli_fetch_array($result1))
            {
                $ingrediente = $tbl1[0];
                $qntut_ingrediente = $tbl1[1];
                $qntut_ingrediente = $qntut_ingrediente * $qnt_pedido;

                if($qntut_ingrediente < 5)
                {
                    $sql2 = "UPDATE tb_ingrediente SET I_QNT_INGREDIENTE = $qntut_ingrediente, B_ATV_INGREDIENTE = 0 WHERE I_COD_INGREDIENTE = $ingrediente";
                    $result2 = mysqli_query($link, $sql2);
                }
                else
                {
                    $sql2 = "UPDATE tb_ingrediente SET I_QNT_INGREDIENTE = $qntut_ingrediente WHERE I_COD_INGREDIENTE = $ingrediente";
                    $result2 = mysqli_query($link, $sql2);
                }
                
            }
        }
        $sql = "DELETE FROM tb_pedido WHERE S_PED_PEDIDO = '$md5pedido' AND I_COD_PESSOA = $cod_pessoa";
        unset($_SESSION['pedido']);
        mysqli_query($link, $sql);
        if($_SESSION['nivel' == 10])
        {
            header('Location: listapedido.php?msg_erro=Pedido cancelado.');
            exit();
        }
        else
        {
            header('Location: usuario.php?msg_erro=Pedido cancelado.');
            exit();
        }
        
    }

    if (!isset($_GET['pedido']))
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
    else
    {
        if($_SESSION['nivel'] == 10)
        {
            $pedido = $_GET['pedido'];
            $_SESSION['pedido'] = $pedido;
        }
        else
        {
            $pedido = $_GET['pedido'];
            $_SESSION['pedido'] = $pedido;
            $sql = "SELECT I_COD_PESSOA FROM tb_pedido WHERE I_COD_PEDIDO = $pedido";
            $result = mysqli_query($link, $sql);
            while($tbl=mysqli_fetch_array($result))
            {
                $cod_pessoa = $tbl[0];
            }
            if($cod_pessoa != $_SESSION['id'])
            {
                header("Location: login.php?msg_erro=Você não pode cancelar esse pedido.");
                unset($_SESSION['pedido']);
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
    $sql = "SELECT S_CPF_PESSOA FROM tb_pessoa WHERE I_COD_PESSOA = $cod_pessoa";
    $result = mysqli_query($link, $sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $cpf_pessoa = $tbl[0];
    }
    
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Cancelar pedido</title>
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
            <form action="deletarpedido.php" method="post">
                <p>Deseja cencelar o pedido do CPF: <b><?=$cpf_pessoa?></b>?</p>
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