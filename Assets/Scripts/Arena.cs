using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe responsável por gerenciar uma arena do tabuleiro
/// </summary>
public class Arena : MonoBehaviour {

    public enum DIRECTION { vertical, horizontal, diagonalP, diagonalS };

    /// <summary>
    /// Número da arena
    /// </summary>
    public int arenaNumber;

    /// <summary>
    /// Coluna da arena no tabuleiro
    /// </summary>
    public int col;

    /// <summary>
    /// Linha da coluna no tabuleiro
    /// </summary>
    public int row;

    private ArenaField[] fields;

    // Use this for initialization
    void Start () {
        this.fields = this.GetComponentsInChildren<ArenaField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Verifica se a arena pode ser usada pelo jogador
    /// </summary>
    /// <returns>true caso possua casas</returns>
    public bool HasFreeField()
    {
        bool hasFreeFields = false;

        foreach(ArenaField field in fields)
        {
            hasFreeFields = field.arms == 0;
            if (hasFreeFields)
            {
                break;
            }
        }

        return hasFreeFields;
    }

    /// <summary>
    /// Verifica se a arena está selecionada no tabuleiro
    /// </summary>
    /// <returns>true se estiver selecionada</returns>
    public bool isSelected()
    {
        return GetComponentInParent<Board>().selectedArena == arenaNumber;
    }

    /// <summary>
    /// Pinta uma linha da arena
    /// </summary
    /// <param name="row">Número da linha</param>
    /// <param name="col">Número da coluna</param>
    /// <param name="dir">Direção da linha</param>
    public void PaintLine(int row, int col, DIRECTION dir)
    {
        Player player = GameManager.instance.GetPlayer();
        
        int n = GameEngine.NUM_ROW_COL - 1;
        foreach (ArenaField field in fields)
        {
            if (dir.Equals(DIRECTION.horizontal) && field.row == row)
            {
                field.PaintMe(player, dir);
                FindObjectOfType<AudioManager>().Play("menubselect");
            }
            else if (dir.Equals(DIRECTION.vertical) && field.column == col)
            {
                field.PaintMe(player, dir);
            }
            else if (dir.Equals(DIRECTION.diagonalP) && field.row == field.column)
            {
                field.PaintMe(player, dir);
            }
            else if (dir.Equals(DIRECTION.diagonalS) && (field.row + field.column == n) )
            {
                field.PaintMe(player, dir);
            }
        }
    }
}
