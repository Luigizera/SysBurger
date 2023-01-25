<?php
    include('conectaBD.php');
    include('seguranca0.php');
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $erro = false;
        if($_SESSION['nivel']!=10)
        {
            $id = $_SESSION['id'];
            unset($_SESSION["altcliente"]);
        }
        else
        {
            $id = $_SESSION['altcliente'];
            unset($_SESSION["altcliente"]);
        }
        
        $nome = $_POST['nome'];
        if(!$nome)
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=Coloque seu nome.");
        }
        $snm = $_POST['sobrenome'];
        if(!$snm)
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=Coloque seu sobrenome.");
        }
        $cpf = $_POST['cpf'];
        $cpf =  preg_replace("/[^0-9]/", "", $cpf); // deixa apenas numeros
        if (strlen($cpf) != 11)
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=CPF inválido.");
        }

        if (preg_match('/(\d)\1{10}/', $cpf)) // Verifica se foi informada uma sequência de digitos repetidos. Ex: 111.111.111-11 (https://gist.github.com/rafael-neri/ab3e58803a08cb4def059fce4e3c0e40)
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=CPF inválido.");
        }

        for ($t = 9; $t < 11; $t++) // Faz o calculo para validar o CPF (https://gist.github.com/rafael-neri/ab3e58803a08cb4def059fce4e3c0e40)
        {
            for ($d = 0, $c = 0; $c < $t; $c++) 
            {
                $d += $cpf[$c] * (($t + 1) - $c);
            }
            $d = ((10 * $d) % 11) % 10;
            if ($cpf[$c] != $d) 
            {
                $erro = true;
                header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=CPF inválido.");
            }
        }
        $cpf = substr_replace($cpf, '-', 9, 0);
        $cpf = substr_replace($cpf, '.', 6, 0);
        $cpf = substr_replace($cpf, '.', 3, 0);
        $cel = $_POST['celular'];
        $cel = preg_replace("/[^0-9]/", "", $cel); // deixa apenas numeros
        if (strlen($cel) != 11) 
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=Celular inválido.");
        }
        $cel = substr_replace($cel, '-', 7, 0);
        $cel = substr_replace($cel, ')', 2, 0);
        $cel = substr_replace($cel, '(', 0, 0);
        $email = $_POST['email'];
        if(!$email)
        {
            $erro = true;
            header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=Coloque seu email.");
        }
        $senha = $_POST['senha'];
        if(!$senha)
        {
            $sql = "SELECT S_SEN_PESSOA FROM tb_pessoa WHERE I_COD_PESSOA = $id";
            $result = mysqli_query($link, $sql);
            while($tbl = mysqli_fetch_array($result))
            {
                $senha = $tbl[0];
            }
        }
        else
        {
            $confirm = $_POST['confirmasenha'];
            if($confirm != $senha)
            {
                $erro = true;
                header("Location: alterarpessoa.php?cliente=".$id."&msg_erro=Senha não condiz.");
            }
            $senha = $senha."LUIGIZERA";
            $senha = md5($senha);
        }

        if($_SESSION['nivel'] == 10)
        {
            $nvl = $_POST['nvl'];
        }
        else
        {
            $nvl = 0;
        }
        

        if(!$erro)
        {
            $sql = "UPDATE 
            tb_pessoa 
            SET 
            S_NM_PESSOA = '$nome', S_SNM_PESSOA = '$snm', S_CPF_PESSOA = '$cpf', S_CEL_PESSOA = '$cel', S_MAIL_PESSOA = '$email', S_SEN_PESSOA = '$senha', I_NVL_PESSOA = $nvl
            WHERE 
            I_COD_PESSOA = $id";
            mysqli_query($link, $sql);
            header("Location: login.php?msg_erro=Sucesso!");
        }
    }

    $id = $_GET['cliente'];
    $_SESSION['altcliente'] = $id;
    if(!isset($_GET['cliente']) || $_SESSION['nivel']!=10)
    {
        $id = $_SESSION['id'];
    }
    $sql = "SELECT * FROM tb_pessoa WHERE I_COD_PESSOA = $id";
    $result = mysqli_query($link, $sql);
    while ($tbl = mysqli_fetch_array($result)) 
    {
        $nome = $tbl[2];
        $snome = $tbl[3];
        $cpf = $tbl[4];
        $cel = $tbl[5];
        $email = $tbl[6];
        $nvl = $tbl[8];
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Alterar Informações</title>
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
            <form action="alterarpessoa.php" method="post">
                <h2>Alterar Informações</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    $id;
                    ?>
                </h3>
                <p>
                    <label for="nome">Nome:</label>
                    <input type="text" name="nome" id="nome" maxlength="30" placeholder="Digite seu Nome" value="<?=$nome?>" required>
                </p>
                <p>
                    <label for="sobrenome">Sobrenome:</label>
                    <input type="text" name="sobrenome" id="sobrenome" maxlength="30" placeholder="Digite seu Sobrenome" value="<?=$snome?>" required>
                </p>
                <p>
                    <label for="cpf">CPF:</label>
                    <input type="text" name="cpf" id="cpf" maxlength="14" placeholder="XXX.XXX.XXX-XX" value="<?=$cpf?>" required>
                </p>
                <p>
                    <label for="celular">Celular:</label>
                    <input type="text" name="celular" id="celular" maxlength="14" placeholder="(XX)XXXXX-XXXX" value="<?=$cel?>" required>
                </p>
                <p>
                    <label for="email">Email:</label>
                    <input type="email" name="email" id="email" maxlength="40" placeholder="Digite seu email" value="<?=$email?>" required>
                </p>
                <p>
                    <label for="senha">Senha:</label>
                    <input type="password" name="senha" id="senha" placeholder="Digite sua senha">
                </p>
                <p>
                    <label for="confirmasenha">Confirmar Senha:</label>
                    <input type="password" name="confirmasenha" id="confirmasenha" placeholder="Confirme sua senha">
                </p>
                <?php
                    if($_SESSION['nivel'] == 10)
                    {
                        ?>
                        <p>
                            <label for="nvl">Nivel:</label>
                            <select name="nvl" id="nvl" value="<?=$nvl?>">
                                <option value="0" <?= $nvl == 0 ? "selected='selected'" : "" ?>>Usuário</option>
                                <option value="10" <?= $nvl == 10 ? "selected='selected'" : "" ?>>Administrador</option>
                            </select>
                        </p>
                        <?php
                    }
                ?>
                <p>
                    <input type="submit" value="Salvar">
                </p>
            </form>
        </div>
    </main>
</body>
</html>

<script src="script.js"></script>