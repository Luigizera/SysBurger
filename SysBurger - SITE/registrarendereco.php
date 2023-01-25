<?php
    include('conectaBD.php');
    include('seguranca0.php');
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $id = $_SESSION['id'];
        $erro = false;
        $endereco = $_POST['endereco'];
        if(!$endereco)
        {
            $erro = true;
            header("Location: registrarendereco.php?msg_erro=Coloque seu endereço.");
        }
        $bairro = $_POST['bairro'];
        if(!$bairro)
        {
            $erro = true;
            header("Location: registrarendereco.php?msg_erro=Coloque seu bairro.");
        }
        $cidade = $_POST['cidade'];
        if(!$cidade)
        {
            $erro = true;
            header("Location: registrarendereco.php?msg_erro=Coloque sua cidade.");
        }
        $UF = $_POST['UF'];
        if (strlen($UF) != 2)
        {
            $erro = true;
            header("Location: registrarendereco.php?msg_erro=Estado Inválido.");
        }
        $CEP = $_POST['CEP'];
        $CEP = preg_replace("/[^0-9]/", "", $CEP); // deixa apenas numeros
        if (strlen($CEP) != 8)
        {
            $erro = true;
            header("Location: registrarendereco.php?msg_erro=CEP Inválido.");
        }
        $CEP = substr_replace($CEP, '-', 5, 0);

        if(!$erro)
        {
            $sql = "INSERT INTO tb_endereco (I_COD_PESSOA, B_DEL_ENDERECO, S_END_ENDERECO, S_BAI_ENDERECO, S_CID_ENDERECO, S_UF_ENDERECO, S_CEP_ENDERECO) VALUES ($id, 0, '$endereco', '$bairro', '$cidade', '$UF', '$CEP')";
            mysqli_query($link, $sql);
            header("Location: usuario.php?msg_erro=Sucesso!");
        }
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Registrar Endereço</title>
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
            <form action="registrarendereco.php" method="post">
                <h2>Registrar Endereço</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="endereco">Endereço:</label>
                    <input type="text" name="endereco" id="endereco" maxlength="50" placeholder="Digite seu Endereço" required>
                </p>
                <p>
                    <label for="bairro">Bairro:</label>
                    <input type="text" name="bairro" id="bairro" maxlength="25" placeholder="Digite seu Bairro" required>
                </p>
                <p>
                    <label for="UF">Estado:</label>
                    <select name="UF" id="UF">
                        <option value="SP">São Paulo (SP)</option>
                    </select>
                </p>
                <p>
                    <label for="cidade">Cidade:</label>
                    <select name="cidade" id="cidade">
                        <option value="São Paulo">São Paulo</option>
                        <option value="Ribeirão Preto">Ribeirão Preto</option>
                    </select>
                </p>
                <p>
                    <label for="CEP">CEP:</label>
                    <input type="text" name="CEP" id="CEP" maxlength="9" placeholder="XXXXX-XXX" required>
                    
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