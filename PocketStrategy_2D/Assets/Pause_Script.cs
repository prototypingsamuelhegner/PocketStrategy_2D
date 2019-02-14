using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour
{
    public GameObject pausePanel;

    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            /*if(!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }

            if(pausePanel.activeInHierarchy)
            {
                UnpauseGame();
            }*/

            PauseGame();
            paused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            UnpauseGame();
            paused = false;
        }


    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
