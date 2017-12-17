using UnityEngine;
using _Scripts.Player;

namespace _Scripts.Levels
{
	public class LevelScript : MonoBehaviour
	{
		[SerializeField] private Vector3 _playerStart;
		[SerializeField] private Vector3 _playerScale = Vector3.one;
		[SerializeField] private Color _playerColor = Color.white;
		[SerializeField] private float _cameraSize = 5;
		[SerializeField] private AudioClip _clipToPlay;
		[SerializeField] private float _playerSpeed;

		// Use this for initialization
		void Start ()
		{
			PlayerManager.Instance.SpawnPlayer(_playerStart, _playerScale, _playerColor, _playerSpeed, _cameraSize);
			MusicManager.Instance.SetClip(_clipToPlay);
		}
	}
}
