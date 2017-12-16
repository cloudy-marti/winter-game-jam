using UnityEngine;
using _Scripts.Player;

namespace _Scripts.Levels
{
	public class Level01 : MonoBehaviour
	{
		[SerializeField] private Vector3 _playerStart;

		// Use this for initialization
		void Start ()
		{
			PlayerManager.Instance.SpawnPlayer(_playerStart);
		}
	}
}
