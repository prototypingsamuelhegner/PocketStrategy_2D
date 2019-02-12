﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    public GameObject tile;

    public GameObject mortar;

    float textureSize;

    int damage;

    public float timer;

    private void Start()
    {
        
    }

    void Awake()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timer);

            Destroy(this.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        coll.gameObject.GetComponent<Health_Script>().RemoveHealth(damage);
    }
}
