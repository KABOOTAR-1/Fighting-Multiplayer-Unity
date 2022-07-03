using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }
    private void Awake()
    {
        _states=new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
