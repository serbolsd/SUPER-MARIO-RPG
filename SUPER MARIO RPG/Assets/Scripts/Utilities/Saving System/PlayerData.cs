using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int level;
    public int hp;
    public int atk;
    public int def;
    public int magAtk;
    public int magDef;
    public float[] position;
    public int[] IDItemsConsumibles;
    public int[] IDItemsClave;
    public int[] IDItemsEquipables;
    public PlayerData(Player Jugador)
    {
        level = Jugador.getLVL();
        hp = Jugador.getHP();
        atk = Jugador.getATK();
        def = Jugador.getDEF();
        magAtk = Jugador.getMagATK();
        magDef = Jugador.getMagDEF();
        position = new float[2];
        position[0] = Jugador.transform.position.x;
        position[0] = Jugador.transform.position.y;
        IDItemsConsumibles = new int[30];
        IDItemsClave = new int[30];
        IDItemsEquipables = new int[30];
    }
}