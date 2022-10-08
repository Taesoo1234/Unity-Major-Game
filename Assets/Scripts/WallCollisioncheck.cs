using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisioncheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableCollision());
    }

    IEnumerator DisableCollision()
    {
        yield return new WaitForSeconds(.5f);
        this.GetComponent<WallCollisioncheck>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }

  
}
