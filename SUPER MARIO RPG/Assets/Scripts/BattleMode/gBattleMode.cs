﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace mrpgBattleBGs
{
    enum E
    {
        castleBattle = 0,
        bowserChandelierBattle,
        shroomRoadFirst_N_Third,
        shroomRoadSecond,
        kCOUNT
    }
}

public class gBattleMode : MonoBehaviour
{
    #region Global Combat Methods
    public void startBattle(GameObject initiator, cCharacter[] enemies, cCharacter[] party, int battleField)
    {
        m_battleInitiator = initiator;
        m_arrEnemies = enemies;
        m_arrPlayerChars = party;
        m_WorldMode.gameObject.SetActive(false);
        m_BattleMode.gameObject.SetActive(true);
        //TODO: battle music
        setUpTurns();
        sortTurns();
    }

    public void endBattleVictory()
    {
        //TODO: Get loot
        //TODO: Fade out transition
        m_WorldMode.gameObject.SetActive(true);
        m_BattleMode.gameObject.SetActive(false);
        Destroy(m_battleInitiator);
    }

    public void endBattleDefeat()
    {
        //TODO: Display Game Over as an atk name
        SceneManager.LoadScene("MAINMENU");
    }

    public void destroyEnemy(int i)
    {
        Destroy(m_arrEnemies[i]);
    }

    public void loadBBG(int index)
    {
        if(index == (int)mrpgBattleBGs.E.castleBattle)
            m_srBG.sprite = Resources.Load<Sprite>("Assets/Sprites/Maps/BattleStages/castleBBG");
        else if(index == (int)mrpgBattleBGs.E.bowserChandelierBattle)
            m_srBG.sprite = Resources.Load<Sprite>("Assets/Sprites/Maps/BattleStages/castleBBG");
        else if(index == (int)mrpgBattleBGs.E.shroomRoadFirst_N_Third)
            m_srBG.sprite = Resources.Load<Sprite>("Assets/Sprites/Maps/BattleStages/shroomRoad1-3BBG");
        else if(index == (int)mrpgBattleBGs.E.shroomRoadSecond)
            m_srBG.sprite = Resources.Load<Sprite>("Assets/Sprites/Maps/BattleStages/castleBBG");
        else
            m_srBG.sprite = Resources.Load<Sprite>("Assets/Sprites/Maps/BattleStages/512x448");
        resizeSprite();
    }

    public cCharacter getRandTargetPlayer()
    {
        return m_arrPlayerChars[0];
    }

    public static int Attack(cCharacter _char, cCharacter _target, float timingMod)
    {
        return (int)Mathf.Max(1, (_char.getATK() - _target.getDEF()) * timingMod);
    }
    #endregion

    #region Start and Update
    private void Start()
    {
        //m_arrInitiativeOrder = GetComponentsInChildren<cCharacter>();
        //combatButtons = gameObject.AddComponent<battlebuttons>();
        m_currTurn = 0;
        m_srBG = Camera.main.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        onPreUpdate();
        onUpdate();
    }
    #endregion

    #region Sprite Management
    void resizeSprite()
    {
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / m_srBG.sprite.bounds.size.x,
            worldScreenHeight / m_srBG.sprite.bounds.size.y, 1);
    }

    void setSpritePos(int nEnemies)
    {
        if(nEnemies == 1)
        {
            m_arrEnemies[0].setPos(m_SingleEnemy.transform.position);
        }

        else if (nEnemies == 2)
        {
            m_arrEnemies[0].setPos(m_DoubleEnemies[0].transform.position);
            m_arrEnemies[1].setPos(m_DoubleEnemies[1].transform.position);
        }

        else if(nEnemies == 3)
        {
            m_arrEnemies[0].setPos(m_TripleEnemies[0].transform.position);
            m_arrEnemies[1].setPos(m_TripleEnemies[1].transform.position);
            m_arrEnemies[2].setPos(m_TripleEnemies[2].transform.position);
        }

        else if(nEnemies == 4)
        {
            m_arrEnemies[0].setPos(m_QuadEnemies[0].transform.position);
            m_arrEnemies[1].setPos(m_QuadEnemies[1].transform.position);
            m_arrEnemies[2].setPos(m_QuadEnemies[2].transform.position);
            m_arrEnemies[3].setPos(m_QuadEnemies[3].transform.position);
        }
    }

    #endregion

    #region PreUpdate
    public void onPreUpdate()
    {
        if(m_arrEnemies.Length == 0)
        {
            m_victory = true;
            m_battleActive = false;
        }
        else if(m_arrPlayerChars.Length == 0)
        {

        }

    }
    #endregion

    #region onUpdate
    public void onUpdate()
    {
        if (m_battleActive)
        {
            if (takeTurn(m_currTurn))
            {
                ++m_currTurn;
            }
        }
        else if (m_victory && !m_battleActive)
        {
            endBattleVictory();
        }
        else if (!m_victory && !m_battleActive)
        {
            endBattleDefeat();
        }
    }
    #endregion

    #region Turn Management
    bool takeTurn(int turnIndex)
    {
        return m_arrInitiativeOrder[turnIndex].takeTurn();
    }

    void sortTurns()
    {
        bool swaped = true;
        while (swaped)
        {
            swaped = false;
            for (int i = 0; i < m_arrInitiativeOrder.Length; ++i)
            {
                if (i + 1 < m_arrInitiativeOrder.Length)
                {
                    if (m_arrInitiativeOrder[i].m_Stats.m_bSpeed < m_arrInitiativeOrder[i + 1].m_Stats.m_bSpeed)
                    {
                        m_swapAux = m_arrInitiativeOrder[i];
                        m_arrInitiativeOrder[i] = m_arrInitiativeOrder[i + 1];
                        m_arrInitiativeOrder[i + 1] = m_swapAux;
                        swaped = true;
                    }
                }
            }
        }
    }

    void setUpTurns()
    {
        m_arrInitiativeOrder = m_arrPlayerChars.Concat(m_arrEnemies).ToArray();
    }
    #endregion

    //TODO: make mario attack

    GameObject m_battleInitiator;

    [SerializeField]
    GameObject m_BattleMode;
    [SerializeField]
    GameObject m_WorldMode;

    [SerializeField]
    public GameObject m_SingleEnemy;
    [SerializeField]
    public GameObject[] m_DoubleEnemies;
    [SerializeField]
    public GameObject[] m_TripleEnemies;
    [SerializeField]
    public GameObject[] m_QuadEnemies;


    //[SerializeField]
    //public battlebuttons combatButtons;
    public cCharacter[] m_arrInitiativeOrder;
    public cCharacter[] m_arrPlayerChars;
    public cCharacter[] m_arrEnemies;

    [SerializeField]
    public SpriteRenderer m_srBG;
    cCharacter m_swapAux;
    bool m_battleActive;
    bool m_victory;
    int m_currTurn;
    int m_nEnemies;
    int m_nAllies;
}
