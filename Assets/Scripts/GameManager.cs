using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject arenaPrefab;
    public GameObject quickBoardPrefab;
    public GameObject normalBoardPrefab;
    public GameObject heroBoardPrefab;
    public bool isGameEnds = false;
    public GAMELMODE gameMode;

    private Timer gameTimer;
    private Transform mainCanvas;
    private Text P1Score;
    private Text P2Score;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private GameObject board;

    public enum GAMELMODE { quick, normal, hero };

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
    }

    //Initializes the game for each level.
    void InitGame()
    {
        this.isGameEnds = false;
        this.P1Score.text = "000";
        this.P2Score.text = "000";
        this.scoreP1 = 0;
        this.scoreP2 = 0;
        int time = 4;
        if (gameMode.Equals(GAMELMODE.quick))
        {
            time = 11;
        } else if (gameMode.Equals(GAMELMODE.normal)) {
            time = 6;
        }
        this.gameTimer.totalTime = time;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Timer.OnTimeOut += ChangePlayer;
        Board.OnBoardChose += StartTimer;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Timer.OnTimeOut -= ChangePlayer;
        Board.OnBoardChose -= StartTimer;
    }

    /// <summary>
    /// Função disparada quando ocorre um evento para carregar uma cena
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {  
        if (scene.name.Equals("Game"))
        {
            this.P1Score = GameObject.FindGameObjectWithTag("P1Score").GetComponent<Text>();
            this.P2Score = GameObject.FindGameObjectWithTag("P2Score").GetComponent<Text>();
            this.mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
            this.gameTimer = GameObject.FindObjectOfType<Timer>();
            NewGame();
        }
    }

    private void StartTimer()
    {
        this.gameTimer.ResetTimer();
        this.gameTimer.StartTimer();
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
    public void NewGame()
    {
        InitGame();
        if (this.gameMode.Equals(GAMELMODE.quick))
        {
            this.board = Instantiate(quickBoardPrefab, mainCanvas);
        }
        else if (this.gameMode.Equals(GAMELMODE.normal))
        {
            this.board = Instantiate(normalBoardPrefab, mainCanvas);
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
        NewGame();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
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
        this.gameTimer.PauseTimer();
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
            Debug.Log("Player1 points: " + points + " Total: " + scoreP1);
            P1Score.text = scoreP1.ToString();
        } else
        {
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
