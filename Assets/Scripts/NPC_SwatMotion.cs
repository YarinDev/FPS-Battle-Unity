using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_SwatMotion : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    private bool flag = true;
    public GameObject target;
    public GameObject target2;
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
            if (flag)
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
                            //print("oved2");
                            StartCoroutine(npcRifleRun());
                            gunInBox.SetActive(false);
                            gunInHand.SetActive(true);
                            flag = false;
                        }
                    }
                }
            }
            else
            {
                agent.SetDestination(target2.transform.position);
            }


            IEnumerator npcRifleRun()
            {
                yield return new WaitForSeconds(0f); // delay
                animator.SetInteger("state", 2);
            }
        }
    }
}