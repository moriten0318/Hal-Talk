using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;/// <summary>
/// TextMeshProを使うために必要！！

public class Test : MonoBehaviour
{

    //オブジェクトと結びつける(変数の宣言)
    [SerializeField] TMP_InputField inpF;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        //Componentをアタッチできるようにする
        inpF = inpF.GetComponent<TMPro.TMP_InputField>();
        text = text.GetComponent<TMPro.TextMeshProUGUI> ();

    }

    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        text.text = inpF.text;
        Debug.Log("hello");

    }
}
