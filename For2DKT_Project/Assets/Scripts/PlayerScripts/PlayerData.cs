using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Health _health;

    [Header("MoveSettings")]
    [SerializeField] private float _moveSpeed;

    [Header("JumpSettings")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private LayerMask _whatIsGround;

    [Header("ShootSettings")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootPower;

    public Animator Animator => _animator;
    public Rigidbody2D Rigidbody => _rigidbody;
    public Collider2D Collider => _collider;
    public Health Health => _health;
    public float MoveSpeed => _moveSpeed;
    public float JumpForce => _jumpForce;
    public IGun GazePistol { get; private set; }
    public Animation Animation { get; set; }

    public float ReadMoveInput() => Input.GetAxisRaw("Horizontal");

    public bool ReadShootInput() => Input.GetKeyDown(KeyCode.Mouse0);

    public bool ReadJumpInput() => Input.GetKey(KeyCode.Space);

    public bool ReadJumpInputUp() => Input.GetKeyUp(KeyCode.Space);

    public bool IsGrounded() => Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0f, _whatIsGround);

    private void Awake() => GazePistol = new GazePistol(_bulletPrefab, _shootPoint, _shootPower);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
    }
}