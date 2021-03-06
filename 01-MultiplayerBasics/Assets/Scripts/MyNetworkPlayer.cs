using Mirror;
using UnityEngine;

public partial class MyNetworkPlayer : NetworkBehaviour {
    [SyncVar(hook = nameof(SetTitle)), SerializeField]
    string displayName = "Missing Name";

    [SyncVar(hook = nameof(SetRendererColor)), SerializeField]
    Color displayColor = Color.magenta;

    [SyncVar(hook = nameof(SetHealth)), SerializeField]
    int displayHealth;

    [SerializeField] Transform titlePoint;
    [SerializeField] Renderer colorRenderer;
}
