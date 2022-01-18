using System.Diagnostics.CodeAnalysis;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public partial class MyNetworkPlayer {
    void SetTitle(string _, string newValue) => SetTitle(newValue, displayHealth);
    void SetRendererColor(Color _, Color newValue) => colorRenderer.material.color = newValue;
    void SetHealth(int _, int newValue) => SetTitle(displayName, newValue);
    void SetTitle(string value, int health) => title.text = $"{value} ({health})";

    Label title;
    Camera mainCamera;

    void Awake() {
        title = GetComponent<UIDocument>().rootVisualElement.Q<Label>();
        mainCamera = Camera.main;
    }

    [ClientRpc]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    void RpcLogName(string value) => Debug.Log($"Server object name is {value}");

    [TargetRpc]
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
    void TargetLogColorChange() => Debug.Log("Server changed our color");

    [ClientCallback]
    void Update() {
        if (!hasAuthority) {
            return;
        }

        if (Keyboard.current.cKey.wasPressedThisFrame) {
            CmdChangeColor();
        }

        if (Keyboard.current.hKey.wasPressedThisFrame) {
            CmdIncreaseHealth(10);
        }

        if (isServer && Keyboard.current.nKey.wasPressedThisFrame) {
            RpcLogName(displayName);
        }
    }

    void LateUpdate() {
        var position = RuntimePanelUtils.CameraTransformWorldToPanel(title.panel, titlePoint.position, mainCamera);
        title.parent.transform.position = position;
    }
}
