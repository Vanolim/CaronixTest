namespace Battle
{
    public class Enemy
    {
        private readonly Health _health;
        private readonly EnemyBarView _enemyBarView;

        public IHealth Health => _health;
        public EnemyView EnemyView { get; }

        public EnemyHealthBarView EnemyHealthBarView => _enemyBarView.EnemyHealthBarView;

        public Enemy(Health health, EnemyView enemyView, EnemyBarView enemyBarView)
        {
            _health = health;
            EnemyView = enemyView;
            _enemyBarView = enemyBarView;
        }

        public void TakeDamage(int value) => _health.DecreaseValue(value);
    }
}