using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    public GameObject Pacman;
    void OnTriggerEnter2D(Collider2D co){
        // Do Stuff...
        if (co.name == "pacman")
        {
            Pacman.GetComponent<PacmanAll>().score++;
            Destroy(gameObject);
        }
        if (co.name == "pacman (1)")
        {
            
            Destroy(gameObject);
        }
    }
}
