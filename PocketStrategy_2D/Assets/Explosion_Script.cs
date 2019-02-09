using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{

    GameObject player;

    float explosionRadius;
    int explosionDamage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Explode() {

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);

        float distanceToPlayer = Vector2.Distance(playerPos, thisPos);

        if (distanceToPlayer < explosionRadius) {
            player.GetComponent<Health_Script>().RemoveHealth(explosionDamage);
        }
    }
}
