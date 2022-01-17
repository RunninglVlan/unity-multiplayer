using Mirror;
using UnityEngine;
using UnityEngine.UIElements;

public class MyNetworkPlayer : NetworkBehaviour {
    [SyncVar(hook = nameof(SetTitle)), SerializeField]
    string displayName = "Missing Name";

    [SyncVar(hook = nameof(SetRendererColor)), SerializeField]
    Color displayColor = Color.magenta;

    [SerializeField] Transform titlePoint;
    [SerializeField] Renderer colorRenderer;

    Label title;
    Camera mainCamera;

    [Server]
    public void SetDisplayName(string name) => displayName = name;

    [Server]
    public void SetDisplayColor(Color value) => displayColor = value;

    void SetTitle(string _, string newValue) => title.text = newValue;
    void SetRendererColor(Color _, Color newValue) => colorRenderer.material.color = newValue;

    void Awake() {
        title = GetComponent<UIDocument>().rootVisualElement.Q<Label>();
        mainCamera = Camera.main;
    }

    void LateUpdate() {
        var position = RuntimePanelUtils.CameraTransformWorldToPanel(title.panel, titlePoint.position, mainCamera);
        title.parent.transform.position = position;
    }
}
