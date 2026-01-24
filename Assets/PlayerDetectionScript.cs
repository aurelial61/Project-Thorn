using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public LayerMask playerMask;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector3 playerToEnemyAngle = (player.position - transform.position).normalized;
        if ((player.position - transform.position).magnitude <= 25 &&
            Vector3.Angle(transform.forward, playerToEnemyAngle) < 20 &&
            Physics.Raycast(transform.position, playerToEnemyAngle, out RaycastHit a, 25, playerMask))
        {
            //Debug.Log("AH");
        }
    }
}
