public class EnemyIdleState : State
{
    private EnemyData _enemyData;

    public EnemyIdleState(FiniteStateMachine finiteStateMachine, EnemyData enemyData) : base(finiteStateMachine) => _enemyData = enemyData;

    public override void OnStateEnter()
    {
        _enemyData.Animator.Play("Mushroom_Idle");
        _enemyData.Health.OnTakeDamage += ToHurtStateTransition;
    }

    public override void OnStateExit() => _enemyData.Health.OnTakeDamage -= ToHurtStateTransition;

    private void ToHurtStateTransition() => FiniteStateMachine.SetState<EnemyHurtState>();
}
