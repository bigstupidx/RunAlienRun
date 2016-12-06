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
    //private Collider2D myCollider;

    public bool grounded;
    public LayerMask whatIsGrounded;
    public Transform groundCheck;

    private bool beeHurtTime = false; 

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
       //myCollider = GetComponent<Collider2D>();

        jumpTimerCounter = jumpTime;

      //  startTime = Time.time;

        speedMilestoneCount = speedIncreaseMilestone;

        //theScoreManager = FindObjectOfType<ScoreManager>();

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPaused)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

        if (alienHurtTime == -1)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);

            if (transform.position.x > speedMilestoneCount)

            {
                speedMilestoneCount += speedIncreaseMilestone;

               speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplayer;
               moveSpeed = moveSpeed * speedMultiplayer;
            }

            myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);

            if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1") && jumpsLeft > 0)
            {
                if (myRigidBody.velocity.y < 0)
                {
                    myRigidBody.velocity = Vector2.zero;
                }

                if (jumpsLeft == 1)
                {
                    myRigidBody.AddForce(transform.up * alineJumpForce * 0.75f);
                }
                else
                {
                    myRigidBody.AddForce(transform.up * alineJumpForce);
                }

                if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
                {
                    if (jumpTimerCounter > 0)
                    {
                        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x , alineJumpForce);
                        jumpTimerCounter -= Time.deltaTime;
                    }
                }

                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonUp(0))
                {
                    jumpTimerCounter = 0;
                }

                if(grounded)
                {
                    jumpTimerCounter = jumpTime;
                }

                /*if(transform.position.y < -1)
                {
                    if (!beeHurtTime)
                        GameManagaer.Instance.LoseLP();
                }*/

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

        //  alienHurtTime = Time.time;
        //  myAnim.SetBool("alienHurt", true);
        // myRigidBody.velocity = Vector2.zero;
        // myRigidBody.AddForce(transform.up * alineJumpForce);
        //myCollider.enabled = false;

    }
        }
     

    

