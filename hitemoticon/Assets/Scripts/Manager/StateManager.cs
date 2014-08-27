using UnityEngine;
using System.Collections;

/// <summary>
/// Game state. ゲーム全体の状態を管理するクラス
/// </summary>
public class StateManager : SingletonMonoBehaviour<StateManager>
{
	// ゲームの状態
	private int state;
	
	// コンボ
	public bool IsCommboChain ()
	{
		return GetState () == (int)Enum.State.COMMBO;
	}
	
	// フィーバー
	public bool IsFeverMode ()
	{
		return GetState() == (int)Enum.State.FEVER;
	}
	
	// ノーマルモード
	public bool IsNormalMode ()
	{
		return GetState () == (int)Enum.State.NORMAL;
	}
	
	// スタートモード
	public bool IsStartMode ()
	{
		return GetState () == (int)Enum.State.START;
	}
	
	// 現在のゲーム状態を取得
	public int GetState ()
	{
		return this.state;
	}
	
	// 現在のゲームの状態をセット
	public void SetState (int newState)
	{
		if (newState == state)
			return;
		int oldState = state;
		state = newState;
	}
	
	// ネットワークに接続しているかどうか
	public bool IsConnctNetwork ()
	{
		return Application.internetReachability == NetworkReachability.NotReachable ? false : true;
	}
}
