using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
	private static AudioManager s_instance 				= null;
	public static AudioManager Instance
	{
		get 
		{ 
			if(s_instance == null)
			{
				GameObject audioManagerObj = new GameObject("AudioManager");
				AudioManager audioManager = audioManagerObj.AddComponent<AudioManager>();
				s_instance = audioManager;
			}

			return s_instance; 
		}
	}

	[SerializeField] private AudioClip[] m_bgmClips		= null;
	[SerializeField] private AudioClip[] m_sfxClips 	= null;

	private List<AudioSource> m_pooledAudioSource 		= null;

	public void Awake()
	{
		if(s_instance == null)
		{
			s_instance = this;
		}
		else
		{
			Destroy(this);
		}

		DontDestroyOnLoad(this);
		m_pooledAudioSource = new List<AudioSource>();
	}

	public void playBGM(string p_clipName, bool m_isLooping = true)
	{
		// Do Something!
		AudioClip bgmClip = getBGMClip(p_clipName);
		AudioSource bgmAudioSource = getAudioSourceFromPool();
		bgmAudioSource.clip = bgmClip;
		bgmAudioSource.loop = m_isLooping;

		bgmAudioSource.Play();
	}

	public void playSFX(string p_clipName)
	{
		// Do Something!
		AudioClip sfxClip = getSFXClip(p_clipName);
		AudioSource sfxAudioSource = getAudioSourceFromPool();
		sfxAudioSource.clip = sfxClip;
		sfxAudioSource.loop = false;

		sfxAudioSource.Play();
	}

	public void stopAudioSource(string p_clipName)
	{
		AudioSource audioSource = getAudioSourceFromPool(p_clipName);
		if(audioSource != null)
		{
			audioSource.Stop();
		}
	}

	public void stopAllBGM()
	{
		if(m_pooledAudioSource == null || m_pooledAudioSource.Count <= 0)
		{
			return;
		}

		for(int i = 0; i < m_pooledAudioSource.Count; i++)
		{
			AudioSource audioSource = m_pooledAudioSource[i];
			if(audioSource.loop)
			{
				audioSource.Stop();
			}
		}
	}

	private AudioSource getAudioSourceFromPool()
	{
		for(int i = 0; i < m_pooledAudioSource.Count; i++)
		{
			AudioSource audioSource = m_pooledAudioSource[i];
			if(!audioSource.isPlaying)
			{
				return audioSource;
			}
		}

		return createAudioSource();
	}

	private AudioSource createAudioSource()
	{
		GameObject audioSourceObj = new GameObject("audio");
		Transform audioSourceT = audioSourceObj.transform;
		audioSourceT.SetParent(transform, true);

		AudioSource audioSource = audioSourceObj.AddComponent<AudioSource>();
		m_pooledAudioSource.Add(audioSource);
		return audioSource;
	}

	private AudioSource getAudioSourceFromPool(string p_clipName)
	{
		if(m_pooledAudioSource == null || m_pooledAudioSource.Count <= 0)
		{
			return null;
		}

		for(int i = 0; i < m_pooledAudioSource.Count; i++)
		{
			AudioSource audioSource = m_pooledAudioSource[i];
			string clipName = audioSource.clip.name;
			if(clipName == p_clipName)
			{
				return audioSource;
			}
		}

		return null;
	}

	private AudioClip getBGMClip(string p_bgmClip)
	{
		for(int i = 0; i < m_bgmClips.Length; i++)
		{
			string bgmName = m_bgmClips[i].name;
			if(bgmName == p_bgmClip)
			{
				return m_bgmClips[i];
			}
		}

		return null;
	}

	private AudioClip getSFXClip(string p_sfxClip)
	{
		for(int i = 0; i < m_sfxClips.Length; i++)
		{
			string sfxName = m_sfxClips[i].name;
			if(sfxName == p_sfxClip)
			{
				return m_sfxClips[i];
			}
		}

		return null;
	}
}
