using UnityEngine;
using System.Collections;

public class FallingItem : MonoBehaviour
{
		private void FallItem (GameObject target)
		{
				CloneManager.CloneItem (gameObject, target);
		}
}
