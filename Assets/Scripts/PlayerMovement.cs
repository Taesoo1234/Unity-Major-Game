using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public bool hasPowerup = false;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }

        controller.Move(direction * 0 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // makes the hasPowerup bool true
        // destroys the powerup gameObject
        // spawns the powerup indicator
        // starts the coroutine to countdown the duration of the powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            speed = 6f;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }


        IEnumerator PowerupCountdownRoutine()
        {
            // wait 5 seconds
            yield return new WaitForSeconds(8);

            speed = 4f;

            // make the hasPowerup bool false
            hasPowerup = false;

            // removes the powerup indicator
            powerupIndicator.gameObject.SetActive(false);

        }
    }
}

