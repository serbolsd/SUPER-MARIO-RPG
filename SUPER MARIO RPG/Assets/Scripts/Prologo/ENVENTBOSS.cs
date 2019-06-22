using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENVENTBOSS : MonoBehaviour
{
    public Sprite[] mario_sprite;
    public CameraFollow cameraEvent;
    public SpriteRenderer renderMario;
    public SpriteRenderer renderMarioExtra;
    public Transform marioTrans;
    public Player MARIO;
    public Transform transCamera;
    public CANDELABRO[] candeledes;
    public bool initEvent = false;
    public bool finishEvent = false;
    public bool marioFinishSearch = false;
    public bool start = false;
    public bool finishMoveSecene = false;


    public float timeTans = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initEvent)
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
            timeTans = 0;
            start = true;
        }
        if (!start)
        {
            return;
        }
        if (!finishMoveSecene)
        {
            marioSearch();
        }
    }

    void marioSearch()
    {

        if (timeTans<.4)
        {
            Debug.Log("izquierda");
            renderMario.sprite = mario_sprite[0];
            renderMario.flipX=true;
            return;
        }
        if (timeTans < .8)
        {
            Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 1.2)
        {
            Debug.Log("derecha");
            renderMario.sprite = mario_sprite[2];
            return;
        }
        if (timeTans < 1.6)
        {
            Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 2)
        {
            Debug.Log("izquierda");
            renderMario.sprite = mario_sprite[0];
            return;
        }
        if (timeTans < 2.4)
        {
            Debug.Log("centro");
            renderMario.sprite = mario_sprite[1];
            return;
        }
        if (timeTans < 3)
        {
            Debug.Log("vuelta izquierda");
            renderMario.sprite = mario_sprite[3];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 3.4)
        {
            Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 3.8)
        {
            Debug.Log("vuelta derecha");
            renderMario.sprite = mario_sprite[5];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 4.2)
        {
            Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 4.6)
        {
            Debug.Log("vuelta izquierda");
            renderMario.sprite = mario_sprite[3];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 5.2)
        {
            Debug.Log("vuelta centro");
            renderMario.sprite = mario_sprite[4];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 5.8)
        {
            Debug.Log("preocupado izquierda");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 6.2)
        {
            Debug.Log("preocupado derecha");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = true;
            return;
        }
        if (timeTans < 6.8)
        {
            Debug.Log("preocupado izquierda");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 7.4)
        {
            Debug.Log("preocupado derecha");
            renderMario.sprite = mario_sprite[6];
            renderMario.flipX = true;
            return;
        }
        if (timeTans < 8)
        {
            Debug.Log("frente");
            renderMario.sprite = mario_sprite[7];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 8.6)
        {
            Debug.Log("diag");
            renderMario.sprite = mario_sprite[8];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 9.4)
        {
            Debug.Log("diag");
            renderMario.sprite = mario_sprite[9];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 10.4)
        {
            Debug.Log("diag");
            renderMario.sprite = mario_sprite[10];
            renderMario.flipX = false;
            return;
        }
        if (timeTans < 10.8)
        {
            Debug.Log("sorpresa");
            renderMario.flipX = false;
            renderMario.sprite = mario_sprite[11];
            return;
        }
        renderMarioExtra.transform.position = marioTrans.position;
        renderMarioExtra.enabled=true;
        renderMario.enabled = false;
        marioFinishSearch = true;
    }
    void moveScene()
    {

    }
}
