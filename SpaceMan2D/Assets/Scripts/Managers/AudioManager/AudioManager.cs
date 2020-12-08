using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	private string currentMusicTheme = null;

	private float globalVolume
	{
		get
		{
			return PlayerPrefs.GetFloat("globalVolume", 1f);
		}

		set
		{
			AudioListener.volume = value;
			PlayerPrefs.SetFloat("globalVolume", value);
		}
	}

	public bool isMuted
	{
		get
		{
			return globalVolume == 0;
		}

		set
		{
			globalVolume = value ? 0 : 1;
		}
	}

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);

			foreach (Sound s in sounds)
			{
				s.source = gameObject.AddComponent<AudioSource>();
				s.source.clip = s.clip;
				s.source.loop = s.loop;

				s.source.outputAudioMixerGroup = mixerGroup;
			}

			AudioListener.volume = globalVolume;
		}
	}

	private Sound FindSound(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);

		if (s == null)
		{
			Debug.LogWarning("Sound \"" + sound + "\" not found!");
		}

		return s;
	}

	public static IEnumerator StartFade(Sound s, float duration, float startVolume, float targetVolume)
	{
		float currentTime = 0;

		s.source.volume = startVolume;

		if (startVolume == 0f)
		{
			s.source.Play();
		}

		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			s.source.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / duration);
			yield return null;
		}

		s.source.volume = targetVolume;

		if (targetVolume == 0f)
		{
			s.source.Stop();
		}

		yield break;
	}

	public void Play(string sound, float fadeDuration = 0f)
	{
		Sound s = FindSound(sound);

		if (s == null)
		{
			return;
		}

		float targetVolume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		if (fadeDuration == 0f)
		{
			s.source.volume = targetVolume;
			s.source.Play();
		}
		else
		{
			StartCoroutine(StartFade(s, fadeDuration, 0f, targetVolume));
		}
	}

	public void Stop(string sound, float fadeDuration = 0f)
	{
		Sound s = FindSound(sound);

		if (s == null)
		{
			return;
		}

		if (fadeDuration == 0f)
		{
			s.source.Stop();
		}
		else
		{
			StartCoroutine(StartFade(s, fadeDuration / 2f, s.source.volume, 0f));
		}
	}

	public void ToggleMute()
	{
		isMuted = !isMuted;
	}

	public void ChangeMusicTheme(string musicTheme, float transitionTime = 0f)
	{
		if (currentMusicTheme != musicTheme)
		{
			if (currentMusicTheme != null)
			{
				Stop(currentMusicTheme, transitionTime);
			}

			if (musicTheme != null)
			{
				Play(musicTheme, transitionTime);
			}

			currentMusicTheme = musicTheme;
		}
	}
}
