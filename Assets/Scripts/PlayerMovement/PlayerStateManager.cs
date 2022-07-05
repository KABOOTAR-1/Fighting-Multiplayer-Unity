using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    bool isWalking;
    Animator animator;
    float x = 0;
    bool iSAttacking=false;
    public bool _isWalking { get { return isWalking; } }
    public bool _isJumping = false;

    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }
    public bool isJumping { get { return _isJumping; } set { _isJumping=value; } }
    public Animator Anime { get { return animator; } }
    public bool _isAttacking { get { return iSAttacking; } set { iSAttacking=value; } }
    private void Awake()
    {
        _states=new PlayerStateFactory(this);
        _currentState = _states.Walk();
        _currentState.EnterState();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        isWalking =Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A);
        _isJumping = Input.GetButtonDown("Jump");
        _isAttacking = Input.GetKeyDown(KeyCode.I);
        Anime.SetBool("IsAttacking", _isAttacking);
        currentState.CheckStates();
    }

   
}
