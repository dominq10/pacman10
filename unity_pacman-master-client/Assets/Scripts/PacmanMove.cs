using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
      
    public float[] TransfMessage = new float[9];
    public float[] Answer = new float[14];
    /*0 - номер клиента 
     1 - статус(0-живой, 1 - умер, 3 -победил, 4 проиграл)
     2- х
     3 - у
     4 - собранных очков
     5 x призрака 1
     6 у призрака 1
     7 х призрака2
     8 у призрака2
         */
    public GameObject Prizrak1, Prizrak2, clonePacman, Client;

    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;

    void Start ()
    {
        dest = transform.position;
        TransfMessage[0] = 1;
        TransfMessage[1] = 0;
        clonePacman.transform.position = new Vector2(12, 14);
        
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);


        TransfMessage[2] = GetComponent<Transform>().position.x;
        TransfMessage[3] = GetComponent<Transform>().position.y;

        TransfMessage[5] =Prizrak1.GetComponent<Transform>().position.x;
        TransfMessage[6] = Prizrak1.GetComponent<Transform>().position.y;

        TransfMessage[7] = Prizrak2.GetComponent<Transform>().position.x;
        TransfMessage[8] = Prizrak2.GetComponent<Transform>().position.y;

        Answer = Client.GetComponent<Client>().Answer;

        clonePacman.transform.position = new Vector2(Answer[7],Answer[8]);

    }

    bool valid (Vector2 dir)
    {
        // cast line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast (pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D> ());
    }



    //void OnGUI()
    //{

        
        
    //        GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 300, 300), "ffffff");
    //        GUI.Label(new Rect(Screen.width - Screen.width / 2, Screen.height - Screen.height / 2, 300, 300), "bbbbbbb");
        

    //}
}