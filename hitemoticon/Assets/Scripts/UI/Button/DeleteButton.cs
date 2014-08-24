using UnityEngine;
using System.Collections;

public class DeleteButton : MonoBehaviour
{
		private void OnClick ()
		{
				ApiManager.Instance.DATA_DELETE ();
		}
}
