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
    public enum GAMELMODE { quick, normal, hero };

    // Jogador que está na vez
    public int player = 0;
    public Sprite[] arms = new Sprite[2];
    public Color[] playerColor = new Color[2];
    public GameObject[] playerTurnMessagePrefab = new GameObject[2];
    public GameObject[] playerWinMessagePrefab = new GameObject[2];
    public GameObject arenaPrefab;
    public GameObject quickBoardPrefab;
    public GameObject normalBoardPrefab;
    public GameObject heroBoardPrefab;
    public bool isGameEnds = false;
    public GAMELMODE gameMode;

    private List<GameObject> playerTurnMsg = new List<GameObject>();
    private Timer gameTimer;
    private Transform mainCanvas;
    private Text P1Score;
    private Text P2Score;
    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private GameObject board;
    private GameObject winMessage;


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
            foreach (GameObject turnMsg in this.playerTurnMessagePrefab)
            {
                GameObject obj = Instantiate(turnMsg, this.mainCanvas);
                this.playerTurnMsg.Add(obj);
            }
        }
    }

    //Initializes the game for each level.
    void InitGame()
    {
        this.isGameEnds = false;
        DestroyImmediate(this.winMessage);
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

    /// <summary>
    /// Inicia o contador de tempo
    /// </summary>
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
        this.playerTurnMsg[this.player].SetActive(false);
        this.isGameEnds = true;
        GameEngine.instance.CountExtraPoints();
        if (scoreP1 > scoreP2)
        {
            Debug.Log("Player 1 Wins");
            this.winMessage = Instantiate(this.playerWinMessagePrefab[0], this.mainCanvas);
        } else
        {
            Debug.Log("Player 1 Wins");
            this.winMessage = Instantiate(this.playerWinMessagePrefab[1], this.mainCanvas);
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
        this.playerTurnMsg[this.player].SetActive(true);
        Invoke("ChoseArena", 1);
    }

    /// <summary>
    /// Inicia a escolha da arena
    /// </summary>
    private void ChoseArena()
    {
        this.playerTurnMsg[this.player].SetActive(false);
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
            Debug.Log("Player2 points: " + points + " Total: " + scoreP2);
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
