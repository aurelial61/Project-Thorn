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
    public float damageTimer;
    public Material damageMat;
    public Material defaultMat;
    public float chargeForce;
    public float swimSpeed;
    public float rotationSpeed;
    public float aggroRange;
    public float attackingRange;
    public float attackAngle;
    public float aggroAngle;
    public Vector3 idleRotate;
    public State currentState;
    public Enemy1IdleState idleState;
    public Enemy1FollowState followState;
    public Enemy1ChargingState chargingState;
    public Enemy1CooldownState cooldownState;
    public Enemy1AttackingState attackingState;
    public PlayerDetectionScript detect;
    public Enemy1RangedState rangedState;
    public Enemy1PreparingState preparingState;
    public GameObject HPRestore;
    public GameManagerScript gm;

    [Header("Harpoon")]
    public GameObject harpoon;
    public HarpoonScript harpoonPrefab;
    private HarpoonScript spawnedHarpoon;
    public Vector3 hStartPos;
    public float harpoonOffset;
    public float hForce;
    public bool thrown = false;
    public Transform target;
    public float harpoonSpeed;
    public UnityEvent harpoonEnd;

    public UnityEvent startAttack;


    private void Awake()
    {
       idleState = new Enemy1IdleState(this, detect);
       followState = new Enemy1FollowState(this, detect);
       chargingState = new Enemy1ChargingState(this, detect);
       cooldownState = new Enemy1CooldownState(this, detect);
       attackingState = new Enemy1AttackingState(this, detect);
        rangedState = new Enemy1RangedState(this, detect);
        preparingState = new Enemy1PreparingState(this, detect);
    }

    void Start()
    {
        currentState = idleState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        
        if (damageTimer > 0)
        {
            
            gameObject.GetComponent<MeshRenderer>().material = damageMat;
            damageTimer -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        }
        
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
        
    }

    public void OnDeath()
    {
        if (Random.value > 0.7)
        {
            Instantiate(HPRestore, transform.position, Quaternion.identity);
        }
        /*
        gm.EnemyDeath();
        */
        Destroy(gameObject);
    }

    public void ChangeState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void onDamageTaken()
    {
        if (currentState == idleState)
        {
            ChangeState(followState);
        }
        damageTimer = 0.1f;
        //Debug.Log("a");
    }

    public void EndAttack()
    {
        
           ChangeState(cooldownState);
        
    }
    public void HarpoonAttack()
    {
        if (spawnedHarpoon != null)
        {
            return;
        }

        spawnedHarpoon = Instantiate(harpoonPrefab, harpoon.transform.position, harpoon.transform.rotation);
        spawnedHarpoon.Throw(harpoon, hForce, target, harpoonSpeed, "Player", 1, harpoonEnd);
        harpoon.gameObject.SetActive(false);
    }

   
}
