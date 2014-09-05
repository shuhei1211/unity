using UnityEngine;
using System.Collections;

/// <summary>
/// イベントの通知と処理を管理する
/// </summary>
public class Notificator : SingletonMonoBehaviour<Notificator>
{

		/// <summary>
		/// スコアのポップさせる
		/// </summary>
		/// <param name="position">Position.</param>
		public void PopUpScore (Vector3 position)
		{
				GameObject go = Instantiate (CloneManager.PopScore) as GameObject;
				go.transform.SetParent (CloneManager.ParentPanel ());
				go.AddComponent<TweenPosition> ();
				go.GetComponent<TweenPosition> ().duration = 1f;
				go.GetComponent<TweenPosition> ().from.x = position.x - 100;
				go.GetComponent<TweenPosition> ().from.y = position.y + 450;
				go.GetComponent<TweenPosition> ().to.x = position.x - 100;
				go.GetComponent<TweenPosition> ().to.y = position.y + 500;
				go.GetComponent<UILabel> ().text = "" + _ScoreManager.CalulateCommboScore ();
				Destroy (go, 1f);
		}

		/// <summary>
		/// スピードアイテムを取得
		/// </summary>
		public void OnEffectedSppedItem ()
		{
				StartCoroutine (OnTakeItem ());
		}
		
		/// <summary>
		/// ライフアイテムを取得
		/// </summary>
		public void OnEffectedLifeItem ()
		{
				charaControll.AddLife ();
		}
		
		IEnumerator OnTakeItem ()
		{
				GameObject feverObject = Instantiate (Resources.Load (PrefabPath.Prefabs_UI_Other_Fever)) as GameObject;
				feverObject.transform.SetParent (CloneManager.ParentUiRoot ());
//				Time.timeScale = 0f;
//				float pauseEndTime = Time.realtimeSinceStartup + 2.5f;
//				while (Time.realtimeSinceStartup < pauseEndTime) {
//						yield return 0;
//				}
//				Time.timeScale = 1f;
				yield return new WaitForSeconds(2.5f);
				Destroy (feverObject);
				GameObject.Find ("Emitter").SendMessage ("OnSpeedSpwan");
		}
}