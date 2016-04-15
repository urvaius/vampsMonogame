using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vamps.Utility;

namespace Vamps.Entities
{
	public class Butterfly : Entity
	{

		public int Width
		{
			get { return EntityAnimation.FrameWidth; }
		}

		//get the height of the enemy ship
		public int Height
		{
			get { return EntityAnimation.FrameHeight; }
		}

		
			public override void Initialize(Animation animation,Vector2 position)
		{
			base.Initialize(animation,position);

			//load enemy ship texture
			EntityAnimation = animation;
			//set the position of enemy
			Position = position;
			// initizlize the enemy to be active
			Active = true;
			//set the helath
			Health = 20;
			//set damage it can do
			Damage = 10;
			// set how fast the enemy moves
			entityMoveSpeed = 3f;
			//set the score value
			Value = 200;
			OnScreen = true;


		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			//the enemy always move to the left so decrement its xposition
			Position.X -= entityMoveSpeed;
			//update the position of the animation
			EntityAnimation.Position = Position;
			//update animation
			EntityAnimation.Update(gameTime);
			//if the enemy is past the screen or its health reaches 0 then deactivate it
			if (Position.X < -Width)
			{
				//by setting the active flat to false the game will remove this object


				OnScreen = false;
			}
			if (Health <= 0)
			{
				Active = false;
				OnScreen = false;
			}


		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);



		}


	}
}
