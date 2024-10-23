using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Bhehaviour : MonoBehaviour
{
    [SerializeField] private bool TimePaused;
    [SerializeField] private int level;

    public void levelSeclect()
    {

        if(level == 1)
        {
            SceneManager.LoadScene(1);
        }

        else if(level == 2)
        {
            SceneManager.LoadScene(2);
        }

        else if(level == 3)
        {
            SceneManager.LoadScene(3);
        }

        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void TimeManagement()
    {
        if (TimePaused)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }  
}
