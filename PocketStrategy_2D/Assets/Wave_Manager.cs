using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public bool activeWave;

    public float timeBetweenSpawn;

    public float numberOfEnemies;

    public int bombEveryNormals;

    public List<GameObject> activeEnemies;

    Object_Pool pool;

    Vector3 firstPoint;



    void Start()
    {
        firstPoint = GameObject.FindObjectOfType<Path_Creation>().path[0].transform.position;
        pool = Object_Pool.Instance;
        StartCoroutine(SpawnWave());
    }


    IEnumerator SpawnWave() {
        while (true) {
            if (activeWave) {
                
                GameObject newEnemy = pool.SpawnFromPool("Normal", firstPoint, Quaternion.identity);
                activeEnemies.Add(newEnemy);
            }
            

            
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
