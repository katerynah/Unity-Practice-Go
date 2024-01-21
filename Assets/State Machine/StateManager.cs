using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager : MonoBehaviour
{
    //void Awake() { }

    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;

    protected bool  IsTransitioningState = false;

    void Start() 
    {
        CurrentState.EnterState();
    }

    void Update() 
    {
        EState nextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState stateKey) 
    {
        IsTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[stateKey];
        CurrentState.EnterState();
        IsTransitioningState = false;
    }

    void OnTriggerEnter(Collider other) 
    {
        CurrentState.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other) 
    {
        CurrentState.OnTriggerStay(other);
    }

    void OntriggerExit(Collider other) 
    {
        CurrentState.OnTriggerExit(other);
    }

    /* void OnCollisionEnter(Collider other) { }

     void OnCollisionStay(Collider other) { }

     void oncollisionexit(collider other) { }*/


}
