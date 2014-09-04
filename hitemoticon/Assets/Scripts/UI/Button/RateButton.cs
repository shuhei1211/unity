using UnityEngine;
using System.Collections;

/// <summary>
/// Rate button. ランキングを表示するボタン
/// </summary>
public class RateButton : BaseButton
{
		UIPlayTween playTween;

		void Start ()
		{
				playTween = GetComponent<UIPlayTween> ();
				playTween.tweenTarget = GameObject.Find ("RankingBackground") as GameObject;
		}

		// Update is called once per frame
		void Update ()
		{
				EnenabledButton ();
				if (_StateManager.IsConnctNetwork ()) {
						GetComponent<UIPlayTween> ().enabled = true;
				} else {
						GetComponent<UIPlayTween> ().enabled = false;
				}
		}
		
		private void OnClick ()
		{
				base.OnClickPlaySound ();
				BlockUI ();
				WWW www = ApiManager.Instance.GET (Config.API_POST_URL);
				StartCoroutine (WaitForRequest (www));
		}
		
		private IEnumerator WaitForRequest (WWW www)
		{
				yield return www;
				if (!string.IsNullOrEmpty (www.error)) {
						Debug.LogError (string.Format ("WWW error\n{0}", www.error));
						yield break;
				}
				
				NGUITools.Broadcast ("CreateRankingItem", www);
				www.Dispose ();
		}
}