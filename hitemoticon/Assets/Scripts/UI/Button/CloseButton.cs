using UnityEngine;
using System.Collections;

public class CloseButton : BaseMonoBehaviour
{
		void Update ()
		{
		    _BoxCollider2D.enabled = true;
		}
		
		public void OnFinished ()
		{
				ToggleActiveBlockUI(false);
				NGUITools.Broadcast ("DestroyRankItem");
		}
		
		public void CloseWindow ()
		{
				Destroy (transform.parent.gameObject);
		}
}
