using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battlebuttons : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite neutral;
    public Sprite attack;
    public Sprite special;
    public Sprite item;
    public Sprite etc;
    public SpriteRenderer menuinfo;
    public Sprite [] menusinfos;
    public SpriteRenderer fondoInfo1;
    public SpriteRenderer fondoInfo2;
    public SpriteRenderer fondoInfo2_1;
    public SpriteRenderer fondoInfo3;
    public SpriteRenderer menu;

    void Start()
    {
        menuinfo.enabled = false;
        fondoInfo1.enabled = false;
        fondoInfo2.enabled = false;
        fondoInfo2_1.enabled = false;
        fondoInfo3.enabled = false;
        //menu = this.GetComponent<SpriteRenderer>();
        //menu.sprite = neutral;
    }

    // Update is called once per frame
    void Update()
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
        if (InputManager.BButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = true;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = false;
            menuinfo.sprite = menusinfos[0];
            menu.sprite = etc;
        }
        if (InputManager.XButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = false;
            fondoInfo2_1.enabled = false;
            fondoInfo3.enabled = true;
            menuinfo.sprite = menusinfos[2];
            menu.sprite = item;
        }
        if(InputManager.YButton())
        {
            menuinfo.enabled = true;
            fondoInfo1.enabled = false;
            fondoInfo2.enabled = true;
            fondoInfo2_1.enabled = true;
            fondoInfo3.enabled = false;
            menuinfo.sprite = menusinfos[1];
            menu.sprite = special;
        }
    }
}
