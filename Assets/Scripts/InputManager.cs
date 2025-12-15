using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputActionEnum CurrentAction { get; private set; }

    private void Update()
    {
        CurrentAction = InputActionEnum.None;
        if (Input.GetMouseButton(0))
            CurrentAction = InputActionEnum.LeftHold;
        if (Input.GetMouseButtonUp(0))
            CurrentAction = InputActionEnum.LeftRelease;
        if (Input.GetMouseButtonDown(1))
            CurrentAction = InputActionEnum.RightClick;
        if (Input.GetKeyDown(KeyCode.F))
            CurrentAction = InputActionEnum.SwitchCamera;
    }
}
