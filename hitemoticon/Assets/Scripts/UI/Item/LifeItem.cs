using UnityEngine;
using System.Collections;

public class LifeItem : BaseItem
{
		protected override void EffectedItem ()
		{
				charaControll.AddLife ();
		}
}
