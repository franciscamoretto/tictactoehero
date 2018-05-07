using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    // Constante com o valor do brasão do player 1
    public const int ARMS1 = 1;
    // Constante com o valor dos brasão do player 2
    public const int ARMS2 = 2;

    private const int OFFSET = 10;
    // Jogador que está na vez
    public int player = 0;
    public Sprite[] arms = new Sprite[2];
    public Color[] playerColor = new Color[2];
    public int numOfArenas = 1;
    public Transform mainCanvas;
    public GameObject arenaPrefab;
    public Text P1Score;
    public Text P2Score;
    public GameObject easyBoardPrefab;
    public GameObject mediumBoardPrefab;
    public GameObject heroBoardPrefab;
    public bool isGameEnds = false;

    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private GAMELEVEL gameLevel;
    private GameObject board;

    public enum GAMELEVEL { easy, medium, hero };

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        this.isGameEnds = false;
        this.P1Score.text = "000";
        this.P2Score.text = "000";
        this.scoreP1 = 0;
        this.scoreP2 = 0;
    }

    /// <summary>
    /// Finaliza o jogo
    /// </summary>
    public void FinishGame()
    {
        this.isGameEnds = true;
        GameEngine.instance.CountExtraPoints();
        if (scoreP1 > scoreP2)
        {
            Debug.Log("Player 1 Wins");
            // TODO: Player 1 Wins
        } else
        {
            Debug.Log("Player 1 Wins");
            // TODO: Player 2 Wins
        }
    } 

    /// <summary>
    /// Inicia um novo jogo
    /// </summary>
    /// <param name="level">Nível do jogo</param>
    public void NewGame(GAMELEVEL level)
    {
        this.gameLevel = level;
        if (level.Equals(GAMELEVEL.easy))
        {
            this.board = Instantiate(easyBoardPrefab, mainCanvas);
        }
        else if (level.Equals(GAMELEVEL.medium))
        {
            this.board = Instantiate(mediumBoardPrefab, mainCanvas);
        }
        else
        {
            this.board = Instantiate(heroBoardPrefab, mainCanvas);
        }
    }
    

    /// <summary>
    /// Reinicia o jogo
    /// </summary>
    public void RestartGame()
    {
        DestroyImmediate(this.board);
        InitGame();
        NewGame(this.gameLevel);
    }

    // Update is called once per frame
    void Update () {
		
	}

    /// <summary>
    /// Altera o player que está jogando
    /// </summary>
    public void ChangePlayer()
    {
        this.player = this.player == 0 ? 1 : 0;
        this.board.GetComponent<Board>().ChooseArena();
    }

    /// <summary>
    /// Marca pontos no placar do jogador selecionado
    /// </summary>
    /// <param name="points">Número de pontos</param>
    /// <param name="player">Jogador</param>
    public void ScorePoints(int points, int player)
    {
        this.player = player;
        ScorePoints(points);
    }

    /// <summary>
    /// Marca pontos no placar do jogador atual
    /// </summary>
    /// <param name="points">Número de pontos</param>
    public void ScorePoints(int points)
    {
        if (player == 0)
        {
            scoreP1 += points;
            Debug.Log("Player0" + "points:" + points + "Total:" + scoreP1);
            P1Score.text = scoreP1.ToString();
        } else
        {
            Debug.Log("Player1" + "points:" + points + "Total:" + scoreP2);
            scoreP2 += points;
            P2Score.text = scoreP2.ToString();
        }
    }

    /// <summary>
    /// Retorna a cor do player
    /// </summary>
    /// <returns>Cor do player</returns>
    public Color GetPlayerColor()
    {
        return this.playerColor[this.player];
    }

}
