using textRPG;









Game game = new Game();

bool isGameOver = false;

game.Start();
while (!isGameOver)
{
     isGameOver = game.Update();
}
game.Exit();