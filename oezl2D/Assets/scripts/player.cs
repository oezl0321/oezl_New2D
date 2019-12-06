
using UnityEngine;
using UnityEngine.UI; //引用 介面 API
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
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamond;
    [Header("鑽石區域")]
    public int diamondCurrent;
    public int diamondTotal;
    public Text textDiamond;


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



        //如果按下A角度 = (0, 180 ,0)
        //如果按下D角度 = (0, 0, 0)
        // teansform.eulerAngles 角色變形元件.世界角度
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);        
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 0, 0);
        
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
            ani.SetTrigger("衝天跑");  //動畫原件.設定觸發器("參數")
        }

    }
    private void Dead()
    {


    }

    private void Start()
    {
        //尋找所有指定標籤物件("指定標籤").數量
        diamondTotal=GameObject.FindGameObjectsWithTag("鑽石").Length;
        //更新介面
        textDiamond.text = "鑽石:0/" + diamondTotal;
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
    //觸發事件:針對碰撞器有勾選 ISTrigger 的物件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "鑽石")
        {
            aud.PlayOneShot(soundDiamond, 1.5f);  //音源 撥放一次音效(音效，音量)
            Destroy(collision.gameObject);        //刪除(碰撞的物件)
            diamondCurrent++;
            textDiamond.text = "鑽石:" + diamondCurrent + "/" + diamondTotal;
        }
    }

}




