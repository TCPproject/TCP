using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    private float stopingdistance = 2f;
    protected Transform basa;
    private NavMeshAgent agent;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        basa = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, basa.position) > stopingdistance)
        {
            agent.Resume();
            agent.SetDestination(basa.position);
        }
        else if (Vector2.Distance(transform.position, basa.position) <= stopingdistance)
        {
            agent.Stop();
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
}
