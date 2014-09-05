using UnityEngine;
using System.Collections;

public class LifeItem : BaseItem
{
		public delegate void OnCallback ();
	
		public OnCallback callback;

		protected override void EffectedItem ()
		{
				callback = _Notificator.OnEffectedLifeItem;
				callback();
		}
}
