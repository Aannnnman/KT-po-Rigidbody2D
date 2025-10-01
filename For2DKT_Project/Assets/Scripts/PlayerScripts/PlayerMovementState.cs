using UnityEngine;

public class PlayerMovementState : State
{
    private PlayerData _playerData;
    private float _coyoteTime = 0.05f;
    private float _jumpCutMultiplier = 0.5f;
    private float _fallMultiplier = 2.5f;
    private float _lowJumpMultiplier = 2f;
    private float _airControlFactor = 1f;
    private float _coyoteTimeCounter;

    public PlayerMovementState(FiniteStateMachine finiteStateMachine, PlayerData playerData) : base(finiteStateMachine) => _playerData = playerData;

    public override void OnStateUpdate()
    {
        if (_playerData.IsGrounded())
            _coyoteTimeCounter = _coyoteTime;
        else
            _coyoteTimeCounter -= Time.deltaTime;

        if (_playerData.ReadJumpInput() && _coyoteTimeCounter > 0f)
            Jump();

        if (_playerData.ReadJumpInputUp() && _playerData.Rigidbody.velocity.y > 0)
        {
            _playerData.Rigidbody.velocity = new Vector2(
                _playerData.Rigidbody.velocity.x,
                _playerData.Rigidbody.velocity.y * _jumpCutMultiplier
            );
        }

        MovementAnimationUpdate();
        ApplyGravityModifiers();
        Move();
        MovementStateTransitions();
    }

    private void Jump()
    {
        _playerData.Rigidbody.velocity = new Vector2(_playerData.Rigidbody.velocity.x, _playerData.JumpForce);
        _coyoteTimeCounter = 0f;
    }

    private void Move()
    {
        float controlFactor = _playerData.IsGrounded() ? 1f : _airControlFactor;
        _playerData.Rigidbody.velocity = new Vector2(_playerData.ReadMoveInput() * _playerData.MoveSpeed * controlFactor, _playerData.Rigidbody.velocity.y);
    }

    private void ApplyGravityModifiers()
    {
        if (_playerData.Rigidbody.velocity.y < 0)
        {
            _playerData.Rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_playerData.Rigidbody.velocity.y > 0 && !_playerData.ReadJumpInput())
        {
            _playerData.Rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void MovementAnimationUpdate()
    {
        _playerData.Animator.SetBool("Jump", !_playerData.IsGrounded());
        _playerData.Animator.SetBool("Fall", _playerData.Rigidbody.velocity.y < 0 && !_playerData.IsGrounded());
        _playerData.Animator.SetBool("Run", _playerData.ReadMoveInput() != 0f && _playerData.IsGrounded() && !_playerData.ReadShootInput());
    }

    private void MovementStateTransitions()
    {
        if (_playerData.ReadMoveInput() == 0f && _playerData.IsGrounded())
        {
            FiniteStateMachine.SetState<PlayerIdleState>();
        }

        if (_playerData.ReadShootInput() && _playerData.IsGrounded() || _playerData.ReadShootInput() && _playerData.ReadMoveInput() != 0f && _playerData.IsGrounded())
        {
            FiniteStateMachine.SetState<PlayerShootingState>();
        }
    }
}
