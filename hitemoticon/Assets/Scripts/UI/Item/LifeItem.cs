using UnityEngine;
using System.Collections;

public class LifeItem : BaseItem
{
		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.tag == "Player") {
						NGUITools.PlaySound (audioClipPickup);
						charaControll.AddLife ();
						Destroy (gameObject);
				}
		}
}
