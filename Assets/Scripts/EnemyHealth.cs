using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 3;
    public GameObject ScoreKeeper;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
            gameObject.SendMessageUpwards("IncreaseScore");
            SendMessageUpwards("Death");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Reflector"))
        {
            health = -1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ReflectedProjectile"))
        {
            health = -3f;
            Debug.Log("Hit");
            Destroy(other.gameObject);
        }
    }
     
}

