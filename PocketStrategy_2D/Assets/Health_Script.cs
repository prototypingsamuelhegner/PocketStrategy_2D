using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Script : MonoBehaviour
{
    public int startHealth;

    int health;

    public bool destroyOnDeath, animationOnDeath, explodeOnDeath;

    Animator anim;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Death() {
        if (explodeOnDeath) {
            
        }
        if (animationOnDeath) {

        }
        if (destroyOnDeath) {

        }
        yield return null;
    }

}
