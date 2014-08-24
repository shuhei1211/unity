using UnityEngine;
using System.Collections;

/// <summary>
/// Clone manager. Clone作成や処理を管理するクラス
/// </summary>
public class CloneManager : MonoBehaviour
{
		#region public method
		/// <summary>
		/// スコアを作成する
		/// </summary>
		/// <param name="tf">Tf.</param>
		public static void CloneScore (GameObject parent)
		{
				GameObject clone = Instantiate (Score) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "Score";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		/// <summary>
		/// プレイヤーを作成する
		/// </summary>
		public static void ClonePlayer (GameObject parent)
		{
				GameObject clone = Instantiate (Player) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "Player";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		/// <summary>
		/// 敵の出現ポイントを作成する
		/// </summary>
		/// <param name="tf">Tf.</param>
		public static void CloneEmitter (GameObject parent)
		{
				GameObject clone = Instantiate (Emitter) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "Emitter";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		/// <summary>
		/// 敵を複製する
		/// </summary>
		public static void CloneEnemy (GameObject parent)
		{
				GameObject clone = Instantiate (Enemy, new Vector2 (Random.Range (-0.7f, 0.7f), 1.2f), Quaternion.identity) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "Enemy";
				clone.transform.SetLocalScale (1, 1, 1);
		}
	
		/// <summary>
		/// ゲーム画面を作成する
		/// </summary>
		/// <param name="tf">Tf.</param>
		public static void CloneMainPanel (GameObject parent)
		{
				if (parent) {
						return;
				}
				GameObject clone = Instantiate (MainPanel, parent.transform.localPosition, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "MainPanel";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		/// <summary>
		/// Clones the game over.  ゲームオーバー画面を作成する
		/// </summary>
		/// <param name="tf">Tf.</param>
		public static void CloneGameOver (Transform tf)
		{
				if (ParentGameOver ()) {
						return;
				}
				GameObject clone = Instantiate (GameOver, tf.localPosition, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "GameOver";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void CloneGameoverFlag (GameObject parent)
		{
				GameObject clone = Instantiate (FlagObject, parent.transform.position, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "FlagObject";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void CloneFireButton (GameObject parent)
		{
				GameObject clone = Instantiate (FireButton, parent.transform.position, Quaternion.identity) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "FireButton";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void CloneRegisterPanel (Transform tf)
		{
				GameObject clone = Instantiate (RegisterPanel, tf.localPosition, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "RegisterPanel";
				clone.transform.SetLocalScale (1, 1, 1);
		}

		public static void CloneLifeBar (GameObject parent)
		{
				GameObject clone = Instantiate (LifeBar, parent.transform.position, Quaternion.identity) as GameObject;
				clone.transform.parent = parent.transform;
				clone.name = "LifeBar";
				clone.transform.SetLocalScale (1, 1, 1);
		}

		public static void CloneLife (Transform tf)
		{
				GameObject clone = Instantiate (Life, tf.position, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentLifeGrid.transform;
				clone.name = "Life";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void CloneFallingItem (GameObject parent)
		{
				GameObject clone = Instantiate (FallingItem, parent.transform.position, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "FallingItem";
				clone.transform.SetLocalScale (1, 1, 1);
		}
		
		public static void CloneItem (Transform tf, GameObject itemObj)
		{
				GameObject clone = Instantiate (itemObj, tf.position, Quaternion.identity) as GameObject;
				clone.transform.parent = ParentUiRoot ().transform;
				clone.name = "Item";
				clone.transform.SetLocalScale (1, 1, 1);
		}

		#endregion
		
		#region public method - Find
		public static GameObject ParentUiRoot ()
		{
				return GameObject.Find ("UI Root");
		}
		
		public static GameObject ParentPanel ()
		{
				return GameObject.Find ("MainPanel");
		}
		
		public static GameObject ParentFrontPanel ()
		{
				return GameObject.Find ("FrontPanel");
		}
		
		public static GameObject ParentEmitter ()
		{
				return GameObject.Find ("Emitter");
		}
		
		public static GameObject ParentGameOver ()
		{
				return GameObject.Find ("GameOver");
		}
		
		public static GameObject ParentRankingGrid ()
		{
				return GameObject.Find ("RankingGrid");
		}

		public static GameObject ParentLifeGrid {
				get	{ return GameObject.Find ("LifeGrid"); }
		}
	#endregion
		
		#region private method - Load
		private static GameObject MainPanel {
				get { return Resources.Load ("Prefabs/UI/Panel/MainPanel") as GameObject;}
		}
	
		private static GameObject FrontPanel {
				get { return Resources.Load ("Prefabs/UI/Panel/FrontPanel") as GameObject;}
		}
		
		private static GameObject GameOver {
				get { return Resources.Load ("Prefabs/UI/Panel/GameOver") as GameObject;}
		}
		
		private static GameObject RegisterPanel {
				get { return Resources.Load ("Prefabs/UI/Panel/RegisterPanel") as GameObject;}
		}
	
		private static GameObject Score {
				get { return Resources.Load ("Prefabs/UI/Label/Score") as GameObject;}
		}
		
		private static GameObject FireButton {
				get { return Resources.Load ("Prefabs/UI/Button/FireButton") as GameObject;}
		}
		
		private static GameObject Player {
				get { return Resources.Load ("Prefabs/Actor/Player") as GameObject; }
		}

		private static GameObject Enemy {
				get { return Resources.Load ("Prefabs/Actor/Enemy") as GameObject;}
		}
		
		private static GameObject FallingItem {
				get { return Resources.Load ("Prefabs/Actor/FallingItem") as GameObject;}
		}
		
		private static GameObject Emitter {
				get { return Resources.Load ("Prefabs/Actor/Emitter") as GameObject;}
		}
		
		private static GameObject FlagObject {
				get { return Resources.Load ("Prefabs/Actor/GameoverFlag") as GameObject;}
		}

		private static GameObject LifeBar {
				get { return Resources.Load ("Prefabs/UI/Item/LifeBar") as GameObject;}
		}

		private static GameObject Life {
				get { return Resources.Load ("Prefabs/UI/Item/Life") as GameObject;}
		}
		
		public static GameObject LifeItem {
				get { return Resources.Load ("Prefabs/UI/Item/LifeItem") as GameObject;}
		}
	
		public static GameObject SpeedItem {
				get { return Resources.Load ("Prefabs/UI/Item/SpeedItem") as GameObject;}
		}
	
		public static GameObject StopItem {
				get { return Resources.Load ("Prefabs/UI/Item/TimeItem") as GameObject;}
		}
	#endregion
}
