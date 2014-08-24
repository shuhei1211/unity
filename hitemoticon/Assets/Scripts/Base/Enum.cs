using UnityEngine;
using System.Collections;

/// <summary>
/// Enum. 定数宣言
/// </summary>
public class Enum
{
		// NORMAL = 通常 
		// START = スタート時
		// COMPLETE = ゲーム終了
		// COMMBO = コンボ中
		// FEVER = フィーバー
		public enum State
		{
				NORMAL = 0,
				START,
				COMMBO,
				FEVER,
		}
}
