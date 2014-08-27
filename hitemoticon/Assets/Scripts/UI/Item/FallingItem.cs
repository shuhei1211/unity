using UnityEngine;
using System.Collections;

public class FallingItem : MonoBehaviour
{
		/// <summary>
		/// Falls the item.
		/// from ScoreManager
		/// </summary>
		/// <param name="go">Go.</param>
		private void FallItem (GameObject target)
		{
				CloneManager.CloneItem (gameObject, target);
		}
}
