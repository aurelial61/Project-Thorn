using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public LayerMask playerMask;
    public bool detected;
    public float range;
    public float detectAngle;
    void Start()
    {
        detected = false;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector3 playerToEnemyAngle = (player.position - transform.position).normalized;
        if ((player.position - transform.position).magnitude <= range &&
            Vector3.Angle(transform.forward, playerToEnemyAngle) < detectAngle &&
            Physics.Raycast(transform.position, playerToEnemyAngle, out RaycastHit a, range, playerMask))
        {
            //Debug.Log("AH");
            detected = true;
        }
        else
        {
            detected = false;
        }
    }
}
