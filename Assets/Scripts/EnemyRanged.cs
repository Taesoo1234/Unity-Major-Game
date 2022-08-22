using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        BroadcastMessage("shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        Debug.Log(shooting);
        //shoot object
        StartCoroutine(ShootCooldown());
    }
    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(5);
        BroadcastMessage("shoot");
    }
}
