using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject obj = Instantiate(prefab); //引数1つでInstantiate
            obj.transform.parent = transform; //親要素設定(今回はカメラ)
            obj.transform.localPosition = Vector3.zero; //親要素からのオフセットは0
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //メインカメラからマウスクリックした地点にray(光線)を飛ばす
            Vector3 dir = ray.direction.normalized; //rayの方向を長さを1にしてdirに代入(directionでvectorに変える)
            obj.GetComponent<Rigidbody>().velocity = dir * 100.0f; //生成したobjのRigidbodyを取得し、速度をdir方向に与える
        }
    }
}
