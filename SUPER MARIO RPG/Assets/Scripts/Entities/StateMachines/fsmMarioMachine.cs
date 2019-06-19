using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fsmMarioMachine : mrpgFMS
{
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        anmtr = gameObject.AddComponent<Animator>();
        cc = gameObject.AddComponent<CircleCollider2D>();
        sr = gameObject.AddComponent<SpriteRenderer>();

        cf.NoFilter();

        stateStack = new Stack<mrpgState>();
        s_Idle = gameObject.AddComponent<sMarioIdleState>() as sMarioIdleState;
        s_Jump = gameObject.AddComponent<sMarioJumpState>() as sMarioJumpState;
        s_WalkRun = gameObject.AddComponent<sMarioWalkRunState>() as sMarioWalkRunState;
        s_Pause = gameObject.AddComponent<sPauseState>() as sPauseState;
        s_Battle = gameObject.AddComponent<sMarioBattleState>() as sMarioBattleState;
        s_Dialog_CutScene = gameObject.AddComponent<sMarioDialogCutSceneState>() as sMarioDialogCutSceneState;

        s_Idle.setFSM(this);
        s_Jump.setFSM(this);
        s_WalkRun.setFSM(this);
        s_Pause.setFSM(this);
        s_Battle.setFSM(this);

        pushState(s_Idle);
    }

    public void endInteract()
    {
        setState(s_Idle);
    }

    public mrpgState s_Idle;
    public mrpgState s_Jump;
    public mrpgState s_WalkRun;
    public mrpgState s_Dialog_CutScene;
    public mrpgState s_Pause;
    public mrpgState s_Battle;
}
