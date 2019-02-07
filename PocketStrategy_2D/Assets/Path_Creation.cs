﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
public class Path_Creation : MonoBehaviour
{
    public List<GameObject> path = new List<GameObject>();


    void Awake()
    {
        if (path.Count != transform.childCount)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                path.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 1; i < path.Count; i++) {
            Gizmos.DrawLine(path[i].transform.position, path[i - 1].transform.position);
        }
    }
}
