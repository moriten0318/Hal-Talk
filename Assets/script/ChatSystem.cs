using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

    public class ChatSystem : MonoBehaviour
    {

        /// 自分とGPT間のチャット内容を表示するUIのPrefabを生成するためのクラス

        public GameObject _myChatNode;/// 生成するPrefabのための変数宣言
        public GameObject _returnChatNode;
        public GameObject _ChatContent_parent;///chatnodeの親要素用変数
        public TMP_InputField _TextBox;
        public Scrollbar _ScrollBar;
        string userMessage;
        string returnMessage;

        void Start()
        {
            //ユーザーがメッセージを入力するInputField(TMP)の宣言
            _TextBox = _TextBox.GetComponent<TMPro.TMP_InputField>();
            _ScrollBar = _ScrollBar.GetComponent<Scrollbar>();
    }

        public void Create_Mine_chatNode()
        {


            GameObject instantiatedNode_Prefab = Instantiate(_myChatNode, _ChatContent_parent.transform);///Prefab生成

            Transform parent01Transform = instantiatedNode_Prefab.transform;///生成したPrefabはTextの親要素なので、親のTransformとして取得
            Transform parent02Transform = parent01Transform.Find("ChatBoard");
            Transform childTransform = parent02Transform.Find("ChatText");

            TextMeshProUGUI _myChatNode_text = childTransform.GetComponent<TextMeshProUGUI>();


            if (_TextBox.text == "")
            {
                Debug.LogError("テキストボックスに何も入力されていません");
            }

            userMessage = _TextBox.text;
            _myChatNode_text.text = userMessage;

            _TextBox.text = "";///InputFieldを空欄にする
            _ScrollBar.value = 0f;


    }



        public void Create_GPT_chatNode(string GPTmessage)
        {
            GameObject instantiatedNode_Prefab = Instantiate(_returnChatNode, _ChatContent_parent.transform);///GPTからの返信を表示するPrefab
            Transform parent01Transform = instantiatedNode_Prefab.transform;///生成したPrefabはTextの親要素なので、親のTransformとして取得
            Transform parent02Transform = parent01Transform.Find("ChatBoard");
            Transform childTransform = parent02Transform.Find("ChatText");

            TextMeshProUGUI _returnChatNode_text = childTransform.GetComponent<TextMeshProUGUI>();
            returnMessage = GPTmessage;
             _returnChatNode_text.text = returnMessage;
            _ScrollBar.value = 0f;

        }
    }

