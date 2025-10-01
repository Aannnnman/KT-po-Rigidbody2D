using UnityEngine;

public class EnemyFiniteStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;

    private FiniteStateMachine _finiteStateMachine;

    private void Awake()
    {
        _finiteStateMachine = new FiniteStateMachine();

        _finiteStateMachine.AddState(new EnemyIdleState(_finiteStateMachine, _enemyData));
        _finiteStateMachine.AddState(new EnemyHurtState(_finiteStateMachine, _enemyData));
        _finiteStateMachine.AddState(new EnemyDeathState(_finiteStateMachine, _enemyData));

        _finiteStateMachine.SetState<EnemyIdleState>();

        _enemyData.Health.OnHealthZero += _finiteStateMachine.SetState<EnemyDeathState>;
    }

    private void Update() => _finiteStateMachine.StateUpdate();

    private void FixedUpdate() => _finiteStateMachine.StateFixedUpdate();

    private void OnDestroy() => _enemyData.Health.OnHealthZero -= _finiteStateMachine.SetState<EnemyDeathState>;
}
