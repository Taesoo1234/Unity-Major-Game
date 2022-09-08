using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.Rotate(0, 110, 90);
        StartCoroutine(SwordCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.up, 280 * Time.deltaTime);
        transform.localPosition = player.transform.position + (transform.rotation * Vector3.back * 1f);
    }

    IEnumerator SwordCountdown()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
