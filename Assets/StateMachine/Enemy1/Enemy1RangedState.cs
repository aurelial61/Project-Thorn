public class Enemy1RangedState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    public Enemy1RangedState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }
    public override void Enter()
    {
        e.HarpoonAttack();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {


    }
}