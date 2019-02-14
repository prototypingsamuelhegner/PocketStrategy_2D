using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionShooting : MonoBehaviour
{
    GameObject shootTile1, shootTile2;
    public GameObject crosshair1, crosshair2;

    Tower_Movement movement;

    bool horizontal;

    public float shotsPerSeconds;

    Object_Pool pool;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Tower_Movement>();
        Invoke("Rotate", Time.deltaTime);
        Invoke("StartShooting", Time.deltaTime);
        pool = Object_Pool.Instance;
    }



    public void Rotate()
    {
        horizontal = !horizontal;

        if (horizontal)
        {
            if (movement.currentTile.GetComponent<Set_Neighbours>().right != null)
            {
                shootTile1 = movement.currentTile.GetComponent<Set_Neighbours>().right;
                
                crosshair1.transform.position = shootTile1.transform.position;
                crosshair1.SetActive(true);
            }
            else
            {
                crosshair1.SetActive(false);
                shootTile1 = null;
            }


            if (movement.currentTile.GetComponent<Set_Neighbours>().left != null)
            {
                shootTile2 = movement.currentTile.GetComponent<Set_Neighbours>().left;

                crosshair2.transform.position = shootTile2.transform.position;
                crosshair2.SetActive(true);
            }
            else
            {
                crosshair2.SetActive(false);
                shootTile2 = null;
            }
        }
        else
        {
            if (movement.currentTile.GetComponent<Set_Neighbours>().up != null)
            {
                shootTile1 = movement.currentTile.GetComponent<Set_Neighbours>().up;

                crosshair1.transform.position = shootTile1.transform.position;
                crosshair1.SetActive(true);
            }
            else
            {
                crosshair1.SetActive(false);
                shootTile1 = null;
            }


            if (movement.currentTile.GetComponent<Set_Neighbours>().down != null)
            {
                shootTile2 = movement.currentTile.GetComponent<Set_Neighbours>().down;

                crosshair2.transform.position = shootTile2.transform.position;
                crosshair2.SetActive(true);
            }
            else
            {
                crosshair2.SetActive(false);
                shootTile2 = null;
            }

        }
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            if (shootTile1 != null) Gizmos.DrawSphere(shootTile1.transform.position, 0.5f);
            if (shootTile2 != null) Gizmos.DrawSphere(shootTile2.transform.position, 0.5f);
        }

    }

    void StartShooting()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            List<GameObject> thingsToShoot = new List<GameObject>();

            if (shootTile1 != null)
            {
                foreach (GameObject enemy in shootTile1.GetComponent<CurrentEnemies>().currentEnemiesCheck)
                {
                    thingsToShoot.Add(enemy);
                }
            }

            if (shootTile2 != null)
            {
                foreach (GameObject enemy in shootTile2.GetComponent<CurrentEnemies>().currentEnemiesCheck)
                {
                    thingsToShoot.Add(enemy);
                }
            }

            foreach (GameObject obj in thingsToShoot)
            {
                obj.GetComponent<Health_Script>().RemoveHealth(1);
            }

            if (shootTile1 != null)
            {
                GameObject bul1 = pool.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
                bul1.GetComponent<Bullet_Script>().SetTarget(shootTile1);
            }
            if (shootTile2 != null)
            {
                GameObject bul2 = pool.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
                bul2.GetComponent<Bullet_Script>().SetTarget(shootTile2);
            }



            yield return new WaitForSeconds(1f / shotsPerSeconds);
        }
    }
}
