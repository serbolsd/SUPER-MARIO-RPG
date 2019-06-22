using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlebuttons : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {
        menuinfo.enabled = false;
        fondoInfo1.enabled = false;
        fondoInfo2.enabled = false;
        fondoInfo2_1.enabled = false;
        fondoInfo3.enabled = false;
        tookTurn = false;
        //menu = this.GetComponent<SpriteRenderer>();
        //menu.sprite = neutral;
        //TODO: make this load its own sprites on startup
    }

    // Update is called once per frame
    public bool onUpdate()
    {
        if(InputManager.AButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = true;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = false;
            menuinfo.sprite = menusinfos[0];
            menu.sprite = attack;
        }

        else if(InputManager.BButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = true;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = false;
            menuinfo.sprite = menusinfos[0];
            menu.sprite = etc;
        }

        else if(InputManager.XButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = true;
            menuinfo.sprite = menusinfos[2];
            menu.sprite = item;
        }

        else if(InputManager.YButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = true;
            fondoInfo2_1.enabled = true;
            fondoInfo3.enabled = false;
            menuinfo.sprite = menusinfos[1];
            menu.sprite = special;
        }

        if(fondoInfo1.enabled) //A button
        {
            if(InputManager.AButton())
                //TODO: enemy selection arrow
                //TODO: attack enemy
                return true;
        }

        if(fondoInfo2.enabled) //Y button
        {
            if(InputManager.YButton())
                //TODO: enemy selection arrow
                //TODO: attack enemy
                return true;
        }
        return false;
    }

    public Sprite neutral;
    public Sprite attack;
    public Sprite special;
    public Sprite item;
    public Sprite etc;
    public SpriteRenderer menuinfo;
    public Sprite[] menusinfos;
    public SpriteRenderer fondoInfo1;
    public SpriteRenderer fondoInfo2;
    public SpriteRenderer fondoInfo2_1;
    public SpriteRenderer fondoInfo3;
    public SpriteRenderer menu;

    bool tookTurn;
    int nEnemy;
}
