using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(swordPrefab, transform.position + (Vector3.forward * 0.6f), transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            gameOver = true;
        }
    }
}
