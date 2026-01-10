using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int attackState;
    public float attackSpeed;
    public float reach;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }
        switch (attackState)
        {
            case 1:
                if (transform.localPosition.z <= reach)
                {
                    transform.localPosition += new Vector3(0, 0, Time.deltaTime * attackSpeed);
                    break;
                }
                attackState = 2;
                break;

            case 2:
                if (transform.localPosition.z > 0)
                {
                    transform.localPosition += new Vector3(0, 0, -Time.deltaTime * attackSpeed);
                    break;
                }
                attackState = 0;
                transform.localPosition = new Vector3(0.6f, 0, 0);
                break;
        }
    }

    void StartAttack()
    {
        if (attackState == 0)
        {
            attackState = 1;
            
        }
    }

   
}
