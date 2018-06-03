#region Using Statements

using Microsoft.Xna.Framework;

#endregion

namespace CollisionBalls{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CollisionBalls : GameEnvironment {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            base.LoadContent();
            Screen = new Point(1200, 800);
            ApplyResolutionSettings();

            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.SwitchTo("PlayingState");

            IsMouseVisible = true;
        }
    }
}
