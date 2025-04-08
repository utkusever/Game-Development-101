namespace Design_Patterns.States
{
    public class EnemyState : State
    {
        protected Enemy enemy;

        public EnemyState(Enemy enemy)
        {
            this.enemy = enemy;
        }
    }
}