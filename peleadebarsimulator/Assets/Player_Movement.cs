using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 20, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);
        }
    }
}
