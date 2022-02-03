using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create());
    }
    //コルーチンで生成を行う
    IEnumerator Create() {
        float delta = 1.5f; //生成間隔の初期値
        while (true) {
            GameObject obj = Instantiate(
                prefab,
                new Vector3(Random.Range(-10.5f,10.5f),Random.Range(8.0f,12.0f),Random.Range(3.0f,3.0f)),Quaternion.identity
                );
            //GameManagerをセットする
            obj.GetComponent<CubeController>().SetGameManager(gm);
            //生成間隔時間停止
            yield return new WaitForSeconds(delta);
            //徐々に生成間隔を早める
            if (delta > 0.5f) {
                delta -= 0.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
