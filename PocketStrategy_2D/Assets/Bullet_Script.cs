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




        if (target != null)
        {

            if (Vector2.Distance(transform.position, previousPos) < 0.1f)
            {
                target.GetComponent<Health_Script>().RemoveHealth(1);
                gameObject.SetActive(false);
            }
            else
            {
                previousPos = target.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, previousPos, Time.deltaTime * speed);
            }
        }
        else {
            if (Vector2.Distance(transform.position, previousPos) < 0.1f)
            {
                gameObject.SetActive(false);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, previousPos, Time.deltaTime * speed);
            }
        }
    }

    public void SetTarget(GameObject targetObj)
    {
        target = targetObj;
    }
}
