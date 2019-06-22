using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace mrpg
{
    enum E
    {
        castleBattle
    }
}

public class gBattleMode : MonoBehaviour
{
    #region Global Combat Methods
    public void startBattle(cCharacter[] enemies, cCharacter[] party, int battleField)
    {
        m_arrEnemies = enemies;
        m_arrPlayerChars = party;
        m_WorldMode.gameObject.SetActive(false);
        m_BattleMode.gameObject.SetActive(true);
        //TODO: battle music
        sortTurns();
    }

    public void endBattleVictory()
    {
        //TODO: Get loot
        //TODO: Fade out transition
        m_WorldMode.gameObject.SetActive(true);
        m_BattleMode.gameObject.SetActive(false);
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
    #endregion

    private void Start()
    {
        //m_arrInitiativeOrder = GetComponentsInChildren<cCharacter>();
        //combatButtons = gameObject.AddComponent<battlebuttons>();
        m_currTurn = 0;
    }

    private void Update()
    {
        onPreUpdate();
        onUpdate();
    }

    

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
    #endregion

    GameObject m_BattleMode;
    GameObject m_WorldMode;

    [SerializeField]
    battlebuttons combatButtons;
    cCharacter[] m_arrInitiativeOrder;
    cCharacter[] m_arrPlayerChars;
    cCharacter[] m_arrEnemies;

    cCharacter m_swapAux;
    bool m_battleActive;
    bool m_victory;
    int m_currTurn;
    int m_nEnemies;
    int m_nAllies;
}
