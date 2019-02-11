using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    GameObject target;

    Vector3 previousPos;

    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        

        if (Vector2.Distance(transform.position, previousPos) < 0.1f) {
            if (target != null) {
                target.GetComponent<Health_Script>().RemoveHealth(1);
            }
            
            gameObject.SetActive(false);
        }

        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            previousPos = target.transform.position;
        }
    }

    public void SetTarget(GameObject targetObj)
    {
        target = targetObj;
    }
}
