﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Button retry. リトライボタン
/// </summary>
public class RetryButton : BaseButton
{
		public void GameRetry ()
		{
				base.OnClickPlaySound ();
				CameraFade.StartAlphaFade (Color.black, true, 3f);
				CloneManager.CloneReadyPanel ();
				Destroy (CloneManager.ParentPanel ());
				Destroy (CloneManager.ParentGameOver ());
		}
}
