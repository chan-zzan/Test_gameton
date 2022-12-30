using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapDragAndMove : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // 배경 게임 오브젝트의 RectTransform
    public RectTransform rect_Background;

    public float game_X_Resolution = 1080f; // 게임 x 해상도
    public float game_Y_Resolution = 1920f; // 게임 y 해상도

    [SerializeField]
    private float maxWidth; // 화면 이동 최댓 값 (x 기준)
    [SerializeField]
    private float minWidth; // 화면 이동 최솟 값 (x 기준)

    // 드래그를 통한 x 축 이동만 사용
    private float startPoint;   // 드래그 시작 시 맵 x좌표
    private float startDrag;    // 드래그 시작 마우스 좌표
    private float resultPos;    // 이동할 좌표

    public GameObject leftSideUIGroup;  // 화면 드래그 시 비활성화 할 좌측 UI 그룹
    public GameObject rightSideUIGroup; // 화면 드래그 시 비활성화 할 우측 UI 그룹

    

    private void Awake()
    {
        maxWidth = (rect_Background.sizeDelta.x - game_X_Resolution)/2;
        minWidth = (-1 * maxWidth) + 5.0f;  // 화면 끝이 살짝 보여서 5만큼 추가함.
    }



    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 좌우 UI 잠시 제거
        Debug.Log("Start Drag");
        Debug.Log("Xpos : " + eventData.position.x);

        leftSideUIGroup.SetActive(false);
        rightSideUIGroup.SetActive(false);

        // 드래그 시작 좌표 저장
        startPoint = rect_Background.position.x;
        startDrag = eventData.position.x;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        resultPos = eventData.position.x - startDrag;
        rect_Background.position = new Vector2(startPoint + resultPos, rect_Background.position.y);

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        // 드래그 종료 시 좌우 UI 다시 표출
        Debug.Log("End Drag");
        Debug.Log("Xpos : " + rect_Background.anchoredPosition.x);

        leftSideUIGroup.SetActive(true);
        rightSideUIGroup.SetActive(true);

        // 맵 범위가 벗어낫을 경우
        if (rect_Background.anchoredPosition.x > maxWidth)
        {
            rect_Background.anchoredPosition = new Vector2(maxWidth, 0);
        }
        if(rect_Background.anchoredPosition.x < minWidth)
        {
            rect_Background.anchoredPosition = new Vector2(minWidth, 0);
        }
    }


}
