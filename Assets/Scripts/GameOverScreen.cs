using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    
 


    public void RerstartButton()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
