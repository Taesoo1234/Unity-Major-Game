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
            //transform.Translate(Vector3.forward * speed);
            enemyRb.AddForce(Vector3.forward * speed);
        }

        if (reflected == true)
        {
            enemy = GameObject.Find("enemy");
            Vector3 lookDirection = (enemy.transform.position - transform.position).normalized;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Reflector"))
        {
            reflected = true;
        }

    }

}
