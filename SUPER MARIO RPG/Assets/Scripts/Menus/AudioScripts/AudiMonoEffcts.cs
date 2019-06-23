using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiMonoEffcts : MonoBehaviour
{

    public AudioClip MonoEffect;
    public AudioSource Play;
    public TYPESOUNF selec;
    bool get = false;
    void Start()
    {
        Play.clip = MonoEffect;
    }

    // Update is called once per frame
    void Update()
    {

        if(InputManager.RBButton()==true&&! selec.selectbutton)
        {
            Play.Play();
            get = !selec.selectbutton;
        }
        if (InputManager.LBButton() == true && selec.selectbutton)
        {
            Play.Play();
            get = !selec.selectbutton;
        }
    }
}
