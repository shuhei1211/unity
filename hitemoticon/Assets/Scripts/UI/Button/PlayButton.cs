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
				_StateManager.SetState ((int)SceneState.START);
		}
}
