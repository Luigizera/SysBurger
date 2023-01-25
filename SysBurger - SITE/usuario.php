<?php
    include('conectaBD.php');
    include('seguranca0.php');
    $id = $_SESSION['id'];
    $sql = "SELECT COUNT(I_COD_PESSOA) FROM tb_pessoa WHERE I_COD_PESSOA = $id";
    $result = mysqli_query($link,$sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $resultado = $tbl[0];
    }
    if($resultado != 0)
    {
        $sql = "SELECT * FROM tb_pessoa WHERE I_COD_PESSOA = $id";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $nome = $tbl[2];
            $snm = $tbl[3];
            $cpf = $tbl[4];
            $cel = $tbl[5];
            $email = $tbl[6];
        }
    }
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="estilo.css">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Perfil</title>
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
        <section class="tema_pessoal">
            <h1>Tema</h1>
            <p>
                <label for="tema">Escolha um tema:</label>
                <select id="select">
                    <option value="Padrão" onclick="setTheme('Padrão')">Padrão</option>
                    <option value="Invertido" onclick="setTheme('Invertido')">Invertido</option>
                </select>
            </p>
        </section>
        <section class="dados_pessoais">
            <h1>Dados Pessoais</h1>
            <p>
                <label for="nome">Nome:</label>
                <input type="text" name="nome" id="nome" maxlength="30" value="<?=$nome?>" disabled>
            </p>
            <p>
                <label for="sobrenome">Sobrenome:</label>
                <input type="text" name="sobrenome" id="sobrenome" maxlength="30" value="<?=$snm?>" disabled>
            </p>
            <p>
                <label for="cpf">CPF:</label>
                <input type="text" name="cpf" id="cpf" maxlength="14" value="<?=$cpf?>" disabled>
            </p>
            <p>
                <label for="celular">Celular:</label>
                <input type="text" name="celular" id="celular" maxlength="14" value="<?=$cel?>" disabled>
            </p>
            <p>
                <label for="email">Email:</label>
                <input type="email" name="email" id="email" maxlength="40" value="<?=$email?>" disabled>
            </p>
            <a href="alterarpessoa.php?cliente=<?=$id?>"><button id="alterarinfo">Alterar Informações</button></a>
        </section>
        <section class="enderecos_pessoais">
            <h1>Endereços</h1>
            <?php
                $sql = "SELECT COUNT(I_COD_ENDERECO) FROM tb_endereco WHERE I_COD_PESSOA = $id";
                $result = mysqli_query($link, $sql);
                while($tbl = mysqli_fetch_array($result))
                {
                    $resultado = $tbl[0];
                }
                if($resultado == 0)
                {
                    echo("<p>Você não tem nenhum endereço registrado.</p>");
                }
                else
                {
            ?>
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
                            echo ("<td><a href='alterarendereco.php?endereco=" . $tbl[0] . "'><button id='btnalterar'>Alterar</button></a></td>");
                            echo ("<td><a href='deletarendereco.php?endereco=" . $tbl[0] . "'><button id='btnexcluir'>Deletar</button></a></td>");
                            echo ("</tr>");
                        }
                }
                    ?>
                </table>
                <a href="registrarendereco.php?cliente=<?=$id?>"><button id="registrarinfo">Adicionar Endereço</button></a>
        </section>
        <section class="pedidos_pessoais">
        <h1>Pedidos</h1>
        <?php
            $sql = "SELECT COUNT(I_COD_PEDIDO) FROM tb_pedido WHERE I_COD_PESSOA = $id AND B_DEL_PEDIDO = 0";
            $result = mysqli_query($link, $sql);
            while($tbl = mysqli_fetch_array($result))
            {
                $resultado = $tbl[0];
            }
            if($resultado == 0)
            {
                echo("<p>Você não tem nenhum pedido.</p>");
            }
            else
            {
        ?>
            <table>
                <tr>
                    <th>CPF do Comprador</th>
                    <th>Endereço</th>
                    <th>Bairro</th>
                    <th>Cidade</th>
                    <th>UF</th>
                    <th>CEP</th>
                    <th>Produto</th>
                    <th>Quantidade do Produto</th>
                    <th>Valor total do Pedido</th>
                    <th>Data da compra</th>
                    <th></th>
                </tr>
                <?php
                    $sql = "SELECT * FROM tb_pedido WHERE I_COD_PESSOA = $id AND B_DEL_PEDIDO = 0";
                    $result = mysqli_query($link, $sql);
                    while ($tbl = mysqli_fetch_array($result)) //Traz tudo da tabela pedido
                    {
                        $valor = str_replace('.', ',', $tbl[8]);
                        $endereco = $tbl[2];
                        $sql2 = "SELECT * FROM tb_endereco WHERE I_COD_ENDERECO = $endereco";
                        $result2 = mysqli_query($link, $sql2);
                        while($tbl2 = mysqli_fetch_array($result2)) //Traz tudo da tabela endereço
                        {
                            $produto = $tbl[3];
                            $sql3 = "SELECT * FROM tb_produto WHERE I_COD_PRODUTO = $produto";
                            $result3 = mysqli_query($link, $sql3);
                            while($tbl3 = mysqli_fetch_array($result3)) //Traz tudo da tabela produto
                            {
                                $pessoa = $tbl[1];
                                $sql4 = "SELECT S_NM_PESSOA, S_SNM_PESSOA FROM tb_pessoa WHERE I_COD_PESSOA = $pessoa";
                                $result4 = mysqli_query($link, $sql4);
                                while($tbl4 = mysqli_fetch_array($result4)) //Traz o CPF da tabela pessoa
                                {
                                    echo ("<tr>");
                                    echo ("<td>" . $tbl4[0] . " ". $tbl4[1] . "</td>");
                                    echo ("<td>" . $tbl2[3] . "</td>");
                                    echo ("<td>" . $tbl2[4] . "</td>");
                                    echo ("<td>" . $tbl2[5] . "</td>");
                                    echo ("<td>" . $tbl2[6] . "</td>");
                                    echo ("<td>" . $tbl2[7] . "</td>");
                                    echo ("<td>" . $tbl3[2] . "</td>");
                                    echo ("<td>" . $tbl[6] . "</td>");
                                    echo ("<td>" . $valor . "</td>");
                                    echo ("<td>" . date("d/m/Y - H:i:s", strtotime($tbl[9])) . "</td>");
                                    echo ("<td><a href='deletarpedido.php?pedido=" . $tbl[0] . "'><button id='btnexcluir'>Cancelar pedido</button></a></td>");
                                    echo ("</tr>");
                                }
                            }
                        }
                    }
                }
                ?>
            </table>
        </section>
    </main>
    </main>
</body>
</html>

<script src="script.js"></script>