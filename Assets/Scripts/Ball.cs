using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody rigidbody;
    private Vector3 velocity;
    private Renderer renderer;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();

        //Take 0.5 sec to launch ball 
        Invoke("BallLaunch", 0.5f);
    }

    private void BallLaunch()
    {
        //When create ball goes down
        rigidbody.velocity = Vector3.down * speed;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
        velocity = rigidbody.velocity;

        if (!renderer.isVisible)
        {
            //Decrease balls in game manager
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal); 
    }
}
