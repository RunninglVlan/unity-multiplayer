using Mirror;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour {
    [SyncVar, SerializeField] private string displayName = "Missing Name";
    [SyncVar, SerializeField] private Color displayColor = Color.magenta;

    [Server]
    public void SetDisplayName(string name) => displayName = name;

    [Server]
    public void SetDisplayColor(Color value) => displayColor = value;
}
