using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class EnemyMovement : IInitializable,
         ILateDisposable
    {
        private readonly Enemy _enemy;
        private Tween _tween;
        
        private const int _moveBorder = 5;
        private const float _moveTime = 1.5f;

        public EnemyMovement(Enemy enemy)
        {
            _enemy = enemy;
        }

        private void SetEnemyToStartPosition()
        {
            Transform enemyView = _enemy.EnemyView.transform;
            Vector3 enemyPosition = enemyView.position;
            
            enemyPosition = new Vector3(enemyPosition.x - _moveBorder, enemyPosition.y, enemyPosition.z);
            enemyView.position = enemyPosition;
        }

        private void StartMove()
        {
            _tween = _enemy.EnemyView.transform.DOMoveX(_moveBorder, _moveTime)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Yoyo);
            _tween.Play();
        }

        public void Initialize()
        {
            SetEnemyToStartPosition();
            StartMove();
        }

        public void LateDispose()
        {
            _tween.Kill();
        }
    }
}