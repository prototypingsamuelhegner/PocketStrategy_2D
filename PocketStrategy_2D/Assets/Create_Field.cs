using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Field : MonoBehaviour
{

    public GameObject tile;

    public int col, row;

    float textureSize;

    // Start is called before the first frame update
    void Start()
    {
        textureSize = tile.GetComponent<Renderer>().bounds.size.x;
        CreateField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateField() {
        for (int i = 0; i < col; i++) {
            for (int j = 0; j < row; j++) {
                Vector3 position = new Vector3((-(col*textureSize / 2f)) + (textureSize*i) + (textureSize/2), (-(row*textureSize / 2f)) + (textureSize*j) + (textureSize/2), 0);
                
                Instantiate(tile, transform.TransformPoint(position), Quaternion.identity, transform);
            }
        }
    }
}
