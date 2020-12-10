using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleUI : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] float scaleValue = 1.1f;
    [SerializeField] float endValue = 1f;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        audioSource = FindObjectOfType<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {        
        rectTransform.DOScale(scaleValue, .2f);
        audioSource.PlayOneShot(audioClip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(endValue, .2f);
    }
}
