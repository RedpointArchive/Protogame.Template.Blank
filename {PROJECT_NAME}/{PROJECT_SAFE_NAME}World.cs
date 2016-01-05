namespace {PROJECT_SAFE_NAME}
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    using Protogame;

    public class {PROJECT_SAFE_NAME}World : IWorld
    {
        private readonly I2DRenderUtilities _renderUtilities;

        private readonly IAssetManager _assetManager;

        private readonly FontAsset _defaultFont;
        
        public {PROJECT_SAFE_NAME}World(
            I2DRenderUtilities twoDRenderUtilities,
            IAssetManagerProvider assetManagerProvider,
            IEntityFactory entityFactory)
        {
            this.Entities = new List<IEntity>();

            _renderUtilities = twoDRenderUtilities;
            _assetManager = assetManagerProvider.GetAssetManager();
            _defaultFont = this._assetManager.Get<FontAsset>("font.Default");

            // You can also save the entity factory in a field and use it, e.g. in the Update
            // loop or anywhere else in your game.
            var entityA = entityFactory.CreateExampleEntity("EntityA");
            entityA.X = 100;
            entityA.Y = 50;
            var entityB = entityFactory.CreateExampleEntity("EntityB");
            entityB.X = 120;
            entityB.Y = 100;

            // Don't forget to add your entities to the world!
            this.Entities.Add(entityA);
            this.Entities.Add(entityB);
        }

        public IList<IEntity> Entities { get; private set; }

        public void Dispose()
        {
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            gameContext.Graphics.GraphicsDevice.Clear(Color.Purple);

            this._renderUtilities.RenderText(
                renderContext,
                new Vector2(10, 10),
                "Hello {PROJECT_NAME}!",
                this._defaultFont);

            this._renderUtilities.RenderText(
                renderContext,
                new Vector2(10, 30),
                "Running at " + gameContext.FPS + " FPS; " + gameContext.FrameCount + " frames counted so far",
                this._defaultFont);
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
        }
    }
}
