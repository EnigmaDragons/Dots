﻿using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;
using MonoDragons.Core.PhysicsEngine;

namespace Dots.Characters
{
    public class EnemyBlob : Blob, IAutomaton
    {
        private static readonly RandomColor Colorizer = new RandomColor();

        private const int MinimumDistance = 100;
        private const int MaximumDistance = 200;

        private readonly Physics _physics = new Physics();

        private Vector2 _targetLoc;

        public EnemyBlob() : base(Colorizer.Next())
        {
            GenerateNewTargetPosition();
        }

        public void Update(TimeSpan delta)
        {
            _physics.MoveTowards(_center, _targetLoc, _speed, delta, x => _center = x);
            _physics.Arrive(_center, _targetLoc, GenerateNewTargetPosition);
        }

        private void GenerateNewTargetPosition()
        {
            _targetLoc = _physics.GetLocation(_center, new RandomDirection().Get(), Rng.Int(MinimumDistance, MaximumDistance));
        }
    }
}
