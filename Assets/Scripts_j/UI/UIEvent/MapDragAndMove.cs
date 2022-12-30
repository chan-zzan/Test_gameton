using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapDragAndMove : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // ��� ���� ������Ʈ�� RectTransform
    public RectTransform rect_Background;

    public float game_X_Resolution = 1080f; // ���� x �ػ�
    public float game_Y_Resolution = 1920f; // ���� y �ػ�

    [SerializeField]
    private float maxWidth; // ȭ�� �̵� �ִ� �� (x ����)
    [SerializeField]
    private float minWidth; // ȭ�� �̵� �ּ� �� (x ����)

    // �巡�׸� ���� x �� �̵��� ���
    private float startPoint;   // �巡�� ���� �� �� x��ǥ
    private float startDrag;    // �巡�� ���� ���콺 ��ǥ
    private float resultPos;    // �̵��� ��ǥ

    public GameObject leftSideUIGroup;  // ȭ�� �巡�� �� ��Ȱ��ȭ �� ���� UI �׷�
    public GameObject rightSideUIGroup; // ȭ�� �巡�� �� ��Ȱ��ȭ �� ���� UI �׷�

    

    private void Awake()
    {
        maxWidth = (rect_Background.sizeDelta.x - game_X_Resolution)/2;
        minWidth = (-1 * maxWidth) + 5.0f;  // ȭ�� ���� ��¦ ������ 5��ŭ �߰���.
    }



    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� �¿� UI ��� ����
        Debug.Log("Start Drag");
        Debug.Log("Xpos : " + eventData.position.x);

        leftSideUIGroup.SetActive(false);
        rightSideUIGroup.SetActive(false);

        // �巡�� ���� ��ǥ ����
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
        // �巡�� ���� �� �¿� UI �ٽ� ǥ��
        Debug.Log("End Drag");
        Debug.Log("Xpos : " + rect_Background.anchoredPosition.x);

        leftSideUIGroup.SetActive(true);
        rightSideUIGroup.SetActive(true);

        // �� ������ ����� ���
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
