### COMO EXECUTAR O JOGO? ###

- BASTA ABRIR A bin/Debug e executar o arquivo CJD GAME.exe

##############################################################

- Projeto realizado no primeiro semestre do curso de "Técnico em Programação de Jogos Digitais" na matéria de L.P (Lógica de Programação)
- A grande sacada desse projeto foi projetar um jogo 100% funcional no "Windows Formulários" (como a ferramenta não foi feita para isso, foi um desafio fazer toda a mecânica do jogo);
- Utilizei a linguagem C#;
- Foi preciso calcular todas as jogadas possíveis e ir estruturando o código através de inúmeras condicionais;
- Mais de mil linhas de códigos foram necessárias, porém é um dos projetos que mais me orgulho (dada as condições e conhecimentos que tinha na época).

################### MAIS SOBRE O JOGO ###################

Fanorona é um jogo de tabuleiro de dois jogadores, originário de Madagascar e baseado no jogo Alquerque.

O tabuleiro do jogo é composto de linhas verticais, horizontais e diagonais, cujas interseções são as casas do tabuleiro:

![image](https://user-images.githubusercontent.com/61744533/152618797-d89855ce-e919-4701-aac8-0572bc762142.png)


Cada jogador controla 22 peças, que são posicionadas antes da partida, deixando vazia a casa central:

![image](https://user-images.githubusercontent.com/61744533/152618804-75bfa2b8-cfc4-47a5-89e7-b049d4fad9a5.png)

Os adversários jogam alternadamente, movimentando uma peça de cada vez, podendo efetuar captura de peças adversárias. O jogador que ficar sem peças perde a partida.

O movimento consiste em deslocar uma peça para uma posição vazia adjacente (que deve estar ligada à posição inicial por uma linha). Há dois modos de capturar peças adversárias: por aproximação e por afastamento. Se a posição final do movimento for adjacente a uma peça adversária na direção do movimento, então a peça adversária e todas as outras peças adversárias adjacentes na direção do movimento são capturadas e saem do jogo (captura por aproximação). A captura pode ainda ser feita ao se afastar de uma peça adversária adjacente na direção do movimento (captura por afastamento).

Ao realizar uma captura, o jogador pode realizar outros movimentos de captura com a mesma peça na mesma jogada (exceto na primeira jogada do jogador na partida).


FONTE: https://pt.wikipedia.org/wiki/Fanorona

