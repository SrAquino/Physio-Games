> # Padronização das cenas:

> Dica: Verificar a ESCALA (Scale)  : Se tiver diferente de 1, a fonte pode estar no tamanho certo, porém ficar menor ou maior que a fonte selecionada;<br><br>
> Dica: Verificar o Pivot (Anchors) : Se tiver diferente de 0,5, a referencia para posicionar na tela fica diferente. (Então por exemplo. X : 0 não é o no inicio da tela ) <br><br>
> Dica: Se um objeto está ficando POR BAIXO de outro MESMO que ele seja um filho (O que deveria automáticamente colocar por cima), verifique os 'Z' da posição de cada objeto, provavelmente um está diferente do outro: **Mantenha os 'Z' em 0**<br><br>
> Dica: Se ainda está com problema de sobreposição, não esquece que a ordem dos objetos lsitados, importa. Tente trocar a ordem deles na lista. <br><br>
> Dica: Não esqueça de dar APLY após mudar coisas nos prefabs, se não ele não salva as alterações que vc fez<br><br>
> Lembrete: NADA QUE É FEITO DURANTE A EXECUÇÃO DO JOGO É SALVO, nunca se esqueça de pausar a execução antes de começar a arrumar algo na cena, pode ser realmente frustrante perder tudo que vc arrumou só pq o jogo ta rodando!<br><br> 
> Bom Saber: Caso o objeto esteja invisivel, e aparece ao decorrer da cena: dentro de algum script deve ter um setActive(true/false)
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/setActive.png)<br><br>
> Dica: Caso não esteja encontrando onde tal variavel é alterada, ela provavelmente está sendo alterada em outro script, e você pode usar a lupa do vscode para pesquisar por acessos a ela, por exemplo: tem uma variável start no script ControllGame.cs, você pesquisa por "ControllGame.start", e o vscode vai retornar todos os scriptis que estão acessando essa variável, no caso: progressSlider.<br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/acharacessodevariavel.png)<br><br>
> Erro identificado: Como o projeto se iniciou no linux, e eu continuei pelo windows, ele tem um problema na identificação correta da porta para comunicação do arduino com a Unity, no linux é na [0] e no windows é na [1]<br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/portaProblema.png)<br><br>
> Dica: Não esquecer que application.quit é apenas para fechar a aplicação compilada, quando tiver nos testes da unity tem que colocar o isPlaying = false: <br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/isplaying.png)<br><br>

> ## Ordem das cenas
> 1. _Inicial 
> 1. SceneLoginFisioterapeuta {Login | Cadastras}
> 1. 
>       - {Cadastrar} SceneCadastroFisioterapeuta {Vai para SceneLoginPaciente}
> 1. {Login} SceneLoginPaciente {Login | Cadastras}
> 1. 
>       - {Cadastrar} SceneCadastroPaciente {Vai para sceneColetaDadosFisicos}
>       - {Login} SceneColetaDadosFisicos {Sim | Não}
> 1. SceneProximaAcao { Acessar Histórico de Seções | Nova partida }
>       - {Acessar Histórico de Seções} SceneSelecionaSessoes
>

> ## Cores
>> Azul escuro (Padrão das cenas)   : #2E5889<br>
>> Azul variação (Itens secundário) : #277DA1<br>
>> Azul claro (Fundo dos painéis)   : #E9F1FF<br>
>> Branco (Fundo das cenas)         : #FFFFFF<br>
>> Vermelho (Botões de negação)     : #960200<br>
>> Verde    (Botões de afirmação)   : #70B77E<br>
>> Laranja (Instruções)             : #FA690F<br>

> ## Titulos
>> W: **685**; H: **70**;<br>
>> X: **0**;   Y: **157.5**;<br>
>> Font Size: **40**;<br>
>> Alignment: **center**<br>
>> ### Caso dentro da barra supeior:<br>
>> W: **685**; H: **70**;<br>
>> X: **0**;   Y: **0**;<br>
> ## Barra supeior
>> Left: **0** ; Top: **0**;<br>
>> Righ: **0** ; Bottom: **315** ;<br>
> ## h2
>> W: - ; H: **40**;<br>
>> X: - ; Y: - ;<br>
>> Font Size: **21**
> ## Inputs de texto
>> W (Grande: de um lado ao outro da tela): **600** ;<br>
>> W (Médio: Metade da tela): **250** ;<br>
>> W (Pequeno): **100** ;<br>
>> H: **40**;<br>
>> X: - ; Y: - ;<br>
>> ### Texto (O que será escrito dentro)
>> Left: **10** ; Top: **5**;<br>
>> Righ: **10** ; Bottom: **5** ;<br>
>> Font Size: **17**<br><br>
>> Dica: Caso não esteja dando para escrever dentro do imput, verifique se a font do texto não está maior do que a caixa de imput!<br><br>
>> Dica: Se colocou exatamente como está aqui, mas o texto parece ficar muito em cima ou muito embaixo quando digita, verifica o Alignment, ele precisa estar em CENTER<br><br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/imputdeTexto.png)
> ## Dropdown
>> W (Grande: de um lado ao outro da tela): **400** ;<br>
>> W (Médio: Metade da tela): **175** ;<br>
>> W (Pequeno): **100** ;<br>
>> H: **55**;<br>
>> X: - ; Y: - ;<br>
>> ### Texto (O que será escrito dentro)
>> Left: **10** ; Top: **5**;<br>
>> Righ: **10** ; Bottom: **5** ;<br>
>> Font Size: **17**<br><br>
>> Dica: Se vc muda o texto da label para ser exebido por exemplo "Selecione seu nome", mas ele fica apagando a label e voltando pro default, é pq não existe opção no dropdown com esse texto: coloque "Selecione seu nome" na primeira opção do dropdown<br><br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/optionDropdown.png)<br>
>> Dica: Se os itens do seu dropdown estiverem sendo gerados mas não estiver aparecendo, verifica o tamanho do altura do item, se a font do text estiver maior, o item não cabe lá<br><br>
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/alturadositensdoDropdown.png)
> ## h3
>> W: - ; H: 40;<br>
>> X: - ;   Y: - ;<br>
>> Font Size: **17**;
> ## Botões
>> W: **200**; H: **40**;<br>
>> ### Para finalizar (canto inferior direito)
>> X: **212** ;   Y: **-142,5** ;<br>
> ### Texto dentro de botões
>> W: - ; H: - ;<br>
>> X: **0**;   Y: **0**;<br>
>> Font Size: **21**;
> ## 
> ![Imagem de exemplo de onde foi usado cada formatação!](/imgs_Notation/font.png)