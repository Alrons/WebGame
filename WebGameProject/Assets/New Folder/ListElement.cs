using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class ListElement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private RectTransform m_transform;
    [Space]
    [SerializeField] private Text m_title;
    [Space]
    [SerializeField] private Image m_image;
    [SerializeField] private Text m_description;
    /// <summary>
    /// поле для установки названия блока
    /// </summary>
    /// <param name="title"></param>
    public void SetTitle(string title) => m_title.text = title;
    /// <summary>
    /// поле для установки изображения
    /// </summary>
    /// <param name="image"></param>
    public void SetImage(Sprite image) => m_image.sprite = image;
    /// <summary>
    /// поле для установки описания
    /// </summary>
    /// <param name="description"></param>
    public void SetDescription(string description) => m_title.text = description;


    public float Width()=> m_transform.rect.width;//возвращает ширину элемента

    public float Height() => m_transform.rect.height;//возвращает высоту элемента

}
