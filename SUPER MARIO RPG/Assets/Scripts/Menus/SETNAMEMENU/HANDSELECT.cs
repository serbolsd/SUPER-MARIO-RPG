using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HANDSELECT : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2[][] pos;
    public NAME selection;
    int fila=0;
    int max_fila=6;
    int columna=0;
    int max_columna=10;
    bool jostick_vertival = false;
    bool jostick_horizontal = false;
    public DIFUMINADO dif;
    void Start()
    {
        initPos();
        this.transform.position =new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(!dif.sceneIsVisible)
        {
            return;
        }
        if(selection.isDone)
        {
            dif.changeSecne = true;
            dif.obscurecer();
            if (!dif.readyToChange)
                return;
            SceneManager.LoadScene("PROLOGO");
        }
        if(selection.bLetterMove)
        {
            selection.moveLetter();
            return;
        }
        if(selection.ismoveHand)
        {
            fila = max_fila;
            columna = max_columna;
            this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            selection.ismoveHand = false;
        }
        if (jostick_vertival)
        {
            if (!InputManager.jostickMoveVertical() && !InputManager.DOWNButton() && !InputManager.UPButton())
            {
                jostick_vertival = false;
            }
            else
            {
                return;
            }
        }
        if (jostick_horizontal)
        {
            if (!InputManager.jostickMoveHorizontal() && !InputManager.RightButton() && !InputManager.LefhtButton())
            {
                jostick_horizontal = false;
            }
            else
            {
                return;
            }
        }
        if ((InputManager.jostickMoveVertical() || InputManager.DOWNButton()))
        {
            if (InputManager.Joystick().y < 0 || InputManager.DOWNButton())
            {
                jostick_vertival = true;
                fila++;
                if (fila > max_fila)
                    fila = 0;
                this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            }
            //else if (Input.GetKeyDown(KeyCode.S))
            //{
            //    fila++;
            //    if (fila > max_fila)
            //        fila = 0;
            //    this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            //}
        }
        if ((InputManager.jostickMoveVertical() || InputManager.UPButton()))
        {
            if (InputManager.Joystick().y > 0 || InputManager.UPButton())
            {
                jostick_vertival = true;
                fila--;
                if (fila < 0)
                    fila = max_fila;
                this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            }
            //else if (Input.GetKeyDown(KeyCode.W))
            //{
            //    fila--;
            //    if (fila < 0)
            //        fila = max_fila;
            //    this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            //}
        }
        if (InputManager.jostickMoveHorizontal() || InputManager.RightButton()  )
        {
            if (InputManager.Joystick().x >= 0 || InputManager.RightButton())
            {
                jostick_horizontal = true;
                columna++;
                if (columna > max_columna)
                    columna = 0;
                this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            }
            //else if (Input.GetKeyDown(KeyCode.D))
            //{
            //    columna++;
            //    if (columna > max_columna)
            //        columna = 0;
            //    this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            //}
        }
        if (InputManager.jostickMoveHorizontal() || InputManager.LefhtButton()  )
        {
            if (InputManager.Joystick().x <= 0 || InputManager.LefhtButton())
            {
                jostick_horizontal = true;
                columna--;
                if (columna <0)
                    columna = max_columna;
                this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            }
            //else if (Input.GetKeyDown(KeyCode.A))
            //{
            //    columna--;
            //    if (columna < 0)
            //        columna = max_columna;
            //    this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            //}
        }

        if(InputManager.AButton()||InputManager.YButton())
        {
            selection.addLetter(fila,columna);
        }
        if (InputManager.BButton())
        {
            selection.backspace();
        }
        if(InputManager.StartButton())
        {
            fila = max_fila;
            columna = max_columna;
            this.transform.position = new Vector3(pos[fila][columna].x, pos[fila][columna].y, 0);
            selection.ismoveHand = false;
        }
    }

    void initPos()
    {
        pos = new Vector2[7][];
        pos[0] = new Vector2[11] {
            new Vector2(-1.077f, 0.183f) ,
            new Vector2(-0.928f, 0.183f) ,
            new Vector2(-0.762f, 0.183f) ,
            new Vector2(-0.598f, 0.183f) ,
            new Vector2(-0.44f,   0.183f) ,
            new Vector2(-0.288f, 0.183f) ,
            new Vector2(-0.126f,  0.183f) ,
            new Vector2(0.034f,  0.183f) ,
            new Vector2(0.19f,  0.183f) ,
            new Vector2(0.364f,  0.183f) ,
            new Vector2(0.52f,  0.183f) };
        pos[1] = new Vector2[11] {
            new Vector2(-1.077f, 0.018f) ,
            new Vector2(-0.928f, 0.018f) ,
            new Vector2(-0.762f, 0.018f) ,
            new Vector2(-0.598f, 0.018f) ,
            new Vector2(-0.44f,  0.018f) ,
            new Vector2(-0.288f, 0.018f) ,
            new Vector2(-0.126f, 0.018f) ,
            new Vector2(0.034f,  0.018f) ,
            new Vector2(0.19f,   0.018f) ,
            new Vector2(0.364f,  0.018f) ,
            new Vector2(0.52f,   0.018f) };
        pos[2] = new Vector2[11] {
            new Vector2(-1.077f, -0.136f) ,
            new Vector2(-0.928f, -0.136f) ,
            new Vector2(-0.762f, -0.136f) ,
            new Vector2(-0.598f, -0.136f) ,
            new Vector2(-0.44f,  -0.136f) ,
            new Vector2(-0.288f, -0.136f) ,
            new Vector2(-0.126f, -0.136f) ,
            new Vector2(0.034f,  -0.136f) ,
            new Vector2(0.19f,   -0.136f) ,
            new Vector2(0.364f,  -0.136f) ,
            new Vector2(0.52f,   -0.136f) };
        pos[3] = new Vector2[11] {
            new Vector2(-1.077f, -0.298f) ,
            new Vector2(-0.928f, -0.298f) ,
            new Vector2(-0.762f, -0.298f) ,
            new Vector2(-0.598f, -0.298f) ,
            new Vector2(-0.44f,  -0.298f) ,
            new Vector2(-0.288f, -0.298f) ,
            new Vector2(-0.126f, -0.298f) ,
            new Vector2(0.034f,  -0.298f) ,
            new Vector2(0.19f,   -0.298f) ,
            new Vector2(0.364f,  -0.298f) ,
            new Vector2(0.52f,   -0.298f) };
        pos[4] = new Vector2[11] {
            new Vector2(-1.077f, -0.471f) ,
            new Vector2(-0.928f, -0.471f) ,
            new Vector2(-0.762f, -0.471f) ,
            new Vector2(-0.598f, -0.471f) ,
            new Vector2(-0.44f,  -0.471f) ,
            new Vector2(-0.288f, -0.471f) ,
            new Vector2(-0.126f, -0.471f) ,
            new Vector2(0.034f,  -0.471f) ,
            new Vector2(0.19f,   -0.471f) ,
            new Vector2(0.364f,  -0.471f) ,
            new Vector2(0.52f,   -0.471f) };
        pos[5] = new Vector2[11] {
            new Vector2(-1.077f, -0.617f) ,
            new Vector2(-0.928f, -0.617f) ,
            new Vector2(-0.762f, -0.617f) ,
            new Vector2(-0.598f, -0.617f) ,
            new Vector2(-0.44f,  -0.617f) ,
            new Vector2(-0.288f, -0.617f) ,
            new Vector2(-0.126f, -0.617f) ,
            new Vector2(0.034f,  -0.617f) ,
            new Vector2(0.19f,   -0.617f) ,
            new Vector2(0.364f,  -0.617f) ,
            new Vector2(0.52f,   -0.617f) };
        pos[6] = new Vector2[11] {
            new Vector2(-1.077f, -0.776f) ,
            new Vector2(-0.928f, -0.776f) ,
            new Vector2(-0.762f, -0.776f) ,
            new Vector2(-0.598f, -0.776f) ,
            new Vector2(-0.44f,  -0.776f) ,
            new Vector2(-0.288f, -0.776f) ,
            new Vector2(-0.126f, -0.776f) ,
            new Vector2(0.034f,  -0.776f) ,
            new Vector2(0.19f,   -0.776f) ,
            new Vector2(0.364f,  -0.776f) ,
            new Vector2(0.52f,   -0.776f) };
    }
}
