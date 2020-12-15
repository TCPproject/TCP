using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public bool teleported = false;
    public Teleport target;
    public GameObject teleport1, teleport2, spawn;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!teleported)
            {
                target.teleported = true;
                other.gameObject.transform.position = target.gameObject.transform.position;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            teleported = false;
            teleport1.SetActive(false);
            teleport2.SetActive(false);
            spawn.SetActive(true);
        }
    } 

}