using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        BroadcastMessage("shoot");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
    }

    public void shoot()
    {
        Debug.Log("shooting");
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        StartCoroutine(ShootCooldown());
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(5);
        BroadcastMessage("shoot");
    }
}
