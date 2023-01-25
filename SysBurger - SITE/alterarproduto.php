<?php
    include('conectaBD.php');
    include('seguranca0.php');
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id_produto = $_SESSION['altproduto'];
        unset($_SESSION['altproduto']);
        $erro = false;
        $nome = $_POST['nome'];
        if(!$nome)
        {
            $erro = true;
            header("Location: alterarproduto.php?produto=".$id_produto."&msg_erro=Coloque o nome genérico do produto.");
        }
        $sql = "SELECT COUNT(I_COD_PRODUTO) FROM tb_produto WHERE S_NM_PRODUTO = '$nome' AND B_DEL_PRODUTO = 0";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $count = $tbl[0];
        }
        $sql = "SELECT S_NM_PRODUTO FROM tb_produto WHERE I_COD_PRODUTO = $id_produto AND B_DEL_PRODUTO = 0";
        $result = mysqli_query($link, $sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $nome_original = $tbl[0];
        }
        if($count != 1 && $nome_original != $nome)
        {
            $erro = true;
            header("Location: alteraringrediente.php?produto=".$id_produto."&msg_erro=Nome do produto já existente.");
        }


        $descricao = $_POST['descricao'];
        if(!$descricao)
        {
            $erro = true;
            header("Location: alterarproduto.php?produto=".$id_produto."&msg_erro=Coloque a descrição do produto.");
        }

        $valor = $_POST['valor'];
        if(!$valor)
        {
            $erro = true;
            header("Location: alterarproduto.php?produto=".$id_produto."&msg_erro=Coloque o valor do produto.");
        }
        $valor = str_replace(",", ".", $valor);
        
        if(getimagesize($_FILES['img']['tmp_name']) == false)
        {
            $erro = true;
            header("Location: alterarproduto.php?produto=".$id_produto."&msg_erro=Coloque uma imagem.");
        }
        else
        {
            $img = addslashes($_FILES['img']['tmp_name']);
            $img = file_get_contents($img);
            $img = base64_encode($img);
        }


        

        if(!$erro)
        {
            $sql = "UPDATE tb_produto SET S_NM_PRODUTO = '$nome', S_DESC_PRODUTO = '$descricao', D_VLRUNID_PRODUTO = $valor, S_IMG_PRODUTO = '$img' WHERE I_COD_PRODUTO = $id_produto";
            mysqli_query($link, $sql);
            header("Location: listaproduto.php?msg_erro=Sucesso!");
        }
    }
    
    $id_produto = $_GET['produto'];
    $_SESSION['altproduto'] = $id_produto;
    if(!isset($_GET['produto']))
    {
        header('Location: listaproduto.php');
        exit();
    }
    $sql = "SELECT * FROM tb_produto WHERE I_COD_PRODUTO = $id_produto";
    $result = mysqli_query($link, $sql);
    while ($tbl = mysqli_fetch_array($result)) 
    {
        $nome = $tbl[2];
        $descricao = $tbl[4];
        $valor = $tbl[3];
        $img = $tbl[5];
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Alterar informações do produto</title>
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
            <form action="alterarproduto.php" method="post" enctype="multipart/form-data">
                <h2>Alterar informações do produto</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="nome">Nome:</label>
                    <input type="text" name="nome" id="nome" maxlength="30" placeholder="Digite o nome" value="<?=$nome?>" required>
                </p>
                <p>
                    <label for="descricao">Descrição:</label>
                    <input type="text" name="descricao" id="descricao" maxlength="30" placeholder="Digite a descrição" value="<?=$descricao?>" required>
                </p>
                <p>
                    <label for="valor">Valor por Unidade:</label>
                    <input type="number" min="1" step="any" name="valor" id="valor" placeholder="Digite o valor" value="<?=$valor?>" required>
                </p>
                <p>
                    <label for="img">Imagem do Produto:</label>
                    <input type="file" name="img" id="img" value="<?=$img?>" accept="image/png, image/jpeg, image/jpg">
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