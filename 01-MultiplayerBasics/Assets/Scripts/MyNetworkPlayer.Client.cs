using System.Diagnostics.CodeAnalysis;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public partial class MyNetworkPlayer {
    void SetTitle(string _, string newValue) => title.text = newValue;
    void SetRendererColor(Color _, Color newValue) => colorRenderer.material.color = newValue;

    Label title;
    Camera mainCamera;

    void Awake() {
        title = GetComponent<UIDocument>().rootVisualElement.Q<Label>();
        mainCamera = Camera.main;
    }

    [ClientRpc]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    void LogName(string value) => Debug.Log($"Server object name is {value}");

    [TargetRpc]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    void LogColorChange() => Debug.Log("Server changed our color");

    void Update() {
        var local = isLocalPlayer;
        if (local && Keyboard.current.cKey.wasPressedThisFrame) {
            ChangeColor();
        }
        if (local && isServer && Keyboard.current.nKey.wasPressedThisFrame) {
            LogName(displayName);
        }
    }

    void LateUpdate() {
        var position = RuntimePanelUtils.CameraTransformWorldToPanel(title.panel, titlePoint.position, mainCamera);
        title.parent.transform.position = position;
    }
}
