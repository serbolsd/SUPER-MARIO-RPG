using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedRespawn;
    public bool isRespawn = false;
    public float speed;
    public float y_inicio;
    public float y_final;
    public Sprite[] fuegtitos;
    public float timeTrans;
    public bool finishUpeer = false;
    public bool finishSpin = false;
    public bool finishDown = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > speedRespawn && !isRespawn)
        {
            timeTrans = 0;
            this.GetComponent<AudioSource>().Play();
            isRespawn = true;
        }
        else if (!isRespawn)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        else
            this.GetComponent<SpriteRenderer>().enabled = true;
        Animation();


    }
    void Animation()
    {
        if(!finishUpeer)
        {
            upper();
            return;
        }
        if (!finishSpin)
        {
            spin();
            return;
        }
        if (!finishDown)
        {
            fall();
            return;
        }
        isRespawn = false;
        finishDown = false;
        finishSpin = false;
        finishUpeer = false;
    }
    void upper()
    {
        this.GetComponent<SpriteRenderer>().sprite = fuegtitos[0];
        
        Vector3 fuegitoPos = new Vector3(this.transform.position.x,y_final,0.0f) - new Vector3(this.transform.position.x, y_inicio, 0.0f);
        if (timeTrans > speed)
        {
            timeTrans = speed;
        }
        this.transform.position = new Vector3(this.transform.position.x, y_inicio, 0.0f) + (fuegitoPos * timeTrans) / (speed);
        if (this.transform.position == new Vector3(this.transform.position.x, y_final, 0.0f))
        {
            //Debug.Log("jumpi");
            finishUpeer = true;
            timeTrans = 0;

            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetBool("fall", false);
            this.GetComponent<Animator>().Play("Fuego_Movimiento");
            //this.GetComponent<Animator>();
            return;
        }
    }
    void spin()
    {
        if(timeTrans<1.17)
        {
            
        }
        else
        {
            this.GetComponent<Animator>().SetBool("fall", true);
            this.GetComponent<Animator>().Play("falling");
            finishSpin = true;
            timeTrans = 0;
            return;
        }
    }
    void fall()
    {

        //this.GetComponent<SpriteRenderer>().sprite = fuegtitos[1];

        Vector3 fuegitoPos = new Vector3(this.transform.position.x, y_inicio, 0.0f) - new Vector3(this.transform.position.x, y_final, 0.0f);
        if (timeTrans > speed)
        {
            timeTrans = speed;
        }
        this.transform.position = new Vector3(this.transform.position.x, y_final, 0.0f) + (fuegitoPos * timeTrans) / (speed);
        if (this.transform.position == new Vector3(this.transform.position.x, y_inicio, 0.0f))
        {
            //Debug.Log("jumpi");
            this.GetComponent<Animator>().enabled = false;
            finishDown = true;
            timeTrans = 0;
        }
    }

}
