using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologo : MonoBehaviour
{
    float timeTrans = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTrans += Time.deltaTime;
        if(timeTrans>53)
        {
            SceneManager.LoadScene("FisrtRoom(Empty)");
        }
    }
}
