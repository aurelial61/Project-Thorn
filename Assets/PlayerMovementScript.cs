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
    public static int stamina;
    public static int maxStamina = 20;
    public float staminaRegenTime = 1.5f;
    public float staminaTimer;
    public int strokeStamina = 2;
    public int spearStamina = 1;
    public int harpoonStamina = 3;
    [Header("Stroke settings")]
    public float strokeForce;
    public float forceTimer;
    [Header("Attacks")]
    public UnityEvent spearAttack = new UnityEvent();
    
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
    public string damageTag;
    public UnityEvent harpoonEnd;
    [Header("Damage")]
    public float damageTimer;
    public Material damageMat;
    public Material defaultMat;
    

    public UnityEvent die = new UnityEvent();

    void Start()
    {
        fish = false;
        //hStartPos = harpoon.GetComponent<Transform>().position;
        Cursor.lockState = CursorLockMode.Locked;

        stamina = maxStamina;
        

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
          ReadAttackInput();
        };
        if (damageTimer > 0)
        {

            gameObject.GetComponent<MeshRenderer>().material = damageMat;
            damageTimer -= Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        }

        if (stamina < maxStamina)
        {
            staminaTimer += Time.deltaTime;

            if (staminaTimer >= staminaRegenTime)
            {
                stamina += 1;
                staminaTimer = 0;
            }
        }
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
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && forceTimer <= 0 && stamina >= strokeStamina)
        {
            ApplyStroke();
            forceTimer = 0.5f;
            stamina -= strokeStamina;
        }
        else if (forceTimer > 0)
        {
            forceTimer -= Time.deltaTime;
        }
    }

    void ApplyStroke()
    {
        Vector3 finalDirection = Camera.main.transform.forward;
        if (!(moveDirection == Vector3.zero))
        {

            finalDirection = Camera.main.transform.right * moveDirection.x + Camera.main.transform.forward * moveDirection.z;

            finalDirection.Normalize();

            


        }


        GetComponent<Rigidbody>().AddForce(strokeForce * finalDirection, ForceMode.Impulse);
    }
    public void onDamageTaken()
    {
        
        damageTimer = 0.1f;
        //Debug.Log("a");
    }
    void HarpoonAttack()
    {
        if (spawnedHarpoon != null)
        {
            return;
        }

        spawnedHarpoon = Instantiate(harpoonPrefab, harpoon.transform.position, harpoon.transform.rotation);
        spawnedHarpoon.Throw(harpoon, hForce, target, harpoonSpeed, damageTag, 1, harpoonEnd);
        harpoon.gameObject.SetActive(false);
    }

    void ReadAttackInput()
    {

        if (Input.GetMouseButtonDown(0) && stamina >= spearStamina)
        {
            spearAttack.Invoke();
            stamina -= spearStamina;

        }
        else if (Input.GetMouseButtonDown(1) && stamina >= harpoonStamina)
        {
            HarpoonAttack();
            stamina -= harpoonStamina;
        }
    }

    public void Die()
    {
        die.Invoke();
        Destroy(gameObject);
    }
}
