using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMotion : MonoBehaviour
{
    private float speed = 10, angularSpeed = 200;
    private CharacterController controller;
    private float rotationAboutY = 0, rotationAboutX = 0;

    public GameObject camera; // publics must be initialized in Unity

    private AudioSource stepSound;
    public GameObject npc, npc2, npc3;
    private Animator animator, animator2, animator3;
    private NavMeshAgent agent, agent2, agent3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dy = -1 /*kind of a gravity*/, dz;

        // rotation about Y
        rotationAboutY += Input.GetAxis("Mouse X") * angularSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationAboutY, 0);

        // rotation about X
        rotationAboutX -= Input.GetAxis("Mouse Y") * angularSpeed * Time.deltaTime;
        camera.transform.localEulerAngles = new Vector3(rotationAboutX, 0, 0);

        // moving forward/backward/left/right
        dz = Input.GetAxis("Vertical"); // can be -1, 0 , 1
        dz *= speed * Time.deltaTime;

        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        Vector3 motion = new Vector3(dx, dy, dz); // in Local coordinates
        motion = transform.TransformDirection(motion); // change to Global coordinates
        controller.Move(motion); //in Global coordinates
        //if  was A/W/S/D key was pressed
        if (dz < 0 || dz > 0 || dx < 0 || dx > 0)
        {
            if (!stepSound.isPlaying)
                stepSound.Play();
            //turn on npc
            animator = npc.GetComponent<Animator>();
           animator2 = npc2.GetComponent<Animator>();
           animator3 = npc3.GetComponent<Animator>();
            animator.SetInteger("state", 1);
            animator2.SetInteger("state", 1);
            animator3.SetInteger("state", 1);
            agent = npc.GetComponent<NavMeshAgent>();
            agent2 = npc2.GetComponent<NavMeshAgent>();
           agent3 = npc3.GetComponent<NavMeshAgent>();
            //StartCoroutine(npcActivation());
            agent.enabled = true; //this starts npc motion
            agent2.enabled = true; //this starts npc motion
            agent3.enabled = true; //this starts npc motion

           
        }

        //bob starts walk after standing
        IEnumerator npcActivation()
        {
            yield return new WaitForSeconds(0f); // delay
            //animator.SetInteger("state", 2);
            agent.enabled = true; //this starts npc motion
            agent2.enabled = true; //this starts npc2 motion
           // agent3.enabled = true; //this starts npc3 motion
           
            //and let npc walk through
        }
        // simple motion
//        transform.Translate(new Vector3(dx, dy, dz));
        // simple motion forward
        //      transform.Translate(new Vector3(0, 0, 0.1f));
        // simple motion to the left
        //      transform.Translate(new Vector3(-0.1f, 0, 0));
    }
}