﻿
using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位區域
    // 定義欄位 Field
    // 欄位類型 欄位名稱 (指定 值)結尾
    //預設 private 私人(在屬性面板上隱藏)
    //public 公開 (在屬性面板上顯示)
    [Header("速度")][Range(0f,50f)]
    public float speed = 3.5f;      //浮點數 - 結尾要有f
    [Header("跳躍"),Range(100, 2000)]
    public int jump = 300;          //整數
    [Header("是否在地板上"),Tooltip("用來判定角色是否在地上。")]
    public bool isGround = false;   //布林值 - true 、 false
    [Header("角色名稱")]
    public string _name = "Oezl";   //字串 - 需要用雙引號
    [Header("2D原件")]
    public Rigidbody2D r2d;
    public Animator ani;
    #endregion
    //定義方法
    //語法:
    //修飾詞 傳回類型 方法名稱() {  }
    //void 無傳回

    private void Move()
    {
        float h =Input.GetAxisRaw("Horizontal");//輸入取得軸向("水平")左右 AD
        r2d.AddForce(new Vector2(speed * h, 0));
        ani.SetBool("衝天跑", h != 0);  //動畫原件.設定布林值
    }
    private void Jump()
    {
        //如果 按下空白建 並解 在地板上 等於 勾選
        if (Input.GetKeyDown(KeyCode.Space)&&isGround==true)
        {
            //在地板上 =取消
            isGround = false;
            //鋼體.推力(往上)
            r2d.AddForce(new Vector2(0, jump));
        }

    }
    private void Dead()
    {


    }

    //事件:在特定時間點已指定次數執行
    //更新事件:1秒執行約60次(60FPS)
    private void Update()
    {
        Move();
        Jump();
    }

    //碰撞事件:2D物件碰撞時執行一次
    //collision 參數: 碰到物件的資訊
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰撞.物件.名稱 等於"地板"
        if(collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
}

