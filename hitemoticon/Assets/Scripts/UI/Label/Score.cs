using UnityEngine;
using System.Collections;

/// <summary>
/// Score.　スコア表示クラス
/// </summary>
public class Score : BaseMonoBehaviour
{
		private UILabel scoreLabel;
		
		void Awake ()
		{
				if (!scoreLabel) {
						scoreLabel = GetComponent<UILabel> ();
				}
		}
		
		void Start ()
		{
				scoreLabel.text = "SCORE : " + 0;
		}
	
		void Update ()
		{
				scoreLabel.text = "SCORE : " + _ScoreManager.GetScore ();
		}
}