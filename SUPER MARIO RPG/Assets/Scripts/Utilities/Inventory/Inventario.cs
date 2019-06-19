using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventario : MonoBehaviour
{
    void add(Item _i)
    {
      if(_i == Comparar)
        {
            ItemsEquipables.Add((EquipableItem)_i);
        }
      else if(_i == Comparar1)
        {
            ItemsClaves.Add((KeyItem)_i);
        }
      else if(_i == Comparar2)
        {
            ItemsConsumible.Add((ConsumableItem)_i);
        }
    }
    void remove(int Index, List<Item>ListaDeITems)
    {
        if(ListaDeITems != null)
        {
            ListaDeITems.RemoveAt(Index);
        }
    }

    
    void use(int _index, List<Item> ListaDeITems)
    {
        if(ListaDeITems != null)
        {
            
        }

    }

    /**
     * ************************
     * *
     * *  @TODO:  Comparar0 - 2 so se usan bien aqui, pls fix
     * *
     * ************************
     * */
    EquipableItem Comparar;
    KeyItem Comparar1;
    ConsumableItem Comparar2;

    List<EquipableItem> ItemsEquipables=new List<EquipableItem>();
    List<KeyItem>ItemsClaves = new List<KeyItem>();
    List<ConsumableItem> ItemsConsumible=new List<ConsumableItem>();


}
