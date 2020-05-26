using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanAll : MonoBehaviour
{

    public int score, status;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        status = 0;
    }

    // Update is called once per frame
    void Update()
    {
        status = (int)GetComponent<PacmanMove>().Answer[1];
        GetComponent<PacmanMove>().TransfMessage[4] = score;
        
    }

    void OnGUI()
    {
       
        
         GUI.Label(new Rect(Screen.width - 60, 60, 50, 50), score.ToString());



        if (status==3)
            GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 300, 300), "Game Over - Win");
        if (status == 4)
            GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 300, 300), "Game Over - Lose");




    }
}
