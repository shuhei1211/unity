using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

/// <summary>
/// File manager. ファイル管理クラス
/// </summary>
public static class FileManager
{
		// ファイル保存フォルダ
		public static string path = Application.dataPath + "/Prefs";
		
		// ファイルの名前
		public static string fileName = "score.txt";

		/// <summary>
		/// Saves the score.  スコアを保存
		/// </summary>
		/// <param name="score">Score.</param>
		public static void SaveScore (string score)
		{
				// Prefフォルダがなければ作成
				if (!Directory.Exists (path)) {
						Directory.CreateDirectory (path);
				}
		
				// スコア保存
				try {
						File.WriteAllText (path + "/" + fileName, score, System.Text.Encoding.UTF8);
				} catch (System.Exception ex) {
				}
		}
	
		/// <summary>
		/// Loads the score.  スコアをロード
		/// </summary>
		/// <returns>The score.</returns>
		public static string LoadScore ()
		{
				string readLine = "0";
				try {
						readLine = File.ReadAllText (path + "/" + fileName);
				} catch (System.Exception ex) {
				}
				return readLine;
		}
}
