/*
# Unity Game - Bob's Adventure | Ydays Ynov
# Manager script for the lifebar UI
# Léo Séry ~ 2021
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Gradient gradient;
    public Slider slider;
    public float health;
    public Image fill;

    void Start ()
    {
        SetMaxHealth(1);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        this.health = health;
    }

    public void SetHealth(float health)
    {
        slider.value = slider.maxValue * health;
        fill.color = gradient.Evaluate(health);
        this.health = health;
    }
    
    void Update ()
    {
        fill.color = gradient.Evaluate(this.health);
    }
}