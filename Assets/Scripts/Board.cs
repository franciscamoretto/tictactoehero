using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    private List<Arena> freeArenas;
    public int turnTime = 0;
    public float minRandomTime = 3f;
    public float maxRandomTime = 10f;
    private float endTime = 0f;
    private float refreshTimer = 0f;
    private float refreshDelay = 0.25f;
    private GameObject p1Selector;
    private GameObject p2Selector;
    private Arena arena;
    private bool selectingArena = false;
    public int selectedArena = -1;
    public int verticalArenas;
    public int horizontalArenas;
    public GameObject[] arenaSelectors = new GameObject[2];
    public delegate void BoardChosen();
    public static BoardChosen OnBoardChose;

	// Use this for initialization
	void Start () {
        this.freeArenas = new List<Arena>(this.GetComponentsInChildren<Arena>());
        GameEngine.instance.CreateArenas(verticalArenas, horizontalArenas);
        p1Selector = Instantiate(arenaSelectors[0], this.transform);
        p2Selector = Instantiate(arenaSelectors[1], this.transform);
        p1Selector.transform.localScale = freeArenas[0].transform.localScale;
        p2Selector.transform.localScale = freeArenas[0].transform.localScale;
        ChooseArena();
    }
	
	// Update is called once per frame
	void Update () {
        refreshTimer -= Time.deltaTime;
        bool isChoosingArena = this.endTime > Time.fixedTime;
        //Debug.Log("isChoosing: " + isChoosingArena);

        if (isChoosingArena  && refreshTimer <= 0 && freeArenas.Count > 1)
        {
            refreshTimer = refreshDelay;
            int iArena = Random.Range(0, freeArenas.Count);
            this.arena = freeArenas[iArena];
            if (arena.HasFreeField())
            {
                PaintSelectedArena(this.arena);    
            } else
            {
                freeArenas.Remove(this.arena);
            }
             
        } else if (freeArenas.Count == 1)
        {

            this.arena = this.freeArenas[0];
            this.selectedArena = this.arena.arenaNumber;
            PaintSelectedArena(this.arena);
            
            if (!arena.HasFreeField() && !GameManager.instance.isGameEnds)
            {
                GameManager.instance.FinishGame();
            }
        }

        if (!isChoosingArena)
        {
            if (arena.HasFreeField())
            {
                if (OnBoardChose != null && this.selectingArena)
                {
                    this.selectingArena = false;
                    this.selectedArena = this.arena.arenaNumber;
                    OnBoardChose();
                }
            } else
            {
                ChooseArena();
            }
        }
	}

    /// <summary>
    /// Pinta a arena selecionada
    /// </summary>
    /// <param name="arena">arena a ser selecionada</param>
    private void PaintSelectedArena(Arena arena)
    {
        Vector3 position = arena.transform.localPosition;
        if (GameManager.instance.GetPlayer().order == 0)
        {
            p2Selector.SetActive(false);
            p1Selector.SetActive(true);
            p1Selector.transform.localPosition = position;
        }
        else
        {
            p1Selector.SetActive(false);
            p2Selector.SetActive(true);
            p2Selector.transform.localPosition = position;
        }
    }

    /// <summary>
    /// Inicia a escolha ramdomica da arena
    /// </summary>
    public void ChooseArena()
    {
        this.selectingArena = true;
        if (freeArenas.Count > 1)
        {
            float randomTime = Random.Range(minRandomTime, maxRandomTime);
            this.endTime = Time.fixedTime + randomTime;
        }
    }
}
