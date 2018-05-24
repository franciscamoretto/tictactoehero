using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.
    private const int OFFSET = 10;
    public enum GAMELMODE { quick, normal, hero };

    public GameObject quickBoardPrefab;
    public GameObject normalBoardPrefab;
    public GameObject heroBoardPrefab;
    public bool isGameEnds = false;
    public GAMELMODE gameMode;
    public GameObject DrawMessagePrefab;

    // Jogador que está na vez
    private Player player;
    private Player[] players = new Player[2];
    private List<GameObject> playerTurnMsg = new List<GameObject>();
    private GameObject board;
    private GameObject winMessage;
    private Transform boardArea;


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
            Player[] playerList = FindObjectsOfType<Player>();
            foreach (Player p in playerList)
            {
                this.players[p.order] = p;
            }
            this.boardArea = GameObject.FindGameObjectWithTag("MainCanvas").transform;            
            
            NewGame();
        }
    }

    //Initializes the game for each level.
    void InitGame()
    {
        this.isGameEnds = false;
        DestroyImmediate(this.winMessage);
        int time = this.board.GetComponent<Board>().turnTime;
        this.playerTurnMsg.Clear();
        foreach (Player player in this.players)
        {
            player.CleanScore();
            player.timer.totalTime = time;
            GameObject obj = Instantiate(player.TurnMessagePrefab, this.boardArea);
            this.playerTurnMsg.Add(obj);
        }
        this.player = this.players[0];
    }

    /// <summary>
    /// Inicia um novo jogo
    /// </summary>
    public void NewGame()
    {
        if (this.gameMode.Equals(GAMELMODE.quick))
        {
            this.board = Instantiate(quickBoardPrefab, this.boardArea);
        }
        else if (this.gameMode.Equals(GAMELMODE.normal))
        {
            this.board = Instantiate(normalBoardPrefab, this.boardArea);
        }
        else
        {
            this.board = Instantiate(heroBoardPrefab, this.boardArea);
        }
        this.board.transform.SetAsFirstSibling();
        InitGame();
    }


    /// <summary>
    /// Finaliza o jogo
    /// </summary>
    public void FinishGame()
    {
        this.playerTurnMsg[this.player.order].SetActive(false);
        this.isGameEnds = true;
        GameEngine.instance.CountExtraPoints();
        
        if (this.players[0].score > this.players[1].score)
        {
            Debug.Log("Player 1 Wins");
            this.winMessage = Instantiate(this.players[0].WinMessagePrefab, this.boardArea);

        } else if (this.players[0].score < this.players[1].score)
        {
            Debug.Log("Player 2 Wins");
            this.winMessage = Instantiate(this.players[1].WinMessagePrefab, this.boardArea);

        } else
        {
            this.winMessage = Instantiate(this.DrawMessagePrefab, this.boardArea);
        }
        
    }

    /// <summary>
    /// Retorna o Player da vez
    /// </summary>
    /// <returns>Player</returns>
    public Player GetPlayer()
    {
        return this.player;
    }
    
    
    /// <summary>
    /// Reinicia o jogo
    /// </summary>
    public void RestartGame()
    {
        DestroyImmediate(this.board);
        NewGame();
    }

    /// <summary>
    /// Inicia o contador de tempo
    /// </summary>
    private void StartTimer()
    {
        this.player.timer.ResetTimer();
        this.player.timer.StartTimer();
    }

    /// <summary>
    /// Pausa o timer do jogador
    /// </summary>
    public void PauseGame(bool pause)
    {
        if (pause) {
            this.player.timer.PauseTimer();
        } else
        {
            this.player.timer.StartTimer();
        }
    }


    /// <summary>
    /// Altera o player que está jogando
    /// </summary>
    public void ChangePlayer()
    {
        this.player.timer.PauseTimer();
        this.player = this.player.order == 0 ? this.players[1] : this.players[0];
        this.playerTurnMsg[this.player.order].SetActive(true);
        Invoke("ChoseArena", 1);
    }

    /// <summary>
    /// Inicia a escolha da arena
    /// </summary>
    private void ChoseArena()
    {
        this.playerTurnMsg[this.player.order].SetActive(false);
        this.board.GetComponent<Board>().ChooseArena();
    }

    /// <summary>
    /// Marca pontos no placar do jogador selecionado
    /// </summary>
    /// <param name="points">Número de pontos</param>
    /// <param name="player">Jogador</param>
    public void ScorePoints(int points, int player)
    {
        this.player = this.players[player];
        ScorePoints(points);
    }

    /// <summary>
    /// Marca pontos no placar do jogador atual
    /// </summary>
    /// <param name="points">Número de pontos</param>
    public void ScorePoints(int points)
    {
        this.player.UpdateScore(points);
    }

    /// <summary>
    /// Retorna a cor do player
    /// </summary>
    /// <returns>Cor do player</returns>
    public Color GetPlayerColor()
    {
        return this.player.playerColor;
    }

}
