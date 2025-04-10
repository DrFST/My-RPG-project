using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaBbackground : MonoBehaviour
{
    // 存放主相机对象
    private GameObject cam;
    // 视差系数（决定背景移动的快慢，值越小，背景越“远”）
    [SerializeField] private float parallaEffect;
    // 记录背景物体的初始X坐标
    private float xPosition;


    void Start()
    {
        cam = GameObject.Find("Main Camera");
        // 记录背景的初始X坐标
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 计算相机移动时，背景应该移动的距离（乘以视差系数）
        float distanceToMove = cam.transform.position.x * parallaEffect;
        // 设置背景的新位置：在初始位置的基础上加上偏移(X轴位置根据视差计算,Y轴保持不变)
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

    }
}
