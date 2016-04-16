#region File Description
//-----------------------------------------------------------------------------
// BackgroundScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameStateManagement;
using TexturePackerLoader;
#endregion

namespace Vamps
{
    /// <summary>
    /// The background screen sits behind all the other menu screens.
    /// It draws a background image that remains fixed in place regardless
    /// of whatever transitions the screens on top of it may be doing.
    /// </summary>
    class BackgroundScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        //Texture2D backgroundTexture;
		private SpriteSheet spriteSheet;

		private SpriteRender spriteRender;

		private SpriteFrame backgroundSprite;
		private Vector2 centreScreen;

		
		#endregion

		#region Initialization


		/// <summary>
		/// Constructor.
		/// </summary>
		public BackgroundScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(0.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        /// <summary>
        /// Loads graphics content for this screen. The background texture is quite
        /// big, so we use our own local ContentManager to load it. This allows us
        /// to unload before going from the menus into the game itself, wheras if we
        /// used the shared ContentManager provided by the Game class, the content
        /// would remain loaded forever.
        /// </summary>
        public override void Activate(bool instancePreserved)
        {

			
			if (!instancePreserved)
            {
                if (content == null)
                    content = new ContentManager(ScreenManager.Game.Services, "Content");

               // backgroundTexture = content.Load<Texture2D>(@"Graphics/background");


				//spriteBatch = new SpriteBatch(GraphicsDevice);
				
				
				var spriteSheetLoader = new SpriteSheetLoader(content);
				spriteSheet = spriteSheetLoader.Load("vampspack.png");
				backgroundSprite = this.spriteSheet.Sprite(TexturePackerMonoGameDefinitions.vampsassets.Backgrounds_forest);
			}
        }


        /// <summary>
        /// Unloads graphics content for this screen.
        /// </summary>
        public override void Unload()
        {
            content.Unload();
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the background screen. Unlike most screens, this should not
        /// transition off even if it has been covered by another screen: it is
        /// supposed to be covered, after all! This overload forces the
        /// coveredByOtherScreen parameter to false in order to stop the base
        /// Update method wanting to transition off.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);
        }


        /// <summary>
        /// Draws the background screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
			SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
			spriteRender = new SpriteRender(spriteBatch);

			Viewport viewport = ScreenManager.GraphicsDevice.Viewport;
           // Rectangle fullscreen = new Rectangle(0, 0, viewport.Width, viewport.Height);


			
			Rectangle fullscreen = new Rectangle(viewport.Width / 2, viewport.Height / 2, viewport.Width, viewport.Height);
			centreScreen = new Vector2(viewport.Width / 2, viewport.Height / 2);
			//centreScreen = new Vector2(viewport.Width / 2, viewport.Height / 2);

			//this.spriteRender.Draw(this.backgroundSprite, this.centreScreen,null,0,1,SpriteEffects.None);




			spriteBatch.Begin();

			//new code for texture loader
			//spriteRender.Draw(this.backgroundSprite, fullscreen, null, 0, SpriteEffects.None);
			spriteRender.Draw(backgroundSprite, centreScreen, null, 0, 2, SpriteEffects.None);
			// spriteBatch.Draw(backgroundTexture, fullscreen,
			//                new Color(TransitionAlpha, TransitionAlpha, TransitionAlpha));

			spriteBatch.End();
        }


        #endregion
    }
}
