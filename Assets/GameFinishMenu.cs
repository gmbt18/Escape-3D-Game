using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishMenu : MonoBehaviour
{
    public void NewGame ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
