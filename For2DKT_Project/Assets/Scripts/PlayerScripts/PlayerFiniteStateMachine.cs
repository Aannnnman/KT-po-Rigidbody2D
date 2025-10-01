using UnityEngine;

public class PlayerFiniteStateMachine : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private FiniteStateMachine _finiteStateMachine;

    private void Awake()
    {
        _finiteStateMachine = new FiniteStateMachine();

        _finiteStateMachine.AddState(new PlayerIdleState(_finiteStateMachine, _playerData));
        _finiteStateMachine.AddState(new PlayerMovementState(_finiteStateMachine, _playerData));
        _finiteStateMachine.AddState(new PlayerShootingState(_finiteStateMachine, _playerData));

        _finiteStateMachine.SetState<PlayerIdleState>();
    }

    private void Update() => _finiteStateMachine.StateUpdate();

    private void FixedUpdate() => _finiteStateMachine.StateFixedUpdate();
}
