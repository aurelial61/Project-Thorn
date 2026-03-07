using UnityEngine;
public class Enemy1PreparingState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    float timer;
    float length;
    public Enemy1PreparingState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }
    public override void Enter()
    {
        timer = 0;
        length = 0.3f;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= length)
        {
            e.ChangeState(e.attackingState);
        }

    }
}