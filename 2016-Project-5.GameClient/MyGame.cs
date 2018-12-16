using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Linq;
using _2016_Project_5.ECS;
using _2016_Project_5.GameClient.Models.Enums;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Utils;
using _2016_Project_5.GameClient.Models.Factories;
using _2016_Project_5.GameClient.Models.Systems;
using _2016_Project_5.GameClient.Models.Systems.Models;
using System.Collections.Generic;
using _2016_Project_5.Graphic;
using _2016_Project_5.Lua;
using System.Threading;
using EmptyKeys.UserInterface.Generated;
using _2016_Project_5.UILibrary;
using EmptyKeys.UserInterface;
using EmptyKeys.UserInterface.Media;

namespace _2016_Project_5.GameClient
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MyGame : Game
    {
        private static MyGame _instance;

        public static MyGame Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyGame();
                }

                return _instance;
            }
        }

        private GraphicsDeviceManager _graphics;
        private MySpriteBatch _spriteBatch;
        private Stopwatch _stopwatch;
        private double _updateTime;

        private Thread _threadLua;

        public TextureManager TextureManager { get; private set; }
        public World World { get; private set; }
        public LuaInterpreter Lua { get; private set; }

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }
        public int SpriteWidth { get; private set; }
        public int SpriteHeight { get; private set; }

        public const int MapWidth = 10;
        public const int MapHeight = 10;

        private EmptyKeys.UserInterface.Generated.BasicUI _basicUI;
        private BasicUIViewModel _viewModel;

        public MyGame()
        {
            ScreenWidth = 1366;
            ScreenHeight = 768;
            SpriteWidth = 32;
            SpriteHeight = 32;

            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            //_graphics.PreferMultiSampling = true;
            //_graphics.GraphicsProfile = GraphicsProfile.HiDef;
            //_graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
            _graphics.DeviceCreated += graphics_DeviceCreated;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        void graphics_DeviceCreated(object sender, EventArgs e)
        {
            Engine engine = new MonoGameEngine(GraphicsDevice, ScreenWidth, ScreenHeight);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new MySpriteBatch(GraphicsDevice);

            Utils.FontManager.Instance.LoadFonts(this);

            EmptyKeys.UserInterface.FontManager.DefaultFont = Engine.Instance.Renderer.CreateFont(Utils.FontManager.Instance.GetFont(FontEnum.ARIAL_16));
            Viewport viewport = GraphicsDevice.Viewport;
            _basicUI = new EmptyKeys.UserInterface.Generated.BasicUI();
            _viewModel = new BasicUIViewModel();
            _basicUI.DataContext = _viewModel;

            EmptyKeys.UserInterface.FontManager.Instance.LoadFonts(Content, "Fonts/");
            ImageManager.Instance.LoadImages(Content);
            SoundManager.Instance.LoadSounds(Content);

            var spriteSheet = Content.Load<Texture2D>("Textures/spritesheet");
            TextureManager = new TextureManager(spriteSheet, 32, 32);

            Lua = new LuaInterpreter();

            _threadLua = new Thread(
                new ThreadStart(ConsoleThread));
            _threadLua.Start();

            World = new World();

            var drawSystem = new DrawEntitySystem(
               1,
               new List<Type>() { typeof(SpriteComponent), typeof(TransformComponent) },
               World
               );

            var random = new Random();

            var player = World.CreateGameObject();
            FactoryEntity.CreatePlayer(World, player);

            var bomb = World.CreateGameObject();
            FactoryEntity.CreateBomb(World, bomb, 6, 1);

            var map = new int[MapWidth * MapHeight]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                0, 1, 2, 0, 2, 0, 2, 0, 1, 0,
                0, 1, 2, 0, 2, 0, 2, 0, 1, 0,
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                0, 1, 0, 0, 0, 0, 0, 0, 1, 0,
                0, 1, 0, 0, 0, 0, 0, 0, 1, 0,
                0, 1, 1, 1, 1, 1, 1, 1, 1, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            for(var i=0; i< map.Length; i++)
            {
                var e = World.CreateGameObject();

                var value = map[i];
                switch (value)
                {
                    case 0:
                        FactoryEntity.CreateHardWall(World, e, i % MapWidth, i / MapHeight);
                        break;
                    case 2:
                        FactoryEntity.CreateSoftWall(World, e, i % MapWidth, i / MapHeight);
                        break;
                }
                
                
            }

            World.SystemManager.AddSystem(new UpdateSpriteSystem(0,
               new List<Type>() { typeof(SpriteComponent), typeof(SpriteAnimationComponent) },
               World));
            World.SystemManager.AddSystem(new UpdateInputSystem(0,
              new List<Type>() { typeof(TypeEntityComponent), typeof(TransformComponent), typeof(InputComponent) },
              World));

            World.SystemManager.AddSystem(new DrawFloorSystem(0, null, World));
            World.SystemManager.AddSystem(drawSystem);

            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _stopwatch.Restart();
            World.Update(gameTime.ElapsedGameTime.TotalMilliseconds);

            _basicUI.UpdateInput(gameTime.ElapsedGameTime.TotalMilliseconds);

            //_viewModel.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            //_basicUI.UpdateLayout(gameTime.ElapsedGameTime.TotalMilliseconds);

            _updateTime = _stopwatch.Elapsed.TotalMilliseconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _stopwatch.Restart();
            World.Draw(gameTime.ElapsedGameTime.TotalMilliseconds, _spriteBatch);

            _spriteBatch.DrawString(Utils.FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Draw : " + _stopwatch.Elapsed.TotalMilliseconds.ToString("0.000") + " ms", new Vector2(10, 10), Color.Yellow);
            _spriteBatch.DrawString(Utils.FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Update : " + _updateTime.ToString("0.000") + " ms", new Vector2(10, 30), Color.Yellow);
            _spriteBatch.DrawString(Utils.FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Fps : " + 
                (10000 / ((_updateTime + _stopwatch.Elapsed.TotalMilliseconds) * 10)).ToString("00.00"), new Vector2(10, 50), Color.Yellow);
            _spriteBatch.DrawString(Utils.FontManager.Instance.GetFont(FontEnum.ARIAL_16), "Draw calls : " + _spriteBatch.DrawCallsCount, new Vector2(10, 70), Color.Yellow);

            _spriteBatch.End();

            //_basicUI.Draw(gameTime.ElapsedGameTime.TotalMilliseconds);

            base.Draw(gameTime);
        }

        public void ConsoleThread()
        {
            //Déclaration des méthodes dispos en Lua
            Lua.AddCommandAvailable(MovePlayer);
            Lua.AddCommandAvailable(ListTypeEntity);
            Lua.AddCommandAvailable(ListEntities);

            while (true)
            {
                var command = System.Console.ReadLine();
                Lua.Command(command);
            }
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public string MovePlayer(string positions)
        {
            var componentTypes = new List<Type>() { typeof(TypeEntityComponent), typeof(TransformComponent), typeof(InputComponent) };

            var player = World.EntityManager.GetEntities().Where(x => x.HasComponents(componentTypes) && x.GetComponent<TypeEntityComponent>().TypeEntity == EnumTypeEntity.Player).FirstOrDefault();

            if (player != null)
            {
                var transformComponent = player.GetComponent<TransformComponent>();
                var inputComponent = player.GetComponent<InputComponent>();

                if(!string.IsNullOrEmpty(positions))
                {
                    var tab = positions.Split(',');

                    transformComponent.X += int.Parse(tab[0]);
                    transformComponent.Y += int.Parse(tab[1]);
                }
            }

            return null;
        }

        public string ListTypeEntity(string param)
        {
            return string.Join("\n\t", Enum.GetNames(typeof(EnumTypeEntity)).ToList());
        }

        public string ListEntities(string type)
        {
            var componentTypes = new List<Type>() { typeof(TypeEntityComponent) };

            var typeEnum = (EnumTypeEntity)Enum.Parse(typeof(EnumTypeEntity), type);

            var entities = World.EntityManager.GetEntities().Where(x => x.HasComponents(componentTypes) && x.GetComponent<TypeEntityComponent>().TypeEntity == typeEnum).ToList();

            if (entities != null && entities.Any())
            {
                return string.Join("\n\t", entities.Select(x =>
                {
                    return x.GetComponent<TypeEntityComponent>().TypeEntity.ToString() + " : " + x.Id;
                }));
            }

            return string.Empty;
        }
    }
}

