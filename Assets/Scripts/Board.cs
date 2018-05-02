using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    private Arena[] arenas;
    public float minRandomTime = 3f;
    public float maxRandomTime = 10f;
    private float endTime = 0f;
    private float refreshTimer = 0f;
    private float refreshDelay = 0.25f;
    private GameObject p1Selector;
    private GameObject p2Selector;
    public int verticalArenas;
    public int horizontalArenas;
    public GameObject[] arenaSelectors = new GameObject[2];

	// Use this for initialization
	void Start () {
        this.arenas = this.GetComponentsInChildren<Arena>();
        GameEngine.instance.CreateArenas(verticalArenas, horizontalArenas);
        p1Selector = Instantiate(arenaSelectors[0], this.transform);
        p2Selector = Instantiate(arenaSelectors[1], this.transform);
        p1Selector.transform.localScale = arenas[0].transform.localScale;
        p2Selector.transform.localScale = arenas[0].transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        refreshTimer -= Time.deltaTime;
        if (this.endTime > Time.fixedTime && refreshTimer <= 0)
        {
            refreshTimer = refreshDelay;
            int iArena = Random.Range(0, arenas.Length);
            Vector3 position = arenas[iArena].transform.localPosition;
            Debug.Log("Choosing arena: " + iArena);
            Debug.Log("start: " + endTime + " time: " + Time.fixedTime);
            if (GameManager.instance.player == 0)
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
		
	}

    /// <summary>
    /// Inicia a escolha ramdomica da arena
    /// </summary>
    public void ChooseArena()
    {
        float randomTime = Random.Range(minRandomTime, maxRandomTime);
        this.endTime = Time.fixedTime + randomTime;
    }
}
