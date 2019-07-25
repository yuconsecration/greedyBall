~~*<font color=red>@2019072102d</font>*~~ 
# 1.实战要求

> 1.学会使用unity一些基本的操作。
> 2.学会一些基本的脚本代码编写。
> 3.完整代码：https://github.com/DedicationTechology/unity_GreedyBall
> 4.注意相关的脚本要拖动到对应的物体的属性栏中
# 2.项目需求
> 开发一款可以使用键盘方向键控制小球来吃小方块并且记分的小游戏。
# 3.项目开发流程
## 3.1基本场景搭建
> 1.创建一个地面Plane
> 2.创建四周的围墙来限制小球的运动范围(创建多个cube,注意不要加刚体属性，防止围墙被撞飞)
> 3.创建一个小球Sphere(设定刚体属性：Add Component-->pysical-->Rigidbody)
> 4.创建食物(用cube来代替)
> 5.创建分数显示面板和游戏结束显示面板(Create-->UI-->Test)(创建两个面板)
## 3.2围墙操作
> 1.使用ctrl+d表示复制并创建物体，对需要多次使用的物体，创建一个prefab文件夹，将该物体拖至该文件夹下充当模板，需要多个物体时只需从该模板下拖拽即可，同时当模板的相关属性改变时，其实物的相关属性也都改变
> 2.按住ctrl键拖拽可以等距离移动物体
> 3.当需要另外两个方向的墙体时，可以使用重置物体，点击属性面板(Inspector)中Transform右上角的设置按钮下的reset，然后修改物体的比例scale来改变方向
## 3.3小球操作
### 3.3.1通过键盘控制小球的移动
> 1.在工程面板下创建一个script文件夹用来放置工程的脚本文件
> 2.创建一个脚本sphere

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sphere : MonoBehaviour {
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
```
### 3.3.2给小球创建一个触发器(注意与碰撞器的区别)
#### 3.3.2.1说明

> 碰撞器表示拥有碰撞器的物体不能穿过被碰撞的物体，而触发器表示拥有触发器的物体可以穿过其他物体(前提是其他物体的Inspector属性面板中的box collider中的is trigger必须勾选上)
#### 3.3.2.2创建脚本
> 在script文件夹下创建一个脚本chufa，用来实现小球的触发操作

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chufa : MonoBehaviour {
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
            Destroy(other.gameObject);
        }
            
    }
}
```
## 3.4食物操作

> 让小球实现旋转来表示食物
> 新建一个脚本cube

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cude : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0));//物体向y轴方向旋转，每次旋转一度，update下物体一秒大概执行60次，transform表示当前物体
	}
}
```
## 3.5显示面板操作

> 在chufa脚本中添加一些代码
>在显示的属性面板中，在rect transform属性的左上角按住alt键选择显示在屏幕上的位置
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//使用test组件时必须引入的命名空间
public class chufa : MonoBehaviour {
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
```
## 3.6相机跟随物体移动
> 创建一个脚本follow

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {
    public Transform MySphere;//设定一个Transform组件来得到物体的位置，MySphere需要在属性面板中指定物体
    private Vector3 offset;//设定一个向量，用来存储x,y,z的位置
    // Use this for initialization
    void Start () {
         offset= transform.position - MySphere.position;//transform表示当前物体的位置，在这里表示相机的位置，这里通过计算相机和物体位置的偏移量来确定相机与物体的位置联系
	}
	// Update is called once per frame
	void Update () {
        transform.position = offset + MySphere.position;//表示实施更新物体的位置而保证相机和物体位置的偏移量从而达到控制相机随物体运动的效果
	}
}
```
# 4上传游戏

> 点击untiy中file目录下的build setting选择build，然后选择需要保存的位置，会产生一个数据文件夹和一个.exe的应用程序，这两个文件缺一不可，数据文件夹中包括游戏需要的一些数据，点击.exe文件就可以开始游戏。

