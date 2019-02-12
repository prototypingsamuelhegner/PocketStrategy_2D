using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    public GameObject tile;
    GameObject[] mortars;

    public GameObject mortar;

    float textureSize;
    public float timer;

    void Awake()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        //MortarRadius();
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timer);
            //mortars = GameObject.FindGameObjectsWithTag("Mortars");
            //mortars[].tag = "Tile";
            Destroy(this.gameObject);
        }
    }
}
