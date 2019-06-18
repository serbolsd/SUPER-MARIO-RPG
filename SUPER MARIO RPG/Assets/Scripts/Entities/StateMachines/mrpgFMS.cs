using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class mrpgFMS : MonoBehaviour
{
    void 
    Start()
    {
        
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anmtr = gameObject.AddComponent<Animator>();
        cc = gameObject.AddComponent<CircleCollider2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();
        

        cf.NoFilter();

        stateStack = new Stack<mrpgState>();
    }

    public void 
    setState(mrpgState newState)
    {
        stateStack.Peek().onExit();
        stateStack.Pop();
        stateStack.Push(newState);
        stateStack.Peek().onEnter();
    }

    public void 
    pushState(mrpgState newState)
    {
        stateStack.Push(newState);
        stateStack.Peek().onEnter();
    }

    public void 
    popState()
    {
        stateStack.Peek().onExit();
        stateStack.Pop();
    }

    public void 
    onUpdate()
    {
        cc.OverlapCollider(cf, arrContacts);
        if (arrContacts.Length > 0)
        {
            for (int i = 0; i < arrContacts.Length - 1; ++i)
            {
                arrGO_Contacts[i] = arrContacts[i].gameObject;
            }
        }
        stateStack.Peek().onUpdate();
    }


    private Stack<mrpgState> stateStack;

    private ContactFilter2D cf;


    public Rigidbody2D rb;
    public Animator anmtr;
    public CircleCollider2D cc;
    public SpriteRenderer sr;

    public GameObject[] arrGO_Contacts;
    public Collider2D[] arrContacts;
}
