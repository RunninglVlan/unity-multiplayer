using Mirror;
using UnityEngine;

public partial class MyNetworkPlayer {
    [Server]
    public void SetDisplayName(string value) => displayName = value;

    [Server]
    public void SetDisplayColor(Color value) => displayColor = value;

    [Server]
    public void SetDisplayHealth(int value) => displayHealth = value;

    [Command]
    void CmdChangeColor() {
        SetDisplayColor(Random.ColorHSV());
        TargetLogColorChange();
    }

    [Command]
    void CmdIncreaseHealth(int value) {
        SetDisplayHealth(displayHealth + value);
    }
}
