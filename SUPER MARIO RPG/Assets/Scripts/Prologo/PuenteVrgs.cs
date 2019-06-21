using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteVrgs : MonoBehaviour
{
    public float endTime1, endTime2, startTime;
    float timeTrans;
    bool fase1 = false;
    bool fase2 = false;
    public Vector3 initPos;
    Vector3 finalPos1;
    Vector3 finalPos2;
    bool start = false;
    public bool finish;
    // Start is called before the first frame update
    void Start()
    {
        endTime1 = 0.1f;
        endTime2 = 0.2f;
        initPos = this.transform.position;
        finalPos1 = new Vector3(this.transform.position.x,this.transform.position.y-.08f,0.0f);
        finalPos2 = new Vector3(this.transform.position.x, this.transform.position.y - 1f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //fallwood();
    }
    public void fallwood()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans < startTime && !start)
        {
            return;
        }
        else if (!start)
        {
            start = true;
            timeTrans = 0;
        }

        if (!fase1)
        {
            fall1();
            return;
        }
        if (!fase2)
        {
            fall12();
            return;
        }
        finish = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
        return;//algo
    }

    void fall1()
    {
        Vector3 vec = finalPos1 - initPos;
        if(timeTrans> endTime1)
        {
            timeTrans = endTime1;
        }
        this.transform.position = initPos + (vec * timeTrans) / (endTime1 );
        if(this.transform.position== finalPos1)
        {
            timeTrans = 0;
            fase1 = true;
        }

    }
    void fall12()
    {
        Vector3 vec = finalPos2 - finalPos1;
        if (timeTrans > endTime2)
        {
            timeTrans = endTime2;
        }
        this.transform.position = finalPos1 + (vec * timeTrans) / (endTime2);
        if (this.transform.position == finalPos2)
        {
            timeTrans = 0;
            fase2 = true;
        }
    }
}
