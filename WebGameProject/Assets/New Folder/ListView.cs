using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//создание и позиционирование элементов внутри списка
public class ListView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform m_ContentTransform;// определяем родителя
    [SerializeField] private RectTransform m_ContentRecktTransform;// обределяем высоту

    [Header("Settings")]
    [SerializeField] private List<GameObject> m_elements;
    [SerializeField] private float m_offset;// величина отступа между элементами 

    public GameObject Add(GameObject element)
    {
        GameObject createdElement = Instantiate(element, this.m_ContentRecktTransform);
        if (this.m_elements.Count == 0)
        {
            this.m_elements.Add(createdElement);
            return createdElement;
        }
        ListElement elementMeta=createdElement.GetComponent<ListElement>();
        GameObject lastElement = this.m_elements.Last();

        Vector3 lastElementPosition = lastElement.transform.localPosition;
        Vector3 newElementPosition = new Vector3
        {
            x = lastElementPosition.x,
            y = lastElementPosition.y - elementMeta.Height() - this.m_offset,
            z = lastElementPosition.y
        };
        createdElement.transform.localPosition = newElementPosition;

        this.m_elements.Add(createdElement);
        return createdElement;
    }
}
