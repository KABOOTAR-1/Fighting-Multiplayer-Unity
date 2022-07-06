

public class PlayerStateFactory 
{
    PlayerStateManager _context;
  
    public PlayerStateFactory(PlayerStateManager _currentContext)
    {
        _context = _currentContext;
     
    }

  
    public PlayerBaseState Walk() {
        return new PlayerWalkState(_context,this);
    }
    public PlayerBaseState Jump() {
        return new PlayerJumpState(_context,this);
    }

    public PlayerBaseState Attack(Attacked state)
    {
        return new PlayerAttackState(_context,this,state) ;
    }
    public PlayerBaseState HurricaneKick()
    {
        return new PlayerHurricaneState(_context, this);
    }

    public PlayerBaseState Kick()
    {
        return new PlayerKickState(_context, this);
    }

    public PlayerBaseState Punch()
    {
        return new PlayerPunchState(_context, this);
    }

    public PlayerBaseState FireBall()
    {
        return new PlayerFireBallState(_context, this);
    }
}
