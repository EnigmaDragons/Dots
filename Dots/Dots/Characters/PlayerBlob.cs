using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;

namespace Dots.Characters
{
    public class PlayerBlob : Blob, IAutomaton
    {
        private readonly Physics _physics = new Physics();

        private Direction _direction;

        public PlayerBlob(Color color) : base(color)
        {
            Input.OnDirection(x => _direction = x);
        }

        public void Update(TimeSpan delta)
        {
            _physics.Move(_center, new Vector2((float)_direction.HDir, (float)_direction.VDir), _speed, delta, x => _center = x);
        }
    }
}
