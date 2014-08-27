using UnityEngine;
using System.Collections;

/// <summary>
/// Clone manager. Clone作成や処理を管理するクラス
/// </summary>
public class CloneManager : BaseMonoBehaviour
{
		#region public method
		
		public static void CloneObject (GameObject target, GameObject parent, string cloneName)
		{
				if (parent == null) {
						return;
				}
				GameObject clone = Instantiate (target) as GameObject;
				clone.SettingClone (parent, cloneName);
		}
		
		public static void CloneEnemy (GameObject parent)
		{
				GameObject clone = Instantiate (Enemy, new Vector2 (Random.Range (-0.7f, 0.7f), 1.2f), Quaternion.identity) as GameObject;
				clone.SettingClone (parent, "Enemy");
		}
	
		/// <summary>
		/// Clones the game over.  ゲームオーバー画面を作成する
		/// </summary>
		public static void CloneGameOver (GameObject parent)
		{
				if (ParentGameOver ())
						return;
				GameObject clone = Instantiate (GameOver) as GameObject;
				clone.SettingClone (parent, "GameOver");
		}
		
		public static void CloneFireButton (GameObject parent)
		{
				GameObject clone = Instantiate (FireButton) as GameObject;
				clone.SettingClone (parent, "FireButton");
		}
		
		public static void CloneRegisterPanel (GameObject parent)
		{
				GameObject clone = Instantiate (RegisterPanel) as GameObject;
				clone.SettingClone (parent, "RegisterPanel");
		}

		public static void CloneLifeBar (GameObject parent)
		{
				GameObject clone = Instantiate (LifeBar, parent.transform.position, Quaternion.identity) as GameObject;
				clone.SettingClone (parent, "LifeBar");
		}

		public static void CloneLife (GameObject parent)
		{
				GameObject clone = Instantiate (Life) as GameObject;
				clone.SettingClone (parent, "Life");
		}
		
		public static void CloneItem (GameObject parent, GameObject itemObj)
		{
				GameObject clone = Instantiate (itemObj) as GameObject;
				clone.SettingClone (parent, "Item");
		}
						
		public static void CloneFallingItem (GameObject parent)
		{
				GameObject clone = Instantiate (FallingItem, parent.transform.position, Quaternion.identity) as GameObject;
				clone.SettingClone (ParentUiRoot (), "FallingItem");
		}
		
		public static void CloneMainPanel (GameObject parent)
		{
				if (ParentPanel ())
						return;
				GameObject clone = Instantiate (MainPanel) as GameObject;
				clone.SettingClone (ParentUiRoot (), "MainPanel");
		}
		
		public static void CloneGameoverFlag (GameObject parent)
		{
				GameObject clone = Instantiate (FlagObject) as GameObject;
				clone.SettingClone (ParentUiRoot (), "FlagObject");
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
		
		#region public method - Load
		public static GameObject MainPanel {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Panel_MainPanel) as GameObject;}
		}
	
		public static GameObject FrontPanel {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Panel_FrontPanel) as GameObject;}
		}
		
		public static GameObject GameOver {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Panel_GameOver) as GameObject;}
		}
		
		public static GameObject RegisterPanel {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Panel_RegisterPanel) as GameObject;}
		}
	
		public static GameObject Score {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Label_Score) as GameObject;}
		}
		
		public static GameObject FireButton {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Button_FireButton) as GameObject;}
		}
		
		public static GameObject Player {
				get { return Resources.Load (PrefabPath.Prefabs_Actor_Player) as GameObject; }
		}

		public static GameObject Enemy {
				get { return Resources.Load (PrefabPath.Prefabs_Actor_Enemy) as GameObject;}
		}
		
		public static GameObject FallingItem {
				get { return Resources.Load (PrefabPath.Prefabs_Actor_FallingItem) as GameObject;}
		}
		
		public static GameObject Emitter {
				get { return Resources.Load (PrefabPath.Prefabs_Actor_Emitter) as GameObject;}
		}
		
		public static GameObject FlagObject {
				get { return Resources.Load (PrefabPath.Prefabs_Actor_GameoverFlag) as GameObject;}
		}

		public static GameObject LifeBar {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Item_LifeBar) as GameObject;}
		}

		public static GameObject Life {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Item_Life) as GameObject;}
		}
		
		public static GameObject LifeItem {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Item_LifeItem) as GameObject;}
		}
	
		public static GameObject SpeedItem {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Item_SpeedItem) as GameObject;}
		}
	
		public static GameObject StopItem {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Item_DiamondItem) as GameObject;}
		}
		
		public static GameObject BlockUI {
				get { return Resources.Load (PrefabPath.Prefabs_UI_Other_BlockingUI) as GameObject;}
		}
 	#endregion
}
