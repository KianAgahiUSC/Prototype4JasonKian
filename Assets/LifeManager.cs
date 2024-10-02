using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;  // 引入 TextMeshPro 命名空间

public class LifeManager : MonoBehaviour
{
    public int lives = 3;  // 初始生命值
    public TextMeshProUGUI livesText; // 用于显示生命值的 TextMeshPro 组件

    // 在开始时更新UI上的生命值显示
    void Start()
    {
        UpdateLivesText();
    }

    // 当敌人与 GameOverZone 碰撞时调用
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞物体是否具有 "GameOverZone" 标签
        if (collision.gameObject.CompareTag("GameOverZone"))
        {
            // 再检查碰撞物体是否具有 "enemy" 标签
            if (collision.collider.CompareTag("Enemy"))
            {
                // 生命值减少
                lives--;

                // 如果生命值为0，执行游戏结束逻辑
                if (lives <= 0)
                {
                    GameOver();
                }
            }
        }
    }

    // 更新UI上的生命值显示
    void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }

    // 游戏结束的处理方法
    void GameOver()
    {
        Debug.Log("Game Over!");
        // 在这里可以加载游戏结束场景或显示游戏结束界面
    }
}
