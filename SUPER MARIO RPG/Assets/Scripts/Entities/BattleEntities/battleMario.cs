using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleMario : cCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        m_Stats = FindObjectOfType<Player>().getStats();
        m_name = "MARIO";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool takeTurn()
    {
        return base.takeTurn();
    }

    [SerializeField]
    public battlebuttons combatButtons;
}
