using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// セーブとロードの管理
/// </summary>
public static class SaveManager
{
		// ファイルの名前
		private static string fileName = "score.txt";

		/// <summary>
		/// Saves the score.  スコアを保存
		/// </summary>
		public static void SaveScore (string score)
		{
				byte[] byteMessage = Encoding.UTF8.GetBytes (score);
				if (byteMessage.Length < NGUITools.Load (fileName).Length) {
						return;
				}
				
				NGUITools.Broadcast ("CreateRegisterPanel");
				NGUITools.Save (fileName, byteMessage);
		}
	
		/// <summary>
		/// Loads the score.  スコアをロード
		/// </summary>
		public static string LoadScore ()
		{
				byte[] byteMessage = NGUITools.Load (fileName);
				if (byteMessage == null) {
						byte[] b = Encoding.UTF8.GetBytes ("0");
						NGUITools.Save (fileName, b);
				}
				string message = Encoding.UTF8.GetString (byteMessage);
				return message;
		}
}
