using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OgurEnemy : MonoBehaviour
{
    public float health = 100;
    public float Damage = 15;

    private float stopingdistance = 2f;
    private float agro = 3f;
    protected Transform basa;
    private NavMeshAgent agent;
    private bool stop;
    private Transform tomat;

    // Start is called before the first frame update
    void Start()
    {
        tomat = GameObject.FindGameObjectWithTag("Tomat").GetComponent<Transform>();
        basa = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 7;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.avoidancePriority = Random.Range(1, 100);
        //Debug.Log(agent.avoidancePriority);
    }

    // Update is called once per frame
    void Update()
    {

        //if (Vector2.Distance(transform.position, basa.position) > stopingdistance)
        //{
        //    agent.Resume();
        //    agent.SetDestination(basa.position);
        //}
        //else if (Vector2.Distance(transform.position, basa.position) <= stopingdistance)
        //{
        //    agent.Stop();
        //}


        if (tomat != null)
        {
            if (agent.avoidancePriority < 50 && Vector2.Distance(transform.position, tomat.position) > agro)
            {
                if (Vector2.Distance(transform.position, basa.position) > stopingdistance)
                {
                    agent.SetDestination(basa.position);
                    agent.Resume();
                }
                else if (Vector2.Distance(transform.position, basa.position) <= stopingdistance)
                {
                    agent.Stop();
                }
            }
            else if (Vector2.Distance(transform.position, tomat.position) > agro)
            {
                agent.SetDestination(tomat.position);

            }
            //атака

            if (Vector2.Distance(transform.position, tomat.position) < agro)
            {

            }
        }

        if (tomat == null)
        {
            agent.Stop();
            tomat = GameObject.FindGameObjectWithTag("Tomat").GetComponent<Transform>();
            //Debug.Log("ID" + tomat.GetInstanceID());
            agent.SetDestination(tomat.position);
            agent.Resume();
        }

        //if ((transform.position - target.transform.position).magnitude < 1 && !stop)
        //{
        //    stop = true;
        //    target.GetComponent<Navigate>().enabled = false;

        //    //var win = FindObjectOfType<Continue>();
        //    //win.WinCondition();
        //}

        //Navigate.DebugDrawPath(agent.path.corners);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TomatEnemy tomatEnemy = other.gameObject.GetComponent<TomatEnemy>();

        if (tomatEnemy != null)
        {
            tomatEnemy.TakeDamage(Damage);
            //anima.Play("Bo");
            StartCoroutine(Dead());
        }
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        Debug.Log("Tomat HP: " + health);
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {
        float number1 = Random.Range(0.15f, 0.2f);
        yield return new WaitForSeconds(number1);
        //dead++;
        //PlayerPrefs.SetInt("Dead", dead);
        Destroy(gameObject);
    }


}
