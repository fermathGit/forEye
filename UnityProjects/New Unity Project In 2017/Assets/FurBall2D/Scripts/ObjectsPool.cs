using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//https://zhuanlan.zhihu.com/p/30575559
public class ObjectsPool : MonoBehaviour {
    [SerializeField]
    GameObject _prefab;

    Queue<GameObject> _pooledInstanceQueue = new Queue<GameObject>();

    public GameObject GetInstance() {
        if ( _pooledInstanceQueue.Count > 0 ) {
            GameObject instanceToReuse = _pooledInstanceQueue.Dequeue();
            instanceToReuse.SetActive( true );
            return instanceToReuse;
        }
        return Instantiate( _prefab );
    }

    public void ReturnInstance( GameObject gameObjectToPool ) {
        _pooledInstanceQueue.Enqueue( gameObjectToPool );
        gameObjectToPool.SetActive( false );
        gameObjectToPool.transform.SetParent( transform );

    }
}
