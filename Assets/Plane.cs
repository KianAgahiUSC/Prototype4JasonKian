using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
 // 在Inspector面板中可调整的移动速度
    public float moveSpeed = 5f;

    // Update 每帧调用一次
    void Update()
    {
        // 获取左右方向的输入 (A/D 键或左/右箭头)
        float moveDirection = Input.GetAxis("Horizontal");

        // 根据输入移动物体
        transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
    }
}
