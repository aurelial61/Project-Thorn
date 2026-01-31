using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // swimming
        ReadMovementInput();
        ApplyMovement();
        ApplyRotation();
    }

    void ReadMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        // normalized: magnitude 1
        moveDirection = new Vector3(x, 0, z).normalized;
    }

    void ApplyMovement()
    {
        // move according to camera direction
        // multiply right and forward (positive vectors) by where teh camera is looking
        Vector3 finalDirection = Camera.main.transform.right * moveDirection.x + Camera.main.transform.forward * moveDirection.z;
        transform.Translate(speed * Time.deltaTime * finalDirection, Space.World);
    }

    void ApplyRotation()
    {
        Quaternion targetRotation = Camera.main.transform.rotation;


        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
