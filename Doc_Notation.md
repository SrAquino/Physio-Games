> # Padronização das cenas:

> Dica: Verificar a ESCALA (Scale)  : Se tiver diferente de 1, a fonte pode estar no tamanho certo, porém ficar menor ou maior que a fonte selecionada;<br><br>
> Dica: Verificar o Pivot (Anchors) : Se tiver diferente de 0,5, a referencia para posicionar na tela fica diferente. (Então por exemplo. X : 0 não é o no inicio da tela ) <br><br>
> Dica: Se um objeto está ficando POR BAIXO de outro MESMO que ele seja um filho (O que deveria automáticamente colocar por cima), verifique os 'Z' da posição de cada objeto, provavelmente um está diferente do outro: **Mantenha os 'Z' em 0**<br><br>
> Dica: Se ainda está com problema de sobreposição, não esquece que a ordem dos objetos lsitados, importa. Tente trocar a ordem deles na lista. <br><br> 

> ## Ordem das cenas
> 1. _Inicial 
> 2. SceneLoginFisioterapeuta {Login | Cadastras}
> 3. 
>       - {Cadastrar} SceneCadastroFisioterapeuta {Vai para SceneLoginPaciente}
> 4. {Login} SceneLoginPaciente {Login | Cadastras}
> 5. 
>       - {Cadastrar} SceneCadastroPaciente {Vai para sceneColetaDadosFisicos}
>       - {Login} SceneColetaDadosFisicos {Sim | Não}
> 1. SceneProximaAcao { Acessar Histórico de Seções | Nova partida }
>       - {Acessar Histórico de Seções} SceneSelecionaSessoes
>

> ## Cores
>> Azul: #2E5889
>>
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
>> Dica: Se os itens do seu dropdown não estiverem sendo gerados mas não estiver aparecendo, verifica o tamanho do altura do item, se a font do text estiver maior, o item não cabe lá<br><br>
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