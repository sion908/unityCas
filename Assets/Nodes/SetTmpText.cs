using System;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class SetTmpText : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize]
    public ValueInput gameObject;

    [DoNotSerialize]
    public ValueInput text;

    protected override void Definition()
    {
        // 入力の定義。
        inputTrigger = ControlInput("", (flow) => {
            // 引数を取得。
            var obj = flow.GetValue<GameObject>(gameObject);
            var value = flow.GetValue<string>(text);

            // TextMeshProUGUI を取得。
            var tmp = obj.GetComponent<TextMeshProUGUI>();

            // テキストを設定。
            tmp.text = value;

            return outputTrigger;
        });

        // 出力の定義。
        outputTrigger = ControlOutput("");

        // 引数の定義。
        gameObject = ValueInput<GameObject>("gameObject");
        text = ValueInput<string>("text", String.Empty);
    }
}
