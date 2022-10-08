using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    public float speed;
    private GameObject enemy;
    public bool reflected = false;
    private Rigidbody enemyRb;

    // Start is called before the first frame update
    public void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
      
        if (reflected == false)
        {
            transform.Translate(Vector3.forward * speed);
        }

        if (reflected == true)
        {
            transform.Translate(Vector3.back * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Reflector"))
        {
            reflected = true;
            gameObject.tag = "ReflectedProjectile";
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }

}
