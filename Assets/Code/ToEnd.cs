using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToEnd : MonoBehaviour
{
    // ��� �������, ������� ����� ���������� ����� ���������� �������� �������
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    // ������� ������, ������� ����� ������� ����� ����������� ���� ��������
    public GameObject targetObject;

    private int destroyedCount = 0;

    void Start()
    {
        object1.SetActive(true); // ���������, ��� ������� ������������ ����������
        object2.SetActive(true);
        object3.SetActive(true);

        targetObject.SetActive(false); // ���������� ������� ������ ��������
    }

    void Update()
    {
        if (destroyedCount == 3)
        {
            targetObject.SetActive(true);
        }
    }

    public void OnObjectDestroyed(GameObject destroyedObject)
    {
        if (destroyedObject == object1 || destroyedObject == object2 || destroyedObject == object3)
        {
            destroyedCount++;
        }
    }
}

