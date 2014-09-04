using UnityEngine;
using System.Collections;

/// <summary>
/// Fire button. 弾発射クラス
/// </summary>
public class FireButton : BaseMonoBehaviour
{
		private bool isToggleFlag = true;

		public void onPress ()
		{
				SendFireBullet ();
		}

		private void SendFireBullet ()
		{
				_ParentGameObject.GetComponent<UISprite> ().alpha = isToggleFlag == true ? 1.0f : 0.3f;
				if (GameObject.Find ("Player")) {
						GameObject.Find ("Player").SendMessage ("FireBullet", isToggleFlag);
				}
				isToggleFlag = !isToggleFlag;
		}
}