using UnityEngine;
using System.Collections;

public class CloseButton : BaseMonoBehaviour
{
		public void OnFinished ()
		{
				NGUITools.Broadcast ("DestroyRankItem");
		}
		
		public void CloseWindow ()
		{
				Destroy (transform.parent.gameObject);
		}
}
