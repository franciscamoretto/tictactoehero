using UnityEngine;
using UnityEngine.UI;

public class ArenaField : MonoBehaviour {

    public int column;
    public int row;
    public int arms;

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
        this.arms = player == 0 ? GameManager.ARMS1 : GameManager.ARMS2;
        int arena = this.GetComponentInParent<Arena>().arenaNumber;
        Image img = GetComponent<Image>();
        img.color = Color.white;
        img.sprite = manager.arms[player];
        this.GetComponent<Button>().interactable = false;
        engine.SetArms(this.arms, arena, row, column);
        manager.ChangePlayer();
    }

    /// <summary>
    /// Pinta a campo com a cor do jogador
    /// </summary>
    /// <param name="color">Cor do jogador</param>
    public void PaintMe(Color color)
    {
        Image img = GetComponent<Image>();
        img.color = color;
        img.sprite = null;
    }
}
