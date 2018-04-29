# tictactoehero

O jogo Tic-tac-toe Hero é um jogo casual para aplicativos móveis baseado em um jogo clássico de papel e caneta, conhecido em vários países e no Brasil é popularmente conhecido como jogo-da-velha cuja origem é incerta. Neste jogo em específico há varias arenas de jogo-da-velha que são disputadas aleatoriamente. Dois jogadores, um a cada turno jogam em uma das arenas no tabuleiro. A arena é escolhida sorteando um número de 1 à 10, onde o jogador define sua posição em que irá colocar o seu brasão (X ou 0).

O jogo possui três modos de jogo: rápido, médio e hero. A diferença entre eles consiste em:
1. Número de arenas sendo quatro, seis e nove respectivamente.
2. O tempo que cada jogador tem para fazer sua jogada, 15, 10, e 5 segundos respectivamente.


//Em domínios com múltiplos objetivos concorrentes, as pessoas enfrentam um desafio básico: como //fazer com que sua estratégia seja flexível o suficiente para lidar com circunstâncias //variáveis sem perder de vista seus objetivos gerais.


## Objetivo

O objetivo de cada jogador é através de suas jogadas (que consiste no posicionamento estratégico de seus brasoes) obter mais pontos que o seu adversário.

Gênero:	Jogo Casual
Jogadores:	2
Habilidade(s) necessárias: 	Estratégia, táticas, observação e sorte

## Regras

O tabuleiro possui várias arenas, essas pode ser distribuidas das seguintes maneiras: 
*Modo fácil: possui 4 arenas, dispostas em uma matriz 2x2 (duas linhas por duas colunas).
*Modo nomal: possui 6 arenas, dispostas em uma matriz 2x3 (duas linhas por três colunas).
*Modo hero: possui 9 arenas, dispostas em uma matriz 3x3 (três linhas por três colunas). 
Cada arena é uma matriz de três linhas por três colunas.

Dois jogadores escolhem uma marcação (brasão) cada um, geralmente um círculo (O) e um xis (X).
Os jogadores jogam alternadamente por turno, ao começar o turno é escolhido um número aleatório:
*Modo fácil: 1 à 4.
*Modo normal: 1 à 6.
*Modo hero: 1 à 9.
Após da seleção do número, este corresponde à arena na qual o jogador deverá colocar um brasão em uma posição vazia.

O objetivo é conseguir três brasões em linha, quer horizontal, vertical ou diagonal em uma ou mais arenas. Ao mesmo tempo quando possível, impedir o adversário de completar uma linha, coluna ou diagonal na próxima jogada.
Quando um jogador conquista o objetivo, costuma-se riscar os três símbolos.


## Tempo

O tempo de cada turno do jogador para fazer sua jogada está relacionado ao modo de jogo da partida, cada jogador possui:
*Modo fácil: 15 segundos.
*Modo normal: 10 segundos.
*Modo hero: 5 segundos.

## Pontuação

1. Ganhar: maior pontuação acumulada nos turnos após preenchido o tabuleiro.
2. Bloquear: Se o oponente tiver duas peças em linha, ponha a terceira para bloqueá-lo desde que o número da arena aleatória permita essa movimentação.
3. Triângulo: Crie uma oportunidade em que você poderá ganhar mais pontos no tabuleiro de duas maneiras.
4. Passar a vez: Se o jogador não realizar uma jogada antes do término do tempo de seu turno 


## Bonus



## Jogabilidade

(melhorar baseado na ideia do jogo)
Analisando o número de possibilidades de forma simplista, existem 362.880 (ou 9!) maneiras de se dispor a cruz e o círculo no tabuleiro, sem considerar jogadas vencedoras. Quando consideramos as combinações vencedoras, existem 255.168 jogos possíveis. Assumindo que 'X' inicia o jogo (se considerar que 'O' inicia, os resultados passam a ser inversos), temos:

131.184 jogos finalizados são ganhos por 'X'
1.440 são ganhos por 'X' após 5 movimentos
47.952 são ganhos por 'X' após 7 movimentos
81.792 são ganhos por 'X' após 9 movimentos
77.904 jogos finalizados são ganhos por 'O'
5.328 são ganhos por 'O' após 6 movimentos
72.576 são ganhos por 'O' após 8 movimentos
46.080 jogos finalizados resultam em empate
Ignorando jogadas simétricas (outras jogadas rotacionadas ou refletidas), existem apenas 138 resultados únicos. Assumindo novamente que 'X' sempre inicia o jogos, temos:

91 resultados únicos são ganhos por 'X'
21 são ganhos por 'X' após 5 movimentos
58 são ganhos por 'X' após 7 movimentos
12 são ganhos por 'X' após 9 movimentos
44 resultados únicos são ganhos por 'O'
21 são ganhos por 'O' após 6 movimentos
23 são ganhos por 'O' após 8 movimentos
3 resultados únicos são empates


