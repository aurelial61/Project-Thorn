using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearInactiveState : State
{
    SpearScript spearScript;
    public SpearInactiveState(SpearScript s)
    {
        spearScript = s;
    }
    public override void Enter()
    {
        spearScript.enemyAttacked = new List<Transform>();
        spearScript.transform.localPosition = spearScript.defaultPos;
        spearScript.theCollider.enabled = false;
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
