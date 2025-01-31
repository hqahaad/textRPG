using textRPG;
using textRPG.Scenes;

Game game = new Game();
bool isGameOver = false;

//game.Start();
TitleScene scene = new TitleScene();
scene.View();
while (!isGameOver)
{
     isGameOver = game.Update();
}
game.Exit();