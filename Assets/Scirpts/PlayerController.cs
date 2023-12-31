using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // To Manage Scenes

public class PlayerController : MonoBehaviour
{

    public float speed; // speed for moving the ball - in Inspector it's 15

    Rigidbody rb;

    float xInput;
    float yInput;

    int score = 0; // our score for collection coins

    public int winScore; // set max score equal to our coins

    public GameObject winText; // will store our Win Text and appear it
    

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if ball fals down reload Game scene
        if (transform.position.y < -5f) 
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void FixedUpdate() 
    {
        // Assign Direction movement to left/right and back/forward
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        // Apply a force to this Rigidbody in direction of this GameObject to left/right and back/forward
        rb.AddForce(xInput * speed, 0, yInput * speed); //
    }

    private void OnTriggerEnter(Collider other) 
    {
        // When we collide to the Coin it will disappear
        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);

            score++; // increment score

            if (score >= winScore)
            {
                // gamewwin
                winText.SetActive(true);
            }
        }
    }
}
