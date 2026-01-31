using UnityEngine;
public class Enemy1CooldownState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    float timer;
    float length;
    public Enemy1CooldownState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }
    public override void Enter()
    {
        timer = 0;
        length = 0.5f + Random.value;
    }

    public override void Exit()
    {

    }

    public override void Update()
    {
        timer += Time.deltaTime;
        if (timer >= length)
        {
            e.ChangeState(e.followState);
        }

    }
}
