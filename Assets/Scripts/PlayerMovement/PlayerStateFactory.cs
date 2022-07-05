

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

    public PlayerBaseState HurricaneKick()
    {
        return new PlayerHurricaneState(_context, this);
    }

    public PlayerBaseState Kick()
    {
        return new PlayerKickState(_context, this);
    }
}
