using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour
{
		private int playerHP = Config.PLAYER_HP;		// プレイヤーのHP
		
		public int PlayerHP {
				get {
						return this.playerHP;
				}
				set {
						playerHP = value;
				}
		}		
		
		// プレイヤーを初期化
		public void InitPlayer ()
		{
				playerHP = Config.PLAYER_HP;
		}
		
		// ダメージを受けたとき
		public void DoDamage ()
		{
				Debug.Log ("damage");
				playerHP--;
				if (GameObject.Find ("LifeBar")) {
						GameObject.Find ("LifeGrid").SendMessage ("DecreaseLifeCount");
				}
				
		}
		
		public void AddLife ()
		{
				if (PlayerHP <= 10) {
						playerHP++;
						if (GameObject.Find ("LifeBar")) {
								GameObject.Find ("LifeGrid").SendMessage ("IncreaseLifeCount");
						}
				}
		}
		
		// プレイヤーの死亡フラグ
		public bool IsPlayerDead ()
		{
				return playerHP <= 0 ? true : false;
		}
}
