namespace Proyecto_Arkanoid
{
    public static class PlayerController
    {
        public static void CreateNewScore()
        {
            ConnectionDB.ExecuteNonQuery($"INSERT INTO SCORE(score, nickname) VALUES" +
                                         $" ({GameData.Score}, '{GameData.nickName}')");
        }
    }
}