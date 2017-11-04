using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCtrl : MonoBehaviour {
    Transform myTransform;
    Vector3 selfScenePosition;

	// Use this for initialization
	void Start () {
        myTransform = transform;
        selfScenePosition = Camera.main.WorldToScreenPoint( myTransform.position );
        print( "scenePosition   :  " + selfScenePosition );
    }

    private void OnMouseDrag() {
        print( "鼠标拖动该模型区域时" );
        print( Input.mousePosition.x + "     y  " + Input.mousePosition.y + "     z  " + Input.mousePosition.z );
        //由鼠标确定的新的屏幕坐标
        Vector3 currentScenePosition = new Vector3( Input.mousePosition.x, Input.mousePosition.y, selfScenePosition.z );
        Vector3 currentWorldPosition = Camera.main.ScreenToWorldPoint( currentScenePosition );
        myTransform.position = currentWorldPosition;
    }

    void OnMouseDown() {
        print( "鼠标按下时" );
    }

    void OnMouseUp() {
        print( "鼠标抬起时" );
    }

    void OnMouseEnter() {
        print( "鼠标进入该对象区域时" );
    }

    void OnMouseExit() {
        print( "鼠标离开该模型区域时" );
    }
}
