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

