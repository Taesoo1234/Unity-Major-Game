using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 90);
        //StartCoroutine(SwordCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.up, 360 * Time.deltaTime);
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, .02f);
    }

    //IEnumerator SwordCountdown()
}
