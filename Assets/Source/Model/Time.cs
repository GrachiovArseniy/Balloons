using System.Collections.Generic;

namespace Balloons.Model
{
    public class Time
    {
        private readonly List<IUpdateable> _entities = new List<IUpdateable>();
        private readonly BalloonSpawner _balloonSpawner;
        private readonly FieldBorder _fieldBorder;
        private readonly PlayerHealth _playerHealth;
        private readonly Score _score;

        public Time(BalloonSpawner balloonSpawner, FieldBorder fieldBorder, PlayerHealth playerHealth, Score score)
        {
            _balloonSpawner = balloonSpawner;
            _fieldBorder = fieldBorder;
            _playerHealth = playerHealth;
            _score = score;
        }

        public void UpdateAll(float deltaTime)
        {
            _balloonSpawner.Update(deltaTime);
            _fieldBorder.Update(deltaTime);
            _entities.ForEach(i => i.Update(deltaTime));
        }

        public void StopGame()
        {
            _fieldBorder.DestroyAll();
            _playerHealth.Clear();
            _score.Clear();
        }

        internal void AddEntity(Transformable entity)
        {
            _entities.Add(entity);
            _fieldBorder.AddEntity(entity);

            entity.Removing += RemoveEntity;
            entity.Destroying += DestroyEntity;
        }

        private void RemoveEntity(Transformable entity)
        {
            entity.Removing -= RemoveEntity;
            entity.Destroying -= DestroyEntity;

            _entities.Remove(entity);
        }

        private void DestroyEntity(Transformable entity)
        {
            entity.Removing -= RemoveEntity;
            entity.Destroying -= DestroyEntity;

            _entities.Remove(entity);

            _score.Add(((dynamic)entity).Type);
        }
    }
}
