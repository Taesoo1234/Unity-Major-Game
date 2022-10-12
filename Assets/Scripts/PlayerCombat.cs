using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool swordReady = true;
    public bool gameOver = false;
    public GameObject swordPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //code for swinging sword
        if (Input.GetKeyDown(KeyCode.X) && swordReady)
        {
            Instantiate(swordPrefab, transform.position + (Vector3.forward * 1f) + (Vector3.up * 0.3f), transform.rotation);
            swordReady = false;
            StartCoroutine(SwordCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            gameOver = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SwordCountdown()
    {
        yield return new WaitForSeconds(.5f);
        swordReady = true;
    }

   
}
