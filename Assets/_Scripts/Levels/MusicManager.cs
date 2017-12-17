using UnityEngine;

namespace _Scripts.Levels
{
	public class MusicManager : MonoBehaviour
	{
		public static MusicManager Instance { get; set; }
		private AudioSource _audioSource;

		// Use this for initialization

		void Awake()
		{
			Instance = this;
			_audioSource = gameObject.GetComponent<AudioSource>();
			_audioSource.clip = null;
			_audioSource.loop = true;
			DontDestroyOnLoad(gameObject);
		}

		void Start()
		{
		}

		public void SetClip(AudioClip clip)
		{
			if (_audioSource.clip == clip) return;
			_audioSource.Stop();
			_audioSource.clip = clip;
			_audioSource.Play();
		}
	}
}
