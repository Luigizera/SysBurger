<?php
    include('conectaBD.php');
    include('seguranca0.php');
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id_ingrediente = $_SESSION['altingrediente'];
        unset($_SESSION['altingrediente']);
        $erro = false;
        $nome = $_POST['nome'];
        if($nome == "")
        {
            $erro = true;
            header("Location: alteraringrediente.php?msg_erro=Coloque o nome do ingrediente.");
        }
        $sql = "SELECT COUNT(I_COD_INGREDIENTE) FROM tb_ingrediente WHERE S_NM_INGREDIENTE = '$nome' AND B_DEL_INGREDIENTE = 0";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $count = $tbl[0];
        }
        $sql = "SELECT S_NM_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $id_ingrediente AND B_DEL_INGREDIENTE = 0";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $nome_original = $tbl[0];
        }
        if($count != 1 && $nome_original != $nome)
        {
            $erro = true;
            header("Location: alteraringrediente.php?msg_erro=Nome de ingrediente já existente.");
        }

        $qntingrediente = $_POST['qntingrediente'];
        if($qntingrediente == "")
        {
            $erro = true;
            header("Location: alteraringrediente.php?msg_erro=Coloque a quantidade do ingrediente.");
        }

        if(!$erro)
        {
            if($qntingrediente < 5)
            {
                $sql = "UPDATE tb_ingrediente SET S_NM_INGREDIENTE = '$nome', I_QNT_INGREDIENTE = $qntingrediente, B_ATV_INGREDIENTE = 1 WHERE I_COD_INGREDIENTE = $id_ingrediente";
            }
            else
            {
                $sql = "UPDATE tb_ingrediente SET S_NM_INGREDIENTE = '$nome', I_QNT_INGREDIENTE = $qntingrediente, B_ATV_INGREDIENTE = 0 WHERE I_COD_INGREDIENTE = $id_ingrediente";
            }
            
            mysqli_query($link, $sql);
            header("Location: listaingrediente.php?msg_erro=Sucesso!");
            exit();
        }
    }
    
    $id_ingrediente = $_GET['ingrediente'];
    $_SESSION['altingrediente'] = $id_ingrediente;
    if(!isset($_GET['ingrediente']))
    {
        header('Location: listaingrediente.php');
        exit();
    }
    $sql = "SELECT S_NM_INGREDIENTE, I_QNT_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $id_ingrediente";
    $result = mysqli_query($link, $sql);
    while ($tbl = mysqli_fetch_array($result)) 
    {
        $nome = $tbl[0];
        $qntingrediente = $tbl[1];
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Alterar informações do ingrediente</title>
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
        <div class="tela_registro-pessoa">
            <form action="alteraringrediente.php" method="post">
                <h2>Alterar informações do ingrediente</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="nome">Ingrediente:</label>
                    <input type="text" name="nome" id="nome" maxlength="30" placeholder="Digite o nome" value="<?=$nome?>" required>
                </p>
                <p>
                    <label for="qntingrediente">Quantidade:</label>
                    <input type="number" name="qntingrediente" id="qntingrediente" maxlength="10" placeholder="Digite a quantidade" value="<?=$qntingrediente?>" required>
                </p>
                <p>
                    <input type="submit" value="Salvar">
                </p>
            </form>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>