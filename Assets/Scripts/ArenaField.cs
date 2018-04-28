using UnityEngine;
using UnityEngine.UI;

public class ArenaField : MonoBehaviour {

    public int collum;
    public int row;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Função responsável por selecionar o campo pressionado na arena
    /// </summary>
    public void OnClickField()
    {
        GameEngine engine = GameEngine.instance;
        GameManager manager = GameManager.instance;

        int player = manager.player;
        int arena = 0;
        engine.SetArms(player, arena, row, collum);
        manager.ChangePlayer();
        Image img = GetComponent<Image>();
        img.color = Color.white;
        img.sprite = manager.arms[player];
        this.GetComponent<Button>().interactable = false;
    }
}
