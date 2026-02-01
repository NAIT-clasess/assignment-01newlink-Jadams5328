using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;


namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D picture;
    Texture2D background;

    SimpleAnimation antAnimation;

    Vector2 antPosition = new Vector2(400, 400);
    float antSpeed = 100f;
    bool movingRight = true;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        background = Content.Load<Texture2D>("picnic");
        picture = Content.Load<Texture2D>("pancake1");
        Texture2D antTexture = Content.Load<Texture2D>("ant");
        antAnimation = new SimpleAnimation(antTexture, 96, 101, 4, 6f);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        antAnimation.Update(gameTime);

        if (movingRight)
        {
            antPosition.X += antSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (antPosition.X > _graphics.PreferredBackBufferWidth - 96)
            movingRight = false;
        }
        else
        {
            antPosition.X -= antSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (antPosition.X <0)
                movingRight = true;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
        _spriteBatch.Draw(picture, new Vector2(20, 100), Color.White);

        antAnimation.Draw(_spriteBatch, antPosition, SpriteEffects.None);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
