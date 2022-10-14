using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    // public gameobjects for the projectile it shoots and the player to face
    public GameObject projectilePrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // broadcast "shoot" to trigger void shoot()
        BroadcastMessage("shoot");
    }

    // Update is called once per frame
    void Update()
    {
        // find the player
        player = GameObject.Find("Player");

        // look at the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
    }

    public void shoot()
    {
        // instantiate the projectile
        GameObject projectile = (GameObject)Instantiate(projectilePrefab);

        // inherit the position and rotation of the enemy gameobject
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;

        // start a countdown before it can shoot again
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        // wait 5 seconds
        yield return new WaitForSeconds(5);

        // broadcast "shoot" to trigger void shoot()
        BroadcastMessage("shoot");
    }
}
