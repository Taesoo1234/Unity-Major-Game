using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // The float used to keep track of health of the enemies
    public float health = 1;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        // if health is smaller than 1
        if (health < 1)
        {
            // destroy the enemy gameobject
            Destroy(gameObject);
            
            // send messages to the parent gameobject "Increase Score" and "Death
            gameObject.SendMessageUpwards("IncreaseScore");
            gameObject.SendMessageUpwards("Death");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // on collision with an object with the tag "Reflector" (player's sword)
        if (collision.gameObject.CompareTag("Reflector"))
        {
            // decrease health by 1
            health = -1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // on trigger with a collider with the tag reflected projectile
        if (other.CompareTag("ReflectedProjectile"))
        {
            // reduce health by 3 and destroy the reflected projectile
            health = -3f;
            Destroy(other.gameObject);
        }
    }
     
}

