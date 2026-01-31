using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fish;

    [Header("General movement")]
    public Vector3 moveDirection;
    public float forceScalar;
    public float rotationSpeed;
    [Header("Stroke settings")]
    public float strokeForce;
    public float forceTimer;
    [Header("Attacks")]
    public UnityEvent spearAttack = new UnityEvent();
    
    public GameObject harpoon;
    public HarpoonScript harpoonPrefab;
    private HarpoonScript spawnedHarpoon;
    public Vector3 hStartPos;
    public float hForce;
    public bool thrown = false;

    void Start()
    {
        fish = false;
        hStartPos = harpoon.GetComponent<Transform>().position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovementInput();
        
        ApplyRotation();
        ReadStrokeInput();

        // attack
        if (!fish)
        {
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
                ReadAttackInput();
                //HarpoonAttack();
            //}

        }
        //ReadAttackInput();
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
        if (!(moveDirection == Vector3.zero) && Vector3.Magnitude(GetComponent<Rigidbody>().velocity) < 10)
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

    void HarpoonAttack()
    {
        if (spawnedHarpoon != null)
        {
            return;
        }

        spawnedHarpoon = Instantiate(harpoonPrefab, harpoon.transform.position, harpoon.transform.rotation);
        spawnedHarpoon.Throw(harpoon, hForce, 20, Camera.main.transform.forward);
        harpoon.gameObject.SetActive(false);
    }

    void ReadAttackInput()
    {

        if (Input.GetMouseButtonDown(0))
        {
            spearAttack.Invoke();
        }

        else if (Input.GetMouseButtonDown(1))
        {
            HarpoonAttack();
        }
    }
}
