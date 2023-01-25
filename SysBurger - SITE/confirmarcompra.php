<?php
    include('conectaBD.php');
    include('seguranca0.php');
    $id = $_SESSION['id'];
    $carrinho = $_SESSION['carrinho'];

    $sql = "SELECT COUNT(S_CAR_CARRINHO) FROM tb_carrinho WHERE S_CAR_CARRINHO = '$carrinho'";
    $result = mysqli_query($link,$sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $resultado = $tbl[0];
    }
    if($resultado != 0)
    {
        $sql = "SELECT COUNT(I_COD_PESSOA) FROM tb_endereco WHERE I_COD_PESSOA = $id";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $resultado = $tbl[0];
        }
        if(!($resultado != 0))
        {
            header("Location: usuario.php?msg_erro=Insira um endereço.");
            exit();
        }
    }
    else
    {
        header("Location: carrinho.php?msg_erro=Insira itens no carrinho.");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Confirmar compra</title>
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
    <section class="enderecos_pessoais">
        <h1>Endereços</h1>
            <table>
                <tr>
                    <th>Endereço</th>
                    <th>Bairro</th>
                    <th>Cidade</th>
                    <th>UF</th>
                    <th>CEP</th>
                    <th><th>
                </tr>
                <?php
                    $sql = "SELECT * FROM tb_endereco WHERE I_COD_PESSOA = $id AND B_DEL_ENDERECO = 0";
                    $result = mysqli_query($link, $sql);
                    while ($tbl = mysqli_fetch_array($result)) //Traz tudo da tabela endereco
                    {
                        echo ("<tr>");
                        echo ("<td>" . $tbl[3] . "</td>");
                        echo ("<td>" . $tbl[4] . "</td>");
                        echo ("<td>" . $tbl[5] . "</td>");
                        echo ("<td>" . $tbl[6] . "</td>");
                        echo ("<td>" . $tbl[7] . "</td>");
                        echo ("<td><a href='finalizarcompra.php?endereco=" . $tbl[0] . "'><button id='btnalterar'>Selecionar Endereço</button></a></td>");
                        echo ("</tr>");
                    }
                ?>
            </table>
        </section>
    </main>
</body>
</html>

<script src="script.js"></script>