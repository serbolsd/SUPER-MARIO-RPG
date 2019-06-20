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
    public SpriteRenderer menu;

    void Start()
    {
        //menu = this.GetComponent<SpriteRenderer>();
        //menu.sprite = neutral;
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.BButton())
        {
            menu.sprite = attack;
        }
        if (InputManager.AButton())
        {
            menu.sprite = etc;
        }
        if (InputManager.YButton())
        {
            menu.sprite = item;
        }
        if(InputManager.XButton())
        {
            menu.sprite = special;
        }
    }
}
