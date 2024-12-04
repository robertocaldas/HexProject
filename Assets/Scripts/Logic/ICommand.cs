namespace johnny.HexProject.Logic
{
    /// <summary>
    /// Each simulation step provides a list of commands that were executed.
    /// </summary>
    public interface ICommand {}
    
    // TODO: Add things to help with visualization
    public struct MoveCommand : ICommand {}
    
    public struct AttackCommand : ICommand {}
}