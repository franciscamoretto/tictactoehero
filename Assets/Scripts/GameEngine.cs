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
        // Verifica combinação de brasões entre colunas (linha vertical)
        bool horizontalLine = (col == 0 && board[localRow, localCol + 1] == arms && board[localRow, localCol + 2] == arms) ||
            (col == 1 && board[localRow, localCol - 1] == arms && board[localRow, localCol + 1] == arms) ||
            (col == 2 && board[localRow, localCol - 1] == arms && board[localRow, localCol - 2] == arms);
        
        // Verifica combinação de brasões entre linhas (linha horizontal)
        bool verticalLine = (row == 0 && board[localRow + 1, localCol] == arms && board[localRow + 2, localCol] == arms) ||
            (row == 1 && board[localRow - 1, localCol] == arms && board[localRow + 1, localCol] == arms) ||
            (row == 2 && board[localRow - 1, localCol] == arms && board[localRow - 2, localCol] == arms);

        // verifica combinação na diagonal primaria da matriz
        bool primaryDiagonal = ((col == row) && (
            (col == 0 && board[localRow + 1, localCol + 1] == arms && board[localRow + 2, localCol + 2] == arms) ||
            (col == 1 && board[localRow - 1, localCol - 1] == arms && board[localRow + 1, localCol + 1] == arms) ||
            (col == 2 && board[localRow - 1, localCol - 1] == arms && board[localRow - 2, localCol - 2] == arms)
            ));

        // verifica combinação na diagonal secundária da matriz
        bool secundaryDiagonal = ((col + row == NUM_ROW_COL - 1) && (
            (col == 0 && board[localRow - 1, localCol + 1] == arms && board[localRow - 2, localCol + 2] == arms) ||
            (col == 1 && board[localRow - 1, localCol + 1] == arms && board[localRow + 1, localCol - 1] == arms) ||
            (col == 2 && board[localRow + 1, localCol - 1] == arms && board[localRow + 2, localCol - 2] == arms) 
            ));
        
        if ( verticalLine  || horizontalLine || primaryDiagonal || secundaryDiagonal)
        {
            GameManager manager = GameManager.instance;
            Arena.DIRECTION dir = Arena.DIRECTION.diagonalP;
            if (verticalLine)
            {
                dir = Arena.DIRECTION.vertical;
                manager.ScorePoints(30);
                arena.PaintLine(row, col, dir);
            }
            if (horizontalLine)
            {
                dir = Arena.DIRECTION.horizontal;
                manager.ScorePoints(30);
                arena.PaintLine(row, col, dir);
            }
            if (primaryDiagonal)
            {
                dir = Arena.DIRECTION.diagonalP;
                manager.ScorePoints(30);
                arena.PaintLine(row, col, dir);
            }
            if (secundaryDiagonal)
            {
                dir = Arena.DIRECTION.diagonalS;
                manager.ScorePoints(30);
                arena.PaintLine(row, col, dir);
            }

            result = true;
        }
        Debug.Log("Brasão: " + arms + " localRow: " + localRow + " localCol: " + localCol + 
            " row: " + row + " col: " + col );
        Debug.Log("VerticalLine: " + verticalLine + " HorizontalLine: " + horizontalLine + " DiagonalP: " + 
            primaryDiagonal + " diagonalS: " + secundaryDiagonal);
        return result;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
