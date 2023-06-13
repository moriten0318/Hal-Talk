using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using say;

public class test : MonoBehaviour
{

    public GameObject targetObject; // エディターから取得できるようにpublicにしておく
    // Use this for initialization
    void Start()
    {
        sayHello say = targetObject.GetComponent<sayHello>(); //コンポーネントを取得
        say.Hello(); // 対象のコンポーネントのスクリプトを実行
    }

    // Update is called once per frame
    void Update()
    {

    }
}
