<?php
    include('conectaBD.php');
    if(session_start()) session_destroy();
    if ($_SERVER['REQUEST_METHOD'] == 'POST') 
    {
        $erro = false;
        $nome = $_POST['nome'];
        if(!$nome)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Coloque seu nome.");
        }
        $snm = $_POST['sobrenome'];
        if(!$snm)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Coloque seu sobrenome.");
        }
        $cpf = $_POST['cpf'];
        $cpf =  preg_replace("/[^0-9]/", "", $cpf); // deixa apenas numeros
        if (strlen($cpf) != 11)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=CPF inválido.");
        }

        if (preg_match('/(\d)\1{10}/', $cpf)) // Verifica se foi informada uma sequência de digitos repetidos. Ex: 111.111.111-11 (https://gist.github.com/rafael-neri/ab3e58803a08cb4def059fce4e3c0e40)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=CPF inválido.");
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
                header("Location: registrar.php?msg_erro=CPF inválido.");
            }
        }

        $cpf = substr_replace($cpf, '-', 9, 0);
        $cpf = substr_replace($cpf, '.', 6, 0);
        $cpf = substr_replace($cpf, '.', 3, 0);
        $sql = "SELECT COUNT(S_CPF_PESSOA) FROM tb_pessoa WHERE S_CPF_PESSOA = '$cpf' AND B_DEL_PESSOA = 0";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $resultado = $tbl[0];
        }
        if($resultado != 0)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=CPF Registrado.");
        }
        $cel = $_POST['celular'];
        $cel = preg_replace("/[^0-9]/", "", $cel); // deixa apenas numeros
        if (strlen($cel) != 11) 
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Celular inválido.");
        }
        $cel = substr_replace($cel, '-', 7, 0);
        $cel = substr_replace($cel, ')', 2, 0);
        $cel = substr_replace($cel, '(', 0, 0);
        $email = $_POST['email'];
        if(!$email)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Coloque seu email.");
        }
        $sql = "SELECT COUNT(S_MAIL_PESSOA) FROM tb_pessoa WHERE S_MAIL_PESSOA = '$email' AND B_DEL_PESSOA = 0";
        $result = mysqli_query($link,$sql);
        while($tbl = mysqli_fetch_array($result))
        {
            $resultado = $tbl[0];
        }
        if($resultado != 0)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Email Registrado.");
        }
        $senha = $_POST['senha'];
        if(!$senha || strlen($senha) < 3)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Coloque uma senha maior que 3 digitos.");
        }
        $confirm = $_POST['confirmasenha'];
        if($confirm != $senha)
        {
            $erro = true;
            header("Location: registrar.php?msg_erro=Senha não condiz.");
        }
        $senha = $senha."LUIGIZERA";
        $senha = md5($senha);

        if(!$erro)
        {
            $sql = "INSERT INTO tb_pessoa (S_NM_PESSOA, S_SNM_PESSOA, S_CPF_PESSOA, S_CEL_PESSOA, S_MAIL_PESSOA, S_SEN_PESSOA, I_NVL_PESSOA) VALUES ('$nome', '$snm', '$cpf', '$cel', '$email', '$senha', 0)";
            mysqli_query($link, $sql);
            header("Location: login.php?msg_erro=Sucesso!");
        }
    }
?>

<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="UTF-8">
    <link href="estilo.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <title>SysBurger - Registrar</title>
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
            <form action="registrar.php" method="post">
                <h2>Registrar-se</h2>
                <h3 id="msg_erro">
                    <?php
                    if (isset($_GET['msg_erro'])) echo ($_GET['msg_erro']);
                    ?>
                </h3>
                <p>
                    <label for="nome">Nome:</label>
                    <input type="text" name="nome" id="nome" maxlength="30" placeholder="Digite seu Nome" required>
                </p>
                <p>
                    <label for="sobrenome">Sobrenome:</label>
                    <input type="text" name="sobrenome" id="sobrenome" maxlength="30" placeholder="Digite seu Sobrenome" required>
                </p>
                <p>
                    <label for="cpf">CPF:</label>
                    <input type="text" name="cpf" id="cpf" maxlength="14" placeholder="XXX.XXX.XXX-XX" required>
                </p>
                <p>
                    <label for="celular">Celular:</label>
                    <input type="text" name="celular" id="celular" maxlength="14" placeholder="(XX)XXXXX-XXXX" required>
                </p>
                <p>
                    <label for="email">Email:</label>
                    <input type="email" name="email" id="email" maxlength="40" placeholder="Digite seu email" required>
                </p>
                <p>
                    <label for="senha">Senha:</label>
                    <input type="password" name="senha" id="senha" placeholder="Digite sua senha" required>
                </p>
                <p>
                    <label for="confirmasenha">Confirmar Senha:</label>
                    <input type="password" name="confirmasenha" id="confirmasenha" placeholder="Confirme sua senha" required>
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