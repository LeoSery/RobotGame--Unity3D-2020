/*
# Unity Game - Bob's Adventure | Ydays Ynov
# Script for shooting animation
# Léo Séry ~ 2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public bool isAiming = false;

    private Animator m_Animator;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            isAiming = true;
        else if (Input.GetMouseButtonUp(1)) 
            isAiming = false;

        if (isAiming)
            m_Animator.SetBool("isAiming", true);
        else if (isAiming == false)
            m_Animator.SetBool("isAiming", false);
    }
}
