using System;

namespace Balloons.Model
{
    public class Score
    {
        public int Value => Convert.ToInt32(_balloonVisitor.AccumulatedScore);

        public event Action Changed;

        private readonly BalloonVisitor _balloonVisitor = new BalloonVisitor();

        internal void Add(BalloonType value)
        {
            _balloonVisitor.Visit(value);
            Changed?.Invoke();
        }

        internal void Clear()
        {
            _balloonVisitor.AccumulatedScore = 0;
            Changed?.Invoke();
        }

        private class BalloonVisitor : IBalloonVisitor
        {
            public uint AccumulatedScore = 0;

            public void Visit(LittleBalloon balloon)
            {
                AccumulatedScore += Config.BigScore;
            }

            public void Visit(MediumBalloon balloon)
            {
                AccumulatedScore += Config.MediumScore;
            }

            public void Visit(BigBalloon balloon)
            {
                AccumulatedScore += Config.LittleScore;
            }

            public void Visit(BalloonType balloon)
            {
                Visit((dynamic)balloon);
            }
        }
    }
}
