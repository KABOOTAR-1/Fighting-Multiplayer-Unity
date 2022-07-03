

public class PlayerStateFactory 
{
    PlayerStateManager _context;
    
    public PlayerStateFactory(PlayerStateManager _currentContext)
    {
        _context = _currentContext;
    }

    public PlayerBaseState Idle() {
        return new PlayerIdleState(_context,this);
    }
    public PlayerBaseState Walk() {
        return new PlayerWalkState(_context,this);
    }
    public PlayerBaseState Jump() {
        return new PlayerJumpState(_context,this);
    }
    public PlayerBaseState Grounded() { 
        return new PlayerGroundedState(_context,this);
    }
}
