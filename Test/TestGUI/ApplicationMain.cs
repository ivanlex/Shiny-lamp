using EyesGUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Win32;
using System;

namespace TestGUI
{
    internal class ApplicationMain : Game
    {
        public ApplicationMain()
        {
            GUI.Instance.Prepare(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GUI.Instance.Initial();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MonoGameOrange);

            DrawTile();

            base.Draw(gameTime);
        }

        RenderTarget2D renderTarget2D;

        public void DrawTile()
        {

            try
            {
                if (renderTarget2D == null)
                {
                    renderTarget2D = new RenderTarget2D(GUI.Instance.Graphics.GraphicsDevice, 1000, 1000);
                    GraphicsDevice.SetRenderTarget(renderTarget2D);
                    GUI.Instance.SpriteBatch.Begin();
                    GUI.Instance.SpriteBatch.Draw(TextureManager.Instance.GetTexture(TextureManager.DefaultTexture), new Rectangle(0, 0, 100, 100), Color.White);
                    GUI.Instance.SpriteBatch.Draw(TextureManager.Instance.GetTexture(TextureManager.DefaultTexture), new Rectangle(150, 150, 100, 100), Color.White);
                    GUI.Instance.SpriteBatch.End();
                    GraphicsDevice.SetRenderTarget(null);
                }

                GUI.Instance.SpriteBatch.Begin();
                GUI.Instance.SpriteBatch.Draw(renderTarget2D, new Rectangle(100, 100, 1000, 1000), Color.White);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GUI.Instance.SpriteBatch.End();
            }


            
        }
    }
}