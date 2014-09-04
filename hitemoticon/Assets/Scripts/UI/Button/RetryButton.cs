using UnityEngine;
using System.Collections;

/// <summary>
/// Button retry. リトライボタン
/// </summary>
public class RetryButton : BaseButton
{
		public void GameRetry ()
		{
				_UIPlaySound.Play ();
				CameraFade.StartAlphaFade (Color.black, true, 3f);
				GameObject.Find ("GameManager").SendMessage ("ReStart");
				Destroy (CloneManager.ParentPanel ());
				Destroy (CloneManager.ParentGameOver ());
		}
}
