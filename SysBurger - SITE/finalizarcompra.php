<?php
    include('conectaBD.php');
    include('seguranca0.php');
    $id = $_SESSION['id'];
    $carrinho = $_SESSION['carrinho'];
    $email = $_SESSION['email'];
    $data = date("Y-m-d H:i:s", time());
    $vlrtotal = 0;
    $ped = substr(md5(mt_rand() . $data . mt_rand()), 0, 7);
    $endereco = $_GET['endereco'];
    $sql = "SELECT I_COD_PESSOA FROM tb_endereco WHERE I_COD_ENDERECO = $endereco"; //Pega o nome do usuário baseado no endereço colocado
    $result = mysqli_query($link,$sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $id_pessoa = $tbl[0];
    }
    if($id != $id_pessoa) //Se a sessão for diferente da pessoa, endereço inválido
    {
        header('Location: login.php?msg_erro=Endereço inválido.');
        exit();
    }

    $sql = "SELECT COUNT(S_CAR_CARRINHO) FROM tb_carrinho WHERE S_CAR_CARRINHO = '$carrinho'"; //Conta quantos carrinhos o usuário tem
    $result = mysqli_query($link,$sql);
    while($tbl = mysqli_fetch_array($result))
    {
        $resultado = $tbl[0];
    }
    if($resultado != 0) //Verifica se existe pelo menos 1 carrinho
    {
        $sql = "SELECT COUNT(I_COD_PESSOA) FROM tb_endereco WHERE I_COD_PESSOA = $id";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $resultado = $tbl[0];
        }
        if($resultado != 0)
        {
            $sql = "SELECT I_COD_PESSOA, D_VLRUNID_CARRINHO FROM tb_carrinho WHERE S_CAR_CARRINHO = '$carrinho'"; //Pega o valor total do carrinho do usuário e a pessoa
            $result = mysqli_query($link, $sql);
            while($tbl = mysqli_fetch_array($result))
            {
                $pessoa = $tbl[0];
                $vlrtotal += $tbl[1];
            }
            $sql = "SELECT * FROM tb_carrinho WHERE S_CAR_CARRINHO = '$carrinho'"; //Seleciona todos os carrinhos do usuário
            $result = mysqli_query($link, $sql);
            while($tbl = mysqli_fetch_array($result)) //Insere todos os carrinhos do usuário e os deleta
            {
                $prod = $tbl[2];
                $sql1 = "SELECT D_VLRUNID_PRODUTO FROM tb_produto WHERE I_COD_PRODUTO = $prod";
                $result1 = mysqli_query($link, $sql1);
                while($tbl1 = mysqli_fetch_array($result1))
                {
                    $vlrunid = $tbl1[0];
                }
                $qnt = $tbl[4];
                $qntvlrunid = $qnt * $vlrunid;

                //INSERE NO PEDIDO
                $sql2 = "INSERT INTO tb_pedido(I_COD_PESSOA, I_COD_ENDERECO, I_COD_PRODUTO, B_DEL_PEDIDO, S_PED_PEDIDO, I_QNT_PEDIDO, D_VLRQNT_PEDIDO, D_VLRTOT_PEDIDO, DT_COMP_PEDIDO) VALUES ($pessoa, $endereco, $prod, 0, '$ped', $qnt, $qntvlrunid, $vlrtotal, '$data')";
                mysqli_query($link, $sql2);

                //DELETA DO CARRINHO
                $sql3 = "DELETE FROM tb_carrinho WHERE I_COD_PRODUTO = $prod AND S_CAR_CARRINHO = '$carrinho' AND I_COD_PESSOA = $id";
                mysqli_query($link, $sql3);

                //RETIRA A QUANTIDADE DE INGREDIENTES UTILIZADOS DA TABELA INGREDIENTE
                $sql4 = "SELECT I_COD_INGREDIENTE, I_QNTUT_INGREDIENTE_PRODUTO FROM tb_ingrediente_produto WHERE I_COD_PRODUTO = $prod";
                $result4 = mysqli_query($link, $sql4);
                while($tbl4 = mysqli_fetch_array($result4))
                {
                    $cod_ingrediente = $tbl4[0];
                    $qntut_ingrediente = $tbl4[1];
                    $sql5 = "SELECT I_QNT_INGREDIENTE FROM tb_ingrediente WHERE I_COD_INGREDIENTE = $cod_ingrediente";
                    $result5 = mysqli_query($link, $sql5);
                    while($tbl5 = mysqli_fetch_array($result5))
                    {
                        $qnt_ingrediente = $tbl5[0];
                        $qnt_ingrediente = $qnt_ingrediente - ($qntut_ingrediente * $qnt);
                        if($qnt_ingrediente <= 0)
                        {
                            $sql6 = "UPDATE tb_ingrediente SET I_QNT_INGREDIENTE = 0, B_ATV_INGREDIENTE = 1 WHERE I_COD_INGREDIENTE = $cod_ingrediente";
                            mysqli_query($link, $sql6);
                        }
                        else
                        {
                            $sql6 = "UPDATE tb_ingrediente SET I_QNT_INGREDIENTE = $qnt_ingrediente WHERE I_COD_INGREDIENTE = $cod_ingrediente";
                            mysqli_query($link, $sql6);
                        }
                    }
                }
            }
            $_SESSION['carrinho'] = md5($email. date("m.d.y H:i:s") . rand()); //Atualiza a variavel de sessão 'carrinho' do usuário
        }
        else
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
    <title>SysBurger - Compra concluída</title>
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
        <section class="dados_pessoais">
            <p>Compra Concluida</p>
        </section>
    </main>
</body>
</html>

<script src="script.js"></script>