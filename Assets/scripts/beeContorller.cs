using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class beeContorller : MonoBehaviour
{
    public static GameManagaer Instance { set; get; }
    public bool isPaused { get; private set; }

    private Rigidbody2D myRigidBody;
    private Animator myAnim;
    private Collider2D myCollider;

    public bool grounded;
    public LayerMask whatIsGrounded;
    public Transform groundCheck;

    private bool beeHurtTime = false;
    private bool stoppedJumping;
    private bool doubleJumped;

    private int jumpsLeft = 2;

    //audio thing
    public AudioSource jumpSfx;
    public AudioSource deathSfx;


    public float jumpTime;
    public float speedMultiplayer;
    public float speedIncreaseMilestone;
    public float alineJumpForce = 500f;
    public float groundCheckRadius;
    public float moveSpeed;

    private float jumpTimerCounter;
    private float startTime;
    private float moveSpeedStore;
    private float speedMilestoneCountStore;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float alienHurtTime = -1;

    public GameManagaer theGameManager;
    public ScoreManager theScoreManager;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        jumpTimerCounter = jumpTime;



        speedMilestoneCount = speedIncreaseMilestone;


        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
            return;


        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);

            if (transform.position.x > speedMilestoneCount)

            {
                speedMilestoneCount += speedIncreaseMilestone;

               speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplayer;
               moveSpeed = moveSpeed * speedMultiplayer;
            }

            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

            {


                if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    if (grounded)
                    {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x , alineJumpForce);
                        stoppedJumping = false;
                    }

                    if(!grounded && doubleJumped )
                    {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, alineJumpForce);
                        stoppedJumping = false;
                        doubleJumped = false;
                    }
                }

                if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping)
                {
                    if (jumpTimerCounter > 0)
                    {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, alineJumpForce);
                        jumpTimerCounter -= Time.deltaTime;
                    } 
                }

                if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
                {
                    jumpTimerCounter = 0;
                    stoppedJumping = true;
                }

                if(grounded)
                {
                    jumpTimerCounter = jumpTime;
                    doubleJumped = true;
                }

                jumpsLeft--;

                jumpSfx.Play();
            }
           myAnim.SetFloat("vVelocity", myRigidBody.velocity.y);

         }
}
    
    void OnCollisionEnter2D(Collision2D other)
    {
            
        if(other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestone;
            deathSfx.Play();

        }

    }
        }
     

    

