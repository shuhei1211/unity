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
				GameObject.Find ("GameManager").SendMessage ("ReStart");
				Destroy (CloneManager.ParentPanel ());
				Destroy (CloneManager.ParentGameOver ());
		}
}
