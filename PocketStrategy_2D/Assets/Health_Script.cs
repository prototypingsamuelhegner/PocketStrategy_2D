using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health_Script : MonoBehaviour
{
    public GameObject screen;

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
        DeathScene();
        //Restart();
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

    void DeathScene()
    {
        if (health <= 0)
        {
            if (gameObject.tag == "Player")
            
                screen.SetActive(true);
            
        }
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
        if(gameObject.tag == "Player")
        healthCount.text = "Health: " + health;
    }
}
