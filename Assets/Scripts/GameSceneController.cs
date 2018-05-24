using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour {

    public Button[] menuButtons;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        Board.OnBoardChose += EnableMenuButton;
        Board.OnStartBoardChoosing += DisableMenuButton;
    }

    private void OnDisable()
    {
        Board.OnBoardChose -= EnableMenuButton;
        Board.OnStartBoardChoosing -= DisableMenuButton;
    }

    /// <summary>
    /// Habilita o botão de menu
    /// </summary>
    private void EnableMenuButton()
    {
        foreach (Button menu in this.menuButtons)
        {
            menu.interactable = true;
        }
    }

    /// <summary>
    /// Desabilita o botão de menu
    /// </summary>
    private void DisableMenuButton()
    {
        foreach (Button menu in this.menuButtons)
        {
            menu.interactable = false;
        }
    }
}
