using System;

namespace Balloons.Model
{
    public class PlayerHealth
    {
        private readonly BalloonVisitor _balloonVisitor = new BalloonVisitor();

        public event Action Changed;

        public event Action GameLosted;

        public int Value => _balloonVisitor.PlayerHealth;

        internal void Damage(BalloonType balloon)
        {
            _balloonVisitor.Visit(balloon);

            if (Value <= 0)
            {
                _balloonVisitor.PlayerHealth = 0;
                GameLosted?.Invoke();
            }

            Changed?.Invoke();
        }

        internal void Clear()
        {
            _balloonVisitor.PlayerHealth = Config.StartPlayerHealth;
            Changed?.Invoke();
        }

        private class BalloonVisitor : IBalloonVisitor
        {
            public int PlayerHealth = Config.StartPlayerHealth;

            public void Visit(LittleBalloon balloon)
            {
                PlayerHealth -= Config.LittleDamage;
            }

            public void Visit(MediumBalloon balloon)
            {
                PlayerHealth -= Config.MediumDamage;
            }

            public void Visit(BigBalloon balloon)
            {
                PlayerHealth -= Config.BigDamage;
            }

            public void Visit(BalloonType balloon)
            {
                Visit((dynamic)balloon);
            }
        }
    }
}
