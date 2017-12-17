using UnityEngine;
using _Scripts.Player;

namespace _Scripts.Levels
{
	public class LevelScript : MonoBehaviour
	{
		[SerializeField] private Vector3 _playerStart;
		[SerializeField] private Vector3 _playerScale = Vector3.one;
		[SerializeField] private Color _playerColor;

		// Use this for initialization
		void Start ()
		{
			PlayerManager.Instance.SpawnPlayer(_playerStart, _playerScale, _playerColor);
		}
	}
}
