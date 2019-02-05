using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Movement : MonoBehaviour
{
    Ray ray;

    public enum MovementSystem {
        click,
        arrows,
        ui
    }

    public MovementSystem mode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == MovementSystem.click) {
            if (Input.GetMouseButtonDown(0)) {

            }
        }
    }


    void SetNeighbour() {
        for (int i = 0; i < 4; i++) {
            
        }
    }
}
