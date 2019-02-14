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
        Time.timeScale = 0;

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
