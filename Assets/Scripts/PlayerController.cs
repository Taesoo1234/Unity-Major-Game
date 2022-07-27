using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // the rigidbody of the player that can be used for physics
    private Rigidbody playerRb;

    // the jumping variables, jumpForce controls how high the jump is and
    // the gravityModifier controls the falling speed
    public float jumpForce;
    public float gravityModifier;

    public float speed = 10;

    // a bool that is true/false depending on if the player is on the ground
    public bool isOnGround;

    public bool gameOver = false;

    public float horizontalInput;
    public float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        // creates a rigidbody component called playerRb
        playerRb = GetComponent<Rigidbody>();

        // the gravity is multiplied by the float 'gravity Modifier'
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // checks if the space key is pressed, and if the isOnGround bool is true and
        // if the player is not in a gameover state
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // if both conditions are satisfied, make the player jump by adding force vertically
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // make isOnGround false as jumping makes the player no longer touch the ground
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow));
        {
            transform.Translate(Vector3.left * speed * horizontalInput * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) ;
        {
            transform.Translate(Vector3.right * speed * horizontalInput);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) ;
        {
            transform.Translate(Vector3.back * speed * verticalInput * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) ;
        {
            transform.Translate(Vector3.forward * speed * verticalInput);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if the collision is with an object with tag 'ground',
        // make the isOnGround bool true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
