using UnityEngine;
using UnityEngine.Events;

public class SpearReturnState : State
{
    SpearScript spearScript;
    UnityEvent end;
    public SpearReturnState(SpearScript s, UnityEvent e)
    {
        spearScript = s;
        end = e;
    }
    public override void Enter()
    {

    }

    public override void Exit()
    {
        end.Invoke();
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        if (spearScript.transform.localPosition.z < spearScript.defaultPos.z)
        {
            spearScript.ChangeState(spearScript.inactiveState);
            return;
        }

        spearScript.transform.localPosition += new Vector3(0, 0, -Time.deltaTime * spearScript.attackSpeed);
    }
}