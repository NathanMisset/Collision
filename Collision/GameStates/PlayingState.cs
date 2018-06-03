using Microsoft.Xna.Framework;
using System;

namespace CollisionBalls {
    class PlayingState : GameObjectList {
        const float EARTH_GRAVITY = 9.807f, MARS_GRAVITY = 3.711f, MOON_GRAVITY = 1.62f;
        GameObjectList balls;

        public PlayingState()
            : base() {
            SpriteGameObject background = new SpriteGameObject("calligraphy");
            this.Add(background);
            balls = new GameObjectList(0, "balls");

            Random random = new Random();
            for (int i = 0; i < 20; i++) {
                int randomsprite = random.Next(1, 4);
                string assetName = "spr_ball_green";
                if (randomsprite == 1)
                    assetName = "spr_ball_green";
                if (randomsprite == 2)
                    assetName = "spr_ball_blue";
                if (randomsprite == 3)
                    assetName = "spr_ball_red";

                Vector2 aPositon = new Vector2(random.Next(100, 700), random.Next(100, 500));
                Vector2 aVelocity = new Vector2(((float)random.NextDouble() - 0.5f) * 10, ((float)random.NextDouble() - 0.5f) * 10);

                balls.Add(new Ball(assetName, aPositon, aVelocity, Vector2.Zero, new Vector2(0, EARTH_GRAVITY), 15f, 0.85f));
            }
            this.Add(balls);
        }

        protected void HandleCollisions() {
            for (int i = 0; i < balls.Children.Count; i++) {
                Ball ball1 = balls.Children[i] as Ball;
                for (int j = i + 1; j < balls.Children.Count; j++) {
                    Ball ball2 = balls.Children[j] as Ball;
                    ball1.ResolveCollisionWith(ball2);
                }
            }
        }

        public override void Update(GameTime gameTime) {
            HandleCollisions();
            base.Update(gameTime);
        }
    }
}