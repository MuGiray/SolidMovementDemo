using UnityEngine;
using UnityEngine.InputSystem;
using Project.Core;

public class KeyboardInput : MonoBehaviour, IInputProvider
{
    public Vector3 GetMovementInput()
    {
        // Yeni Input System'da klavye okuma yöntemi budur
        Vector2 move = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) move.y = 1;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) move.y = -1;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) move.x = -1;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) move.x = 1;
        }

        return new Vector3(move.x, 0, move.y).normalized;
    }
}