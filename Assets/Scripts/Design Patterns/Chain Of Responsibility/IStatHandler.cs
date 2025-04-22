namespace Design_Patterns.Chain_Of_Responsibility
{
    public interface IStatHandler
    {
        void SetNext(IStatHandler next);
        void Handle(ref float damageValue);
    }
}