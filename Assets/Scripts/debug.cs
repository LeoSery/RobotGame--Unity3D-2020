/*
# Unity Game - Bob's Adventure | Ydays Ynov
# Simple debug script
# Léo Séry ~ 2021
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class debug : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
