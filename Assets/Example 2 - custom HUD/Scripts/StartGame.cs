using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(MainMenu.isServer)
        {
            NetworkManager.singleton.StartHost();
        }
        else
        {
            NetworkManager.singleton.StartClient();
        }
    }
}
