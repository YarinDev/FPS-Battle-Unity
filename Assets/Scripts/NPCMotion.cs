using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position); //start AI path generation(A* algorithem)
            //and start moving on the path
            //draw path
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        //   animator.SetInteger("state", 5);
                        StartCoroutine(npcRifleRun());
                        //left chair location fot target
                        /*player.transform.SetPositionAndRotation(new Vector3(35.3f, 1.1f, -43.49f),
                            new UnityEngine.Quaternion(0, 90, 0, 0));*/
                        //agent.transform.SetPositionAndRotation(new Vector3(35.78f, 1.1f, -43.49f),
                        //     Quaternion.Euler(new Vector3(0,90,0)));
                        //  StartCoroutine(delayBeforeStand());
                        // StartCoroutine(delayBeforeWalk());
                    }
                }
            }

            IEnumerator npcRifleRun()
            {
                print("oved");
                yield return new WaitForSeconds(0f); // delay
                animator.SetInteger("state", 2);

            }
        }
    }
}