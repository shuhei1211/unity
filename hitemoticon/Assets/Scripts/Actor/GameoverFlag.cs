using UnityEngine;
using System.Collections;

public class GameoverFlag : BaseMonoBehaviour
{
		void Update ()
		{
				if (!GameObject.Find ("Player")) {
						Debug.Log ("false");
				}
				
		if (GameObject.Find ("Player")) {
			Debug.Log ("true");
		}
		
				if (!GameObject.Find ("Player") && !GameObject.Find ("Bullet") && !_StateManager.IsCommboChain ()) {
						GameObject.Find ("GameManager").SendMessage ("GameFinish");
						Destroy (gameObject);
				}
		}
}
