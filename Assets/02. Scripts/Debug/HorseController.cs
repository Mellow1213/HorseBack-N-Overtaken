using System;
using UnityEditor.Timeline.Actions;
using UnityEngine;
public class HorseController : MonoBehaviour
{
    public BoxTriggerController leftBox;
    public BoxTriggerController rightBox;
    public Material[] BoxMaterials; // 머티리얼 배열

    private int statement = 0;
    
    void Start()
    {
        // 박스의 이벤트 리스너 설정
        leftBox.OnHandEntered += (hand) => CheckHandsInBox(leftBox);
        leftBox.OnHandExited += (hand) => CheckHandsInBox(leftBox);
        rightBox.OnHandEntered += (hand) => CheckHandsInBox(rightBox);
        rightBox.OnHandExited += (hand) => CheckHandsInBox(rightBox);
    }

    private void CheckHandsInBox(BoxTriggerController boxController)
    {
        if (boxController.HandsCount == 2)
        {
            boxController.gameObject.GetComponent<Renderer>().material = BoxMaterials[1];
            // 두 손이 박스 안에 있을 때의 처리
            // 예: 박스의 머티리얼 변경 
            if (boxController == leftBox)
                statement = 1;
            else
            {
                statement = 2;
            }
        }
        else
        {
            boxController.gameObject.GetComponent<Renderer>().material = BoxMaterials[0];
            statement = 0;
            // 그 외의 경우
            // 예: 박스의 머티리얼을 원래대로 변경
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward*8f*Time.deltaTime);
        transform.position = new Vector3(transform.position.x,
            transform.position.y + Mathf.Sin(Time.realtimeSinceStartup*8f)*0.01f, transform.position.z);
        switch (statement)
        {
            case 1:
                transform.Rotate(Vector3.down * 45f * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(Vector3.up * 45f * Time.deltaTime);
                break;
        }
    }
}