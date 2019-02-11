using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Field : MonoBehaviour
{
    GameObject[] tiles;
    public GameObject tile;
    int index;
    int numMortars = 20;

    public GameObject mortar;
    GameObject mortarPos;

    public float timer;

    [Range(0, 50)]
    public int col, row;
    int numTiles;

    float textureSize;

    void Awake()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        CreateField();
        StartCoroutine(MortarTimer());
        print("Number of Tile Created: " + numTiles);
    }

    void CreateField()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Vector3 position = new Vector3((-(col*textureSize / 2f)) + (textureSize*i) + (textureSize/2), (-(row*textureSize / 2f)) + (textureSize*j) + (textureSize/2), 0);
                
                GameObject newTile = Instantiate(tile, transform.TransformPoint(position), Quaternion.identity, transform);
                newTile.transform.parent = tile.transform;
                numTiles++;
            }
        }
    }

    void MortarStrike()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");

        for (int i = 0; i < numMortars; i++)
        {
            index = Random.Range(0, tiles.Length);
            mortarPos = tiles[index];
            //print(mortar.name);
            GameObject newMortar = Instantiate(mortar, mortarPos.transform.position, Quaternion.identity, transform);
            //numMortars++;
        }
    }

    IEnumerator MortarTimer()
    {
        while (enabled)
        {
            MortarStrike();
            yield return new WaitForSeconds(timer);
            
        }
    }
}
