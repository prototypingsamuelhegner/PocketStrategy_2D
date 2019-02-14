using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{
    GameObject player;

    //public Camera shake;

    float explosionRadius = 1;
    int explosionDamage = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    public void Explode() {
        if (player != null) {
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);

            float distanceToPlayer = Vector2.Distance(playerPos, thisPos);

            if (distanceToPlayer < explosionRadius)
            {
                player.GetComponent<Health_Script>().RemoveHealth(explosionDamage);
                Camera.main.GetComponent<CameraControl>().Shake(.2f, 40, 10f);
                Debug.Log("Hit");
            }
        }
    }
}
