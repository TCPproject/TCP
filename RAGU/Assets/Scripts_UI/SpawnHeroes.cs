using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeroes : MonoBehaviour
{
    public GameObject Heroes;
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Heroes, cursorPos, Quaternion.identity);
        }
    }
}
