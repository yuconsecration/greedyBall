using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    private Rigidbody rgd;//定义一个刚体组件
    public int  speed = 3;//设置一个速度用来控制键盘移动小球的速度
	// Use this for initialization
	void Start () {//该部分表示只执行一次
        rgd = GetComponent<Rigidbody>();//得到场景中的刚体组件并将值传递给rgd
	}
	
	// Update is called once per frame
	void Update () {//该部分表示可以持续执行
        float h = Input.GetAxis("Horizontal");//表示得到水平轴
        float v = Input.GetAxis("Vertical");//表示达到竖直轴
        rgd.AddForce(new Vector3(h, 0, v)*speed);//通知键盘来控制刚体不同方向上的变化
	}
}

