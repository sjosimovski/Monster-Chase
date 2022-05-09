using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{

    public bool shootTrue;       


    public void RestartGame() // function for restart
    {

        SceneManager.LoadScene("Gameplay");

    }

    public void HomeButton() // function for home screen
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void ShootButton() // function for shooting button
    {
        shootTrue = true;

    }

}
