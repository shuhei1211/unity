using UnityEngine;
using System.Collections;

public class CloseButton : BaseButton
{
		void Update ()
		{
				boxcollider2D.enabled = true;
		}
		
		/// <summary>
		/// Raises the finished event. for Ranking
		/// </summary>
		public void OnFinished ()
		{
				DestroyBlockUI ();
				NGUITools.Broadcast ("DestroyRankItem");
		}
		
		/// <summary>
		/// Closes the window. for Register
		/// </summary>
		public void CloseWindow ()
		{
				base.OnClickPlaySound ();
				DestroyBlockUI ();
				Destroy (transform.parent.gameObject);
		}
}
