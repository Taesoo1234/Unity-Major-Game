using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // the character controller component
    public CharacterController controller;

    // the float for speed of the player
    public float speed = 6f;

    // the bool to check if the player has a powerup
    public bool hasPowerup = false;

    // a gameobject to show that the player had a powerup
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // the floats for the input of the vertical and horizontal axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // the direction is the vector3 of the horizontal and vertical input
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // if the magnitude of direction is greater than .1
        if (direction.magnitude >= 0.1f)
        {
            // calculate how much the player should rotate by the x and y axis
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // rotate the player by the float calculated above
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // move the player in the direction
            controller.Move(direction * speed * Time.deltaTime);
        }

        // trick the game into thinking the player is constantly moving
        // to prevent a bug
        controller.Move(direction * 0 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Powerup"))
        {
            // makes the hasPowerup bool true
            hasPowerup = true;

            // destroys the powerup gameObject
            Destroy(other.gameObject);

            // set the speed with 6
            speed = 6f;

            // spawns the powerup indicator
            powerupIndicator.gameObject.SetActive(true);

            // starts the coroutine to countdown the duration of the powerup
            StartCoroutine(PowerupCountdownRoutine());
        }


        IEnumerator PowerupCountdownRoutine()
        {
            // wait 8 seconds
            yield return new WaitForSeconds(8);

            // set the speed to 4
            speed = 4f;

            // make the hasPowerup bool false
            hasPowerup = false;

            // removes the powerup indicator
            powerupIndicator.gameObject.SetActive(false);

        }
    }
}

