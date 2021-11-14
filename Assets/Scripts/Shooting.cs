using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject aCamera;

    public GameObject target;

    public GameObject muzzle;

    private LineRenderer line;
    public AudioSource shootingSound1;
    public AudioSource shootingSound2;
    public AudioSource shootingSound3;
    public AudioSource shootingSound4;
    public GameObject NPC_GAS, NPC_SWAT;
    private Animator animator, animator2;
    private static int numHitsGAS, numHitsSWAT;
    private NavMeshAgent agent, agent2;
    public Text text ;


    // Start is called before the first frame update
    void Start()
    {
        numHitsGAS = 0;
        numHitsSWAT = 0;
        line = GetComponent<LineRenderer>();
        animator = NPC_GAS.GetComponent<Animator>();
        animator2 = NPC_SWAT.GetComponent<Animator>();
        agent = NPC_GAS.GetComponent<NavMeshAgent>();
        agent2 = NPC_SWAT.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            Transform child;
            int count = 0;
            for (int i = 0; i < aCamera.transform.childCount; i++)
            {
                child = aCamera.transform.GetChild(i);
                if (child.transform.gameObject.activeSelf == true)
                {
                    count++;
                }
            }

           // print("count: " + count);
            if (count > 0)
            {
                if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
                {
                    target.transform.position = hit.point;
                    //draw line
                    shootingSound1.Play();
                    shootingSound2.Play();
                    shootingSound3.Play();
                    shootingSound4.Play();
                    StartCoroutine(ShowFlash());


                    //check that the bullet hit the GAS
                    if (hit.transform.gameObject == NPC_GAS)
                    {
                        numHitsGAS++;
                        if (numHitsGAS == 3) //dying
                        {
                            animator.SetInteger("state", 3); 
                            agent.enabled = false;
                        }
                    }
                    else if (hit.transform.gameObject == NPC_SWAT)
                    {
                        numHitsSWAT++;
                        if (numHitsSWAT == 3) //dying
                        {
                            animator2.SetInteger("state", 3); //dying
                            agent2.enabled = false;
                        }
                    }

                    if (numHitsSWAT >= 3 && numHitsGAS >= 3)
                    {
                        text.text = "You Won!!!\n GAME OVER";
                    }
                }
            }
        }
    }

    IEnumerator KnightFallAndGettingUp()
    {
        //check what state was before falling
        int st = animator.GetInteger("state");

        //stop moving towards the target
        if (st == 1) //walking
            agent.enabled = false;

        animator.SetInteger("state", 2); //fall back

        yield return new WaitForSeconds(2f); // delay
        animator.SetInteger("state", 3); //getting up
        yield return new WaitForSeconds(1f); // delay
        //renew motion
        if (st == 1) //it was walking
            agent.enabled = true;


        animator.SetInteger("state", st); //previuos state
    }


    IEnumerator ShowFlash()
    {
        //draw flash
        line.SetPosition(0, muzzle.transform.position);
        line.SetPosition(1, target.transform.position);

        //all the lines before next run immidiatly
        yield return new WaitForSeconds(0.1f); // delay
        //the next line will be executed after the delay
        //erase flash
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);
    }
}