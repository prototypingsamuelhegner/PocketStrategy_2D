using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_Strike : MonoBehaviour
{

    GameObject[] tiles;
    public GameObject tile;
    int index;

    public GameObject mortar;

    [Range(0, 3)]
    public int col, row;

    int numMortars = 6;
    float textureSize;
    public float timer;

    void Awake()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        //MortarRadius();
        StartCoroutine(ExplosionTime());
        print("Number of Tile Created: " + numMortars);
    }

    void MortarRadius()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Vector3 position = new Vector3((-(col * textureSize / 2f)) + (textureSize * i) + (textureSize / 2), (-(row * textureSize / 2f)) + (textureSize * j) + (textureSize / 2), 0);

                GameObject newTile = Instantiate(mortar, transform.TransformPoint(position), Quaternion.identity, transform);

                numMortars++;
            }
        }
    }

    IEnumerator ExplosionTime()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(timer);
            Destroy(this.gameObject);
        }
    }
}
