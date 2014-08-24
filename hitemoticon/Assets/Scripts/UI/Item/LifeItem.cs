using UnityEngine;
using System.Collections;

public class LifeItem : CommonItem
{
		void Start ()
		{
				Destroy (gameObject, Config.DESTROY_TIME_ITEM);
		}
	
		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.tag == "Player") {
						NGUITools.PlaySound(audioClipPickup);
						charaControll.AddLife ();
						Destroy (gameObject);
				}
		}
}
