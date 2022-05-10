using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Player player;
    public Laser laser;
    public Collector collector;
    public GameObject GameOverPopUp;
    public GameObject laserAnimation;
    public GameplayUIController gameplayUIController;

    public GameObject ShootingTimer;
    public GameObject ShootingButton;
        
    

    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiSeconds;

    public int Duration;

    private int remainingDuration;

    private Vector3 laserVector;





    // Start is called before the first frame update
    void Start()
    {
        

        laser = FindObjectOfType<Laser>();

        player = FindObjectOfType<Player>();

        collector = FindObjectOfType<Collector>();

        gameplayUIController = FindObjectOfType<GameplayUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        // laserAnimation = GameObject.Find("laser-a-3");


        if (player.isDead || collector.isHitOnEnd)
        {
           // Debug.Log("Dead");

            GameOverPopUp.SetActive(true);

        }


        //if (gameplayUIController.shootTrue)
        //{
        //    LaserAnimation.SetActive(true);
        //}

    }

    public void shoot()
    {

        laserAnimation = laser.LaserObject;

        laserAnimation.SetActive(true);

        ShootingButton.SetActive(false);

        Invoke("DisableLaser", 4);

        ShootingTimer.SetActive(true);
        Begin(Duration);


    }

        void DisableLaser()
    {
        laserAnimation.SetActive(false);
    }


    public void Begin(int Second) // start timer
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }


    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiSeconds.text = $"{remainingDuration}";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }


    private void OnEnd()
    {
        if (player.isDead == false)
        {
            
            ShootingTimer.SetActive(false);
            ShootingButton.SetActive(true);

        }

    }
}
