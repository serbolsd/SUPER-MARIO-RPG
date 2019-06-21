using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SALTAR : MonoBehaviour
{
    float timeTrans=0;
    bool canSkip = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > 5 && InputManager.anyButton())
        {
            SceneManager.LoadScene("PRESSTART");
        }
        else if(timeTrans>332)
        {
            SceneManager.LoadScene("PRESSTART");

        }

    }
}
