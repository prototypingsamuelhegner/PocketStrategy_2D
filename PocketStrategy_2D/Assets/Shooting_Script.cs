using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{

    Wave_Manager waveManager;

    GameObject target;

    public GameObject bullet;

    public List<GameObject> possibleEnemies;

    bool shooting;

    public int shotsPerSecond;

    Object_Pool pool;


    void Start()
    {
        waveManager = GameObject.FindObjectOfType<Wave_Manager>();
        shooting = false;
        StartCoroutine(Shoot());
        pool = Object_Pool.Instance;
    }

    void Update()
    {
        if (possibleEnemies.Count > 0)
        {
            shooting = true;
        }
        else {
            shooting = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!possibleEnemies.Contains(other.transform.gameObject) && other.transform.tag == "Enemy") {
            possibleEnemies.Add(other.transform.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        possibleEnemies.Remove(other.transform.gameObject);
    }

    IEnumerator Shoot() {
        while (true) {
            if (shooting) {
                GameObject objToShoot;
                int lowestIndex = int.MaxValue;

                for (int i = 0; i < possibleEnemies.Count; i++) {
                    int currentIndex = waveManager.activeEnemies.IndexOf(possibleEnemies[i]);
                    if (currentIndex < lowestIndex) {
                        lowestIndex = currentIndex;
                    }
                }

                objToShoot = waveManager.activeEnemies[lowestIndex];
                GameObject bul = pool.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
                
                bul.GetComponent<Bullet_Script>().SetTarget(objToShoot);
            }
            yield return new WaitForSeconds(1f / (float)shotsPerSecond);
        }
    }
}
