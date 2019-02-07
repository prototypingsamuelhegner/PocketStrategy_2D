using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Path : MonoBehaviour
{
    LineRenderer line;

    Path_Creation pathRef;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        pathRef = GetComponent<Path_Creation>();
        SetLinePoints();
    }

    void SetLinePoints() {

        line.positionCount = pathRef.path.Count;
        

        for (int i = 0; i < pathRef.path.Count; i++) {
            line.SetPosition(i, pathRef.path[i].transform.position);
        }
    }
}
