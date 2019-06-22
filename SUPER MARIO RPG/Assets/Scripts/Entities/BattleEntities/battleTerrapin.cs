using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleTerrapin : cCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        m_name = "TERRAPIN";
        m_Stats = new cStats();
        m_Stats.m_HP = 10;
        m_Stats.m_DEF = 8;
        m_Stats.m_ATK = 1;
        m_Stats.m_MagDEF = 1;
        m_Stats.m_MagATK = 0;
        m_Stats.m_currHP = m_Stats.m_HP;
        m_Stats.m_expReward = 0;
        m_Stats.m_coinReward = 0;

        m_SR = gameObject.AddComponent<SpriteRenderer>();
        m_SR.sprite = Resources.Load<Sprite>("Assets/Sprites/Enemies/Terrapin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool takeTurn()
    {
        if (Random.Range(0, 3) == 0)
        {

        }
        else
        {
            cCharacter target = GetComponentInParent<gBattleMode>().getRandTargetPlayer();
            gBattleMode.Attack(this, target, 1);
        }
        return true;
    }

    public SpriteRenderer m_SR;
}
