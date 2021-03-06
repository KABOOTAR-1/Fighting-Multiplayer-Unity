using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    public Vector3 dir;
    [SerializeField] public HitResponder[] hr=new HitResponder[4];
    public InstantiateFireball fireballmove;
    public bool _isWalking { get { return isWalking; } }
    public PlayerBaseState currentState { get { return _currentState; } set { _currentState = value; } }
    public bool isJumping { get { return _isJumping; } set { _isJumping=value; } }
    public Animator Anime { get { return animator; } }
    public bool _isAttacking { get { return iSAttacking; } set { iSAttacking=value; } }
    public Attacked states { get { return state; } set { states = value; } }
    PhotonView myview;
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
        dir = Vector3.Normalize(transform.right);
        fireballmove = transform.GetComponentInChildren<InstantiateFireball>();
        myview = GetComponent<PhotonView>();
        //Time.timeScale = 0.2f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myview.IsMine)
            Inputs();       
    }

    [PunRPC]
    void Inputs()
    {
        isWalking = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A);
        _isJumping = Input.GetButtonDown("Jump");
        AttackInput();
        Anime.SetBool("IsAttacking", _isAttacking);
        currentState.CheckStates();
        
    }
    void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            iSAttacking = true;
            state = Attacked.Fireball;
            //hr[2].enabled = true;
            //hr[2].m_attack = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            iSAttacking = true;
            state = Attacked.HurricaneKick;
            myview.RPC("star", RpcTarget.All, 1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            iSAttacking = true;
            state = Attacked.Punch;
            myview.RPC("star", RpcTarget.All, 3);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            iSAttacking = true;
            state = Attacked.Kick;
            myview.RPC("star", RpcTarget.All, 0);
        }
        

    }

    [PunRPC]
    void star(int i)
    {
        hr[i].enabled = true;
        hr[i].m_attack = true;
    }

   public void Fire()
    {
        fireballmove.InstanatiteFireBall(FireBallPrefab);
    }
}   
 