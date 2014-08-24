using UnityEngine;
using System.Collections;

/// <summary>
/// GameStart Button
/// </summary>
public class PlayButton : BaseMonoBehaviour
{
		public void GameStart ()
		{
				StateManager.Instance.SetState ((int)Enum.State.START);
		}
}
