using UnityEngine;
using System.Collections;

public class DestroyCloud : MonoBehaviour {
    public ObjectsPool pool;
    // Use this for initialization
    void Start(){

		Invoke("DestroyIt",0.8f);
	}

	void DestroyIt(){
        pool.ReturnInstance( gameObject);}
    

    // Update is called once per frame
    void Update () {
	
	}
}
