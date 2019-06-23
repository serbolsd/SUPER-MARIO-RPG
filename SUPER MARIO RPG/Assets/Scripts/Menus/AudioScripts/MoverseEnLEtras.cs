using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverseEnLEtras : MonoBehaviour
{
    public MarioSelect selection;
    public AudioClip MonoEffect;
    public AudioSource Reproducir;
    public AudioClip clip;
    void Start()
    {
        Reproducir.clip = MonoEffect;
    }



    // Update is called once per frame
    void Update()
    {


        if (selection.indexPos == 0||selection.indexPos>4)
        {
            return;  
        }
        else
            Reproducir.clip = clip;
        if (InputManager.jostickMoveVertical())
        {
            Reproducir.Play();
        }
    }
}

