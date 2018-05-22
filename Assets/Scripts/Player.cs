using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    // Constante com o valor do brasão do player 1
    public const int ARMS1 = 1;
    // Constante com o valor dos brasão do player 2
    public const int ARMS2 = 2;

    public new string name;
    public int order = 0;
    public Sprite armsSprite;
    [HideInInspector]
    public int arms = 0;
    public int score = 0;
    public Text scoreText;
    public Color playerColor;
    public Timer timer;
    public GameObject TurnMessagePrefab;
    public GameObject WinMessagePrefab;

    // Use this for initialization
    void Start () {
        this.arms = this.order == 0 ? ARMS1 : ARMS2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Soma os pontos no placar e atualiza a GUI
    /// </summary>
    /// <param name="points"></param>
    public void UpdateScore(int points)
    {
        this.score += points;
        this.scoreText.text = score.ToString("D3");
    }

    /// <summary>
    /// Limpa o score do jogador
    /// </summary>
    public void CleanScore()
    {
        this.score = 0;
        this.scoreText.text = score.ToString("D3");
    }

}
