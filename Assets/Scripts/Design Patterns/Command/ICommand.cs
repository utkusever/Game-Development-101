namespace Design_Patterns.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}