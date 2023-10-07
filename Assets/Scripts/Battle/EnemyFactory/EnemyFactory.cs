using SearchEnemy;
using UnityEngine;

namespace Battle
{
    public class EnemyFactory
    {
        private Health GetHealth(Vector2 minMaxHealthValue)
        {
            int randomValue = Random.Range((int)minMaxHealthValue.x, (int)minMaxHealthValue.y + 1);
            return new Health(randomValue);
        }

        private EnemyView GetEnemyView(EnemyViewContainer enemyViewContainer, Transform container)
        {
            EnemyView[] enemyViews = enemyViewContainer.EnemyViews;
            return Object.Instantiate(enemyViews[Random.Range(0, enemyViews.Length)], container);
        }
        
        private EnemyBarView GetEnemyBarView(EnemyBarView enemyBarView, EnemyInfo enemyInfo)
        {
            EnemyBarView enemyBarViewInstance = Object.Instantiate(enemyBarView);
            enemyBarViewInstance.SetAvatar(enemyInfo.Avatar);
            enemyBarViewInstance.SetName(enemyInfo.Name);
            return enemyBarViewInstance;
        }

        public Enemy GetEnemy(EnemyViewContainer enemyViewContainer, EnemyBarView enemyBarView,
            EnemyData enemyData, Transform container, EnemyInfo enemyInfo)
        {
            return new Enemy(GetHealth(enemyData.MinMaxHealthValue),
                GetEnemyView(enemyViewContainer, container),
                GetEnemyBarView(enemyBarView, enemyInfo));
        }
    }
}