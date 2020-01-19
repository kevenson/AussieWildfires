using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class link2donate : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://www.wires.org.au/");
        Debug.Log("is this working?");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
