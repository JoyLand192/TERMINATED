using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public CR cr;
    [SerializeField] RectTransform playButton;
    [SerializeField] Transform logo;
    public void Awake()
    {
        cr = GameObject.FindWithTag("Player").GetComponent<CR>();
    }
    public void GameStart()
    {
        logo.GetComponent<Animator>().SetTrigger("Start");
        StartCoroutine(StartTween());
    }
    IEnumerator StartTween()
    {
        float duration = 0.7f;
        var ease = Ease.InCubic;
        logo.DOMoveY(6f, duration).SetEase(ease);
        playButton.DOAnchorPosY(-40f, duration).SetEase(ease);

        yield return new WaitForSeconds(duration);

        Destroy(logo.gameObject);
        Destroy(playButton.gameObject);
        cr.transform.DOMoveY(-3f, 1f).SetEase(Ease.OutCirc);
        Camera.main.DOOrthoSize(6.6f, 1f).SetEase(Ease.OutCirc);
    }
}
