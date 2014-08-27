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
				SetScore (score + GetCommboCount () * GetCommboCount ());
				if (GetCommboCount () % 70 == 0 && !GameObject.Find ("LifeItem")) {
						GameObject.Find ("FallingItem").SendMessage ("FallItem", CloneManager.LifeItem);
				} else if (GetCommboCount () % 3 == 0 && !_StateManager.IsFeverMode ()) {
						GameObject.Find ("FallingItem").SendMessage ("FallItem", CloneManager.SpeedItem);
						_StateManager.SetState ((int)Enum.State.FEVER);
				} else if (GetCommboCount () % 7 == 0) {
//						GameObject.Find ("FallingItem").SendMessage ("FallItem", CloneManager.StopItem);
				}
		}
	
		// 現在のコンボ数	
		public int GetCurrentCommboCount ()
		{
				return commbo;
		}
}
