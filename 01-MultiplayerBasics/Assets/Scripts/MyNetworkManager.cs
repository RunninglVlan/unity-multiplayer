using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager {
    public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);

        var player = conn.identity.GetComponent<MyNetworkPlayer>();

        player.SetDisplayName($"Player {numPlayers}");
        player.SetDisplayColor(Random.ColorHSV());
        player.SetDisplayHealth(50);
    }
}
