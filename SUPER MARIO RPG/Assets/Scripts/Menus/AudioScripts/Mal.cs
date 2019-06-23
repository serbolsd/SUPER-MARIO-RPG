using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mal : MonoBehaviour
{
    public MarioSelect selection;
    public AudioClip MonoEffect;
    public AudioSource Reproducir;
    public AudioClip[] clips = new AudioClip[2];
   
    void Start()
    {
        Reproducir.clip = MonoEffect;
    }

    // Update is called once per frame
    void Update()
    {


        if(!selection.canPlay)
        {
            return;
        }
        if(selection.indexPos==0)
        {
            Reproducir.clip = clips[0];
        }
        else
            Reproducir.clip = clips[1];
        if (InputManager.AButton()||InputManager.StartButton()||InputManager.YButton())
        {
           Reproducir.Play();
        }
    }
}


