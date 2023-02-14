# Tic-Tac-Toe Hero

## Idea

casual game of strategy and luck for mobile devices

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic03.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/pic04.png)

## Synopsis

The Tic-tac-toe Hero game is a casual game for mobile applications based on a classic pen and paper game, known in several countries and in Brazil it is popularly called tic-tac-toe whose origin is uncertain.

In this specific game there is a board where there are several tic-tac-toe arenas, which are played randomly. Players play in alternating turns, each turn an arena is drawn and the player in turn marks with his coat of arms (X or O) the chosen position within the arena.

The game has three game modes: fast, normal and hero. The difference between them consists of:

1. Number of arenas are: four, six and nine respectively.

2. The time of each player has to make their move: 15, 10, and 5 seconds respectively.

## Plataform
Smart phones: Android e iOS.

## Game Genres

Pluzze, casual strategy. 

## Target Audience

Youth and Adults aged 18 to 36 who enjoy casual games involving strategy. Similar to the player profiles of Candy Crush Saga and Color Switch distributed for mobile platforms.

## Objective

Provide a casual game for entertainment in short periods of time. Based on the traditional tic-tac-toe game, “TIC-TAC-TOE Hero” offers difficulty options that allow players to choose the difficulty of the game. The goal of each player is through their moves (which consists of the strategic placement of their coats of arms) to obtain more points than their opponent, through the following skills: strategy, tactics, observation and luck.

# Game Play

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/flow.png)

## Rules

Players have a board that has several arenas, these can be distributed in the following ways:

* Easy mode: it has 4 arenas, arranged in a 2x2 matrix (two rows by two columns).

* Normal mode: has 6 arenas, arranged in a 2x3 matrix (two rows by three columns).

* Hero mode: has 9 arenas, arranged in a 3x3 matrix (three rows by three columns).

Each arena is a three-row-by-three-column matrix.

Two players each choose a marking (coat of arms), usually a circle (O) or cross (X).
Players play alternately per turn, at the beginning of the turn a random number is chosen for the selection in which arena the player must perform the action:

* Quick mode: 1 to 4.

* Normal mode: 1 to 6.

* Hero mode: 1 to 9.

After selecting the number, this corresponds to the arena in which the player must place a coat of arms in an empty position.

The objective is to get three coats of arms in a row, either horizontally, vertically or diagonally in one or more arenas. At the same time when possible, prevent the opponent from completing a row, column or diagonal on the next move.
When a player achieves the goal, it is customary to scratch the three symbols.

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/prototypw.png)

## Time

The duration of game time is indefinite. The game ends when there are no empty spaces on the board.
The time of each player's turn to make his move is related to the game mode of the match, each player has:

* Quick mode: 15 seconds.

* Normal mode: 10 seconds.

* Hero mode: 5 seconds.

## Pontuação

Score

The player can get score by completing three coats of arms in a row, either horizontally, vertically or diagonally. At the end of the game, points will be awarded for each extra coat of arms that completes a line, whether horizontal, vertical or diagonal, that crosses a new arena.
Each player is free to place a mark in any position on their turn, as long as the position is empty (no marks). By placing a mark on the board, the move passes to the next player, where the process is repeated until one of the players wins, or until the board is completely filled, in which case a tie may occur.
Victory is achieved through the highest accumulated score in turns after filling the board. It is possible to block the opponent if the pieces in vertical, horizontal or diagonal are filled with a coat of arms to block him as long as the random arena number allows this movement.

Analyzing the number of possibilities in a simplistic way, there are 362,880 (or 9!) ways to arrange each coat of arms in a single arena on the board, without considering winning moves. When we consider winning combinations, there are 255,168 possible games. Assuming that 'Player A' starts the game, if we consider that 'Player B' starts, the results are inverse. The player can choose as a strategy to pass the turn at the end of the time if the player does not make any move before the end of the time of his turn.

## Bonus

The player can get extra points at the end of the game for each completed row, column or diagonal involving more than one arena.
For every 3 complete lines, columns or diagonals in the same arena on the board, the player can obtain a bonus score [X2] that multiplies the player's points by 2 for 3 turns of the respective player.

For every 3 complete lines, columns or diagonals in the same arena on the board, the player can obtain a bonus score [Think Fast] that decreases the opponent player's time for 5 turns. The time the player has to make his move, 7, 5, and 3 seconds respectively.

Every 5 completed lines, columns or diagonals one of the blank spaces on the board will be randomly chosen as a bonus space [Trade-Trade] which allows the player to exchange an opponent's crest that is not scoring in any arena. Not affected by cancel bonus.

Every 5 completed rows, columns or diagonals one of the blank spaces on the board will be randomly chosen as a bonus space [Shuffle] which shuffles the arenas on the board if a player fills it with his crest first, all crests are shuffled in the arenas . Not affected by cancel bonus.

Every 5 completed lines, columns or diagonals one of the blank spaces on the board will be randomly chosen as a bonus space [Flip] that if a player fills it with his coat of arms first, all coats of arms are reversed without the inversion of punctuation (i.e. the player A's coat of arms will be replaced by player B's and vice versa). Not affected by cancel bonus.

Every 5 completed rows, columns or diagonals one of the blank spaces on the board will be randomly chosen as an [Interroper] bonus space, which cancels the effect of the opponent's last applied bonus if it is still active.

## Gameplay

Players can perform their moves by touching the screen of the mobile device, where the match is taking place.

Each player is free to place a mark in any position on their turn, as long as the position is empty (no marks). By placing a mark on the board, the turn passes to the next player, and the process is repeated until the board is completely filled.

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen04.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen05.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen06.png)

Victory is achieved through the highest accumulated score in turns after filling the board.

It is possible to block the opponent if the pieces in vertical, horizontal or diagonal are filled with a coat of arms to block him as long as the random arena number allows this movement.

Analyzing the number of possibilities in a simplistic way, there are 362,880 (or 9!) ways to arrange each coat of arms in a single arena on the board, without considering winning moves. When we consider winning combinations, there are 255,168 possible games. Assuming that 'Player A' starts the game, if we consider that 'Player B' starts, the results are inverse.
The player can choose as a strategy to pass the turn at the end of the time if the player does not make any move before the end of the time of his turn.


# Art

## Concepts

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/concept03.png)

## Color palette

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/colors.png)

## UI

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen01.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen02.png)

![](https://raw.githubusercontent.com/xsery/tictactoehero/master/dev-artifacts/other/screen03.png)

# Sound Effects

The sound effects used during the match according to the list below:

The. Marker placement in the arena: sound effect for when the player places a mark on the screen.

B. Error: sound effect that indicates the attempt to place a marker in the wrong position in an unenabled arena.

w. Victory: sound effect played when the player wins the match.

d. Tie: sound effect played when the player ties the match.

e. Bonus: sound effect of dice thrown when a random element is inserted on the board.

f. Navigation: voice sound effect used when navigating between game menus.

g. Music: engaging that sends the player to an epic battle.


# Play


[PLAY](xxx/)


