using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour {

    /// <summary>
    /// Numero de arenas, minimo de 4 arenas
    /// </summary>
    public int numArenas = 4;
    /// <summary>
    /// Matriz do tabureiro das arenas
    /// </summary>
    private int[,] board;
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
        createArenas(numArenas);
	}

    /// <summary>
    /// Cria as arenas
    /// </summary>
    /// <param name="numArenas">Número de arenas do tabuleiro</param>
    public void createArenas(int numArenas)
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
        checkMatchLine(arena, row, col);
    }

    /// <summary>
    /// Verifica a existencia de combinação entre brasões em linhas, colunas e diagonal
    /// </summary>
    /// <param name="arena">Número da arena</param>
    /// <param name="row">Linha selecionada</param>
    /// <param name="col">Coluna selecionada</param>
    /// <returns></returns>
    private bool checkMatchLine(int arena, int row, int col)
    {
        bool result = false;
        int brasao = board[row * arena, col * arena];
        // Verifica combinação de brasões entre colunas (linha vertical)
        bool verticalLine = (col == 0 && board[row, col + 1] == brasao && board[row, col + 2] == brasao) ||
            (col == 1 && board[row, col - 1] == brasao && board[row, col + 1] == brasao) ||
            (col == 2 && board[row, col - 1] == brasao && board[row, col - 2] == brasao);
        
        // Verifica combinação de brasões entre linhas (linha horizontal)
        bool horizontalLine = (row == 0 && board[row + 1, col] == brasao && board[row + 2, col] == brasao) ||
            (row == 1 && board[row - 1, col] == brasao && board[row + 1, col] == brasao) ||
            (row == 2 && board[row - 1, col] == brasao && board[row - 2, col] == brasao);

        // verifica combinação nas diagonais
        bool diagonalLine = ((col == row && col == 0) && board[col + 1, row + 1] == brasao && board[col + 2, row + 2] == brasao) ||
            ((col == row && col == 1) && board[col - 1, row - 1] == brasao && board[col + 1, row + 1] == brasao) ||
            ((col == row && col == 2) && board[col - 1, row - 1] == brasao && board[col - 2, row - 2] == brasao);
        
        if ( verticalLine  || horizontalLine || diagonalLine)
        {
            result = true;
        }
        return result;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
