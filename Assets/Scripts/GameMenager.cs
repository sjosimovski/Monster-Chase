using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{

    public static GameMenager instance; // object in the class

    [SerializeField]
    private GameObject[] players;

    public Player player;

    // public GameOverScreen gameOverScreen;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // do not destroy game object when load new scene
        }
        else
        {
            Destroy(gameObject); // dellete duplicate object
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // player = FindObjectOfType<Player>();
        // isDead();
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;

    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name =="Gameplay")
        {
            Instantiate(players[CharIndex]);
            
        }
    }

    //private void isDead()
    //{
        
    //        if (player.isDead)
    //        {
    //            gameOverScreen.showPopUp();
    //        }
        
    //}

}// class
