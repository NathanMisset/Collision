﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

namespace CollisionBalls {
    class Ball : SpriteGameObject {
        private float radius;
        private Vector2 acceleration;
        private Vector2 gravity;
        private float inelasticFriction;
        private Vector2 afstandVector;
        private float afstand;
        private Vector2 collisionNormal;
        private Vector2 resetVector;
        private Vector2 parrallelVelocity;

        public Ball(string assetName, Vector2 position, Vector2 velocity, Vector2 acceleration, Vector2 gravity, float radius, float inelastic = 1f)
            : base(assetName, 0, "ball") {
            PerPixelCollisionDetection = false;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            Gravity = gravity;
            Origin = Center;
            Radius = radius;
            scale = radius * 2 / Width;
            InelasticFriction = inelastic;
        }

        public override void Update(GameTime gameTime) {
            Bounce();
            base.Update(gameTime);
        }

        public void ResolveCollisionWith(Ball other) {
            //Step 1: calculate the vector from the position of this ball to the other ball
            afstandVector = position - other.position;
            //Step 2: calculate the distance between the two balls
            afstand = afstandVector.Length() - (other.Radius + this.radius); ;
            //Step 3: if there is a collision
            if (afstand < 0)
            {

                //Step 4: calculate the collision normal
                collisionNormal = afstandVector;
                collisionNormal.Normalize();

                //Step 5: Resolve interpenetration
                resetVector = collisionNormal;
                resetVector *= afstand;
                position -= resetVector / 2;
                other.position += resetVector / 2;

                //Step 6: calculate the velocity component parallel to normal
                parrallelVelocity = (velocity * collisionNormal) * collisionNormal;
                
                //Step 7: calculate the changeVelocity


                //Step 8: change the velocities (assume equal mass)
            }
        }

        public float InelasticFriction {
            get { return inelasticFriction; }
            set { inelasticFriction = value; }
        }

        public float Radius {
            get { return radius; }
            set { radius = value; }
        }

        public Vector2 Acceleration {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public Vector2 Gravity {
            get { return gravity; }
            set { gravity = value; }
        }

        private void Bounce() {
            if (position.X < radius) {
                position.X = radius;
                velocity.X *= -inelasticFriction;
            }
            if (position.X > GameEnvironment.Screen.X - radius) {
                position.X = GameEnvironment.Screen.X - radius;
                velocity.X *= -inelasticFriction;
            }
            if (position.Y < radius) {
                position.Y = radius;
                velocity.Y *= -inelasticFriction;
            }
            if (position.Y > GameEnvironment.Screen.Y - radius) {
                position.Y = GameEnvironment.Screen.Y - radius;
                velocity.Y *= -inelasticFriction;
            }

            Velocity += Gravity;
        }
    }
}