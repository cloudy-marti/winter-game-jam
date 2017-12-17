using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts
{
	public class LevelLoader : MonoBehaviour
	{
		[SerializeField] private string _levelToLoad;

		public void LoadLevel()
		{
			SceneManager.LoadScene(_levelToLoad);
		}
	}
}
