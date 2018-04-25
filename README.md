# tictactoehero

O jogo Tic-tac-toe Hero é um jogo casual para aplicativos móveis baseado em um jogo clássico de papel e caneta, conhecido em vários países e no Brasil é popularmente conhecido como jogo-da-velha cuja origem é incerta. Neste jogo em específico há varias arenas de jogo-da-velha que são disputadas aleatoriamente. Dois jogadores, um a cada turno jogam em uma das arenas no tabuleiro. A arena é escolhida sorteando um número de 1 à 10, onde o jogador define sua posição em que irá colocar o seu brasão (X ou 0).

O jogo possui três modos de jogo: rápido, médio e hero. A diferença entre eles consiste em:
1. Número de arenas sendo quatro, seis e nove respectivamente.
2. O tempo que cada jogador tem para fazer sua jogada, 15, 10, e 5 segundos respectivamente.


//Em domínios com múltiplos objetivos concorrentes, as pessoas enfrentam um desafio básico: como //fazer com que sua estratégia seja flexível o suficiente para lidar com circunstâncias //variáveis sem perder de vista seus objetivos gerais.


## Objetivo

O objetivo de cada jogador é através de suas jogadas (que consiste no posicionamento estratégico de seus brasoes)  obter mais pontos que o seu adversário.

Gênero:	Jogo Casual
Jogadores:	2
Habilidade(s) necessárias: 	Estratégia, táticas, observação e sorte

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


## Regras
Se os dois jogadores jogarem sempre da melhor forma, o jogo terminará sempre em empate. A lógica do jogo é muito simples, existem 3 modos de jogo: iniciante, ok, herói - apesar de o número total de possibilidades ser muito grande, a maioria delas é simétrica, além de que as regras são simples. Por esse motivo, é muito comum que o jogo empate (ou "dê velha").

Um jogador pode facilmente jogar um jogo perfeito seguindo as seguintes regras, por ordem de prioridade:

Antes de iniciar o jogo são definidos o modo de jogo e temporizador para cada jogada.


Em geral, é melhor jogar no centro e em seguida nos cantos pois há maior possibilidade de bloquear ou vencer.
1. Ganhar: Se você tem duas peças numa linha, ponha a terceira.
2. Bloquear: Se o oponente tiver duas peças em linha, ponha a terceira para bloqueá-lo.
3. Triângulo: Crie uma oportunidade em que você poderá ganhar de duas maneiras.
4. Bloquear o Triângulo do oponente:
Opção 1: Crie 2 peças em linha para forçar o oponente a se defender, contanto que não resulte nele criando um triângulo ou vencendo. Por exemplo, se 'X' tem dois cantos opostos do tabuleiro e 'O' tem o centro, 'O' não pode jogar num canto (Jogar no canto nesse cenário criaria um triângulo em que 'X' vence).
Opção 2: Se existe uma configuração em que o oponente pode formar um triângulo, bloqueiem-no.
5. Centro: Jogue no centro.
6. Canto vazio: jogue num canto vazio.
Em suma, a não ser em condições especiais, o jogador deve ter preferência pela posição central, seguida pelos cantos, seguidos pelas bordas.
