using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    // the speed of the projectile
    public float speed;

    // the enemy gameobject
    private GameObject enemy;

    // the bool to check if the projectile is reflected
    public bool reflected = false;

    // the rigidbody of the projectile
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    public void Start()
    {
        // get the rigidbody component and call it enemyRb        
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
      
        // if the projectile isn't reflected
        if (reflected == false)
        {
            // move forward
            transform.Translate(Vector3.forward * speed);
        }

        // if the projectile is reflected
        if (reflected == true)
        {
            // move backward
            transform.Translate(Vector3.back * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // if colliding with a object with the tag "Reflector"
        if (other.CompareTag("Reflector"))
        {
            // set "reflected" is true
            reflected = true;

            // change the tag to "ReflectedProjectile"
            gameObject.tag = "ReflectedProjectile";
        }

        // if colliding with an object with the tag "Wall"
        if (other.CompareTag("Wall"))
        {
            // destroy the object
            Destroy(gameObject);
        }

    }

}
