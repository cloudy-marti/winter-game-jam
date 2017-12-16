using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.GUI
{
	public class DialogueManager : MonoBehaviour
	{
		public static DialogueManager Instance { get; private set; }
		private CanvasGroup _canvasGroup;
		[SerializeField] private Text _diagText;

		DialogueManager()
		{
			Instance = this;
		}

		// Use this for initialization
		void Start ()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			Show("Je susi un test");
		}

		public void Show(string dialogue)
		{
			_canvasGroup.DOFade(1f, 1f);
			_diagText.text = dialogue;
		}
	}
}
