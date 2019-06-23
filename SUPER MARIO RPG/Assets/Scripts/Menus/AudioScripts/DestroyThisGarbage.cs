using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThisGarbage : MonoBehaviour
{
    public void Start()
    {

    }
    public void Update()
    {
        GameObject[] VeteAlv = GameObject.FindGameObjectsWithTag("Music");


        if (VeteAlv.Length==0||VeteAlv.Length>1)
        {
            Destroy(this.gameObject);
        }

            
    }
}
