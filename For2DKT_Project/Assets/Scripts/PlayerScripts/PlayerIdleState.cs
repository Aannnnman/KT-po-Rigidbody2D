public class PlayerIdleState : State
{
    private PlayerData _playerData;

    public PlayerIdleState(FiniteStateMachine finiteStateMachine, PlayerData playerData) : base(finiteStateMachine) => _playerData = playerData;

    public override void OnStateUpdate() => IdleStateTransitions();

    private void IdleStateTransitions()
    {
        if (_playerData.ReadMoveInput() != 0f || _playerData.ReadJumpInput())
        {
            FiniteStateMachine.SetState<PlayerMovementState>();
        }

        if (_playerData.ReadShootInput())
        {
            FiniteStateMachine.SetState<PlayerShootingState>();
        }
    }
}
