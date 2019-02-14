using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    public GameObject tile;

    public GameObject mortar;

    Renderer material;

    float textureSize;

    int damage = 1;

    public float timer;

    float boomTimer = 1f;

    private void Start()
    {
       
    }

    void Awake()
    {
        //color = gameObject.GetComponent<Renderer>().material.color;
        material = gameObject.GetComponent<Renderer>();

        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(boomTimer);

            //Debug.Log("Ready");

            yield return new WaitForSeconds(timer);
            gameObject.GetComponent<Explosion_Script>().Explode();
            //Camera.main.GetComponent<CameraControl>().Shake(1.5f, 5, 1.5f);
            Destroy(this.gameObject);
            
        }
    }
}
