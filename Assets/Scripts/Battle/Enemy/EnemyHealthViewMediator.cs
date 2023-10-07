using Zenject;

namespace Battle
{
    public class EnemyHealthViewMediator : IInitializable,
        ILateDisposable
    {
        private readonly Enemy _enemy;

        public EnemyHealthViewMediator(Enemy enemy)
        {
            _enemy = enemy;
        }

        private void UpdateView(float healthValueDelta) => 
            _enemy.EnemyHealthBarView.SetDelta(healthValueDelta);

        public void Initialize()
        {
            _enemy.Health.OnValueChangeDelta += UpdateView;
        }

        public void LateDispose()
        {
            _enemy.Health.OnValueChangeDelta -= UpdateView;
        }
    }
}