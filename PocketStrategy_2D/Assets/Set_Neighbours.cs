using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_Neighbours : MonoBehaviour
{
    public GameObject right, left, up, down;

    CircleCollider2D col;

    BoxCollider2D box;

    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        Set();

        Invoke("SetTrigger", Time.deltaTime);
        
    }

    void Set() {
        Set_Neighbours[] tiles = FindObjectsOfType<Set_Neighbours>();


        foreach (Set_Neighbours neighbour in tiles) {
            if (col.bounds.Intersects(neighbour.gameObject.GetComponent<Collider2D>().bounds) && neighbour.gameObject != gameObject) {
                if (neighbour.transform.position.y != transform.position.y)
                {
                    //is it the top neighbour
                    if (neighbour.transform.position.y > transform.position.y && neighbour.transform.position.x == transform.position.x)
                    {
                        up = neighbour.gameObject;
                    }
                    //is it the bottom neighbour
                    else if(neighbour.transform.position.y < transform.position.y && neighbour.transform.position.x == transform.position.x)
                    {
                        down = neighbour.gameObject;
                    }
                }
                else
                {
                    //is it the right neighbour
                    if (neighbour.transform.position.x > transform.position.x && neighbour.transform.position.y == transform.position.y)
                    {
                            right = neighbour.gameObject;
                    }
                    //is it the left neighbour
                    else if(neighbour.transform.position.x < transform.position.x && neighbour.transform.position.y == transform.position.y)
                    {
                            left = neighbour.gameObject;
                    }
                }
            }
        }
    }
    void SetTrigger() {
        Destroy(col);
        box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
    }
}
