using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FONOD : MonoBehaviour
{
    public SpriteRenderer textureToAnimate;
    //public Vector2 uvOffset;

    float num1 = 0;
    float num2 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        num1 += 0.001f;
        num2 += 0.001f;
        textureToAnimate.material.mainTextureOffset = new Vector2(num1, -num1);
    }
}
