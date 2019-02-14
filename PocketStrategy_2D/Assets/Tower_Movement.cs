using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Movement : MonoBehaviour
{
    Ray ray;

    Animator anim;

    public GameObject currentTile;

    public bool moving;

    Vector3 rightScale;
    Vector3 leftScale;

    [Range(0, 20)]
    public int speed = 1;

    public enum MovementSystem
    {
        click,
        arrows,
    }

    public MovementSystem mode;

    // Start is called before the first frame update
    void Start()
    {
        rightScale = transform.localScale;
        leftScale = new Vector3(-rightScale.x, rightScale.y, rightScale.z);
        Set_Neighbours[] tiles = FindObjectsOfType<Set_Neighbours>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        GameObject temp_Closest = new GameObject();
        temp_Closest.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        currentTile = temp_Closest;
        for (int i = 0; i < tiles.Length; i++)
        {
            if (Vector3.Distance(tiles[i].transform.position, transform.position) < Vector3.Distance(transform.position, currentTile.transform.position))
            {
                currentTile = tiles[i].gameObject;
            }
        }

        Vector3 tempCurrentTile = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, -2f);

        transform.position = tempCurrentTile;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == MovementSystem.click)
        {
            if (!moving) {
                if (Input.GetMouseButton(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                    if (hit.collider != null) {
                        if (hit.transform.gameObject == currentTile.GetComponent<Set_Neighbours>().left)
                        {
                            currentTile = currentTile.GetComponent<Set_Neighbours>().left;
                            moving = true;
                        }
                        else if (hit.transform.gameObject == currentTile.GetComponent<Set_Neighbours>().right)
                        {
                            currentTile = currentTile.GetComponent<Set_Neighbours>().right;
                            moving = true;
                        }
                        else if (hit.transform.gameObject == currentTile.GetComponent<Set_Neighbours>().up)
                        {
                            currentTile = currentTile.GetComponent<Set_Neighbours>().up;
                            moving = true;
                        }
                        else if (hit.transform.gameObject == currentTile.GetComponent<Set_Neighbours>().down)
                        {
                            currentTile = currentTile.GetComponent<Set_Neighbours>().down;
                            moving = true;
                        }
                    }
                    
                }
            }
            
        }
        
        else if (mode == MovementSystem.arrows)
        {
            if (!moving)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().down != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().down;
                        moving = true;
                        gameObject.SendMessage("Rotate");
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().up != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().up;
                        moving = true;
                        gameObject.SendMessage("Rotate");
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().right != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().right;
                        moving = true;
                        gameObject.SendMessage("Rotate");
                        transform.localScale = rightScale;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().left != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().left;
                        moving = true;
                        gameObject.SendMessage("Rotate");
                        transform.localScale = leftScale;
                    }
                }
            }

        }

        Vector3 tempCurrentTile = new Vector3(currentTile.transform.position.x, currentTile.transform.position.y, -2f);

        if (moving)
        {
            
            if (Vector3.Distance(transform.position, tempCurrentTile) > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, tempCurrentTile, Time.deltaTime * speed);
            }
            else
            {
                moving = false;
            }
        }

        anim.SetBool("Moving", moving);

    }


    void SetNeighbour()
    {
        for (int i = 0; i < 4; i++)
        {

        }
    }
}
