using UnityEngine;
using System.Collections;

/// <summary>
/// GameStart Button
/// </summary>
public class PlayButton : BaseButton
{
		public void GameStart ()
		{
				CameraFade.StartAlphaFade (Color.black, true, 3f);
				Destroy (CloneManager.ParentFrontPanel ());
				CloneManager.CloneReadyPanel ();
		}
}
