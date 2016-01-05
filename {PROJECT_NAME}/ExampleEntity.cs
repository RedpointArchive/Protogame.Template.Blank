using System;
using Protogame;
using Microsoft.Xna.Framework;

namespace {PROJECT_SAFE_NAME}
{
    public class ExampleEntity : Entity
    {
        private readonly string _name;

        private readonly I2DRenderUtilities _renderUtilities;

        private readonly FontAsset _defaultFont;

        public ExampleEntity(I2DRenderUtilities renderUtilities, IAssetManagerProvider assetManagerProvider, string name)
        {
            _renderUtilities = renderUtilities;
            _name = name;
            _defaultFont = assetManagerProvider.GetAssetManager().Get<FontAsset>("font.Default");
        }

        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);

            if (renderContext.IsCurrentRenderPass<I2DBatchedRenderPass>())
            {
                _renderUtilities.RenderText(
                    renderContext,
                    new Vector2(this.X, this.Y),
                    _name,
                    _defaultFont);
            }
        }
    }
}
