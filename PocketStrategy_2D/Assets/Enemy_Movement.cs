using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    int current = 1;

    public float speed;

    GameObject[] myPath;
    Health_Script health;


    void Awake()
    {
        myPath = GameObject.FindObjectOfType<Path_Creation>().path.ToArray();
        transform.position = myPath[0].transform.position;
        health = GetComponent<Health_Script>();
    }

    void Update()
    {
        if (health.health > 0) {
            transform.position = Vector3.MoveTowards(transform.position, myPath[current].transform.position, speed * Time.deltaTime);
        }
        

        if (Vector3.Distance(transform.position, myPath[current].transform.position) < 0.1f) {

            if (current == myPath.Length - 1)
            {
                ReachedEnd();
                gameObject.SetActive(false);
            }
            else {
                current++;
            }
        }
    }

    void ReachedEnd() {
        //whatever happens when the enemy hits the last path point
        GameObject.FindObjectOfType<Wave_Manager>().activeEnemies.Remove(this.gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health_Script>().RemoveHealth(1);
        current = 1;
    }
}
