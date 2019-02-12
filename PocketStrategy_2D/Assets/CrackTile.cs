using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackTile : MonoBehaviour
{
    SpriteRenderer rend;

    public Sprite[] possibleCracks;


    float spriteAlpha;

    void Update()
    {
        if (spriteAlpha > 0)
        {
            spriteAlpha *= (1.0f - (0.01f * Time.deltaTime));
        }
        else if (spriteAlpha < 0) {
            spriteAlpha = 0;
        }
    }

    public void StartFade() {
        int ran = Random.Range(0, possibleCracks.Length);

        rend.sprite = possibleCracks[ran];
        spriteAlpha = 1;
    }
}
