using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TomatEnemy : MonoBehaviour
{
    public float health = 100;
    public float Damage = 5;
    private bool attack;
    private float stopingdistance = 2f;
    private float agro = 10f;
    protected Transform basa;
    private NavMeshAgent agent;
    private Transform ogurec;
    private bool stop;

    void Start()
    {
        ogurec = GameObject.FindGameObjectWithTag("Ogurec").GetComponent<Transform>();
        basa = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 4;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.avoidancePriority = Random.Range(1, 100);
    }

    void Update()
    {   
        //Счетчик всего ботов и если он 0 то проигрыш
                if (ogurec != null)
                {
                    //agent.Resume();
                    agent.SetDestination(ogurec.position);
                }
                if (ogurec == null)
                {
                    agent.Stop();
                    ogurec = GameObject.FindGameObjectWithTag("Ogurec").GetComponent<Transform>();
                    //Debug.Log("ID" + ogurec.GetInstanceID());
                    agent.SetDestination(ogurec.position);
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
        OgurEnemy ogurEnemy = other.gameObject.GetComponent<OgurEnemy>();

        if (ogurEnemy != null)
        {
            ogurEnemy.TakeDamage(Damage);
            //anima.Play("Bo");
            StartCoroutine(Dead());
        }
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
        Debug.Log("Ogurec HP: " + health);
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
