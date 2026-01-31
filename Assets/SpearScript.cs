using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpearScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float attackSpeed;
    public float reach;
    public int damage;
    public SpearInactiveState inactiveState;
    public SpearStabState stabState;
    public SpearReturnState returnState;
    public Vector3 defaultPos;
    public CapsuleCollider theCollider;
    public State currentState;
    public UnityEvent attackEnd;
    public string attackingTag;

    private void Awake()
    {
        inactiveState = new SpearInactiveState(this);
        stabState = new SpearStabState(this);
        returnState = new SpearReturnState(this, attackEnd);
        
    }
    void Start()
    {
        theCollider = GetComponent<CapsuleCollider>();
        ChangeState(inactiveState);
        
    }

    // Update is called once per frame
    void Update()
    {

        currentState?.Update();
        
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    public void StartAttack()
    {
        if (currentState == inactiveState)
        {
            ChangeState(stabState);
            
        }
    }

    public void ChangeState(State state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }



    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != attackingTag)
        {
            return;
        }

        if (currentState != stabState && currentState != returnState)
        {
            return;
        }
        if (! (other.TryGetComponent(out Health health)))
        {
            return;

        }
        health.TakeDamage(2);
    }

}
