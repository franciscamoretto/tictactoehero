# Tic-Tac-Toe Hero

## Idéia
Um jogo casual de estratégia que em que a sorte seja um dos elementos constituintes para qualquer plataforma móvel. 

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic03.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic04.png)

## Sinópse
O jogo Tic-tac-toe Hero é um jogo casual para aplicativos móveis baseado em um jogo
clássico de papel e caneta, conhecido em vários países e no Brasil é popularmente chamado de jogo-da-velha cuja origem é incerta. 
Neste jogo em específico existe um tabuleiro onde há várias arenas de jogo-da-velha, que são disputadas aleatoriamente. Os jogadores jogam em turnos alternados, a cada turno uma arena é sorteada e o jogador da vez marca com seu brasão (X ou O) a posição escolhida dentro da arena.

O jogo possui três modos de jogo: o rápido, o normal e o hero. A diferença entre eles consiste em:

1.	Número de arenas sendo quatro, seis e nove respectivamente.

2.	O tempo que cada jogador tem para fazer sua jogada: 15, 10, e 5 segundos respectivamente.

## Plataforma
Smart Phones: Android e iOS.

## Gênero
Pluzze, casual e estratégia. 

## Público Alvo
Jovens e Adultos na faixa de 18 a 36 anos que gostam de jogos casuais que envolvem estratégia. Similar aos perfil dos jogadores de Candy Crush Saga e Color Switch distribuídos para platformas móveis.

## Objetivo
Fornecer um jogo casual para entretenimento em curtos períodos de tempo. Baseado no jogo da velha tradicional, o “TIC-TAC-TOE Hero” oferece opções de dificuldade que permitem aos jogadores escolher a dificuldade do jogo. O objetivo de cada jogador é através de suas jogadas (que consiste no posicionamento estratégico de seus brasões) obter mais pontos que o seu adversário, através das seguintes habilidades: estratégia, táticas, observação e sorte.

# Game Play

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/flow.png)

## Regras

Os jogadores dispõem de um tabuleiro que possui várias arenas, essas pode ser distribuidas das seguintes maneiras: 

* Modo fácil: possui 4 arenas, dispostas em uma matriz 2x2 (duas linhas por duas colunas).

* Modo nomal: possui 6 arenas, dispostas em uma matriz 2x3 (duas linhas por três colunas).

* Modo hero: possui 9 arenas, dispostas em uma matriz 3x3 (três linhas por três colunas). 

Cada arena é uma matriz de três linhas por três colunas.

Dois jogadores escolhem uma marcação (brasão) cada um, geralmente um círculo (O) e um xis (X).
Os jogadores jogam alternadamente por turno, ao começar o turno é escolhido um número aleatório:

* Modo rápido: 1 à 4.

* Modo normal: 1 à 6.

* Modo hero: 1 à 9.

Após da seleção do número, este corresponde à arena na qual o jogador deverá colocar um brasão em uma posição vazia.

O objetivo é conseguir três brasões em linha, quer horizontal, vertical ou diagonal em uma ou mais arenas. Ao mesmo tempo quando possível, impedir o adversário de completar uma linha, coluna ou diagonal na próxima jogada.
Quando um jogador conquista o objetivo, costuma-se riscar os três símbolos.

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/prototypw.png)

## Tempo

A duração do tempo de jogo é indefinida. A partida finaliza quando não houver espaços vazios no tabuleiro. 
O tempo de cada turno do jogador para fazer sua jogada está relacionado ao modo de jogo da partida, cada jogador possui:

*Modo rápido: 15 segundos.

*Modo normal: 10 segundos.

*Modo hero: 5 segundos.

## Pontuação

O jogador pode obter pontuação ao completar três brasões em linha, quer horizontal, vertical ou diagonal. No final da partida serão atribuídos pontos para cada brasão extra que complete linha, quer horizontal, vertical ou diagonal que cruze uma nova arena.
Cada jogador é livre para colocar uma marca em qualquer posição no seu turno, desde que a posição esteja vazia (sem marcas). Ao colocar uma marca no tabuleiro, a jogada passa para o próximo jogador, aonde o processo é repetido até que um dos jogadores vença, ou até o tabuleiro ser completamente preenchido, situação na qual pode ocorrer um empate. 
A vitória é conquistada através da maior pontuação acumulada nos turnos após preenchido o tabuleiro. É possível bloquear o oponente caso as peças em vertical, horizontal ou diagonal seja preenchido com um brasão para bloqueá-lo desde que o número da arena aleatória permita essa movimentação.

Analisando o número de possibilidades de forma simplista, existem 362.880 (ou 9!) maneiras de se dispor cada brasão em uma única arena no tabuleiro, sem considerar jogadas vencedoras. Quando consideramos as combinações vencedoras, existem 255.168 jogos possíveis. Assumindo que 'Jogador A' inicia o jogo, se considerar que 'Jogador B' inicia, os resultados passam a ser inversos. O jogador pode optar como estratégia passar a vez ao término do tempo se o jogador não realizar nenhuma jogada antes do término do tempo de seu turno. 

## Bônus

O jogador pode obter pontuação extra ao final da partida para cada linha, coluna ou diagonal completas que envolvam mais de uma arena.
A cada 3 linhas, colunas ou diagonais completas em uma mesma arena do tabuleiro o jogador pode obter uma pontuação bônus [X2] que multiplica por 2 os pontos do jogador por 3 turnos do respectivo jogador.

A cada 3 linhas, colunas ou diagonais completas em uma mesma arena do tabuleiro o jogador pode obter uma pontuação bônus [Pensa Rápido] que diminui o tempo do jogador adversário durante 5 turnos. O tempo que o jogador tem para fazer sua jogada, 7, 5, e 3 segundos respectivamente.

A cada 5 linhas, colunas ou diagonais completas um dos espaços em brancos do tabuleiro será aleatoriamente escolhido como um espaço bônus [Troca-Troca] em que permite ao jogador trocar um brasão do adversário que não esteja pontuando em qualquer arena. Não é afetado pelo bônus cancelar.

A cada 5 linhas, colunas ou diagonais completas um dos espaços em brancos do tabuleiro será aleatoriamente escolhido como um espaço bônus [Embaralhar] em que embaralha as arenas do tabuleiro caso um jogador o preencha com seu brasão primeiro, todos os brasões são embaralhados nas arenas. Não é afetado pelo bônus cancelar.

A cada 5 linhas, colunas ou diagonais completas um dos espaços em brancos do tabuleiro será aleatoriamente escolhido como um espaço bônus [Inverter] que caso um jogador o preencha com seu brasão primeiro, todos os brasões são invertidos sem a inversão de pontuação (i.e. os brasões do jogador A serão substituídos pelo jogado B e vice-versa).  Não é afetado pelo bônus cancelar.

A cada 5 linhas, colunas ou diagonais completas um dos espaços em brancos do tabuleiro será aleatoriamente escolhido como um espaço bônus [Interroper] que, cancela o efeito do último bonus aplicado do adversário se estiver ainda ativo.

## Jogabilidade
Os jogadores podem realizar suas jogadas através de toques na tela do dispositivo móvel, onde a partida esteja acontecendo.

Cada jogador é livre para colocar uma marca em qualquer posição no seu turno, desde que a posição esteja vazia (sem marcas). Ao colocar uma marca no tabuleiro, a jogada passa para o próximo jogador, e o processo é repetido até que o tabuleiro seja completamente preenchido. 

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen04.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen05.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen06.png)

A vitória é conquistada através da maior pontuação acumulada nos turnos após preenchido o tabuleiro. 

É possível bloquear o oponente caso as peças em vertical, horizontal ou diagonal seja preenchido com um brasão para bloqueá-lo desde que o número da arena aleatória permita essa movimentação.

Analisando o número de possibilidades de forma simplista, existem 362.880 (ou 9!) maneiras de se dispor cada brasão em uma única arena no tabuleiro, sem considerar jogadas vencedoras. Quando consideramos as combinações vencedoras, existem 255.168 jogos possíveis. Assumindo que 'Jogador A' inicia o jogo, se considerar que 'Jogador B' inicia, os resultados passam a ser inversos. 
O jogador pode optar como estratégia passar a vez ao término do tempo se o jogador não realizar nenhuma jogada antes do término do tempo de seu turno. 


# Arte

## Conceitos

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept03.png)

## Paleta de cores

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/colors.png)

## Intefaces

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen03.png)

# Efeitos sonoros

Os efeitos sonoros utilizados durante a partida de acordo com a lista abaixo:

a. Posicionamento de marcação na arena: efeito sonoro para quando o jogador colocar uma marca na tela. 

b. Erro: efeito sonoro que indica a tentativa de colocar uma marcação na posição incorreta em uma arena não habilitada.

c. Vitória: efeito sonoro tocado quando o jogador vence a partida. 

d. Empate: efeito sonoro tocado quando o jogador empata a partida. 

e. Bônus: efeito sonoro de dados jogados quando um elemento aleatório for inserido no tabuleiro.

f. Navegação: efeito sonoro de voz utilizado quando realizar navegação entre os menus do jogo.

g. Música:  envolvente que remeta o jogador a uma batalha épica.


# Play


[PLAY](xxx/)


