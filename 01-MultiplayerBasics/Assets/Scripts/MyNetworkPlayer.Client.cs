using UnityEngine;
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

    void LateUpdate() {
        var position = RuntimePanelUtils.CameraTransformWorldToPanel(title.panel, titlePoint.position, mainCamera);
        title.parent.transform.position = position;
    }
}
