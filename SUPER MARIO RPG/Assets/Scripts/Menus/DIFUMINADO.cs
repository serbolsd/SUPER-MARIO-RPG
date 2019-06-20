using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIFUMINADO : MonoBehaviour
{
    public SpriteRenderer BLACK;
    Color colore;
    public bool readyToChange = false;
    public bool changeSecne = false;
    public bool sceneIsVisible = false;
    //bool scenaVisible;
    // Start is called before the first frame update
    void Start()
    {
        colore.a = 1.0f;
        colore.r = 0.0f;
        colore.g = 0.0f;
        colore.b = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeSecne)
            return;
        //Color color;
        if(BLACK.color.a > 0)
        {
            colore.a -= 0.006f;
            BLACK.color = colore;
        }
        else
        {
            sceneIsVisible = true;
        }
        if(BLACK.color.a < 0.8f)
        {
            sceneIsVisible = true;
        }

    }
    public void obscurecer()
    {
        if(BLACK.color.a < 1)
        {
            colore.a += 0.006f;
            BLACK.color = colore;
        }
        else
        {
            readyToChange = true;
        }
    }
}
