using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class HarpoonScript : MonoBehaviour
{
    private GameObject originalHarpoon;
    //public GameObject player;

    private float maxDistance;

    private Vector3 startPos;
    private Rigidbody rb;
    public State currentState = State.Idling;
    public UnityEvent attackEnd;

    private float Timer;
    public Vector3 position;
    public Vector3 localPos;
    public Transform target;
    public float speed;
    public string damageTag;
    
    public int damage;
    public enum State
    {
        Going,
        Returning,
        Idling,
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        localPos = transform.localPosition;
        
    }

    /*
     * public void Throw(GameObject original, float force, float distance, Vector3 direction)
    {
        originalHarpoon = original;
        rb.AddForce(force * direction.normalized, ForceMode.Impulse);
        maxDistance = distance;
        startPos = original.transform.position;
        ChangeState(State.Going);
    }
    */

    public void Throw(GameObject original, float force, Transform target, float speed, string damageTag, int damage, UnityEvent hEvent)
    {
        originalHarpoon = original;
        startPos = original.transform.position;
        this.speed = speed;
        this.target = target;
        this.damageTag = damageTag;
        this.damage = damage;
        attackEnd = hEvent;
        ChangeState(State.Going);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case State.Going:
                Timer += Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
                if (Vector3.Distance(transform.position, target.transform.position) <= 0.5f || Timer >= 5)
                {
                    ChangeState(State.Returning);
                }
                break;
            case State.Returning:
                transform.rotation = Quaternion.Slerp(transform.rotation, originalHarpoon.transform.rotation, Time.deltaTime * 200);
                transform.position = Vector3.Lerp(transform.position, originalHarpoon.transform.position, Time.deltaTime * 25);
                if (Vector3.Distance(transform.position, originalHarpoon.transform.position) <= 2)
                {
                    Vector3 direction = originalHarpoon.transform.position - transform.position;

                    transform.position += direction * Time.deltaTime * 20;
                }
                
                if (Vector3.Distance(transform.position, originalHarpoon.transform.position) <= 0.1)
                {
                    attackEnd.Invoke();
                    CleanUp();
                    
                    Destroy(gameObject);
                    //currentState = State.Idling;
                }
                break;
            case State.Idling:
                transform.localPosition = localPos;
                break;
            default:
                break;
        }

        

    }

    private void ChangeState(State nextState)
    {
        // exit

        currentState = nextState;

        // enter
        switch (currentState)
        {
            case State.Going:
                Timer = 0;
                break;
            case State.Returning:
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                break;
            case State.Idling:

                break;
            default:
                break;
        }
    }

    private void CleanUp()
    {
        originalHarpoon.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damageTag)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}
