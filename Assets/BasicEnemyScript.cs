using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public enum EnemyState
    {
        Idle,
        Following,
        Charging,
        Cooldown,
        Attacking
    }
    public float idleSpeed;
    public float chargeForce;
    public float swimSpeed;
    public float rotationSpeed;
    public float aggroRange;
    public float attackingRange;
    public Vector3 idleRotate;
    public State currentState;
    public Enemy1IdleState idleState;
    public Enemy1FollowState followState;
    public Enemy1ChargingState chargingState;
    public Enemy1CooldownState cooldownState;
    public Enemy1AttackingState attackingState;
    public PlayerDetectionScript detect;

    public UnityEvent startAttack;


    private void Awake()
    {
       idleState = new Enemy1IdleState(this, detect);
       followState = new Enemy1FollowState(this, detect);
       chargingState = new Enemy1ChargingState(this, detect);
       cooldownState = new Enemy1CooldownState(this, detect);
       attackingState = new Enemy1AttackingState(this, detect);
    }

    void Start()
    {
        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
        
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    public void ChangeState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void EndAttack()
    {
        if (currentState == attackingState)
        {
            ChangeState(idleState);
        }
    }
}
