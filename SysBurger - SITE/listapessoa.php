<?php
    include('conectaBD.php');
    include('seguranca10.php');
    if ($_SERVER['REQUEST_METHOD'] == "POST") 
    {
        $termo = $_POST['termo'];
        $coluna = $_POST['coluna'];
        $sql = "SELECT * FROM tb_pessoa WHERE B_DEL_PESSOA = 0 AND $coluna LIKE '%$termo%'";
    } 
    else 
    {
        $sql = "SELECT * FROM tb_pessoa WHERE B_DEL_PESSOA = 0";
    }
    $result = mysqli_query($link, $sql);
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Lista de Clientes</title>
    <style>
        #msg_erro
        {
            text-align: center;
        }
    </style>
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
        <h3 id="msg_erro">
            <?php
            if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
            ?>
        </h3>
        <section id="busca">
            <a href="registrar.php"><button>Novo Cliente</button></a>
            <form action="listapessoa.php" method="post">
                <select name="coluna" id="tbusca" onchange="muda()">
                    <option value="S_NM_PESSOA">Nome</option>
                    <option value="S_SNM_PESSOA">Sobrenome</option>
                    <option value="S_CPF_PESSOA">CPF</option>
                    <option value="S_CEL_PESSOA">Celular</option>
                    <option value="S_MAIL_PESSOA">E-mail</option>
                </select>
                <input type="text" name="termo" id="txtb" placeholder="Digite o Nome">
                <input type="submit" value="Pesquisar">
            </form>
        </section>
        <section class="lista">
            <table>
                <tr>
                    <th>Nome</th>
                    <th>CPF</th>
                    <th>Celular</th>
                    <th>Email</th>
                    <th>Nível</th>
                    <th></th>
                    <th></th>
                </tr>
                <?php
                while ($tbl = mysqli_fetch_array($result)) 
                {
                    echo ("<tr>");
                    echo ("<td>" . $tbl[2] . " " . $tbl[3] . "</td>");
                    echo ("<td>" . $tbl[4] . "</td>");
                    echo ("<td>" . $tbl[5] . "</td>");
                    echo ("<td>" . $tbl[6] . "</td>");
                    echo ($tbl[8]==10?"<td>Administrador</td>":"<td>Usuário</td>");
                    echo ("<td><a href='alterarpessoa.php?cliente=" . $tbl[0] . "'><button id='btnalterar'>Alterar</button></a></td>");
                    echo ("<td><a href='deletarpessoa.php?cliente=" . $tbl[0] . "'><button id='btnexcluir'>Excluir</button></a></td>");
                    echo ("</tr>");
                }
                ?>
            </table>
        </section>
    </main>
</body>

</html>
<script src="script.js"></script>