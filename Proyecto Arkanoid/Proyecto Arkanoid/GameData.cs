namespace Proyecto_Arkanoid
{
    public static class GameData
    {
        public static bool gameOn = false;
        public static double ticksRealize = 0;
        public static int dirX = 20, dirY = -dirX, life = 3, Score = 0;
        
        public static void initializeGame()
        {
            gameOn = false;
            life = 3;
            Score = 0;
            
        }
    }
}