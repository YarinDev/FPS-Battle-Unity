using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;
    private AudioSource doorSqueak;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorSqueak = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorisOpenning", true);
        doorSqueak.PlayDelayed(1.2f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorisOpenning", false);
        doorSqueak.PlayDelayed(1.8f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}