
module ExampleGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type ExampleGame () as this =
  inherit Game ()

  let graphics = new GraphicsDeviceManager (this)
  let mutable spriteBatch = Unchecked.defaultof<SpriteBatch>
  let mutable juicyTexture: Texture2D = null

  do this.Content.RootDirectory <- "Content"

  override this.Initialize () =
    spriteBatch <- new SpriteBatch (this.GraphicsDevice)

    graphics.PreferredBackBufferWidth <- 1280
    graphics.PreferredBackBufferHeight <- 720
    graphics.ApplyChanges ()

    base.Initialize ()

  override this.LoadContent () =
    juicyTexture <- this.Content.Load ("Textures/juicy")
    ()

  override this.Update (gameTime) =
    base.Update (gameTime)

  override this.Draw (gameTime) =
    this.GraphicsDevice.Clear Color.CornflowerBlue

    let time = float32 gameTime.TotalGameTime.TotalMilliseconds

    spriteBatch.Begin ()

    for i in 0..20 do
      spriteBatch.Draw (
        juicyTexture,
        new Vector2 (
          500f + float32 i * (cos (time / 500f) * 32f),
          time
          |> fun y -> y + (250f * float32 i)
          |> fun y -> y / 2000f
          |> sin
          |> abs
          |> fun y -> y * 480f + 100f
        ),
        Color.White
      )

    spriteBatch.End ()

    base.Draw (gameTime)
