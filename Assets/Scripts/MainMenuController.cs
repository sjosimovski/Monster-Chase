using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

   

    public void PlayGame() // function for onClick
    {
        // Debug.Log("Button is pressed");

        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); // get name of the button selected.

        GameMenager.instance.CharIndex = selectedCharacter;

        SceneManager.LoadScene("Gameplay");

    }






}// class
