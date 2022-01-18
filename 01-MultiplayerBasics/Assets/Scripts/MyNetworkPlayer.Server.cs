using Mirror;
using UnityEngine;

public partial class MyNetworkPlayer {
    [Server]
    public void SetDisplayName(string name) => displayName = name;

    [Server]
    public void SetDisplayColor(Color value) => displayColor = value;

    [Command]
    void ChangeColor() {
        SetDisplayColor(Random.ColorHSV());
        LogColorChange();
    }
}
