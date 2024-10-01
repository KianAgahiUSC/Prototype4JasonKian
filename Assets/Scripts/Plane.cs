using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float moveSpeed = 5f;  // 玩家移动速度
    private float screenHalfWidthInWorldUnits;  // 屏幕的宽度，单位为世界单位
    private float playerHalfWidth;  // 玩家物体宽度的一半

    void Start()
    {
        // 获取屏幕的世界单位宽度（摄像机的视口宽度）
        float halfScreenHeight = Camera.main.orthographicSize;
        screenHalfWidthInWorldUnits = halfScreenHeight * Camera.main.aspect;

        // 获取玩家自身的宽度，确保不会让玩家的中心离开屏幕
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        // 获取左右方向的输入
        float moveDirection = Input.GetAxis("Horizontal");

        // 计算新的水平位置
        Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        // 限制玩家在屏幕内移动 (Mathf.Clamp确保玩家不能移出屏幕)
        newPosition.x = Mathf.Clamp(newPosition.x, -screenHalfWidthInWorldUnits + playerHalfWidth, screenHalfWidthInWorldUnits - playerHalfWidth);

        // 更新玩家位置
        transform.position = newPosition;
    }
}

