using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private GameManager manager;

    private void Start()
    {
        this.manager = GameManager.instance;
    }

    /// <summary>
    /// Inicia um jogo rápido 2x2
    /// </summary>
    public void PlayQuickGame()
    {
        PlayGame(GameManager.GAMELMODE.quick);
    }

    /// <summary>
    /// Inicia um jogo medio 2x3
    /// </summary>
    public void PlayNormalGame()
    {
        PlayGame(GameManager.GAMELMODE.normal);
    }

    /// <summary>
    /// Inicia um jogo Hero 3x3
    /// </summary>
    public void PlayHeroGame()
    {
        PlayGame(GameManager.GAMELMODE.hero);
    }

    /// <summary>
    /// Inicia um novo jogo
    /// </summary>
    /// <param name="mode">Modo do Jogo</param>
    private void PlayGame(GameManager.GAMELMODE mode)
    {
        this.manager.gameMode = mode;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }


    
}
