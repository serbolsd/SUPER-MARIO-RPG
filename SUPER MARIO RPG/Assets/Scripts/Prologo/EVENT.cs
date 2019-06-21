using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT : MonoBehaviour
{
    public Transform transMario;
    public Transform transCamera;
    public PuenteVrgs[] puenter=new PuenteVrgs[6];
    public BoxCollider2D newWall;
    public bool initEvent = false;
    public bool finishEvent = false;
    float timeTans=0.0f;
    bool downCamera = true;
    Vector3 initPosCamera;
    public Player statemachine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finishEvent)
        {
            statemachine.isCutScene = false;
            return;
        }
        if (transMario.position.x > this.transform.position.x&&!initEvent)
        {
            initPosCamera = transCamera.position;
            statemachine.isCutScene = true;
            initEvent = true;
        }
        if(initEvent)
        {
            if(downCamera&&timeTans>-.05)
            {
                timeTans -= Time.deltaTime;
            }
            else if(timeTans < .05)
                downCamera = false;
            if (!downCamera && timeTans < .05)
            {
                timeTans += Time.deltaTime;
            }
            else if (timeTans > .05)
                downCamera = true; ;


            transCamera.position = new Vector3(transCamera.position.x, initPosCamera.y+(timeTans), transCamera.position.z);
            for (int i = 0; i < puenter.Length; i++)
            {
                puenter[i].fallwood();
            }
            for (int i = 0; i < puenter.Length; i++)
            {
                if (!puenter[i].finish)
                    return;
            }
            statemachine.isCutScene = false;
            finishEvent = true;
            newWall.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        statemachine.isCutScene = true;
        initEvent = true;
    }
}
