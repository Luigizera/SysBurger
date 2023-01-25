<?php
include('conectaBD.php');
include('seguranca10.php');
if ($_SERVER['REQUEST_METHOD'] == 'POST') 
{
    $erro = false;
    $nome = $_POST['nome'];

    $sql = "SELECT COUNT(I_COD_INGREDIENTE) FROM tb_ingrediente WHERE S_NM_INGREDIENTE = '$nome' AND B_DEL_INGREDIENTE = 0";
    $result = mysqli_query($link, $sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $nm = $tbl[0];
    }
    if($nm != 0)
    {
        $erro = true;
        header("Location: registrarproduto.php?msg_erro=Nome de ingrediente já existente.");
    }
    $qntestoque = $_POST['qntestoque'];
    if(!$qntestoque)
    {
        $erro = true;
        header("Location: registrarproduto.php?msg_erro=Coloque a quantidade no estoque do ingrediente.");
    }

    $sql = "INSERT INTO tb_ingrediente (S_NM_INGREDIENTE, I_QNT_INGREDIENTE) VALUES ('$nome', $qntestoque)";
    if (!$erro)
    {
        mysqli_query($link, $sql);
        header("Location: listaingrediente.php?msg_erro=Sucesso!");
        exit();
    }
}
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Cadastro do Ingrediente</title>
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
            <form action="registraringrediente.php" method="post">
                <h2>Registrar Ingrediente</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="nome">Ingrediente:</label>
                    <input type="text" name="nome" id="nome" maxlength="30" placeholder="Digite o nome" required>
                </p>
                <p>
                    <label for="qntestoque">Quantidade no Estoque:</label>
                    <input type="number" min="0" step="any" name="qntestoque" id="qntestoque" placeholder="Digite a quantidade no estoque" required>
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