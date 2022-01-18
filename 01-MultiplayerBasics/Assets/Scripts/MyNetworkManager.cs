using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager {
    public override void OnServerAddPlayer(NetworkConnection conn) {
        base.OnServerAddPlayer(conn);

        var player = conn.identity.GetComponent<MyNetworkPlayer>();

        if (numPlayers == 1) {
            player.transform.position = Vector3.left * 4;
        }
        player.SetDisplayName($"Player {numPlayers}");
        player.SetDisplayColor(Random.ColorHSV());
        player.SetDisplayHealth(50);
    }
}
