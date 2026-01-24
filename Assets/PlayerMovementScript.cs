using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General movement")]
    public Vector3 moveDirection;
    public float forceScalar;
    public float rotationSpeed;
    [Header("Stroke settings")]
    public float strokeForce;
    public float forceTimer;
    [Header("Attacks")]
    public UnityEvent spearAttack = new UnityEvent();
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovementInput();
        
        ApplyRotation();
        ReadStrokeInput();
        ReadAttackInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    void ReadMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
    }

    void ApplyMovement()
    {
        Vector3 finalDirection;
        if (! (moveDirection == Vector3.zero) && Vector3.Magnitude(GetComponent<Rigidbody>().velocity) < 10)
        {
        
            finalDirection = Camera.main.transform.right * moveDirection.x + Camera.main.transform.forward * moveDirection.z;

            finalDirection.Normalize();

            GetComponent<Rigidbody>().AddForce(forceScalar * finalDirection, ForceMode.Impulse); 


        }
        

    }

    void ApplyRotation()
    {
        Quaternion targetRotation = Camera.main.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

   

    void ReadStrokeInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && forceTimer <= 0)
        {
            ApplyStroke();
            forceTimer = 0.5f;
        }
        else if (forceTimer > 0)
        {
            forceTimer -= Time.deltaTime;
        }
    }

    void ApplyStroke()
    {
        GetComponent<Rigidbody>().AddForce(strokeForce * Camera.main.transform.forward, ForceMode.Impulse);
    }

    void ReadAttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spearAttack.Invoke();
        }
    }
}
