using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Field : MonoBehaviour
{
    GameObject[] tiles;
    GameObject[] mortars;
    public GameObject tile;
    public int numMortars;
    int index;

    public GameObject mortar;
    GameObject mortarPos;

    public float timer = 0.5f;

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
                newTile.transform.parent = transform;
                numTiles++;
            }
        }
    }

    void MortarStrike()
    {

        for (int i = 0; i < numMortars; i++)
        {
            tiles = GameObject.FindGameObjectsWithTag("Tile");
            index = Random.Range(0, tiles.Length);
            mortarPos = tiles[index];

            while(mortarPos.tag == "Mortar")
            {
                index = Random.Range(0, tiles.Length);
                mortarPos = tiles[index];
            }
            //print(mortar.name);
            mortarPos.tag = "Mortar";
            GameObject newMortar = Instantiate(mortar, mortarPos.transform.position, Quaternion.identity, transform);
        }

    }

    IEnumerator MortarTimer()
    {
        while (enabled)
        {
            mortars = GameObject.FindGameObjectsWithTag("Mortar");
            MortarStrike();

            yield return new WaitForSeconds(timer);

            foreach( GameObject m in mortars)
            {
                m.tag = "Tile";
            }
        }
    }
}
