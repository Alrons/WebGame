using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ListView m_ListView;
    [SerializeField] private GameObject m_Prefab;

    [Header("Settings")]
    [SerializeField] private string m_title;
    [SerializeField] private string m_description;
    [SerializeField] private List<Sprite> m_images;
    [Space]
    [SerializeField] private int m_Count;

    private Sprite GetRandomSprite()
    {
        int index = Random.Range(0, this.m_images.Count);
        return this.m_images[index];
    }

    private void Awake()
    {
        for (int i = 0; i < this.m_Count; i++)
        {
            GameObject element =  this.m_ListView.Add(this.m_Prefab);
            ListElement elementMeta = element.GetComponent<ListElement>();
            elementMeta.SetTitle(this.m_title+i);
            elementMeta.SetDescription(i + this.m_description);
            elementMeta.SetImage(GetRandomSprite());
        }
    }



}
