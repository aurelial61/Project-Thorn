using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float attackSpeed;
    public float reach;
    public int damage;
    
    public Vector3 defaultPos;
    public CapsuleCollider theCollider;
    public enum AttackState
    {
        Inactive,
        Stab,
        Return,
    }
    public AttackState currentAttackState;
    void Start()
    {
        theCollider = GetComponent<CapsuleCollider>();
        ChangeState(AttackState.Inactive);
        transform.position = defaultPos;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateState(currentAttackState);
        
    }

    public void StartAttack()
    {
        if (currentAttackState == AttackState.Inactive)
        {
            ChangeState(AttackState.Stab);
            
        }
    }

    public void ChangeState(AttackState state)
    {
        ExitState(currentAttackState);
        currentAttackState = state;
        EnterState(currentAttackState);
    }

    public void ExitState(AttackState exit)
    {
        switch (exit)
        {
            case AttackState.Inactive:
                break;
            case AttackState.Stab:
                break;
            case AttackState.Return:
                break;
            default:
                break;
        }
    }

    public void EnterState(AttackState enter)
    {
        switch (enter)
        {
            case AttackState.Inactive:
                transform.localPosition = defaultPos;
                theCollider.enabled = false;
                break;
            case AttackState.Stab:
                theCollider.enabled = true;
                break;
            case AttackState.Return:
                break;
            default:
                break;
        }
    }

    public void UpdateState(AttackState update)
    {
        switch (update)
        {
            case AttackState.Inactive:
                break;
            case AttackState.Stab:
                if (transform.localPosition.z > defaultPos.z + reach)
                {
                    ChangeState(AttackState.Return);
                    break;
                }
                
                transform.localPosition += new Vector3(0, 0, Time.deltaTime * attackSpeed);
                break;
                

            case AttackState.Return:
                if (transform.localPosition.z < defaultPos.z)
                {
                    ChangeState(AttackState.Inactive);
                    break;
                }
                
                transform.localPosition += new Vector3(0, 0, -Time.deltaTime * attackSpeed);
                break;
                
                
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((currentAttackState == AttackState.Stab || currentAttackState == AttackState.Return) && other.gameObject.tag == "Enemy")
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(2);
                Debug.Log(currentAttackState);
            }
        }
    }


}
