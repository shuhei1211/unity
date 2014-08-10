using UnityEngine;
using System.Collections;

public class DelegateTest : MonoBehaviour
{
		public delegate void doSomething ();
		public delegate void doString (string msg);

		public static void GameStart (doSomething callback)
		{
				// ゲームスタート処理
				Debug.Log ("GameStartの処理");
				
				// ゲームスタートの処理が終了したことを各クラスへ通知する
				// たとえばキャラクターを初期化する等
				callback ();
		}

		public static void GameStop (doSomething callback)
		{
				// ゲーム中断処理
				Debug.Log ("GameStopの処理");
				callback ();
		}

		public static void GameFinish (doString callback)
		{
				// ゲーム終了処理
				Debug.Log ("GameFinishの処理");
				callback ("処理の終了を送信する");
		}


}
