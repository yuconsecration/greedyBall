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

