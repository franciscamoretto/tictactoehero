using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    /// <summary>
    /// Matriz do tabureiro das arenas
    /// </summary>
    private int[,] board = null;
    /// <summary>
    /// Constante que define o numero de linhas e colunas de uma arena
    /// </summary>
    public static int NUM_ROW_COL = 3;
    public int numHorizontalArenas;
    public int numVerticalArenas;
    public int linePoint = 30;
    public int extraPoint = 5;

    public static GameEngine instance = null;  //Static instance of GameEngine which allows it to be accessed by any other script.

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);        
    }


    // Use this for initialization
    void Start () {

	}

    /// <summary>
    /// Cria as arenas
    /// </summary>
    /// <param name="numVerticalArenas">Número de arenas na vertical (linhas) do tabuleiro</param>
    /// <param name="numHorizontalArenas">Número de arenas na horizontal (colunas) do tabuleiro</param>
    public void CreateArenas(int numVerticalArenas, int numHorizontalArenas)
    {
        this.numHorizontalArenas = numHorizontalArenas;
        this.numVerticalArenas = numVerticalArenas;
        board = new int[NUM_ROW_COL * numVerticalArenas, NUM_ROW_COL * numHorizontalArenas];
    }

    /// <summary>
    /// Marca uma posição com o brasão do jogador na arena selecionada
    /// </summary>
    /// <param name="brasao">Valor do brasão X ou 0</param>
    /// <param name="arena">Arena no tabuleiro</param>
    /// <param name="row">Linha selecionada pelo jogador</param>
    /// <param name="col">Coluna selecionado pelo jogador</param>
    public void SetArms(int brasao, Arena arena, int row, int col)
    {
        board[row + (NUM_ROW_COL * arena.row), col + (NUM_ROW_COL * arena.col)] = brasao;
        CheckMatchLine(arena, row, col);
    }

    /// <summary>
    /// Verifica a existencia de combinação entre brasões em linhas, colunas e diagonal
    /// </summary>
    /// <param name="arena">Arena no tabuleiro</param>
    /// <param name="row">Linha selecionada</param>
    /// <param name="col">Coluna selecionada</param>
    /// <returns></returns>
    private bool CheckMatchLine(Arena arena, int row, int col)
    {
        bool result = false;
        int localRow = (NUM_ROW_COL * arena.row) + row;
        int localCol = (NUM_ROW_COL * arena.col) + col;
        int arms = board[localRow, localCol];
        int startRow = NUM_ROW_COL * arena.row;
        int startCol = NUM_ROW_COL * arena.col;

        // Verifica combinação de brasões entre colunas (linha vertical)
        bool horizontalLine = board[localRow, startCol] == arms && 
            board[localRow, startCol + 1] == arms && 
            board[localRow, startCol + 2] == arms;

        // Verifica combinação de brasões entre linhas (linha horizontal)
        bool verticalLine = board[startRow, localCol] == arms && 
            board[startRow + 1, localCol] == arms && 
            board[startRow + 2, localCol] == arms;

        // verifica combinação na diagonal primaria da matriz
        bool primaryDiagonal = board[startRow, startCol] == arms && 
            board[startRow + 1, startCol + 1] == arms && 
            board[startRow + 2, startCol + 2] == arms &&
            row == col;

        // verifica combinação na diagonal secundária da matriz
        bool secundaryDiagonal = board[startRow + NUM_ROW_COL - 1, startCol] == arms && 
            board[startRow + 1, startCol + 1] == arms && 
            board[startRow, startCol + NUM_ROW_COL - 1] == arms &&
            (row + col == NUM_ROW_COL - 1);
 
        
        if ( verticalLine  || horizontalLine || primaryDiagonal || secundaryDiagonal)
        {
            GameManager manager = GameManager.instance;
            Arena.DIRECTION dir = Arena.DIRECTION.diagonalP;
            if (verticalLine)
            {
                dir = Arena.DIRECTION.vertical;
                manager.ScorePoints(this.linePoint);
                arena.PaintLine(row, col, dir);
            }
            if (horizontalLine)
            {
                dir = Arena.DIRECTION.horizontal;
                manager.ScorePoints(this.linePoint);
                arena.PaintLine(row, col, dir);
            }
            if (primaryDiagonal)
            {
                dir = Arena.DIRECTION.diagonalP;
                manager.ScorePoints(this.linePoint);
                arena.PaintLine(row, col, dir);
            }
            if (secundaryDiagonal)
            {
                dir = Arena.DIRECTION.diagonalS;
                manager.ScorePoints(this.linePoint);
                arena.PaintLine(row, col, dir);
            }

            result = true;
        }
        return result;
    }

    /// <summary>
    /// Conta o número de pontos extras do jogador
    /// </summary>
    public void CountExtraPoints()
    {
        VerifyExtraLines(Arena.DIRECTION.horizontal);
        VerifyExtraLines(Arena.DIRECTION.vertical);
        
        VerifyDiagonalExtraPoint(Arena.DIRECTION.diagonalP);
        VerifyDiagonalExtraPoint(Arena.DIRECTION.diagonalS);
    }

    /// <summary>
    /// Verifica se as linhas do tabuleiro possuem pontos extras
    /// </summary>
    /// <param name="dir">Direçãodas linhas</param>
    private void VerifyExtraLines(Arena.DIRECTION dir)
    {
        int previewArms = -1;
        int arms = 0;
        int count = 1;
        int[] firstPos = new int[2];
        int totalA, totalB = 0;
        int player = -1;

        if (dir.Equals(Arena.DIRECTION.horizontal))
        {
            totalA = this.numHorizontalArenas * NUM_ROW_COL;
            totalB = this.numVerticalArenas* NUM_ROW_COL;
        } else
        {
            totalA = this.numVerticalArenas * NUM_ROW_COL;
            totalB = this.numHorizontalArenas * NUM_ROW_COL;
        }

        Debug.Log("Verificando linhas " + dir.ToString());
        for (int i = 0; i < totalA; i++)
        {
            previewArms = -1;
            if (count >= NUM_ROW_COL)
            {
                player = arms == GameManager.ARMS1 ? 0 : 1;
                ScoreExtraPoints(firstPos, count, dir, player);
                count = 0;
            }
            for (int j = 0; j < totalB; j++)
            {
                if (dir.Equals(Arena.DIRECTION.horizontal))
                {
                    arms = board[i, j];
                } else
                {
                    arms = board[j, i];
                }
                if (previewArms == arms)
                {
                    count++;
                }
                else
                {
                    player = previewArms == GameManager.ARMS1 ? 0 : 1;
                    ScoreExtraPoints(firstPos, count, dir, player);
                    previewArms = arms;
                    count = 1;
                    firstPos[0] = i;
                    firstPos[1] = j;   
                }
            }
        }
        if (count >= NUM_ROW_COL)
        {
            ScoreExtraPoints(firstPos, count, dir, player);
        }
    }

    /// <summary>
    /// Verifica se existe pontos na diagonal da arena
    /// </summary>
    private void VerifyDiagonalExtraPoint(Arena.DIRECTION dir)
    {
        Debug.Log("Verificando linhas " + dir.ToString());
        int previewArms = -1;
        int arms = 0;
        int count = 1;
        int[] firstPos = new int[2];
        int player = -1;
        for (int i = 0; i < this.numHorizontalArenas * NUM_ROW_COL; i++)
        {
            if (dir.Equals(Arena.DIRECTION.diagonalP))
            {
                arms = board[i, i];
            }
            else if (dir.Equals(Arena.DIRECTION.diagonalS))
            {   
                arms = board[i,(NUM_ROW_COL * this.numHorizontalArenas) - 1 - i];
            }
            
            if (previewArms == arms)
            {
                count++;
            }
            else
            {
                player = previewArms == GameManager.ARMS1 ? 0 : 1;
                ScoreExtraPoints(firstPos, count, Arena.DIRECTION.diagonalP, player);
                previewArms = arms;
                count = 1;
                if (dir.Equals(Arena.DIRECTION.diagonalP))
                {
                    firstPos[0] = i;
                    firstPos[1] = i;
                } else if (dir.Equals(Arena.DIRECTION.diagonalS))
                {
                    firstPos[0] = i;
                    firstPos[1] = (NUM_ROW_COL * this.numHorizontalArenas) -1 - i;
                }
            }
        }
        if (count >= NUM_ROW_COL)
        {
            ScoreExtraPoints(firstPos, count, dir, player);
        }
    }

    /// <summary>
    /// Marca os pontos extras se existir linhas extras
    /// </summary>
    /// <param name="firstPos">int[] - vetor com os valor da linha e coluna do primeiro brasão encontrado</param>
    /// <param name="count">int - número de repetições do brasão</param>
    /// <param name="dir">Arena.DIRECTION - direção da linha</param>
    private void ScoreExtraPoints(int[] firstPos, int count, Arena.DIRECTION dir, int player)
    {
        bool hasScore = false;
        if (count >= NUM_ROW_COL )
        {
            hasScore = IsExtraPoint(firstPos[1], count, dir);
        }

        if (hasScore)
        {
            int points = count * this.extraPoint;
            GameManager.instance.ScorePoints(points, player);
        }
    }

    /// <summary>
    /// Verifica se a linha inicia em uma arena e termina em outra
    /// </summary>
    /// <param name="startPos">Primeira posição do brasão </param>
    /// <param name="count">Número de repetições do brasão</param>
    /// <returns>True se a linha iniciar em uma arena e terminar em outra</returns>
    private bool IsExtraPoint(int startPos, int count, Arena.DIRECTION dir)
    {
        int lastPos = 0;
        if (dir.Equals(Arena.DIRECTION.diagonalS))
        {
            lastPos = startPos - count + 1;
        } else
        {
            lastPos = startPos + count - 1;
        }
        return ((int)startPos / 3 != (int)lastPos / 3);
    }
	 
}