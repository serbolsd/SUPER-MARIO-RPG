﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class NAME : MonoBehaviour
{
    // Start is called before the first frame update
    public string m_name;
    //int fila=0;
    //int columna=0;
    char[][] letters;
    Vector3[][] posLettlers;
    Vector3[] objetivePos;
    Vector3 originalPos;
    public SpriteRenderer[] letter=new SpriteRenderer[8];
    public SpriteRenderer letterextra;
    public Sprite[][] sprites = new Sprite[7][];
    public Sprite[] sprite1 = new Sprite[11];
    public Sprite[] sprite2 = new Sprite[11];
    public Sprite[] sprite3 = new Sprite[11];
    public Sprite[] sprite4 = new Sprite[11];
    public Sprite[] sprite5 = new Sprite[11];
    public Sprite[] sprite6 = new Sprite[11];
    public Sprite[] sprite7 = new Sprite[11];

    public SpriteRenderer flecha;

    int maxletter = 8;
    public int letterIndex=0;
    int maxIndex=0;
    bool fullLetters = false;
    public bool ismoveHand = false;
    float timeToPositione=0.4f;
    float timeTrans;
    int objetiveIndex;
    public bool bLetterMove=false;

    public bool isDone = false;
    void Start()
    {
        initletters();
        initPosLetters();
        initObjetivepos();
        initsprites();
        flecha.transform.position = new Vector3 (objetivePos[letterIndex].x, flecha.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void initletters()
    {
        letters = new char[7][];
        letters[0]= new char[11] {'A','B','C','D','E','F','G','H','I','J','·'};
        letters[1]= new char[11] {'K','L','M','N','O','P','Q','R','S','T',':'};
        letters[2]= new char[11] {'U','V','W','X','Y','Z',' ',' ',' ',' ','/'};
        letters[3]= new char[11] {'a','b','c','d','r','f','g','h','i','j',' '};
        letters[4]= new char[11] {'k','l','m','n','o','p','q','r','s','t','>'};
        letters[5]= new char[11] {'u','v','w','x','y','z',' ',' ',' ',' ','<'};
        letters[6]= new char[11] {'0','1','2','3','4','5','6','7','8','9','+'};
    }
    void initPosLetters()
    {
        posLettlers = new Vector3[7][];
        posLettlers[0] = new Vector3[11]{
            new Vector3(-0.9255f,0.235f,0),
            new Vector3(-0.7647f,0.235f,0),
            new Vector3(-0.605f,0.235f,0),
            new Vector3(-0.451f,0.235f,0),
            new Vector3(-0.287f,0.235f,0),
            new Vector3(-0.132f,0.235f,0),
            new Vector3(0.032f,0.235f,0),
            new Vector3(0.193f,0.235f,0),
            new Vector3(0.347f,0.235f,0),
            new Vector3(0.511f,0.235f,0),
            new Vector3(0.675f,0.235f,0)
        };
        posLettlers[1] = new Vector3[11]{
            new Vector3(-0.9255f, 0.0745f,0),
            new Vector3(-0.7647f, 0.0745f,0),
            new Vector3(-0.605f,  0.0745f,0),
            new Vector3(-0.451f,  0.0745f,0),
            new Vector3(-0.287f,  0.0745f,0),
            new Vector3(-0.132f,  0.0745f,0),
            new Vector3(0.032f,   0.0745f,0),
            new Vector3(0.193f,   0.0745f,0),
            new Vector3(0.347f,   0.0745f,0),
            new Vector3(0.511f,   0.0745f,0),
            new Vector3(0.675f,   0.0745f,0)
        };
        posLettlers[2] = new Vector3[11]{
            new Vector3(-0.9255f, -0.086f,0),
            new Vector3(-0.7647f, -0.086f,0),
            new Vector3(-0.605f,  -0.086f,0),
            new Vector3(-0.451f,  -0.086f,0),
            new Vector3(-0.287f,  -0.086f,0),
            new Vector3(-0.132f,  -0.086f,0),
            new Vector3(0.032f,   -0.086f,0),
            new Vector3(0.193f,   -0.086f,0),
            new Vector3(0.347f,   -0.086f,0),
            new Vector3(0.511f,   -0.086f,0),
            new Vector3(0.675f,   -0.086f,0)
        };
        posLettlers[3] = new Vector3[11]{
            new Vector3(-0.9255f, -0.255f,0),
            new Vector3(-0.7647f, -0.255f,0),
            new Vector3(-0.605f,  -0.255f,0),
            new Vector3(-0.451f,  -0.255f,0),
            new Vector3(-0.287f,  -0.255f,0),
            new Vector3(-0.132f,  -0.255f,0),
            new Vector3(0.032f,   -0.255f,0),
            new Vector3(0.193f,   -0.255f,0),
            new Vector3(0.347f,   -0.255f,0),
            new Vector3(0.511f,   -0.255f,0),
            new Vector3(0.675f,   -0.255f,0)
        };
        posLettlers[4] = new Vector3[11]{
            new Vector3(-0.9255f, -0.405f,0),
            new Vector3(-0.7647f, -0.405f,0),
            new Vector3(-0.605f,  -0.405f,0),
            new Vector3(-0.451f,  -0.405f,0),
            new Vector3(-0.287f,  -0.405f,0),
            new Vector3(-0.132f,  -0.405f,0),
            new Vector3(0.032f,   -0.405f,0),
            new Vector3(0.193f,   -0.405f,0),
            new Vector3(0.347f,   -0.405f,0),
            new Vector3(0.511f,   -0.405f,0),
            new Vector3(0.675f,   -0.405f,0)
        };
        posLettlers[5] = new Vector3[11]{
            new Vector3(-0.9255f, -0.575f,0),
            new Vector3(-0.7647f, -0.575f,0),
            new Vector3(-0.605f,  -0.575f,0),
            new Vector3(-0.451f,  -0.575f,0),
            new Vector3(-0.287f,  -0.575f,0),
            new Vector3(-0.132f,  -0.575f,0),
            new Vector3(0.032f,   -0.575f,0),
            new Vector3(0.193f,   -0.575f,0),
            new Vector3(0.347f,   -0.575f,0),
            new Vector3(0.511f,   -0.575f,0),
            new Vector3(0.675f,   -0.575f,0)
        };
        posLettlers[6] = new Vector3[11]{
            new Vector3(-0.9255f, -0.7297f,0),
            new Vector3(-0.7647f, -0.7297f,0),
            new Vector3(-0.605f,  -0.7297f,0),
            new Vector3(-0.451f,  -0.7297f,0),
            new Vector3(-0.287f,  -0.7297f,0),
            new Vector3(-0.132f,  -0.7297f,0),
            new Vector3(0.032f,   -0.7297f,0),
            new Vector3(0.193f,   -0.7297f,0),
            new Vector3(0.347f,   -0.7297f,0),
            new Vector3(0.511f,   -0.7297f,0),
            new Vector3(0.675f,   -0.7297f,0)
        };
    }
    void initObjetivepos()
    {
        objetivePos = new Vector3[8];
        objetivePos[0] = new Vector3(-0.291f, 0.542f,0.0f);
        objetivePos[1] = new Vector3(-0.2121f, 0.542f, 0.0f);
        objetivePos[2] = new Vector3(-0.1333f, 0.542f, 0.0f);
        objetivePos[3] = new Vector3(-0.0538f, 0.542f,0.0f);
        objetivePos[4] = new Vector3(0.0261f, 0.542f,0.0f);
        objetivePos[5] = new Vector3(0.1053f, 0.542f,0.0f);
        objetivePos[6] = new Vector3(0.1855f, 0.542f,0.0f);
        objetivePos[7] = new Vector3(0.2649f, 0.542f,0.0f);
    }
    void initsprites()
    {
        sprites[0] = sprite1;
        sprites[1] = sprite2;
        sprites[2] = sprite3;
        sprites[3] = sprite4;
        sprites[4] = sprite5;
        sprites[5] = sprite6;
        sprites[6] = sprite7;
    }
    public void addLetter(int fil, int col)
    {

        char letra= letters[fil][col];
        if (letra == '<')
        {
            previous();
            return;
        }
        if (letra == '>')
        {
            next();
            return;
        }
        if (letra == '+')
        {
            done();
            return;
        }
        m_name += letra;
        selectLetter(fil, col);
        if (!fullLetters|| letterIndex<maxIndex)
        {
            letterIndex++;
            
        }
        if (letterIndex > maxIndex)
            maxIndex++;
        if(maxIndex>7)
        {
            fullLetters = true;
            maxIndex = 7;
           // ismoveHand = true;
        }
        else
            fullLetters = false;
        if(letterIndex>7)
        {
            ismoveHand = true;
            letterIndex = 7;
        }
        //flecha.transform.position = new Vector3(objetivePos[letterIndex].x, flecha.transform.position.y, 0);

    }

    void selectLetter(int fil, int col)
    {
        letterextra.sprite = letter[letterIndex].sprite;
        letterextra.transform.position = letter[letterIndex].transform.position;
        letter[letterIndex].gameObject.transform.position = posLettlers[fil][col];
        originalPos = posLettlers[fil][col];
        letter[letterIndex].sprite = sprites[fil][col];
        objetiveIndex = letterIndex;
        bLetterMove = true;
    }
    public void moveLetter()
    {
        timeTrans += Time.deltaTime;
        if (timeTrans > timeToPositione)
            timeTrans = timeToPositione;
        Vector3 pos = objetivePos[objetiveIndex] - originalPos;
        //letter[letterIndex].transform.position = originalPos;
        letter[objetiveIndex].transform.position = originalPos +((pos * timeTrans)/ timeToPositione);
        //letter[objetiveIndex].transform.position = objetivePos[objetiveIndex];
        if (letter[objetiveIndex].transform.position == objetivePos[objetiveIndex])
        {
            timeTrans = 0;
            flecha.transform.position = new Vector3(objetivePos[letterIndex].x, flecha.transform.position.y, 0);
            letterextra.sprite = sprites[2][6];
            bLetterMove = false;
        }
        //if (timeTrans>1.0f)
        //{
        //    timeTrans = 0;
        //    bLetterMove = false;
        //}
    }
    public void backspace()
    {
        
        letter[letterIndex].sprite = sprites[2][6];
        letterextra.sprite = sprites[2][6];
        if (maxIndex > 7)
        {
           maxIndex = 7;
            // ismoveHand = true;
        }
        if (letterIndex==maxIndex)
        {
            maxIndex--;
        }
        letterIndex--;
        if (letterIndex < 0)
        {
            letterIndex = 0;
            return;
        }
        //letterextra = letter[letterIndex];
        flecha.transform.position = new Vector3(objetivePos[letterIndex].x, flecha.transform.position.y, 0);
        m_name.Remove(letterIndex);
    }
    void next()
    {
        if(letterIndex<maxIndex)
            letterIndex++;
        if (letterIndex > 7)
            letterIndex = 7;
        letterextra.sprite = letter[letterIndex].sprite;
        letterextra.transform.position = letter[letterIndex].transform.position;
        flecha.transform.position = new Vector3(objetivePos[letterIndex].x, flecha.transform.position.y, 0);
    }
    void previous()
    {
        if (letterIndex > 0)
            letterIndex--;
        letterextra.sprite = letter[letterIndex].sprite;
        letterextra.transform.position = letter[letterIndex].transform.position;
        flecha.transform.position = new Vector3(objetivePos[letterIndex].x, flecha.transform.position.y, 0);
    }
    void done()
    {
        isDone = true;
        //SceneManager.LoadScene("PROLOGO");
        //PROLOGO
    }
}
