
using UnityEngine;

public class Enemy1IdleState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    public Enemy1IdleState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }
    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        e.transform.position += (e.transform.forward * e.idleSpeed * Time.fixedDeltaTime);
        e.transform.Rotate(e.idleRotate);

        if (d.DetectPlayer(e.aggroRange))
        {
            e.ChangeState(e.followState);
        }
    }
}
