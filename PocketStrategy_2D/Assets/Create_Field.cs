using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Field : MonoBehaviour
{

    public GameObject tile;
    [Range(0, 50)]
    public int col, row;
    int numTiles;

    float textureSize;

    void Awake()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        CreateField();
        print(numTiles);
    }

    void CreateField() {
        for (int i = 0; i < col; i++) {
            for (int j = 0; j < row; j++) {
                Vector3 position = new Vector3((-(col*textureSize / 2f)) + (textureSize*i) + (textureSize/2), (-(row*textureSize / 2f)) + (textureSize*j) + (textureSize/2), 0);
                
                GameObject newTile = Instantiate(tile, transform.TransformPoint(position), Quaternion.identity, transform);
                numTiles++;
            }
        }
    }
}
