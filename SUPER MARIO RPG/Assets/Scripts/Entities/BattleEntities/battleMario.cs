using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleMario : cCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        m_Stats = GetComponentInParent<cStats>();
        m_name = "MARIO";
        combatButtons = gameObject.AddComponent<battlebuttons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool takeTurn()
    {
        return combatButtons.onUpdate();
    }

    [SerializeField]
    public battlebuttons combatButtons;

    //public static battleMario sBattleMario;
}
