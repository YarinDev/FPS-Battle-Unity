using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_TeammateMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    public GameObject gunInBox;
    public GameObject gunInHand;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

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
                        StartCoroutine(npcRifleRun());
                        gunInBox.SetActive(false);
                        gunInHand.SetActive(true);
                    }
                }
            }

            IEnumerator npcRifleRun()
            {
                yield return new WaitForSeconds(0f); // delay
                animator.SetInteger("state", 2);
            }
        }
    }
}