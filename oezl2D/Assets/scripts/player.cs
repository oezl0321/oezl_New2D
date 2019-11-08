
using UnityEngine;

public class player : MonoBehaviour
{
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

}
