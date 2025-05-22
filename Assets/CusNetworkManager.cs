using UnityEngine;
using Mirror;
using System.Collections.Generic;

public class CusNetworkManager : NetworkManager
{
    public GameObject[] Avatars;
    public List<Transform> _StartPositions;

    void onCreateCharector(NetworkConnectionToClient Connection, CreateAvatarMes message)
    {
        /*GameObject Player = Instantiate(Avatars[message.avatarIndex]);
        Player player = Player.GetComponent<Player>();
        //player.Name = "Gilbot-" + Random.Range(0, 1000000);

        NetworkServer.AddPlayerForConnection(Connection, Player);*/
        Transform startPos = startPositions[Random.Range(0, startPositions.Count)];
        startPositions.Remove(startPos);
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : null;

            // instantiating a "Player" prefab gives it the name "Player(clone)"
            // => appending the connectionId is WAY more useful for debugging!
            player.name = $"{playerPrefab.name} [connId={Connection.connectionId}]";
            NetworkServer.AddPlayerForConnection(Connection, player);

    }

    public override void OnStartHost()
    {

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

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            /*Transform startPos = startPositions[Random.Range(0, startPositions.Count)];
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : null;

            // instantiating a "Player" prefab gives it the name "Player(clone)"
            // => appending the connectionId is WAY more useful for debugging!
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);*/
        }
    

}
