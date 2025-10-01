using System.Collections;
using UnityEngine;

public class EnemyHurtState : State
{
    private EnemyData _enemyData;

    public EnemyHurtState(FiniteStateMachine finiteStateMachine, EnemyData enemyData) : base(finiteStateMachine) => _enemyData = enemyData;

    public override void OnStateEnter()
    {
        _enemyData.Animator.SetTrigger("Hurt");
        _enemyData.StartCoroutine(ToIdleStateTransition());
    }

    public override void OnStateExit() => _enemyData.Animator.ResetTrigger("Hurt");

    private IEnumerator ToIdleStateTransition()
    {
        yield return new WaitForSeconds(0.3f);
        FiniteStateMachine.SetState<EnemyIdleState>();
    }
}
