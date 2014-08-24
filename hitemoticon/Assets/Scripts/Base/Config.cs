using UnityEngine;
using System.Collections;

/// <summary>
/// Config.
/// </summary>
public static class Config
{
		public static readonly string API_POST_URL = "http://user.server.bet/~iwamoto/highscorelist.php";
		public static readonly string API_FIELD_SENDMODE = "SendMode";
		public static readonly string API_FIELD_SENDMODE_POST = "2";
		public static readonly string API_FIELD_SENDMODE_DELETE = "4";
		public static readonly string API_FIELD_NAME = "name";
		public static readonly string API_FIELD_SCORE = "score";
		public static readonly int PLAYER_HP = 6;
		public static readonly float DESTROY_TIME_ITEM = 5;
}
