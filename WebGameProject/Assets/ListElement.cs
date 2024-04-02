using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class ListElement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Transform m_transform;
    [Space]
    [SerializeField] private Text m_title;
    [Space]
    [SerializeField] private Image m_image;
    [SerializeField] private Text m_description;

    public void SetTitle(string title)
    {
        m_title.text = title;
    }


    public void SetImage(Sprite image)
    {
        m_image.sprite = image;
    }

    public void SetDescription(string description)
    {
        m_title.text = description;
    }




}
