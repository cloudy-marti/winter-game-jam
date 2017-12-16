using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.GUI
{
	public class DialogueManager : MonoBehaviour
	{
		public static DialogueManager Instance { get; private set; }

		[SerializeField] private GameObject _dialogPrefab;
		private GameObject _dialogPrefabInstance;
		private Text _diagText;
		private CanvasGroup _canvasGroup;

		DialogueManager()
		{
			Instance = this;
		}

		// Use this for initialization
		void Start ()
		{
			_dialogPrefabInstance = Instantiate(_dialogPrefab);
			_dialogPrefabInstance.transform.SetParent(transform);
			_canvasGroup = _dialogPrefabInstance.GetComponent<CanvasGroup>();
			_diagText = _dialogPrefabInstance.transform.Find("DiagBackground/DiagText").GetComponent<Text>();
		}

		public void Show(string dialogue)
		{
			_canvasGroup.DOFade(1f, 1f);
			_diagText.text = dialogue;
		}
	}
}
