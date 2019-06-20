using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int level;
    public int health;
    public float[] position;
    public int[] IDItemsConsumibles;
    public int[] IDItemsClave;
    public int[] IDItemsEquipables;
    public PlayerData(Player Jugador)
    {
        level = Jugador.Level_c;
        health = Jugador.Health_c;
        position = new float[2];
        position[0] = Jugador.transform.position.x;
        position[0] = Jugador.transform.position.y;
        IDItemsConsumibles = new int[30];
        IDItemsClave = new int[30];
        IDItemsEquipables = new int[30];
    }
}