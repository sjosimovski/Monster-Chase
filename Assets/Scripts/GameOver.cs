using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Player player;
    public Collector collector;
    public GameObject GameOverPopUp;




    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();

        collector = FindObjectOfType<Collector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead || collector.isHitOnEnd)
        {
            Debug.Log("Dead");

            GameOverPopUp.SetActive(true);

        }
    }
}
