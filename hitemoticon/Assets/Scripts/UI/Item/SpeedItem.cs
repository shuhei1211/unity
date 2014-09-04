using UnityEngine;
using System.Collections;

public class SpeedItem : BaseItem
{
		protected override void EffectedItem ()
		{
				GameObject.Find ("Emitter").SendMessage ("OnSpeedSpwan");
		}
}