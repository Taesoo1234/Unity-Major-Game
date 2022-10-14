using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisioncheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // start the coroutine "DisableCollision"
        StartCoroutine(DisableCollision());
    }

    IEnumerator DisableCollision()
    {
        // wait .5 seconds
        yield return new WaitForSeconds(.5f);

        // disable the script
        this.GetComponent<WallCollisioncheck>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        // if the colliding gameobject has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // destroy the wall
            Destroy(gameObject);
        }
    }
}
