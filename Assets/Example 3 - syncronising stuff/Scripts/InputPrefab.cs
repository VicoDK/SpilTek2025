using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class InputPrefab : NetworkBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementZ;
    private int speed = 10;

    public override void OnStartAuthority()
    {
        Debug.Log("This is a local player");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isLocalPlayer)
            {
                Debug.Log(gameObject.name + " is local");
            }
            else
            {
                Debug.Log(gameObject.name + " is not local");
            }
        }

            movementX = Input.GetAxis("Horizontal");
            movementZ = Input.GetAxis("Vertical");
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
        rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }
}
