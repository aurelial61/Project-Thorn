public class Enemy1AttackingState : State
{
    BasicEnemyScript e;
    PlayerDetectionScript d;
    public Enemy1AttackingState(BasicEnemyScript enemy, PlayerDetectionScript detect)
    {
        e = enemy;
        d = detect;
    }
    public override void Enter()
    {
        e.startAttack.Invoke();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {


    }
}