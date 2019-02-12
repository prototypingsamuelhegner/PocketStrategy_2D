﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Script : MonoBehaviour
{
    public int startHealth;

    bool deathCalled;

    int health;

    public bool destroyOnDeath, animationOnDeath, explodeOnDeath;

    Animator anim;

    public Text healthCount;

    void Start()
    {
        health = startHealth;
        deathCalled = false;
    }

    void Update()
    {
        if (health <= 0 && !deathCalled)
        {
            StartCoroutine(Death());
            deathCalled = true;
        }

        SetHealthText();
    }

    IEnumerator Death()
    {
        if (explodeOnDeath)
        {
            gameObject.SendMessage("Explode");
        }
        if (animationOnDeath)
        {
            anim.SetTrigger("Death");
        }
        if (destroyOnDeath)
        {
            if (animationOnDeath)
            {
                yield return new WaitForEndOfFrame();
                float clipLength = anim.GetCurrentAnimatorStateInfo(0).length;
                yield return new WaitForSeconds(clipLength);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        yield return null;
    }

    public void RemoveHealth(int healthToLose)
    {
        health -= healthToLose;
    }

    public void AddHealth(int healthToAdd)
    {
        health += healthToAdd;
    }

    void SetHealthText()
    {
        healthCount.text = "Health: " + health.ToString();
    }
}
