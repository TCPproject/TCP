using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    static string tagPlayer = "Player";
    private Transform player;
    public float speed = 5f;
    public int damagePlayer = 1;
    private Vector2 target;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag(tagPlayer).GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DroneController player = other.gameObject.GetComponent<DroneController>();

        if (player != null)
        {
            player.TakeDamagePlayer(damagePlayer);
        }
        if (other.CompareTag("Player"))
        {
            DestroyBullet();
        }
        else if (other.CompareTag("Stena"))
             DestroyBullet();
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
      // Debug.Log(hitInfo.name);
       Destroy(gameObject);
    }
}
*/
