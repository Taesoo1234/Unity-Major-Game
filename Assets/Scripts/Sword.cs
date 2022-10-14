using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // the GameObject that the sword swings around
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // the GameObject player is the GameObject with the tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        // rotate the object
        transform.Rotate(0, 110, 90);

        // start the coroutine "SwordCountdown"
        StartCoroutine(SwordCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        // rotate around the player
        transform.RotateAround(player.transform.position, Vector3.up, 280 * Time.deltaTime);

        // teleport to the player's location
        transform.localPosition = player.transform.position + (transform.rotation * Vector3.back * 1f);
    }

    IEnumerator SwordCountdown()
    {
        // wait .5 seconds
        yield return new WaitForSeconds(.5f);

        // destroy the sword
        Destroy(gameObject);
    }

}
