using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 moveDirection;
    public float speed;
    public float rotationSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReadMovementInput();
        ApplyMovement();
        ApplyRotation();
    }

    void ReadMovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(x, 0, z);
    }

    void ApplyMovement()
    {
        Vector3 finalDirection = Camera.main.transform.right * moveDirection.x + Camera.main.transform.forward * moveDirection.z;
        finalDirection.Normalize();
        transform.Translate(speed * Time.deltaTime * finalDirection, Space.World);
    }

    void ApplyRotation()
    {
        Quaternion targetRotation = Camera.main.transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
