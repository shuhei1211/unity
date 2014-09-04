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
				go.GetComponent<UILabel>().text = "" + ScoreManager.Instance.CalulateCommboScore().ToString();
				Destroy (go, 1f);
		}
}
