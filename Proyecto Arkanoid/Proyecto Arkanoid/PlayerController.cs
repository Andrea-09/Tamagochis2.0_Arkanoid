using System;
using System.Collections.Generic;
using System.Data;

namespace Proyecto_Arkanoid
{
    public static class PlayerController
    {
        public static void CreateNewScore()
        {
            ConnectionDB.ExecuteNonQuery($"INSERT INTO SCORE(score, nickname) VALUES" +
                                         $" ({GameData.Score}, '{GameData.nickName}')");
        }

        public static List<Player> ObtainTopPlayer()
        {
            var toPlayers = new List<Player>();
            DataTable dt = ConnectionDB.ExecuteQuery("SELECT pl.nickname, sc.score " +
                                               "FROM PLAYER pl, SCORE sc " +
                                               "WHERE pl.nickname = sc.nickname " +
                                               "ORDER BY sc.score DESC " +
                                               "LIMIT 10");

            foreach (DataRow dr in dt.Rows)
            {
                toPlayers.Add(new Player(dr[0].ToString(), Convert.ToInt32(dr[1])));
            }

            return toPlayers;
        }
    }
}