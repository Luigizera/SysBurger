<?php
include('conectaBD.php');
include('seguranca10.php');


if ($_SERVER['REQUEST_METHOD'] == 'POST') 
{
    $erro = false;
    $produto = $_SESSION['ingredprod'];
    unset($_SESSION['ingredprod']);
    $ingrediente = $_POST['ingrediente'];

    $sql = "SELECT COUNT(I_COD_INGREDIENTE_PRODUTO) FROM tb_ingrediente_produto WHERE I_COD_PRODUTO = $produto AND I_COD_INGREDIENTE = $ingrediente";
    $result = mysqli_query($link, $sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $count = $tbl[0];
    }
    if($count != 0)
    {
        $erro = true;
        header("Location: registraringredprod.php?msg_erro=Ingrediente do produto já existente.");
    }
    $qntutilizada = $_POST['qntutilizada'];
    if(!$qntutilizada)
    {
        $erro = true;
        header("Location: registraringredprod.php?msg_erro=Coloque a quantidade utilizada do ingrediente no produto.");
    }

    $sql = "INSERT INTO tb_ingrediente_produto (I_COD_PRODUTO, I_COD_INGREDIENTE, I_QNTUT_INGREDIENTE_PRODUTO) VALUES ($produto, $ingrediente, $qntutilizada)";
    if (!$erro)
    {
        mysqli_query($link, $sql);
        header("Location: listaingredprod.php?produto=$produto&msg_erro=Sucesso!");
        exit();
    }
}
if (!isset($_GET['produto'])) header("Location: listaproduto.php?msg_erro=Produto inválido.");
$produto = $_GET['produto'];
$_SESSION['ingredprod'] = $produto;
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Cadastro de Ingrediente do Produto</title>
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
        <div class="tela_registro-produto">
            <form action="registraringredprod.php" method="post">
                <h2>Registrar Ingrediente para Produto</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="ingrediente">Ingrediente:</label>
                    <select name="ingrediente" id="ingrediente">
                    <?php
                        $sql = "SELECT I_COD_INGREDIENTE, S_NM_INGREDIENTE FROM tb_ingrediente WHERE B_DEL_INGREDIENTE = 0";
                        $result = mysqli_query($link,$sql);
                        while($tbl = mysqli_fetch_array($result))
                        {
                            echo("<option value=". $tbl[0] .">". $tbl[1] ."</option>");
                        }
                    ?>
                    </select>
                </p>
                <p>
                    <label for="qntutilizada">Quantidade Utilizada:</label>
                    <input type="number" min="1" step="any" name="qntutilizada" id="qntutilizada" placeholder="Digite o Quantidade Utilizada" required>
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