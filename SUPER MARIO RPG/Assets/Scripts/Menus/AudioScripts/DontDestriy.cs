using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestriy : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        GameObject[] Pistas = GameObject.FindGameObjectsWithTag("Music");
        if (Pistas.Length > 1)
        { 
        Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
      
    }
}
