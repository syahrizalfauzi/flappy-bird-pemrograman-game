using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
