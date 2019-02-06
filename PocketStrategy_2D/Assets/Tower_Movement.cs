﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Movement : MonoBehaviour
{
    Ray ray;

    public GameObject currentTile;

    public bool moving;

    [Range(0, 20)]
    public int speed = 1;

    public enum MovementSystem
    {
        click,
        arrows,
        ui
    }

    public MovementSystem mode;

    // Start is called before the first frame update
    void Start()
    {
        Set_Neighbours[] tiles = FindObjectsOfType<Set_Neighbours>();

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

        transform.position = currentTile.transform.position;
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
        else if (mode == MovementSystem.ui)
        {

        }
        else if (mode == MovementSystem.arrows)
        {
            if (!moving)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().down != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().down;
                        moving = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().up != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().up;
                        moving = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().right != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().right;
                        moving = true;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (currentTile.GetComponent<Set_Neighbours>().left != null)
                    {
                        currentTile = currentTile.GetComponent<Set_Neighbours>().left;
                        moving = true;
                    }
                }
            }

        }


        if (moving)
        {
            if (Vector3.Distance(transform.position, currentTile.transform.position) > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTile.transform.position, Time.deltaTime * speed);
            }
            else
            {
                moving = false;
            }
        }
    }


    void SetNeighbour()
    {
        for (int i = 0; i < 4; i++)
        {

        }
    }
}