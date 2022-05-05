using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    private Transform Player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {

         Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void LateUpdate()
    {
        if (!Player) // if its null dont execute the code under. (if player exists)
            return;

        tempPos = transform.position;
        tempPos.x = Player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;

    }



}//class
