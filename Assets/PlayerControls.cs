using System;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public PlayerInput controls;
    public GameObject bomb;
    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

  
    void Update()
    {
        if (controls.actions.FindAction("BombAttack").triggered && !isAttacking)
        {
             isAttacking = true;
            GameObject bombe = Instantiate(bomb, transform.position, Quaternion.identity);
            bombe.GetComponent<BomExplode>().Player = this.gameObject;
            NetworkServer.Spawn(bombe);
        }
        
    }


}
