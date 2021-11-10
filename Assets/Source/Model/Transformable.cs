using System;

namespace Balloons.Model
{
    public abstract class Transformable : IUpdateable
    {
        public Transformable(Position position)
        {
            Position = position;
        }

        public event Action Moved;
        public event Action<Transformable> Removing;
        public event Action<Transformable> Destroying; // If a player hits the balloon

        public Position Position { get; private set; }

        public void Destroy()
        {
            Destroying?.Invoke(this);
        }

        internal virtual void MakeAbility() { }

        internal void MoveTo(Position position)
        {
            Position = position;
            Moved?.Invoke();
        }

        internal void Remove()
        {
            Removing?.Invoke(this);
        }

        internal override abstract void Update(float deltaTime);
    }
}