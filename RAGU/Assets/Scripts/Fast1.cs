using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast1 : MonoBehaviour
{
    [SerializeField] private float stopingdistance = 3f, Speed = 3f;
    public GameObject hitpoint;
    protected Transform target;
    public float rayDistance = 3f, timeUndoShoots = 1f;
    public float rayDistance1 = 3f;
    private Rigidbody2D rb;
    public float Damage = 5;
    private int dead;
    public int i = 0;
    public Animator anima;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
        anima = GetComponent<Animator>();
    }

    void Update()
    {
        Go();
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance1);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, transform.position + transform.localScale.y * Vector3.up * rayDistance1);

        if (hit1.collider != null)
        {
            rb.velocity = Vector2.up;
        }
        else if (hit2.collider != null)
        {
            rb.velocity = Vector2.right;
        }
        dead = PlayerPrefs.GetInt("Dead", dead);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.y * Vector3.up * rayDistance1);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.y * Vector3.down * rayDistance1);
    }

    public void Go()
    {
        if (Vector2.Distance(transform.position, target.position) > stopingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) <= stopingdistance)
        {
            transform.position = this.transform.position;

            /*if (timeBtwShoots <= 0)
            {
                GameObject hitpref = hitpoint;
                Instantiate(hitpref, transform.position, Quaternion.identity);
                timeBtwShoots = startTimeBtwShots;
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Base BASE = other.gameObject.GetComponent<Base>();
        DroneController Player = other.gameObject.GetComponent<DroneController>();
        i = 0;
        
        if (BASE != null && i == 0)
        {
            BASE.TakeDamage(Damage);
            i++;
            anima.Play("Bo");
            StartCoroutine(Dead());
        }

        if (Player != null && i == 0)
        {
            Player.TakeDamagePlayer(Damage);
            anima.Play("Bo");
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        float number1 = Random.Range(0.15f, 0.2f);
        yield return new WaitForSeconds(number1);
        dead++;
        PlayerPrefs.SetInt("Dead", dead);
        DestroyImmediate(gameObject);
    }
}