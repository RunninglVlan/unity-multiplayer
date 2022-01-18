using Mirror;
using UnityEngine;

public partial class MyNetworkPlayer {
    [Server]
    public void SetDisplayName(string value) => displayName = value;

    [Server]
    public void SetDisplayColor(Color value) => displayColor = value;

    [Command]
    void CmdChangeColor() {
        SetDisplayColor(Random.ColorHSV());
        TargetLogColorChange();
    }
}
