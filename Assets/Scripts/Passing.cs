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

    public GameObject playerIndicator;

    public bool IsPressed;
    Kicking kicking;

    private void Awake()
    {
        allOtherPlayers = FindObjectsOfType<Passing>().Where(t => t != this).ToArray();
        ball = FindObjectOfType<Ball>();
        shoot = false;
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
        anim = GetComponent<Animator>();
        kicking = GetComponent<Kicking>();
        highScore = PlayerPrefs.GetInt("highscore");
        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "High Score : " + highScore.ToString();
    }


    private void Update()
    {
        
        //Mobile
        if (IHaveBall())
        {
            float horizontal = joystick.Horizontal;
            float vertical = joystick.Vertical;

            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            
            Debug.DrawRay(transform.position, direction * 40f, Color.blue);
            

            var targetPlayer = FindPlayerInDirection(direction);
            UpdateRenderers(targetPlayer);

            if (targetPlayer != null)
            {
                if (shoot == true )
                {
                    
                    //if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
                    PassBallToPlayer(targetPlayer);
                    //kicking.animator.GetBool("isKicking");
                    
                }
            }
        }
    }

    private void PassBallToPlayer(Passing targetPlayer)
    {
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
        playerIndicator.gameObject.SetActive(true);
        playerIndicator.transform.position = transform.position + direction;
        var closestAngle = allOtherPlayers
            .OrderBy(t => Vector3.Angle(direction, DirectionTo(t)))
            .FirstOrDefault();
          
        return closestAngle;
    }

    public bool IHaveBall()
    {
        return transform.childCount > 0;
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
