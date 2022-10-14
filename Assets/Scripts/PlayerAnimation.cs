using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // public Animator component called playerAnim
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        // get the Animator component
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // the floats for the input of the vertical and horizontal axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // the direction is the vector3 of the horizontal and vertical input
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // if the magnitude of direction is greater than .1
        if (direction.magnitude >= 0.1f)
        {
            // set the Bool of "Stationary" in the animation component to false
            playerAnim.SetBool("Stationary", false);
        }
        else
        {
            // set the Bool of "Stationary" in the animation component to true
            playerAnim.SetBool("Stationary", true);
        }


      
    }
}
