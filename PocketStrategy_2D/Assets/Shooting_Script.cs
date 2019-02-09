using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Script : MonoBehaviour
{

    Wave_Manager waveManager;
    GameObject target;

    public List<GameObject> possibleEnemies;

    // Start is called before the first frame update
    void Start()
    {
        waveManager = GameObject.FindObjectOfType<Wave_Manager>();
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
}
