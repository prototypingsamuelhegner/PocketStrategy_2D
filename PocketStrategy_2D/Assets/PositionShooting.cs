using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionShooting : MonoBehaviour
{
    GameObject shootTile1, shootTile2;

    Tower_Movement movement;

    bool horizontal;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Tower_Movement>();
        Invoke("Rotate", Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate() {
        horizontal = !horizontal;

        if (horizontal)
        {
            if (movement.currentTile.GetComponent<Set_Neighbours>().right != null)
            {
                shootTile1 = movement.currentTile.GetComponent<Set_Neighbours>().right;
            }
            else
            {
                shootTile1 = null;
            }


            if (movement.currentTile.GetComponent<Set_Neighbours>().left != null)
            {
                shootTile2 = movement.currentTile.GetComponent<Set_Neighbours>().left;
            }
            else
            {
                shootTile2 = null;
            }
        }
        else {
            if (movement.currentTile.GetComponent<Set_Neighbours>().up != null)
            {
                shootTile1 = movement.currentTile.GetComponent<Set_Neighbours>().up;
            }
            else {
                shootTile1 = null;
            }


            if (movement.currentTile.GetComponent<Set_Neighbours>().down != null)
            {
                shootTile2 = movement.currentTile.GetComponent<Set_Neighbours>().down;
            }
            else {
                shootTile2 = null;
            }
            
        }
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying) {
            Gizmos.color = Color.red;
            if(shootTile1 != null)Gizmos.DrawSphere(shootTile1.transform.position, 0.5f);
            if(shootTile2 != null)Gizmos.DrawSphere(shootTile2.transform.position, 0.5f);
        }

    }
}
