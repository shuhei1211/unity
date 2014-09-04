using UnityEngine;
using System.Collections;

/// <summary>
/// Score keeper. スコア管理クラス
/// </summary>
public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

		// score count
		private long score = 0;
		// commbo count
		private int commbo = 1;
		
		// get score
		public long GetScore ()
		{
				return score;
		}
		
		// set score
		public void SetScore (long newScore)
		{
				score = newScore;
		}
		
		// initialize score
		public void InitScore ()
		{
				score = 0;
		}
		
		// コンボ数を取得
		public int GetCommboCount ()
		{
				return commbo;
		}
		
		// コンボ数をセット
		public void SetCommboCount (int count)
		{
				commbo = count;
		}
		
		// スコアを加算
		public void AddScore ()
		{
				SetScore (score + 1);
		}
		
		// コンボ時のスコア加算
		public void CommboScore ()
		{
				commbo++;
				SetScore (score + CalulateCommboScore ());
				
				if (GetCommboCount () % 120 == 0 && !GameObject.Find ("LifeItem")) {
						GameObject.Find ("FallingItem").SendMessage ("FallItem", CloneManager.LifeItem);
				} else if (GetCommboCount () % 25 == 0) {
						if (GameObject.Find ("SpeedItem") || _StateManager.IsFeverMode) {
								return;
						}
						GameObject.Find ("FallingItem").SendMessage ("FallItem", CloneManager.SpeedItem);
				}
		}
	
		// 現在のコンボ数	
		public int GetCurrentCommboCount ()
		{
				return commbo;
		}
		
		public int CalulateCommboScore ()
		{
				float score = 0;
				float pow = 0;
				pow = IsCommboValue (1) ? 1 : IsCommboValue (2) ? 2 : IsCommboValue (4) ? 3 : IsCommboValue (7) ? 4 : IsCommboValue (11) ? 5 : IsCommboValue (16) ? 6 : IsCommboValue (22) ? 7 : IsCommboValue (29) ? 8 : IsCommboValue (37) ? 9 : IsCommboValue (46) ? 10 : IsCommboValue (56) ? 11 : IsCommboValue (67) ? 12 : IsCommboValue (79) ? 13 : IsCommboValue (92) ? 14 : IsCommboValue (106) ? 15 : IsCommboValue (121) ? 16 : 16;
				score = Mathf.Pow (2, pow);
				return (int)score;
		}
		
		private bool IsCommboValue (int value)
		{
				return commbo <= value;
		}
}