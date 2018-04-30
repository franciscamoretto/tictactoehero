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
    public Transform board;
    public GameObject arenaPrefab;
    public Text P1Score;
    public Text P2Score;

    private int scoreP1 = 0;
    private int scoreP2 = 0;
    private GameObject[] arenas = null;

    public enum DIRECTION { vertical, horizontal, diagonal };

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
        this.numOfArenas = (int) Mathf.Pow(numOfArenas, numOfArenas);
        GameEngine.instance.CreateArenas(numOfArenas);
        this.arenas = new GameObject[numOfArenas];
        Vector3 position = Vector3.zero;
        for (int i = 0; i < numOfArenas; i++)
        {
            board.transform.position = new Vector3(position.x - (200*i), position.y);
            GameObject arena = Instantiate(arenaPrefab, board);
            arena.GetComponent<Arena>().arenaNumber = i + 1; 
            arenas[i] = arena;
            arena.transform.localPosition = position;
            Vector2 size = arena.GetComponent<BoxCollider2D>().size;
            Vector2 scale = arena.transform.localScale;
            position = new Vector3( position.x + (size.x * scale.x) + OFFSET, position.y);

        }
    }

    /// <summary>
    /// Rwinicia o jogo
    /// </summary>
    public void RestartGame()
    {
        for (int i = 0; i < numOfArenas; i++)
        {
            DestroyImmediate(arenas[i]);
        }
        InitGame();
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
            P1Score.text = scoreP1.ToString();
        } else
        {
            scoreP2 += points;
            P2Score.text = scoreP2.ToString();
        }
    }

    /// <summary>
    /// Pinta uma linha da arena
    /// </summary>
    /// <param name="posArena">Posição da arena no tabuleiro</param>
    /// <param name="row">Número da linha</param>
    /// <param name="col">Número da coluna</param>
    /// <param name="dir">Direção da linha</param>
    public void PaintLine(Vector2 posArena, int row, int col, DIRECTION dir)
    {
        GameObject arena = arenas[posArena - 1];
        ArenaField[] fields = arena.GetComponentsInChildren<ArenaField>();
        if (dir.Equals(DIRECTION.horizontal))
        {
            foreach(ArenaField field in fields)
            {
                if (field.row == row)
                {
                    field.PaintMe(this.playerColor[player]);
                }
            }
        } else if (dir.Equals(DIRECTION.vertical)) {
            foreach (ArenaField field in fields)
            {
                if (field.column == col)
                {
                    field.PaintMe(this.playerColor[player]);
                }
            }
        } else
        {
            foreach (ArenaField field in fields)
            {
                if (field.row == field.column)
                {
                    field.PaintMe(this.playerColor[player]);
                }
            }
        }
    }
}
