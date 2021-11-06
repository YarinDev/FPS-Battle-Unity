using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject target;
    private LineRenderer line;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            print("kako");
            agent.SetDestination(target.transform.position); //start AI path generation(A* algorithem)
            //and start moving on the path
            //draw path
            line.positionCount = agent.path.corners.Length;
            line.SetPositions(agent.path.corners);
        }
    }
}