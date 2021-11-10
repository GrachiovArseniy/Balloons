using System;

namespace Balloons.Model
{
    public class Balloon : Transformable
    {
        public Balloon(BalloonType type, float speed, Position position, PlayerHealth playerHealth) : base(position) 
        {
            if (speed <= 0)
                throw new ArgumentOutOfRangeException(nameof(speed));

            Type = type;
            _playerHealth = playerHealth;
            _speed = speed;
        }

        public readonly UnityEngine.Color Color = Config.BalloonColors[new Random().Next(0, Config.BalloonColors.Count)];
        public readonly BalloonType Type;

        private readonly PlayerHealth _playerHealth;
        private readonly float _speed;

        internal override void Update(float deltaTime)
        {
            var newPosition = Position + new Position(0, -_speed * deltaTime);
            MoveTo(newPosition);
        }

        // Deals damage, if balloon goes off the screen
        internal override void MakeAbility()
        {
            _playerHealth.Damage(Type);
        }
    }
}