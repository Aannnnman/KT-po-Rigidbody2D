public abstract class State
{
    protected readonly FiniteStateMachine FiniteStateMachine;

    public State(FiniteStateMachine finiteStateMachine) => FiniteStateMachine = finiteStateMachine;

    public virtual void OnStateEnter() { }

    public virtual void OnStateUpdate() { }

    public virtual void OnStateFixedUpdate() { }

    public virtual void OnStateExit() { }
}
