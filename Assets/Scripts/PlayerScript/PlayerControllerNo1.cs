using UnityEngine;

public class PlayerControllerNo1 : MonoBehaviour
{
    private PlayerMovementNo1 _playerControllerNo1;
    float moveSpeed = 5f;

    private void Awake()
    {
        _playerControllerNo1 = GetComponent<PlayerMovementNo1>();
    }

    private void Update()
    {
        Vector3 positionChange = new Vector3(
            _playerControllerNo1.MovementInputVectors.x, 0, _playerControllerNo1.MovementInputVectors.y
            ) * Time.deltaTime * moveSpeed;

        transform.position += positionChange;
    }
}
