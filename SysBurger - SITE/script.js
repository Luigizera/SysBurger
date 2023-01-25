function muda() //Função para buscas
{
    e = document.getElementById("tbusca");
    var text = e.options[e.selectedIndex].text;
    document.getElementById("txtb").placeholder = "Digite o " + text;
}

function setTheme(theme) //Função para alterar o tema
{
    if (theme == 'Padrão') 
    {
        localStorage.setItem('panelTheme', theme);
        
        document.body.style.setProperty('--cor-principal', '#F0E68C');
        document.body.style.setProperty('--cor-principal-escuro', '#CEC679');
        document.body.style.setProperty('--cor-secundaria', '#D83447');
        document.body.style.setProperty('--cor-secundaria-escuro', '#a82937');
        document.body.style.setProperty('--cor-terciaria', '#4682B4');
        document.body.style.setProperty('--cor-terciaria-escuro', '#3B6F99');
        document.body.style.setProperty('--cor-cinza', '#868987');
        document.body.style.setProperty('--cor-branco', '#FFF');
        document.body.style.setProperty('--cor-preto', '#232626');
    }
    if (theme == 'Invertido') 
    {
        localStorage.setItem('panelTheme', theme);
        
        document.body.style.setProperty('--cor-principal', '#4682B4'); 
        document.body.style.setProperty('--cor-principal-escuro', '#3B6F99'); 
        document.body.style.setProperty('--cor-secundaria', '#F0E68C'); 
        document.body.style.setProperty('--cor-secundaria-escuro', '#CEC679'); 
        document.body.style.setProperty('--cor-terciaria', '#D83447'); 
        document.body.style.setProperty('--cor-terciaria-escuro', '#a82937'); 
        document.body.style.setProperty('--cor-cinza', '#868987');
        document.body.style.setProperty('--cor-branco', '#232626');
        document.body.style.setProperty('--cor-preto', '#FFF');
    }
}

function loadTheme() //Função para carregar o tema escolhido
{
    //Ao carregar a página se o 'panelTheme' estiver vazio coloca o tema Padrão.
    if (localStorage.getItem('panelTheme') == '') 
    {
      setTheme('Padrão');
    } 
    else 
    {
      setTheme(localStorage.getItem('panelTheme'));
    }
}