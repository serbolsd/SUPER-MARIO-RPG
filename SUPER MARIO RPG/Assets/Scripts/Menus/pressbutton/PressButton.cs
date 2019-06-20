using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    float timeTrans;
    bool nextScene;
    public DIFUMINADO dif;
    // Start is called before the first frame update
    void Start()
    {
        timeTrans = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeTrans += Time.deltaTime;
        if(InputManager.AButton()||InputManager.StartButton()||InputManager.BackButton())
        {
            dif.changeSecne = true;
            nextScene = true;
           
        }
        if (timeTrans > 19)
        { 
                SceneManager.LoadScene("INICIO");
        }
        if(nextScene)
        {
            dif.obscurecer();
            if ( dif.readyToChange)
            {
                SceneManager.LoadScene("MAINMENU"); //poner escena de inicio
            }
        }
    }
}
