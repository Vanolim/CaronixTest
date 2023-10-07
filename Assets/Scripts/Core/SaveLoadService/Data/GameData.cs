using System;
using System.Runtime.Serialization;

namespace Core
{
    [Serializable]
    public class GameData : ICloneable
    {
        public int CoinsCount { get; set; }
        public string PlayerName { get; set; }
        
        public GameData()
        {
            Initialize();
        }

        [OnDeserializing]
        private void SetDefault(StreamingContext sc)
        {
            Initialize();
        }

        private void Initialize()
        {
            CoinsCount = default;
            PlayerName = default;
        }

        public object Clone() => MemberwiseClone();
    }
}