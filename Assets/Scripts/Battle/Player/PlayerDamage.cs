using UnityEngine;
using Zenject;

namespace Battle
{
    public class PlayerDamage : IInitializable,
        ILateDisposable
    {
        private readonly PlayerData _playerData;
        private readonly Enemy _enemy;
        private readonly PlayerInput _playerInput;
        private readonly Camera _camera;
        
        private (int, int) _minMaxDamage;

        public PlayerDamage(PlayerData playerData, Enemy enemy, PlayerInput playerInput)
        {
            _playerData = playerData;
            _enemy = enemy;
            _playerInput = playerInput;
            _camera = Camera.main;
        }

        private void TakeDamage(Vector2 inputPosition)
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(inputPosition), Vector2.down);
            if (hit.collider != null && hit.collider.TryGetComponent(out EnemyTarget enemyTarget))
            {
                _enemy.TakeDamage(GetRandomDamageValue());
            }
        }

        private int GetRandomDamageValue() =>
            Random.Range(_minMaxDamage.Item1, _minMaxDamage.Item2);

        public void Initialize()
        {
            _minMaxDamage = ((int)_playerData.MinMaxDamage.x, (int)_playerData.MinMaxDamage.y + 1);
            _playerInput.OnInput += TakeDamage;
        }

        public void LateDispose()
        {
            _playerInput.OnInput -= TakeDamage;
        }
    }
}