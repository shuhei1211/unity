﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Score.　スコア表示クラス
/// </summary>
public class UIScore : BaseMonoBehaviour
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
				scoreLabel.text = "" + 0;
		}
	
		void Update ()
		{
				scoreLabel.text = "" + _ScoreManager.GetScore ();
		}
}