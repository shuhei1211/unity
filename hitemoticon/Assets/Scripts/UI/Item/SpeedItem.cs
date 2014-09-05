using UnityEngine;
using System.Collections;

public class SpeedItem : BaseItem
{
		public delegate void OnCallback ();

		public OnCallback callback;
		
		protected override void EffectedItem ()
		{
				callback = _Notificator.OnEffectedSppedItem;
				callback ();
		}
}