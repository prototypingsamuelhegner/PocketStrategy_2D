using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    GameObject target;

    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        

        if ( target == null || Vector2.Distance(transform.position, target.transform.position) < 0.1f ) {
            if (target != null) {
                target.GetComponent<Health_Script>().RemoveHealth(1);
            }
            
            gameObject.SetActive(false);
        }

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    public void SetTarget(GameObject targetObj)
    {
        target = targetObj;
    }
}
