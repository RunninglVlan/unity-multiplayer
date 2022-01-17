using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager {
    public override void OnClientConnect() {
        base.OnClientConnect();
        Debug.Log("I connected to a server!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);
        Debug.Log($"Player {conn} was added! There are now {numPlayers} players.");
    }
}                
