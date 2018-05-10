//-------------------------------------------------------------------------------------
//	ObjectPoolPatternExample.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ObjectPoolPatternExample2
{

    public class ObjectPoolPatternExample : MonoBehaviour
    {
        public string poolName;
        List<GameObject> goList = new List<GameObject>();

        public void CreateFromPoolAction()
        {
            GameObject go = ObjectPoolManager.instance.GetObjectFromPool(poolName, Vector3.zero, Quaternion.identity);
            if (go)
            {
                goList.Add(go);
            }
        }

        public void ReturnToPoolAction()
        {
            foreach (GameObject go in goList)
            {
                ObjectPoolManager.instance.ReturnObjectToPool(go);
            }
            goList.Clear();
        }
    }
}
