namespace Balloons.Model
{
    public interface IBalloonVisitor
    {
        void Visit(LittleBalloon balloon);
        void Visit(MediumBalloon balloon);
        void Visit(BigBalloon balloon);
        void Visit(BalloonType balloon);
    }
}
