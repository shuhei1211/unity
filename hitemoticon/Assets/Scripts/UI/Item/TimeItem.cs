using UnityEngine;
using System.Collections;

public class TimeItem : BaseMonoBehaviour
{
		void Start ()
		{
				Destroy (gameObject, Config.DESTROY_TIME_ITEM);
		}
	
		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.tag == "Player") {
						charaControll.AddLife ();
						Destroy (gameObject);
				}
		}
}
