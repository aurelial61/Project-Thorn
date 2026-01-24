using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public enum EnemyState
    {
        Idle,
        Following,
        Charging,
        Cooldown,
        Attacking
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }


}
