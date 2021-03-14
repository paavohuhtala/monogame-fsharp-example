
open ExampleGame

[<System.STAThread>]
[<EntryPoint>]
let main argv = 
  use game = new ExampleGame ()
  game.Run ()
  0
