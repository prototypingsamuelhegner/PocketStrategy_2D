using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    public GameObject tile;

    public GameObject mortar;

    Color color;

    float textureSize;

    int damage = 1;

    public float timer;

    private void Start()
    {
        
    }

    void Awake()
    {
        //color = gameObject.GetComponent<Renderer>().material.color;
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timer);
           
            gameObject.GetComponent<Explosion_Script>().Explode();
            Destroy(this.gameObject);
            
        }
    }
}
