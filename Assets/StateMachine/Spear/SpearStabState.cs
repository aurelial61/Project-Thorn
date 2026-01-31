using UnityEngine;

public class SpearStabState : State
{
    SpearScript spearScript;
    public SpearStabState(SpearScript s)
    {
        spearScript = s;
    }
    public override void Enter()
    {
        spearScript.theCollider.enabled = true;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        if (spearScript.transform.localPosition.z > spearScript.defaultPos.z + spearScript.reach)
        {
            spearScript.ChangeState(spearScript.returnState);
            return;
        }

        spearScript.transform.localPosition += new Vector3(0, 0, Time.fixedDeltaTime * spearScript.attackSpeed);
    }
}
