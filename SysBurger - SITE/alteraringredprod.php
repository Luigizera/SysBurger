<?php
    include('conectaBD.php');
    include('seguranca0.php');
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id_ingredprod = $_SESSION['altingredprod'];
        unset($_SESSION['altingredprod']);
        $erro = false;
        $ingrediente = $_POST['ingrediente'];
        if(!$ingrediente)
        {
            $erro = true;
            header("Location: alteraringrediente.php?ingredprod=".$id_ingredprod."&msg_erro=Selecione o nome do ingrediente.");
        }

        $sql = "SELECT I_COD_INGREDIENTE FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE_PRODUTO = $id_ingredprod";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $ingrediente_original = $tbl[0];
        }
        if($ingrediente != $ingrediente_original)
        {
            $erro = true;
            header("Location: alteraringrediente.php?ingredprod=".$id_ingredprod."&msg_erro=Selecione o nome do ingrediente.");
        }
        
        $qntingrediente = $_POST['qntingrediente'];
        if(!$qntingrediente)
        {
            $erro = true;
            header("Location: alteraringrediente.php?ingredprod=".$id_ingredprod."&msg_erro=Coloque a quantidade do ingrediente.");
        }

        if(!$erro)
        {
            $sql = "UPDATE tb_ingrediente_produto SET I_QNTUT_INGREDIENTE_PRODUTO = $qntingrediente WHERE I_COD_INGREDIENTE = $ingrediente";
            mysqli_query($link, $sql);
            header("Location: listaingredprod.php?msg_erro=Sucesso!");
            exit();
        }
    }
    
    $id_ingredprod = $_GET['ingredprod'];
    $_SESSION['altingredprod'] = $id_ingredprod;
    if(!isset($_GET['ingredprod']))
    {
        header('Location: listaingredprod.php');
        exit();
    }
    $sql = "SELECT I_COD_INGREDIENTE, I_QNTUT_INGREDIENTE_PRODUTO FROM tb_ingrediente_produto WHERE I_COD_INGREDIENTE_PRODUTO = $id_ingredprod";
    $result = mysqli_query($link, $sql);
    while ($tbl = mysqli_fetch_array($result)) 
    {
        $cod_ingrediente = $tbl[0];
        $qntingrediente = $tbl[1];
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Alterar informações do ingrediente do produto</title>
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
            <form action="alteraringredprod.php" method="post">
                <h2>Alterar informações do ingrediente do produto</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="ingrediente">Ingrediente:</label>
                    <select name="ingrediente" id="ingrediente" disabled>
                    <?php
                        $sql = "SELECT I_COD_INGREDIENTE, S_NM_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $cod_ingrediente AND B_DEL_INGREDIENTE = 0";
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
                    <input type="number" min="1" step="any" name="qntutilizada" id="qntutilizada" placeholder="Digite o Quantidade Utilizada" value="<?=$qntingrediente?>" required>
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