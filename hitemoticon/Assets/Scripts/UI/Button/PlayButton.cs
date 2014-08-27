using UnityEngine;
using System.Collections;

/// <summary>
/// GameStart Button
/// </summary>
public class PlayButton : BaseButton
{
		public void GameStart ()
		{
				_StateManager.SetState ((int)Enum.State.START);
		}
}
