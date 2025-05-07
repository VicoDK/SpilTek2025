using System;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;

public class PlayerControls : NetworkBehaviour
{
    public PlayerInput controls;
    public GameObject bomb;
    public GameObject bombe;
    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

  
    void Update()
    {
        if (!isLocalPlayer) return;

        if (controls.actions.FindAction("BombAttack").triggered && !isAttacking)
        {
            isAttacking = true;
            bombe = Instantiate(bomb, transform.position, Quaternion.identity);
            bombe.GetComponent<BomExplode>().Player = this.gameObject;
            NetworkServer.Spawn(bombe);
        }
        
    }


}
