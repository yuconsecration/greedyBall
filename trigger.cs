using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//使用test组件时必须引入的命名空间

public class trigger : MonoBehaviour {
    private int score = 0;//设定初始分数为0
    //说明何时创建一个组件类型的物体，何时创建一个物体类型,当需要操作某一物体组件下的属性时可以直接创建该物体的组件，当需要操作整个物体的显示等相关操作时需要创建一个物体
    public Text text;//创建一个Test类型的物体text，需要在属性面板中选择需要插入的物体
    public GameObject wintext;//创建一个物体wintext，需要在属性面板中选择需要插入的物体
                              // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //碰撞检测
    //private void OnCollisionEnter(Collision collision)//定义碰撞器的标准格式
    //{
    //    if (collision .collider.tag == "pickup")//判断被碰撞物体的标签是否是pickup，防止碰撞到其他物体会执行下面的代码
    //        Destroy(collision.collider.gameObject);//碰撞事件发生后，毁掉被碰撞的物体，表现在游戏中为被碰撞物体消失
    //}
    //触发检测：使用前要将触发器的box collider设置为is trigger
    private void OnTriggerEnter(Collider other)//定义触发器的标准格式
    {
        if (other.tag == "pickup") {
            score++;//触发到一个物体分数加一
            text.text = score.ToString();//将分数转化为string类型传输到text属性值中
            if (score == 4)//判断当分数达到一定值时执行以下代码
            {
                wintext.SetActive(true);//显示整个组件，之前默认不显示该组件
            }
            Destroy(other.gameObject);
            //注意区分碰撞器和触发器相关代码书写的差异
        }
            
    }
}


