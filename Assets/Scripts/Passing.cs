using System.Linq;
using UnityEngine;

public class Passing : MonoBehaviour
{
    private Passing[] allOtherPlayers;
    private Ball ball;
    private float passForce = 900f;

    private void Awake()
    {
        allOtherPlayers = FindObjectsOfType<Passing>().Where(t => t != this).ToArray();
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (IHaveBall())
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            var targetPlayer = FindPlayerInDirection(direction);
            UpdateRenderers(targetPlayer);

            if (targetPlayer != null)
            {
                if (Input.GetButton("Fire1"))
                    PassBallToPlayer(targetPlayer);
            }
        }
    }

    private void PassBallToPlayer(Passing targetPlayer)
    {
        var direction = DirectionTo(targetPlayer);
        ball.transform.SetParent(null);
        ball.GetComponent<Rigidbody>().isKinematic = false;
        ball.GetComponent<Rigidbody>().AddForce(direction * passForce);
    }

    private void UpdateRenderers(Passing targetPlayer)
    {
        targetPlayer.GetComponent<Renderer>().material.color = Color.green;
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

    private bool IHaveBall()
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
