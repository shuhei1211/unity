using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Sound manager. 音声管理クラス
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
		private AudioSource BGMsource;
		private AudioSource[] SEsources = new AudioSource[16];
		private SoundVolume volume;
	
		public AudioClip[] BGM;
		public AudioClip[] SE;
	
		void Awake ()
		{
				DontDestroyOnLoad (this.gameObject);
				
				volume = new SoundVolume ();
				
				BGMsource = gameObject.AddComponent<AudioSource> ();
				BGMsource.loop = true;
				
				for (int i = 0; i < SEsources.Length; i++) {
						SEsources [i] = gameObject.AddComponent<AudioSource> ();
				}
		}
		
		void Update ()
		{
				// ミュート設定
				BGMsource.mute = volume.Mute;
				foreach (AudioSource source in SEsources) {
						source.mute = volume.Mute;
				}
				
				// ボリューム設定
				BGMsource.volume = volume.BGM;
				foreach (AudioSource source in SEsources) {
						source.mute = volume.Mute;
				}
		}
		
		/// <summary>
		/// BGMを再生
		/// </summary>
		/// <param name="index">BGMの番号</param>
		public void PlayBGM (int index)
		{
				if (0 > index || BGM.Length <= index) {
						return;
				}
				if (BGMsource.clip == BGM [index]) {
						return;
				}
				BGMsource.Stop ();
				BGMsource.clip = BGM [index];
				BGMsource.Play ();
		}
		
		/// <summary>
		/// SEを再生
		/// </summary>
		/// <param name="index">SEの番号</param>
		public void PlaySE (int index)
		{
				if (0 > index || SE.Length <= index) {
						return;
				}
				foreach (AudioSource source in SEsources) {
						if (source.isPlaying == false) {
								source.clip = SE [index];
								source.Play ();
								return;
						}
				}
		}
		
		/// <summary>
		/// SEを停止
		/// </summary>
		public void StopSE ()
		{
				foreach (AudioSource source in SEsources) {
						source.Stop ();
						source.clip = null;
				}
		}
}

/// <summary>
/// Sound volume. 音量構造体
/// Serializableとしてインスペクター上で設定できるようにする
/// </summary>
[System.Serializable]
public class SoundVolume
{
		public float BGM = 1.0f;
		public float SE = 1.0f;
		public bool Mute = false;
	
		public void Init ()
		{
				BGM = 1.0f;
				SE = 1.0f;
				Mute = false;
		}
}
