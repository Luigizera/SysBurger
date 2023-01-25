<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Sobre</title>
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
        <section class="sobre">
            <h1>Mais sobre o SysBurger</h1>
            <br>
            <p>
                O SysBurger é uma lanchonete online cujo objetivo principal é facilitar a compra do usuário.
                Este foi um projeto feito utilizando <b>PHP</b>, <b>C#</b> e uma função em <b>Javascript</b>, porém, o principal foco do site sendo a ligação do <b>PHP</b> com <b>C#</b>,
                utilizando do <strong>Banco de Dados</strong> para realizar o sistema de login, compra, e listas para funcionários da empresa.
            </p>
            <br>
            <p>
                Este projeto foi realizado no Senac de Ribeirão Preto na TI-24 Noite, por
                <b>Luigi Gomes Mechi</b>.
            </p>
            <br>
            <p><strong>Telefone Sysburger:</strong> +55 4002-8922</p>
        </section>
    </main>
</body>
</html>


<script src="script.js"></script>