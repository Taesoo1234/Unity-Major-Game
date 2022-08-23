using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    public float speed;
    private GameObject player;
    public bool reflected = false;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    public void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if (reflected == false)
        {
            transform.Translate(Vector3.forward * speed);
        }
    }
}
