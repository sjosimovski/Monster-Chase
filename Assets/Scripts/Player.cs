using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    public bool isDead = false;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool isGrounded = true;


    protected Joystick joystick;
    protected Joybutton joybutton;
    private float move;

    public Collector collector;

   // public GameObject gameOverScreen; // adding a game object for popup
   // private string popUpObjectName = "GameOverPopup"; // name of object

    
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();

        collector = FindObjectOfType<Collector>();


    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        jumpJoystick();
        moveJoystick();
        playerMoveKeyboard();
        animatePlayer();
        playerJump();


       

        
    }

    private void ForceUpdate()
    {
       
    }

    void playerMoveKeyboard()
    {

        movementX = Input.GetAxisRaw("Horizontal");

       // Debug.Log(movementX);

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;



      
    }

    void moveJoystick()
    {
        move = joystick.Horizontal; // get axis from joystick between -1 and 1 

       // Debug.Log(move);

        transform.position += new Vector3(joystick.Horizontal, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void jumpJoystick()
    {
        if (isGrounded && joybutton.Pressed)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void animatePlayer()
    {
        // going right
        if (movementX > 0 || move > 0)
        {
            sr.flipX = false;
            anim.SetBool(WALK_ANIMATION, true);
            
        }
        // going left
        else if (movementX < 0 || move < 0)
        {
            sr.flipX = true;
            anim.SetBool(WALK_ANIMATION, true);
           
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void playerJump() {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        } 
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            // Debug.Log("Landed");
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG) || collision.gameObject.CompareTag("Collector") )
        {
            isDead = true;

            // gameOverScreen.showPopUp();

             // gameOverScreen.SetActive(true);

            // gameObject.SetActive(false);
              Destroy(gameObject);
            
        }
    }

   



}// class
