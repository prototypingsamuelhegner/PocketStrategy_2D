using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public bool activeWave;

    public bool downTime;

    public int breakTimer;

    int bombDecider;

    int currentWave = 0;

    public static int EnemiesLeft;

    public List<GameObject> activeEnemies;

    Object_Pool pool;

    Vector3 firstPoint;

    public Wave[] waves;



    void Start()
    {
        firstPoint = GameObject.FindObjectOfType<Path_Creation>().path[0].transform.position;
        pool = Object_Pool.Instance;
        SetUpWave();
        StartCoroutine(SpawnWave());
        
    }

    void SetUpWave() {
        EnemiesLeft = waves[currentWave].NumberOfNormal;
        if (waves[currentWave].bombEveryNormal > 0) {
            int bombers = waves[currentWave].NumberOfNormal / waves[currentWave].bombEveryNormal;
            EnemiesLeft += bombers;
        }
        

        bombDecider = waves[currentWave].bombEveryNormal;
    }


    IEnumerator SpawnWave() {
        while (true) {

            float timeBetweenSpawn = waves[currentWave].spawnRate;

            if (activeWave) {

                GameObject newEnemy;
                if (waves[currentWave].bombEveryNormal != 0)
                {
                    if (bombDecider == 0)
                    {
                        newEnemy = pool.SpawnFromPool("Bomb", firstPoint, Quaternion.identity);
                        bombDecider = waves[currentWave].bombEveryNormal;
                    }
                    else
                    {
                        newEnemy = pool.SpawnFromPool("Normal", firstPoint, Quaternion.identity);
                        bombDecider--;
                    }
                }
                else {
                    newEnemy = pool.SpawnFromPool("Normal", firstPoint, Quaternion.identity);
                }
                

                
                activeEnemies.Add(newEnemy);
                EnemiesLeft--;
            }

            if (EnemiesLeft == 0) {
                activeWave = false;
                if (currentWave < waves.Length - 1) {
                    print("reset");

                    currentWave++;
                }
                
                SetUpWave();
            }

            yield return new WaitForSeconds(timeBetweenSpawn);
            

        }
    }

    

}

[System.Serializable]
public class Wave
{
    public int NumberOfNormal;

    [Range(0, 20)]
    public int bombEveryNormal;
    public float spawnRate;
}


