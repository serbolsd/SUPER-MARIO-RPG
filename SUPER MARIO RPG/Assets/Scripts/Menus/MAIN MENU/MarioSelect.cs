using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MarioSelect : MonoBehaviour
{
    Vector3[] pos= { new Vector3(-0.484f, 0.796f,0), new Vector3(-0.913f, 0.418f, 0), new Vector3(-0.913f, 0.018f, 0), new Vector3(-0.913f, -0.381f, 0), new Vector3(-0.913f, -0.781f, 0) };
    // Start is called before the first frame update
    int indexPos = 0;
    bool jostick_vertival = false;
    float escale=.2f;
    public GameObject marco;
    public GameObject allMenu;
    public DIFUMINADO dif;
    public Sprite[] marioMenu = new Sprite[2];
    bool finishJump = false;
    float timeTrans=0.0f;
    float timeJump1=.4f;
    bool jump1 = false;
    bool jump2 = false;
    bool arrive = false;
    float timeJump2=.2f;
    float timeArrive=.2f;
    Vector3[] jumpPos = new Vector3[3];
    bool bsaltoinverso = false;
    public int mips ;
    bool cantCharge = false;
    public int maxmip;
    void Start()
    {
        //mips = this.GetComponent<SpriteRenderer>().sprite.texture.mipmapCount;
        jumpPos[0] = new Vector3(-0.482f, -1.271f,0.0f);
        jumpPos[1] = new Vector3(-0.482f, 0.599f, 0.0f);
        jumpPos[2] = new Vector3(-0.482f, 1.056f, 0.0f);
        allMenu.SetActive(false);
        this.transform.position = jumpPos[0];
        this.GetComponent<SpriteRenderer>().sprite = marioMenu[1];
        marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = 1;

    }

    // Update is called once per frame
    void Update()
    {
        marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = maxmip;
        if (cantCharge)
        {
            erroMips();
            return;
        }
        if (bsaltoinverso)
            saltoInverso();
        if (!dif.sceneIsVisible)
            return;
        if (marco.transform.localScale.y < 1)
        {
            escale += 0.03f;
            if (escale > 1)
                escale = 1;
            Vector3 VEC = new Vector3(1.0f, escale, 0.0f);
            marco.transform.localScale = VEC;
            return;
        }
        else
        {
            allMenu.SetActive(true);
        }
        if(!finishJump)
        {
            jump();
        }
        if (jostick_vertival)
        {
            if(!InputManager.jostickMoveVertical()&&!InputManager.DOWNButton()&&!InputManager.UPButton())
            {
                jostick_vertival = false;
            }
            else
            {
                return;        
            }
        }
        if ((Input.GetKeyDown(KeyCode.S )&& indexPos < 4)||(InputManager.jostickMoveVertical() && indexPos < 4) || (InputManager.DOWNButton() && indexPos < 4))
        {
            if (InputManager.Joystick().y <= 0 || InputManager.DOWNButton())
            {
                jostick_vertival = true;
               indexPos++;
               this.transform.position = pos[indexPos];
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                indexPos++;
                this.transform.position = pos[indexPos];
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && indexPos > 0 || (InputManager.jostickMoveVertical() && indexPos > 0 )|| (InputManager.UPButton() && indexPos > 0))
        {
            if (InputManager.Joystick().y >= 0|| InputManager.UPButton())
            {
                jostick_vertival = true;
                indexPos--;
                this.transform.position = pos[indexPos];
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                indexPos--;
                this.transform.position = pos[indexPos];
            }
        }
        if (Input.GetKey(KeyCode.Return)||InputManager.AButton()||InputManager.YButton()|| InputManager.StartButton())
        {
            jostick_vertival = true;
            select();
        }
    }

    void select()
    {
        
        switch (indexPos)
        {
            case 0:
                // Cargar menu de registro de nombre

                this.GetComponent<SpriteRenderer>().sprite = marioMenu[1];
                dif.changeSecne = true;
                bsaltoinverso = true;
               // SceneManager.LoadScene("SETNAMEMENU");
                //SceneManager.LoadScene("SolarFOX");
                break;
            case 1:
                if(loadArchive())
                {
                }
                else
                {
                    cantCharge = true;
                }
                // cargar archivo 1
                break;
            case 2:
                if (loadArchive())
                {
                }
                else
                {
                    cantCharge = true;
                }
                // cargar archivo 2
                break;
            case 3:
                if (loadArchive())
                {
                }
                else
                {
                    cantCharge = true;
                }
                // cargar archivo 3
                break;
            case 4:
                if (loadArchive())
                {
                }
                else
                {
                    cantCharge = true;
                }
                // cargar archivo 4
                break;
        }
    }

    bool loadArchive()
    {
        return false;
    }

    void erroMips()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans < 0.1f)
            marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = 4;
        else if (timeTrans < 0.18f)
            marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = 3;
        else if (timeTrans < 0.24f)
            marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = 2;
        else if (timeTrans < 0.32f)
        {
            marco.GetComponent<SpriteRenderer>().sprite.texture.mipMapBias = 1;
            timeTrans = 0;
            cantCharge = false;
        }

    }
    void jump()
    {
        if(!jump1)
        {
            relicedJump1();
            return;
        }
        if (!jump2)
        {
            relicedJump2();
            return;
        }
        if (!arrive)
        {
            relicedarrive();
            return;
        }
        finishJump = true;
    }
    void relicedJump1()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeJump1)
            timeTrans = timeJump1;
        Vector3 posi = jumpPos[1] - jumpPos[0];
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = jumpPos[0] + ((posi * timeTrans) / timeJump1);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == jumpPos[1])
        {
            timeTrans = 0;
            jump1 = true ;
        }
    }
    void relicedJump2()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeJump2)
            timeTrans = timeJump2;
        Vector3 posi = jumpPos[2] - jumpPos[1];
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = jumpPos[1] + ((posi * timeTrans) / timeJump2);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == jumpPos[2])
        {
            timeTrans = 0;
            jump2 = true;
        }
    }
    void relicedarrive()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeArrive)
            timeTrans = timeArrive;
        Vector3 posi = pos[0]-jumpPos[2];
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = jumpPos[2] + ((posi * timeTrans) / timeArrive);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == pos[0])
        {
            timeTrans = 0;
            arrive = true;
            this.GetComponent<SpriteRenderer>().sprite = marioMenu[0];
        }
    }

    void saltoInverso()
    {
        if(arrive)
        {
            arriveInverso();
            return;
        }
        if(jump2)
        {
            jump2Inverso();
            return;
        }
        if (jump1)
        {
            jump1Inverso();
            return;
        }
        if(!dif.readyToChange)
        {
            dif.obscurecer();
            return;
        }
        SceneManager.LoadScene("SETNAMEMENU");
    }

    void arriveInverso()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeArrive)
            timeTrans = timeArrive;
        Vector3 posi = jumpPos[2]- pos[0];
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = pos[0] + ((posi * timeTrans) / timeArrive);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == jumpPos[2])
        {
            timeTrans = 0;
            arrive = false;
            this.GetComponent<SpriteRenderer>().sprite = marioMenu[1];
        }
    }
    void jump2Inverso()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeJump2)
            timeTrans = timeJump2;
        Vector3 posi = jumpPos[1] - jumpPos[2];
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = jumpPos[2] + ((posi * timeTrans) / timeJump2);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == jumpPos[1])
        {
            timeTrans = 0;
            jump2 = false;
        }
    }
    void jump1Inverso()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeJump1)
            timeTrans = timeJump1;
        Vector3 posi =  jumpPos[0]- jumpPos[1] ;
        //letter[letterIndex].transform.position = originalPos;
        this.transform.position = jumpPos[1] + ((posi * timeTrans) / timeJump1);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (this.transform.position == jumpPos[0])
        {
            timeTrans = 0;
            jump1 = false;
        }
    }
}



