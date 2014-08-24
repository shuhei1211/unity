using UnityEngine;
using System.Collections;

/// <summary>
/// Button retry. リトライボタン
/// </summary>
public class RetryButton : BaseMonoBehaviour
{
		public void onClick ()
		{
				GameObject.Find ("GameManager").SendMessage ("ReStart");
				Destroy (CloneManager.ParentPanel ());
				Destroy (CloneManager.ParentGameOver ());
		}
}
