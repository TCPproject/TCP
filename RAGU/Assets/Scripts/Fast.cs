using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour
{
    [SerializeField] private float Speed = 3f;
    [SerializeField] private float stopingdistance = 4f;
    [SerializeField] private float timeBtwShoots = 3f;
    [SerializeField] private float startTimeBtwShots = 1;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected VariableJoystick joystick1;
    public float retreatDistance;
    protected Transform target;
    protected Transform player;
    public float rayDistance = 1f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
        joystick1 = FindObjectOfType<VariableJoystick>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stopingdistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) != stopingdistance)
        {
            transform.position = this.transform.position;
        }

        if (timeBtwShoots <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timeBtwShoots = startTimeBtwShots;
        }
        else
        {
            timeBtwShoots -= Time.deltaTime;
        }

    /*  RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
        if (hit.collider != null)
            rb.velocity = Vector2.up;
        if (hit.collider != null)
            rb.velocity = Vector2.down;
            
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance);
    }
    */
}}
/*
void Update()
{
    if (Vector2.Distance(transform.position, player.position) > stopingdistance)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
    }

    else if (Vector2.Distance(transform.position, player.position) < stopingdistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
    {
        transform.position = this.transform.position;
    }
    else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, -Speed * Time.deltaTime);
    }

    if (timeBtwShoots <= 0)
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        timeBtwShoots = startTimeBtwShots;
    }

    else
    {
        timeBtwShoots -= Time.deltaTime;
    }
}
}
*/
/* void Start()
{
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
}

void Update()
{
    if (Vector2.Distance(transform.position, target.position) > stopingdistance)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    else if (Vector2.Distance(transform.position, target.position) < stopingdistance)
    {
        transform.position = this.transform.position;
    }

    if (timeBtwShoots <= 0)
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        timeBtwShoots = startTimeBtwShots;
    }

    else
    {
        timeBtwShoots -= Time.deltaTime;
    }
}
}
*/
//старый код
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float stopingdistance = 4f;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
*/
