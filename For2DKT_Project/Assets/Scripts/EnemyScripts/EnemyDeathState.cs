public class EnemyDeathState : State
{
    private EnemyData _enemyData;

    public EnemyDeathState(FiniteStateMachine finiteStateMachine, EnemyData enemyData) : base(finiteStateMachine) => _enemyData = enemyData;

    public override void OnStateEnter() => Die();

    private void Die()
    {
        _enemyData.Animator.Play("Mushroom_Die");
        _enemyData.Collider.direction = UnityEngine.CapsuleDirection2D.Horizontal;
        _enemyData.EnemyUI.SetActive(false);
    }
}