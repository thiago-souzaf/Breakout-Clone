using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    float throwForce = 10;
    [SerializeField] float speed;
    float maxSpeed = 15f;
    float acceleration = 0.1f;
    private Rigidbody ballRb;

    private Vector3 initialPosition = new(0, -2f);
    public bool isBallMoving;
    
    // Start is called before the first frame update
    void Start()
    { 
        ballRb = GetComponent<Rigidbody>();
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
        speed = ballRb.velocity.magnitude;
        
    }

    public void ThrowBall()
    {
        if (!isBallMoving)
        {
            isBallMoving = true;
            Vector3 randomDirection = new(Random.Range(-1f, 1f), 1, 0);
            randomDirection.Normalize();

            ballRb.AddForce(randomDirection * throwForce, ForceMode.VelocityChange);
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 velocity = ballRb.velocity;
        velocity.Normalize();

        speed = (speed < maxSpeed) ? (speed + acceleration) : maxSpeed;
        
        velocity *= speed;

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 newDirection = GetDirectionAwayFromPlayer(collision.gameObject);

            // Change velocity direction while maintaining speed;
            velocity = velocity.magnitude * newDirection;
        }

        ballRb.velocity = velocity;

    }

    private Vector3 GetDirectionAwayFromPlayer(GameObject player)
    {
        Vector3 playerPos = player.transform.position;
        Vector3 direction = this.transform.position - playerPos;
        direction.Normalize();

        return direction;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        isBallMoving = false;
        ballRb.velocity = Vector3.zero;

    }
}
