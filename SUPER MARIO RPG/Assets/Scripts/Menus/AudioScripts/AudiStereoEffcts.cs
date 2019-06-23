using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiStereoEffcts : MonoBehaviour
{
    public AudioClip MonoEffect;
    public AudioSource Play;
    public TYPESOUNF selec;
    bool get = false;
    // Start is called before the first frame update
    void Start()
    {
        Play.clip = MonoEffect;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.LBButton() == true && selec.selectbutton)
        {
            Play.Play();
            get = !selec.selectbutton;
        }
    }
}
