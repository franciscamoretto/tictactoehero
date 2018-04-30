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
    private const int NUM_ROW_COL = 3;
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
    /// <param name="arena">Posição da arena no tabuleiro</param>
    /// <param name="row">Linha selecionada pelo jogador</param>
    /// <param name="col">Coluna selecionado pelo jogador</param>
    public void SetArms(int brasao, Vector2 arena, int row, int col)
    {
        board[row * (int) arena.x, col * (int)arena.y] = brasao;
        CheckMatchLine(arena, row, col);
    }

    /// <summary>
    /// Verifica a existencia de combinação entre brasões em linhas, colunas e diagonal
    /// </summary>
    /// <param name="arena">Posição da arena no tabuleiro</param>
    /// <param name="row">Linha selecionada</param>
    /// <param name="col">Coluna selecionada</param>
    /// <returns></returns>
    private bool CheckMatchLine(Vector2 arena, int row, int col)
    {
        bool result = false;
        int localRow = (NUM_ROW_COL * (int)arena.x) + row;
        int localCol = (NUM_ROW_COL * (int)arena.y) + col;
        int arms = board[localRow, localCol];
        // Verifica combinação de brasões entre colunas (linha vertical)
        bool horizontalLine = (col == 0 && board[localRow, localCol + 1] == arms && board[localRow, localCol + 2] == arms) ||
            (col == 1 && board[localRow, localCol - 1] == arms && board[localRow, localCol + 1] == arms) ||
            (col == 2 && board[localRow, localCol - 1] == arms && board[localRow, localCol - 2] == arms);
        
        // Verifica combinação de brasões entre linhas (linha horizontal)
        bool verticalLine = (row == 0 && board[localRow + 1, localCol] == arms && board[localRow + 2, localCol] == arms) ||
            (row == 1 && board[localRow - 1, localCol] == arms && board[localRow + 1, localCol] == arms) ||
            (row == 2 && board[localRow - 1, localCol] == arms && board[localRow - 2, localCol] == arms);

        // verifica combinação nas diagonais
        bool diagonalLine = ((localCol == localRow && col == 0) && board[localCol + 1, localRow + 1] == arms && board[localCol + 2, localRow + 2] == arms) ||
            ((localCol == localRow && col == 1) && board[localCol - 1, localRow - 1] == arms && board[localCol + 1, localRow + 1] == arms) ||
            ((localCol == localRow && col == 2) && board[localCol - 1, localRow - 1] == arms && board[localCol - 2, localRow - 2] == arms);
        
        if ( verticalLine  || horizontalLine || diagonalLine)
        {
            GameManager.DIRECTION dir = GameManager.DIRECTION.diagonal;
            if (verticalLine)
            {
                dir = GameManager.DIRECTION.vertical;
            } else if (horizontalLine)
            {
                dir = GameManager.DIRECTION.horizontal;
            }
            GameManager manager = GameManager.instance;
            manager.ScorePoints(30);
            manager.PaintLine(arena, localRow, localCol, dir);

            result = true;
        }
        Debug.Log("Brasão: " + arms);
        Debug.Log("VerticalLine: " + verticalLine + " HorizontalLine: " + horizontalLine + " DiagonalLine: " + diagonalLine);
        return result;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
