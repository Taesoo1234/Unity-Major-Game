using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // the gameobject that the gameObject tracks
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // checks if the gameobject 'Player' has been deleted
        if (GameObject.Find("Player") == null)
        {
            // with an x offset of 5 and a y offset of 4
            // to be visible to the player
            transform.position = new Vector3(0, 4.5f, 0);
        }
    }
}
