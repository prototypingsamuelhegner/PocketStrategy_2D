using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Screen : MonoBehaviour
{

   //public GameObject screen;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        DeathScreen();
    }

    public void DeathScreen()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
