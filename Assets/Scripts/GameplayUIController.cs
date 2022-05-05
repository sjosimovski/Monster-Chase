using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void RestartGame() // function for restart
    {

        SceneManager.LoadScene("Gameplay");

    }

    public void HomeButton() // function for home screen
    {
        SceneManager.LoadScene("MainMenu");

    }

}
