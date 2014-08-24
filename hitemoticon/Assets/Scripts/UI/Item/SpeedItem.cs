using UnityEngine;
using System.Collections;

public class SpeedItem : CommonItem
{
	void Start ()
	{
		Destroy (gameObject, Config.DESTROY_TIME_ITEM);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			NGUITools.PlaySound(audioClipPickup);
			GameObject.Find ("Emitter").SendMessage ("OnSpeedSpwan");
			Destroy (gameObject);
		}
	}
}