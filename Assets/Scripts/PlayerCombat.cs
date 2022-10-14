using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // a bool to check if the sword is ready to be swung
    public bool swordReady = true;

    // the prefab for the sword
    public GameObject swordPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // when x is pressed and swordReady is true
        if (Input.GetKeyDown(KeyCode.X) && swordReady)
        {
            // create the sword prefab
            Instantiate(swordPrefab, transform.position + (Vector3.forward * 1f) + (Vector3.up * 0.3f), transform.rotation);

            // set the swordReady bool to false
            swordReady = false;

            // start the countdown of the sword
            StartCoroutine(SwordCountdown());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if colliding with a gameobject with the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //destroy the player
            Destroy(gameObject);
        }

        // if colliding with a gameobject with the tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // destroy the player
            Destroy(gameObject);
        }

        // if colliding with a gameobject with the tag "Reflector"
        if (collision.gameObject.CompareTag("Reflector"))
        {
            // ignore collision with the sword
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    IEnumerator SwordCountdown()
    {
        // wait 5 seconds
        yield return new WaitForSeconds(.5f);

        // set swordReady to true
        swordReady = true;
    }

   
}
