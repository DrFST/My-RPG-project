using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaBbackground : MonoBehaviour
{
    // ������������
    private GameObject cam;
    // �Ӳ�ϵ�������������ƶ��Ŀ�����ֵԽС������Խ��Զ����
    [SerializeField] private float parallaEffect;
    // ��¼��������ĳ�ʼX����
    private float xPosition;


    void Start()
    {
        cam = GameObject.Find("Main Camera");
        // ��¼�����ĳ�ʼX����
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // ��������ƶ�ʱ������Ӧ���ƶ��ľ��루�����Ӳ�ϵ����
        float distanceToMove = cam.transform.position.x * parallaEffect;
        // ���ñ�������λ�ã��ڳ�ʼλ�õĻ����ϼ���ƫ��(X��λ�ø����Ӳ����,Y�ᱣ�ֲ���)
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

    }
}
