using UnityEngine;

public class PlayerHorizontalFlip : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GameObject[] _noFlipObjects;

    private bool _isFacingRight;

    private void Update()
    {
        if (_playerData.ReadMoveInput() < 0 && !_isFacingRight || _playerData.ReadMoveInput() > 0 && _isFacingRight)
        {
            Flip();
            NoFlip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        transform.Rotate(0, 180f, 0);
    }

    private void NoFlip()
    {
        foreach (var obj in _noFlipObjects)
        {
            obj.transform.Rotate(0f, -180f, 0f);
        }
    }
}