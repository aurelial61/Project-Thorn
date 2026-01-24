using UnityEngine;

public class SpearReturnState : State
{
    SpearScript spearScript;
    public SpearReturnState(SpearScript s)
    {
        spearScript = s;
    }
    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        if (spearScript.transform.localPosition.z < spearScript.defaultPos.z)
        {
            spearScript.ChangeState(spearScript.inactiveState);
            return;
        }

        spearScript.transform.localPosition += new Vector3(0, 0, -Time.deltaTime * spearScript.attackSpeed);
    }
}