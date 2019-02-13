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
        gameObject.GetComponent<Screen_Shake>();
       
    }

    public void Explode() {

        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 thisPos = new Vector2(transform.position.x, transform.position.y);

        float distanceToPlayer = Vector2.Distance(playerPos, thisPos);

        if (distanceToPlayer < explosionRadius) {
            //shake.gameObject.GetComponent<Screen_Shake>().TriggerShake();
            player.GetComponent<Health_Script>().RemoveHealth(explosionDamage);
            Debug.Log("Hit");
        }
    }
}
