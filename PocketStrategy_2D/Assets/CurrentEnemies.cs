using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemies : MonoBehaviour
{
    public List<GameObject> current = new List<GameObject>();

    void OnTriggerStay2D(Collider2D other)
    {
        if (!current.Contains(other.gameObject) && other.gameObject.tag == "Enemy") {
            current.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (current.Contains(other.gameObject) && other.gameObject.tag == "Enemy")
        {
            current.Remove(other.gameObject);
        }
    }

    public GameObject[] currentEnemiesCheck {
        get {
            return current.ToArray();
        }
    }
}
