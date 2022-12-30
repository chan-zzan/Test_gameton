using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoystick : Joystick
{
    Vector2 originPos; // 처음 위치

    public Vector2 lastPos; // 손을 뗐을 때의 위치
    public bool isMove; // 움직이는 중인지 확인

    protected override void Start()
    {
        base.Start();
        originPos = background.anchoredPosition; // 처음 위치 저장
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isMove = true;

        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isMove = false;

        lastPos = new Vector2(base.Horizontal, base.Vertical); // 마지막 위치 저장
        background.anchoredPosition = originPos; // 처음 위치로 다시 되돌아가도록 설정
        base.OnPointerUp(eventData);
    }
}