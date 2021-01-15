using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeroes : MonoBehaviour
{
    public GameObject Heroes;
    private bool i = true;
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Position = new Vector2((int)cursorPos.x, (int)cursorPos.y);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //if (i == true) {
            //Instantiate(Heroes, cursorPos, Quaternion.identity);
            Instantiate(Heroes, Position, Quaternion.identity);
            //Heroes.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Destroy(gameObject);
        }
    }
}
