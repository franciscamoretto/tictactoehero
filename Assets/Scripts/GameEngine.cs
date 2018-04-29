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
    /// <param name="numArenas">Número de arenas do tabuleiro</param>
    public void CreateArenas(int numArenas)
    {
        int numPosicoes = NUM_ROW_COL * numArenas;
        board = new int[numPosicoes, numPosicoes];
    }

    /// <summary>
    /// Marca uma posição com o brasão do jogador na arena selecionada
    /// </summary>
    /// <param name="brasao">Valor do brasão X ou 0</param>
    /// <param name="arena">Número da arena</param>
    /// <param name="row">Linha selecionada pelo jogador</param>
    /// <param name="col">Coluna selecionado pelo jogador</param>
    public void SetArms(int brasao, int arena, int row, int col)
    {
        board[row * arena, col * arena] = brasao;
        CheckMatchLine(arena, row, col);
    }

    /// <summary>
    /// Verifica a existencia de combinação entre brasões em linhas, colunas e diagonal
    /// </summary>
    /// <param name="arena">Número da arena</param>
    /// <param name="row">Linha selecionada</param>
    /// <param name="col">Coluna selecionada</param>
    /// <returns></returns>
    private bool CheckMatchLine(int arena, int row, int col)
    {
        bool result = false;
        int arms = board[row * arena, col * arena];
        // Verifica combinação de brasões entre colunas (linha vertical)
        bool horizontalLine = (col == 0 && board[row, col + 1] == arms && board[row, col + 2] == arms) ||
            (col == 1 && board[row, col - 1] == arms && board[row, col + 1] == arms) ||
            (col == 2 && board[row, col - 1] == arms && board[row, col - 2] == arms);
        
        // Verifica combinação de brasões entre linhas (linha horizontal)
        bool verticalLine = (row == 0 && board[row + 1, col] == arms && board[row + 2, col] == arms) ||
            (row == 1 && board[row - 1, col] == arms && board[row + 1, col] == arms) ||
            (row == 2 && board[row - 1, col] == arms && board[row - 2, col] == arms);

        // verifica combinação nas diagonais
        bool diagonalLine = ((col == row && col == 0) && board[col + 1, row + 1] == arms && board[col + 2, row + 2] == arms) ||
            ((col == row && col == 1) && board[col - 1, row - 1] == arms && board[col + 1, row + 1] == arms) ||
            ((col == row && col == 2) && board[col - 1, row - 1] == arms && board[col - 2, row - 2] == arms);
        
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
            manager.PaintLine(arena, row, col, dir);

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
