using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR : MonoBehaviour
{
    // Start is called before the first frame update
    bool isOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        if(!isOpen)
            this.GetComponent<AudioSource>().Play();
    }
}
