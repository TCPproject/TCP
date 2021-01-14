using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeroes : MonoBehaviour
{
    public GameObject Heroes;
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Position = new Vector2((int)cursorPos.x, (int)cursorPos.y);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Heroes, Position, Quaternion.identity);
        }
    }
}
