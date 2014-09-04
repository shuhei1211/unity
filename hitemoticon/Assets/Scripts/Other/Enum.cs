using UnityEngine;
using System.Collections;

/// <summary>
/// Enum. 定数宣言
/// </summary>
public class Enum
{
	
}

public enum BGM : int
{
		MAINTHEME,
		BGM,
}

public enum SE : int
{
		CLICK,
		EXPLODE_ONE,
		EXPLODE_TWO,
		PICK_UP,
		PLAYER_DAMAGE,
		SHOOT,
}

/// <summary>
/// シーン状態
/// </summary>
public enum SceneState : int
{
		NONE,
		NORMAL,
		TITLE,
		START,
		COMMBO,
		FEVER,
		GAMEOVER,
		BLOCK,
}