using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerMovement {
    Camera mainCamera;

    public override void OnStartAuthority() => mainCamera = Camera.main;

    [ClientCallback]
    void Update() {
        if (!hasAuthority) {
            return;
        }

        if (!Mouse.current.rightButton.wasPressedThisFrame) {
            return;
        }

        var ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out var hit, Mathf.Infinity)) {
            return;
        }

        CmdMove(hit.point);
    }
}
