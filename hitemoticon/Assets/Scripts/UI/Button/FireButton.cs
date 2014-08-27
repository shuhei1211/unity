using UnityEngine;
using System.Collections;

/// <summary>
/// Fire button. 弾発射クラス
/// </summary>
public class FireButton : BaseButton
{
		public void onPress ()
		{
				if (GameObject.Find ("Player")) {
						GameObject.Find ("Player").SendMessage ("FireBullet");
				}
		}
		
		public void onRelease ()
		{
				if (GameObject.Find ("Player")) {
						GameObject.Find ("Player").SendMessage ("StopBullet");
				}
		}
}
