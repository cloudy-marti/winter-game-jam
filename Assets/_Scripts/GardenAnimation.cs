using System.Collections;
using DG.Tweening;
using UnityEngine;
using _Scripts.Diags;
using _Scripts.GUI;
using _Scripts.Levels;
using _Scripts.Player;

namespace _Scripts
{
	public class GardenAnimation : MonoBehaviour
	{
		[SerializeField] private GameObject _sword;
		[SerializeField] private ScriptableDialogue[] _diag;
		private Animator linkAnim;

		// Use this for initialization
		void Start ()
		{
			linkAnim = GetComponent<Animator>();
		}

		IEnumerator PlayAnimation()
		{
			linkAnim.Play("Sword");
			GetComponent<SpriteRenderer>().enabled = true;
			DialogueManager.Instance.Show(_diag[0].Speakers, _diag[0].Speeches, _diag[0].Faces, _diag[0].FacesOrder);
			PlayerManager.Instance.FreezePlayer();
			yield return new WaitForSeconds(5f);

			GameObject sword = Instantiate(_sword);


			sword.transform.position = transform.position;

			sword.transform.DOMove(new Vector3(-20, 0f, -10f), 2f).SetEase(Ease.Linear);
			sword.transform.DORotate(Vector3.forward * -90, 2f).SetEase(Ease.Linear);

			DialogueManager.Instance.Show(_diag[1].Speakers, _diag[1].Speeches, _diag[1].Faces, _diag[1].FacesOrder);
			PlayerManager.Instance.FreezePlayer();
			linkAnim.enabled = false;
			PlayerManager.Instance._playerInstance.GetComponent<SpriteRenderer>().enabled = true;
			PlayerManager.Instance.UnfreezePlayer();
			GetComponent<SpriteRenderer>().enabled = false;
		}

		void Update ()
		{
			GameObject playerInstance = PlayerManager.Instance._playerInstance;
			if (!playerInstance) return;

			PlayerManager.Instance.FreezePlayer();
			playerInstance.GetComponent<PlayerController>().PlayerAnimator.SetInteger("Vertical", -1);

			playerInstance.transform.DOMove(new Vector3(0f, 0f, -5f), 5f).SetEase(Ease.Linear).OnComplete(() =>
			{
				playerInstance.GetComponent<SpriteRenderer>().enabled = false;

				StartCoroutine(PlayAnimation());
			});


			enabled = false;
		}

		private void OnEnable()
		{
			
		}
	}
}
