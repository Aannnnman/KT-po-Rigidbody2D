using System.Collections;
using UnityEngine;

public class PlayerShootingState : State
{
    private PlayerData _playerData;

    public PlayerShootingState(FiniteStateMachine finiteStateMachine, PlayerData playerData) : base(finiteStateMachine) => _playerData = playerData;

    public override void OnStateEnter()
    {
        _playerData.Rigidbody.velocity = Vector2.zero;
        _playerData.Animator.SetBool("Shoot", true);
        _playerData.StartCoroutine(Shoot());
    }

    public override void OnStateExit() => _playerData.Animator.SetBool("Shoot", false);

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        _playerData.GazePistol.Shoot();
        _playerData.StartCoroutine(ShootingStateTransition());
    }

    private IEnumerator ShootingStateTransition()
    {
        yield return new WaitForSeconds(0.2f);
        FiniteStateMachine.SetState<PlayerIdleState>();
    }
}
