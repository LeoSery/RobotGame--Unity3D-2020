/*
# Unity Game - Bob's Adventure | Ydays Ynov
# Simple script to warn the player of a zone exit
# Léo Séry ~ 2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMessage : MonoBehaviour
{
    public GameObject WarningZoneMessage;

    private bool m_PlayerInZone = false;

    void Update()
    {
        if (m_PlayerInZone)
            ShowMessage();
        else
            HideMessage();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name == "Third Person Player")
            m_PlayerInZone = true;
        else
            m_PlayerInZone = false;
    }

    void ShowMessage()
    {
        WarningZoneMessage.SetActive(true);
        m_PlayerInZone = true;
    }

    void HideMessage()
    {
        WarningZoneMessage.SetActive(false);
        m_PlayerInZone = false;
    }
}
