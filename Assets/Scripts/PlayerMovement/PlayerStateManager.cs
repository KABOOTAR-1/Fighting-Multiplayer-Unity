using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    PlayerStateFactory _states;
    bool isWalking;
    Animator animator;
    bool iSAttacking=false;
    bool _isJumping = false;
    Attacked state = Attacked.Idle;
    [SerializeField]
    GameObject FireBallPrefab;
    [SerializeField]
    Transform FireballPos;
    [SerializeField] public HitResponder[] hr=new HitResponder[4];
    public bool _isWalking { get { return isWalking; } }
    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }
    public bool isJumping { get { return _isJumping; } set { _isJumping=value; } }
    public Animator Anime { get { return animator; } }
    public bool _isAttacking { get { return iSAttacking; } set { iSAttacking=value; } }
    public Attacked states { get { return state; } set { states = value; } }
    private void Awake()
    {
        _states=new PlayerStateFactory(this);
        _currentState = _states.Walk();
        _currentState.EnterState();
        animator = GetComponent<Animator>();
        hr = GetComponentsInChildren<HitResponder>();
       
    }
    void Start()
    {
        Time.timeScale = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(Inputs());        
    }

    IEnumerator Inputs()
    {
        isWalking = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
        _isJumping = Input.GetButtonDown("Jump");
        AttackInput();
        Anime.SetBool("IsAttacking", _isAttacking);
        currentState.CheckStates();
        yield return null;
    }
    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            iSAttacking = true;
            state = Attacked.Fireball;
            hr[2].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            iSAttacking = true;
            state = Attacked.HurricaneKick;
            hr[1].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            iSAttacking = true;
            state = Attacked.Punch;
            hr[3].enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            iSAttacking = true;
            state = Attacked.Kick;
            hr[0].enabled = true;
        }
        

    }

    public void InstanatiteFireball()
    {
        Instantiate(FireBallPrefab, FireballPos.position ,Quaternion.identity).AddComponent<FireBall>(); ;
    }

    public void Kick()
    {
        hr[3].enabled = false;
        
    }
}   
 