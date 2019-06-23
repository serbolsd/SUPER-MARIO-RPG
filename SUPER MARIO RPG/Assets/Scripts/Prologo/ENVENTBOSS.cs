using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENVENTBOSS : MonoBehaviour
{
    public Sprite[] mario_sprite;
    public Sprite[] mario_sprite2;
    public CameraFollow cameraEvent;
    public SpriteRenderer renderMario;
    public SpriteRenderer renderMarioExtra;
    public Transform marioTrans;
    public Player MARIO;
    public cStats statesMario;
    public Transform transCamera;
    public CANDELABRO[] candeledes;
    public bool initEvent = false;
    public bool finishEvent = false;
    public bool marioFinishSearch = false;
    public bool start = false;
    public bool finishMoveSecene = false;
    public bool finishMoveSecene2 = false;
    public bool finishMarioScene = false;
    public bool part1 = false;
    int numPutasos = 0;

    Vector3[] finalPosCandelabro = new Vector3[5] { new Vector3(0f, 2.705776f, 0f), new Vector3(0f, 4.455539f, 0f), new Vector3(0f, 4.264415f, 0f), new Vector3(0f, 4.074349f, 0f), new Vector3(0f, 5.834f, 0f) };
    Vector3 finalPosCamara=new Vector3(0.0f,2.81f,0.0f);
    Vector3 originalCameraPos;
    Vector3[] originalPosCandelabro=new Vector3[5];

    Vector3 marioJumpPos1 = new Vector3 (0.0f, 2.07f,0.0f);
    Vector3 OriginalMarioPos;
    bool finishjump1 = false;
    bool finishjump2 = false;
    bool finishjump2_1 = false;
    bool up = false;
    int numSaltos = 0;
    Vector3 marioOrigenJump2 = new Vector3(4.55f, 2.49f,0.0f);
    Vector3[] marioJumpPos2 = new Vector3[2] { new Vector3(3.5f, 4.77f, 0.0f), new Vector3(2.75f, 3.77f, 0.0f)};
    Vector3[] finalPosCandelabro2 = new Vector3[5] { new Vector3(0f, 3.390237f, 0f), new Vector3(0f, 5.09f, 0f), new Vector3(0f, 5.57f, 0f), new Vector3(0f, 4.66f, 0f), new Vector3(0f, 6.37f, 0f) };
    Vector3 finalcameraPos2 = new Vector3(0.0f, 4.38f, -10.0f);

    public float timeTans = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (initEvent)
        {
            runEvent();
        }
        else
        {
            return;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MARIO.isCutScene = true;
        MARIO.JumpEnd();
        for (int i = 0; i < candeledes.Length; i++)
        {
            candeledes[i].isCutScene = true;
        }
        cameraEvent.isCutScene = true;
        initEvent = true;
    }

    void runEvent()
    {
        timeTans += Time.deltaTime;
        if(timeTans>0.5f&&!start)
        {
            for (int i = 0; i < candeledes.Length; i++)
            {
                candeledes[i].GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            timeTans = 0;
            start = true;
        }
        if (!start)
        {
            return;
        }
        //marioFinishSearch
        if (!marioFinishSearch)
        {
            marioSearch();
            return;
        }
        if (!finishMoveSecene)
        {
            moveScene();
            return;
        }
        if (!finishjump1)
        {
           
            jump1();
            return;
        }
        if (!finishMoveSecene2)
        {
            moveScene2();
            return;
        }
        if (!finishjump2)
        {
            jump2();
            return;
        }
        if(!finishMarioScene)
        {
            marioScene();
            return;
        }
    }
    void marioSearch()
    {

        if (timeTans<.4)
        {
            //Debug.Log("izquierda");
            renderMario.sprite = mario_sprite[0];
            renderMario.flipX=true;
            return;
        }
        if (timeTans < .8)
        {
            //Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 1.2)
        {
            //Debug.Log("derecha");
            renderMario.sprite = mario_sprite[2];
            return;
        }
        if (timeTans < 1.6)
        {
            //Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 2)
        {
            //Debug.Log("izquierda");
            renderMario.sprite = mario_sprite[0];
            return;
        }
        if (timeTans < 2.4)
        {
            //Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 3)
        {
            //Debug.Log("vuelta izquierda");
            renderMario.sprite = mario_sprite[3];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 3.4)
        {
            //Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 3.8)
        {
            //Debug.Log("vuelta derecha");
            renderMario.sprite = mario_sprite[5];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 4.2)
        {
            //Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 4.6)
        {
            //Debug.Log("vuelta izquierda");
            renderMario.sprite = mario_sprite[3];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 5.2)
        {
            //Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 5.8)
        {
            //Debug.Log("preocupado izquierda");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 6.2)
        {
            //Debug.Log("preocupado derecha");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = true;
            return;
        }
        if (timeTans < 6.8)
        {
            //Debug.Log("preocupado izquierda");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 7.4)
        {
            //Debug.Log("preocupado derecha");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = true;
            return;
        }
        if (timeTans < 8)
        {
            //Debug.Log("frente");
            renderMario.sprite = mario_sprite[7];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 8.6)
        {
            //Debug.Log("diag");
            renderMario.sprite = mario_sprite[8];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 9.4)
        {
            //Debug.Log("diag");
            renderMario.sprite = mario_sprite[9];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 10.4)
        {
            //Debug.Log("diag");
            renderMario.sprite = mario_sprite[10];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 10.8)
        {
            //Debug.Log("sorpresa");
            renderMario.flipX = false;
            renderMario.sprite = mario_sprite[11];
            return;
        }
        renderMarioExtra.transform.position = marioTrans.position;
        renderMarioExtra.enabled=true;
        renderMario.enabled = false;
        marioFinishSearch = true;
        originalCameraPos = transCamera.position;
        for (int i = 0; i < candeledes.Length; i++)
        {
            originalPosCandelabro[i] = candeledes[i].transform.position;
            //Debug.Log(originalPosCandelabro[i]);
        }
        OriginalMarioPos = renderMarioExtra.transform.position;
        //Debug.Log("finish search");
        //Debug.Log(timeTans);
        timeTans = 0;
    }
    void moveScene()
    {
        //Debug.Log("move secene");
        Vector3 cameraPos = new Vector3(originalCameraPos.x, finalPosCamara.y, -10.0f) - originalCameraPos;
        //Vector3 vec = finalPos1 - initPos;

        if (timeTans > 1)
        {
            timeTans = 1;
        }
        transCamera.position = originalCameraPos + (cameraPos * timeTans) / (1);
        for (int i = 0; i < candeledes.Length; i++)
        {
            Vector3 canPos = new Vector3(originalPosCandelabro[i].x, finalPosCandelabro[i].y, 0.0f) - originalPosCandelabro[i];
            candeledes[i].transform.position= originalPosCandelabro[i]+ (canPos * timeTans) / (1);
        }

        if (transCamera.position == new Vector3(originalCameraPos.x, finalPosCamara.y, -10.0f))
        {
            Debug.Log("finish movescene");
            Debug.Log("init jumps");
            timeTans = 0;
            finishMoveSecene = true;
        }
    }
    void jump1()
    {
        renderMarioExtra.sprite = mario_sprite[12];
        float endTime = 0.5f;
        if (!up)
        {
            Vector3 marioPos = new Vector3(OriginalMarioPos.x, marioJumpPos1.y, 0.0f) - OriginalMarioPos;
            if (timeTans > endTime)
            {
                timeTans = endTime;
            }
            renderMarioExtra.transform.position = OriginalMarioPos + (marioPos * timeTans) / (endTime);
            if (renderMarioExtra.transform.position == new Vector3(OriginalMarioPos.x, marioJumpPos1.y, 0.0f))
            {
                //Debug.Log("jumpi");
                timeTans = 0;
                up = true;
            }
        }
        else
        {

            Vector3 marioPos = OriginalMarioPos- new Vector3(OriginalMarioPos.x, marioJumpPos1.y, 0.0f) ;
            if (timeTans > endTime)
            {
                timeTans = endTime;
            }
            renderMarioExtra.transform.position = new Vector3(OriginalMarioPos.x, marioJumpPos1.y, 0.0f) + (marioPos * timeTans) / (endTime);
            if (renderMarioExtra.transform.position == OriginalMarioPos)
            {
                numSaltos++;
                timeTans = 0;
                up = false;
            }
        }

        if (numSaltos > 2)
        {
            finishjump1 = true;
            originalCameraPos = transCamera.transform.position;
            for (int i = 0; i < candeledes.Length; i++)
            {
                originalPosCandelabro[i] = candeledes[i].transform.position;
            }
        }

    }
    void moveScene2()
    {
        //Debug.Log("move secene");
        Vector3 cameraPos = new Vector3(originalCameraPos.x, finalcameraPos2.y, -10.0f) - originalCameraPos;
        //Vector3 vec = finalPos1 - initPos;
        float endtime = 1.0f;
        if (timeTans > endtime)
        {
            timeTans = endtime;
        }
        transCamera.position = originalCameraPos + (cameraPos * timeTans) / (endtime);
        for (int i = 0; i < candeledes.Length; i++)
        {
            Vector3 canPos = new Vector3(originalPosCandelabro[i].x, finalPosCandelabro2[i].y, 0.0f) - originalPosCandelabro[i];
            candeledes[i].transform.position = originalPosCandelabro[i] + (canPos * timeTans) / (endtime);
        }

        if (transCamera.position == new Vector3(originalCameraPos.x, finalcameraPos2.y, -10.0f))
        {
            Debug.Log("finish movescene2");
            //Debug.Log("init jumps");
            timeTans = 0;
            finishMoveSecene2 = true;
        }
    }
    void jump2()
    {
        renderMarioExtra.sprite = mario_sprite[13];
        if (!finishjump2_1)
        {
            float endTime = 1.0f;
            Vector3 marioPos = marioJumpPos2[0] - marioOrigenJump2;
            if (timeTans > endTime)
            {
                timeTans = endTime;
            }
            renderMarioExtra.transform.position = marioOrigenJump2 + (marioPos * timeTans) / (endTime);
            if (renderMarioExtra.transform.position == marioJumpPos2[0])
            {
                //Debug.Log("jumpi");
                finishjump2_1 = true;
                timeTans = 0;
            }

        }
        else
        {
            float endTime = 1.0f;
            Vector3 marioPos = marioJumpPos2[1] - marioJumpPos2[0];
            if (timeTans > endTime)
            {
                timeTans = endTime;
            }
            renderMarioExtra.transform.position = marioJumpPos2[0] + (marioPos * timeTans) / (endTime);
            if (renderMarioExtra.transform.position == marioJumpPos2[1])
            {
                //Debug.Log("jumpi");
                finishjump2 = true;
                timeTans = 0;
            }
        }
    }
    void marioScene()
    {
        if (!part1)
        {
            if (timeTans < .4)
            {
                //Debug.Log("izquierda");
                renderMarioExtra.sprite = mario_sprite2[12];
                renderMarioExtra.flipX = true;
                return;
            }
            if (timeTans < .8)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[13];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 1.2)
            {
                //Debug.Log("izquierda");
                renderMarioExtra.sprite = mario_sprite2[0];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 1.8)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[1];
                return;
            }
            if (timeTans < 2.2)
            {
                //Debug.Log("derecha");
                renderMarioExtra.sprite = mario_sprite2[2];
                renderMarioExtra.flipX = true;
                return;
            }
            if (timeTans < 2.25)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[3];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 2.3)
            {
                //Debug.Log("izquierda");
                renderMarioExtra.sprite = mario_sprite2[4];
                return;
            }
            if (timeTans < 2.35)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[5];
                return;
            }
            if (timeTans < 2.4)
            {
                //Debug.Log("vuelta izquierda");
                renderMarioExtra.sprite = mario_sprite2[6];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 2.45)
            {
                //Debug.Log("vuelta centro");
                renderMarioExtra.sprite = mario_sprite2[7];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 2.5)
            {
                //Debug.Log("vuelta derecha");
                renderMarioExtra.sprite = mario_sprite2[8];
                renderMarioExtra.flipX = false;
                return;
            }
            part1 = true;
            timeTans = 0;
        }
        else
        {
            if (timeTans < .1)
            {
                //Debug.Log("vuelta centro");
                renderMarioExtra.sprite = mario_sprite2[9];
                renderMarioExtra.flipX = false;
                return;
            }
            if (timeTans < 0.15)
            {
                //Debug.Log("vuelta izquierda");
                renderMarioExtra.sprite = mario_sprite2[10];
                renderMario.flipX = false;
                return;
            }
            if (timeTans < .20)
            {
                //Debug.Log("vuelta centro");
                renderMarioExtra.sprite = mario_sprite2[11];
                renderMario.flipX = false;
                return;
            }
            if (timeTans < .25)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[3];
                return;
            }
            if (timeTans < .30)
            {
                //Debug.Log("izquierda");
                renderMarioExtra.sprite = mario_sprite2[4];
                return;
            }
            if (timeTans < .35)
            {
                //Debug.Log("centro");
                renderMarioExtra.sprite = mario_sprite2[5];
                return;
            }
            if (timeTans < .40)
            {
                //Debug.Log("vuelta izquierda");
                renderMarioExtra.sprite = mario_sprite2[6];
                renderMario.flipX = false;
                return;
            }
            if (timeTans < .45)
            {
                //Debug.Log("vuelta centro");
                renderMarioExtra.sprite = mario_sprite2[7];
                renderMario.flipX = false;
                return;
            }
            if (timeTans < .5)
            {
                //Debug.Log("vuelta derecha");
                renderMarioExtra.sprite = mario_sprite2[8];
                renderMario.flipX = false;
                return;
            }
            timeTans = 0;
            numPutasos++;
            if (numPutasos < 2)
            {
                numPutasos++;
            }
            else
            {
                finishMarioScene = true;
            }
        }
        
        
        //renderMarioExtra.transform.position = marioTrans.position;
        //renderMarioExtra.enabled = true;
        //renderMario.enabled = false;
        //marioFinishSearch = true;
        //originalCameraPos = transCamera.position;
        //for (int i = 0; i < candeledes.Length; i++)
        //{
        //    originalPosCandelabro[i] = candeledes[i].transform.position;
        //    //Debug.Log(originalPosCandelabro[i]);
        //}
        //OriginalMarioPos = renderMarioExtra.transform.position;
        //Debug.Log("finish search");
        //Debug.Log(timeTans);
        timeTans = 0;
    }
}
