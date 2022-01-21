using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteMenu : MonoBehaviour
{
    public void NextLevel ()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
