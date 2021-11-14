using System;

namespace Balloons.Model
{
    public abstract class Spawner<T> : IUpdateable
    {
        protected float multiplier = 1;
        private float _timeOut;

        private Time _time;

        public event Action<T> EntitySpawned;

        protected virtual float EntitiesPerSecond { get; private set; }

        public void SetTime(Time time)
        {
            _time = time;
        }

        internal override void Update(float deltaTime)
        {
            _timeOut += deltaTime;

            if (_timeOut > (1 / (EntitiesPerSecond * multiplier)))
            {
                int balloonType = new Random().Next(1, 4);

                switch (balloonType)
                {
                    case 1:
                        Spawn(new LittleBalloon());
                        break;

                    case 2:
                        Spawn(new MediumBalloon());
                        break;

                    case 3:
                        Spawn(new BigBalloon());
                        break;
                }

                _timeOut = 0;
            }

            multiplier += Config.SpawnerAcceleration;
        }

        protected virtual Transformable SpawnEntity(BalloonType balloonType)
        {
            return null;
        }

        private void Spawn(BalloonType balloonType)
        {
            Transformable newEntity = SpawnEntity(balloonType);
            _time.AddEntity(newEntity);

            EntitySpawned?.Invoke((dynamic)newEntity);
        }
    }
}
