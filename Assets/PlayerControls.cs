using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public PlayerInput controls;
    public GameObject bomb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (controls.actions.FindAction("BombAttack").triggered)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
        
    }


}
