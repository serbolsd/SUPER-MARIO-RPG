using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int c_ItemID;
    public virtual void Use(Item _i){ }

}
