using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    private Arena[] arenas;
    public int verticalArenas;
    public int horizontalArenas;

	// Use this for initialization
	void Start () {
        this.arenas = this.GetComponentsInChildren<Arena>();
        GameEngine.instance.CreateArenas();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
