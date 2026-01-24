
using UnityEngine;

public class Enemy1FollowState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    public Enemy1FollowState(BasicEnemyScript enemy, PlayerDetectionScript detect)
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
        Vector3 dirToPlayer = (d.player.transform.position - e.transform.position).normalized;
        Quaternion lookAtPlayerRot = Quaternion.LookRotation(dirToPlayer);
        e.transform.position += (e.transform.forward * e.swimSpeed * Time.fixedDeltaTime);
        e.transform.rotation = Quaternion.Slerp(e.transform.rotation, lookAtPlayerRot, e.rotationSpeed * Time.fixedDeltaTime);

    }
}
