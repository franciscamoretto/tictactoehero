using UnityEngine;
using UnityEngine.UI;

public class ArenaField : MonoBehaviour {

    public Arena arena;
    public int column;
    public int row;
    public int arms;
    private int spriteIndex = 0;

	// Use this for initialization
	void Start () {
        this.arena = GetComponentInParent<Arena>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Função responsável por selecionar o campo pressionado na arena
    /// </summary>
    public void OnClickField()
    {
        if (arena.isSelected())
        {
            GameEngine engine = GameEngine.instance;
            GameManager manager = GameManager.instance;

            Player player = manager.GetPlayer();
            Image img = GetComponent<Image>();
            img.color = Color.white;
            img.sprite = player.armsSprite[0];
            this.arms = player.arms;
            this.GetComponent<Button>().interactable = false;
            engine.SetArms(this.arms, this.arena, row, column);
            manager.ChangePlayer();
        }
    }

    /// <summary>
    /// Pinta a campo com a cor do jogador
    /// </summary>
    /// <param name="color">Cor do jogador</param>
    public void PaintMe(Player player, Arena.DIRECTION dir)
    {
        switch (dir)
        {
            case Arena.DIRECTION.horizontal:
                this.spriteIndex |= 1;
                break;
            case Arena.DIRECTION.vertical:
                this.spriteIndex |= 2;
                break;
            case Arena.DIRECTION.diagonalP:
                this.spriteIndex |= 4;
                break;
            case Arena.DIRECTION.diagonalS:
                this.spriteIndex |= 8;
                break;
        }
        Image img = GetComponent<Image>();
        img.sprite = player.armsSprite[this.spriteIndex];
    }
}
