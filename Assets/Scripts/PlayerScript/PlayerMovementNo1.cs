using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNo1 : MonoBehaviour
{
    public Vector2 MovementInputVectors { get; private set; }

    public void OnMovement(InputValue inputValue)
    {
        MovementInputVectors = inputValue.Get<Vector2>();
    }
}
