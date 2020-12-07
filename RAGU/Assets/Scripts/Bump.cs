using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    public float damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
       Debug.Log(hitInfo.name);
       Destroy(gameObject);
    }
}