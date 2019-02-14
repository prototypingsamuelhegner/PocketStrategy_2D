using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    public GameObject tile;

    public GameObject mortar;

    public Sprite[] sprites;

    SpriteRenderer sprite;

    float textureSize;

    int damage = 1;

    public float timer;

    float boomTimer = 2f;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Awake()
    {
        //sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        StartCoroutine(ExplosionTime());
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            //sprite = sprites[1];
            yield return new WaitForSeconds(boomTimer);
            sprite.sprite = sprites[1];

            yield return new WaitForSeconds(timer);
            gameObject.GetComponent<Explosion_Script>().Explode();
            sprite.sprite = sprites[2];
            yield return new WaitForSeconds(boomTimer);
            Destroy(this.gameObject);
            
        }
    }
}
