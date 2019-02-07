using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_Manager : MonoBehaviour
{
    public bool activeWave;

    public float timeBetweenSpawn;

    

    IEnumerator SpawnWave() {
        while (activeWave) {


            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
