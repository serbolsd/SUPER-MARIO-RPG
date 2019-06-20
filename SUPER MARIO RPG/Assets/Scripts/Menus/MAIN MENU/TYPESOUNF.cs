using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TYPESOUNF : MonoBehaviour
{
    public SpriteRenderer STEREO;
    float posActive;
    float posInActive;
    public SpriteRenderer MONO;
    public Sprite[] spriteStereo;
    public Sprite[] spriteMono;
    bool selectbutton = false;
    // Start is called before the first frame update
    void Start()
    {
        STEREO.sprite = spriteStereo[0];
        MONO.sprite = spriteMono[0];
        posActive = STEREO.transform.position.y;
        posInActive = MONO.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q)||InputManager.LBButton()||(InputManager.BackButton() && !selectbutton))
        {
            selectbutton = true;
            STEREO.sprite = spriteStereo[0];
            STEREO.transform.position = new Vector3(STEREO.transform.position.x,posActive,0);
            MONO.sprite = spriteMono[0];
            MONO.transform.position = new Vector3(MONO.transform.position.x, posInActive, 0);
        }
        else if (Input.GetKey(KeyCode.E)||InputManager.RBButton() || (InputManager.BackButton() && selectbutton))
        {
            selectbutton = false;
            STEREO.sprite = spriteStereo[1];
            STEREO.transform.position = new Vector3(STEREO.transform.position.x, posInActive, 0);
            MONO.sprite = spriteMono[1];
            MONO.transform.position = new Vector3(MONO.transform.position.x, posActive, 0);
        }
    }
}
