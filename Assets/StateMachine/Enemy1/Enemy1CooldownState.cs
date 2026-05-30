using UnityEngine;
public class Enemy1CooldownState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    float timer;
    float length;
    bool a;
    public Enemy1CooldownState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }

    public Enemy1CooldownState(BasicEnemyScript enemy, PlayerDetectionScript detect, bool a)
    {
        e = enemy;
        d = detect;
        this.a = a;
    }
    public override void Enter()
    {
        timer = 0;
        length = 0.5f + Random.value;
        if (a)
        {
            length = 0.05f;
        }
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
