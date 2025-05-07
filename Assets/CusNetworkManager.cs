using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class CusNetworkManager : NetworkManager
{
    public GameObject[] Avatars;
    public List<Transform> _StartPositions;
    
    void onCreateCharector(NetworkConnectionToClient Connection, CreateAvatarMes message)
    {
        GameObject Player = Instantiate(Avatars[message.avatarIndex]);
        Player player = Player.GetComponent<Player>();
        //player.Name = "Gilbot-" + Random.Range(0, 1000000);

        NetworkServer.AddPlayerForConnection(Connection, Player);

    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        NetworkServer.RegisterHandler<CreateAvatarMes>(onCreateCharector);

    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        
        CreateAvatarMes message = new()
        {
            avatarIndex = Random.Range(0, Avatars.Length)
        };

        NetworkClient.Send(message);
    }

    public override void Start()
    {
        base.Start();
        startPositions = _StartPositions;
        
    }
    

}
