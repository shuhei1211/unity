using UnityEngine;
using System.Collections;

public class SpeedItem : BaseItem
{

		public delegate void OnCallback ();
		public OnCallback callbackCutIn;

		protected override void EffectedItem ()
		{
				callbackCutIn = _Notificator.CutInObject;
				GameObject.Find ("Emitter").SendMessage ("OnSpeedSpwan");
		}
}