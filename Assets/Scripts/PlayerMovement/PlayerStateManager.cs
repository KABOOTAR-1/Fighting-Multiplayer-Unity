using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    bool isWalking;
    Animator animator;
    public bool _isWalking { get { return isWalking; } }
    public bool _isJumping = false;

    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }
    public bool isJumping { get { return _isJumping; } set { _isJumping=value; } }
    public Animator Anime { get { return animator; } }
    private void Awake()
    {
        _states=new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isWalking=Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.A);
        _isJumping = Input.GetButton("Jump");
        currentState.CheckStates();
    }

    public void Move()
    {
        transform.Translate(transform.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 10f);
    }
}
