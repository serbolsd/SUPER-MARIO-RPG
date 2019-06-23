using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{

    public AudioClip MonoEffect;
    public AudioSource Reproducir;
    float timetrans=0;
    bool play = false;

    void Start()
    {
        Reproducir.clip = MonoEffect;
        //Reproducir.PlayDelayed(10);
    }
    private void Update()
    {
        timetrans += Time.deltaTime;
        if(timetrans>0.50&&!play)
        {
            play = true;
            Reproducir.Play();
        }
    }


}

