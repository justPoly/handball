using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Passing : MonoBehaviour
{
    public Passing[] allOtherPlayers;
    private Ball ball;
    private float passForce = 1800f;
    public Joystick joystick;
    private Animator anim;
    public bool shoot = false;
    public Text scoreText;
    public Text highScoreText;
    int score = 0;
    int highScore = 0;
   // public Kicking kicking;
    //public Animator animator;
    
    public bool isKicking = false;

    public GameObject playerIndicator;

    public AudioClip passSound;
    private AudioSource passAudio;

    public bool IsPressed;
   //public  GameManager gameManager;
    
    //Player Movement
    private Rigidbody playerRb;
    public float speed = 400.0f;
    public float horizontalMove, verticalMove;

    public Vector3 startPosition;

    //hashes for animation
    int KickHash = Animator.StringToHash("kick");
    int notKickHash = Animator.StringToHash("isntKicking");
    private void Awake()
    {
        allOtherPlayers = FindObjectsOfType<Passing>().Where(t => t != this).ToArray();
        ball = FindObjectOfType<Ball>();
        shoot = false;
        startPosition = transform.position;
    }
    public void PointerDown()
    {
        shoot = true;

        IsPressed = true;
    

    }
    public void PointerUp()
    {
        IsPressed = false;
        shoot = false;
      

    }

    public void Start()
    {
        passAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        //kicking = GetComponent<Kicking>();
        playerRb = GetComponent<Rigidbody>();

    
        highScore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "High Score : " + highScore.ToString();
    }


    private void Update()
    {
        //Mobile
        if (IHaveBall())
        {
            //PC Up/ Down movement
            float forwardInput = Input.GetAxis("Vertical");
            playerRb.AddForce(Vector3.forward * speed * forwardInput);

            //PC Left/ right movement
            float horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.right * speed * horizontalInput);


            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            
            Debug.DrawRay(transform.position, direction * 40f, Color.blue);
            

            var targetPlayer = FindPlayerInDirection(direction);
            UpdateRenderers(targetPlayer);

            if (targetPlayer != null)
            {
                playerIndicator.gameObject.SetActive(true);
                playerIndicator.transform.position = targetPlayer.transform.position;
                if (shoot == true )
                {
                     anim.SetTrigger(KickHash);
                    PassBallToPlayer(targetPlayer);
                    anim.SetBool(notKickHash, false);

                    //if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)

                    //anim.SetBool("isKicking", true);
                    // kicking.animator.SetBool("isKicking", true);
                    //kicking.isKicking = true;


                }
                else if(shoot !=true)
                {
                    anim.SetBool(notKickHash, true);
                }
            }
        }
        if (!IHaveBall()) {
            transform.position = startPosition;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(horizontalMove, playerRb.velocity.y, verticalMove);  
        
    }

    private void PassBallToPlayer(Passing targetPlayer)
    {
        passAudio.PlayOneShot(passSound, 1.0f);
        var direction = DirectionTo(targetPlayer);
        ball.transform.SetParent(null);
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().AddForce(direction * passForce);

        score++;
        scoreText.text = score.ToString() + " Points";
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    private void UpdateRenderers(Passing targetPlayer)
    {
        targetPlayer.GetComponent<Renderer>().material.color = Color.red;
        foreach (var other in allOtherPlayers.Where(t => t != targetPlayer))
        {
            other.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private Vector3 DirectionTo(Passing player)
    {
        return Vector3.Normalize(player.transform.position - ball.transform.position);
    }

    private Passing FindPlayerInDirection(Vector3 direction)
    {
        
        var closestAngle = allOtherPlayers
            .OrderBy(t => Vector3.Angle(direction, DirectionTo(t)))
            .FirstOrDefault();


        return closestAngle;
    }

    public bool IHaveBall()
    {

    
        return transform.childCount > 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.SetParent(transform);
           
        }
    }
 
}
