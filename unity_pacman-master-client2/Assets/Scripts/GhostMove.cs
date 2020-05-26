using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    bool dead=false;   
    void FixedUpdate(){
    	
    	
    }

    void OnTriggerEnter2D(Collider2D co){
    	if(co.name == "pacman"){


            dead = true;
            
       	}
    }

    void OnGUI()
    {

        
        if (dead)
            GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 300, 300), "Game Over - Lose");


    }
}
