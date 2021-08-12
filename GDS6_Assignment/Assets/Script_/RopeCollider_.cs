using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rope_))]
public class RopeCollider_ : MonoBehaviour
{
    [SerializeField] LineRenderer drawingLine;
    //������ײ���LineRenderer, Ҫ��PolygonCollider2D��LineRenderer���, 
    [SerializeField] GameObject colliderLinePrefab;
    //������ 
    [SerializeField] float minTouchDistance = 0.1f;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        //
        drawingLine.enabled = false;
        drawingLine.positionCount = 0;
    }

    Vector3 tmpTouchPos;
    bool tmpIsMouseDown;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tmpIsMouseDown = true;
            tmpTouchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            tmpTouchPos.z = 0;
            OnPressScreen(tmpTouchPos);
        }
        else if (Input.GetMouseButton(0) && tmpIsMouseDown)
        {
            tmpTouchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            tmpTouchPos.z = 0;
            OnTouchScreen(tmpTouchPos);
        }
        else if (Input.GetMouseButtonUp(0) && tmpIsMouseDown)
        {
            tmpTouchPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            tmpTouchPos.z = 0;
            OnReleaseScreen(tmpTouchPos);
            tmpIsMouseDown = false;
        }
    }

    //�����
    Vector3 lastPos;
    List<Vector3> touchPosList = new List<Vector3>();
    public void OnPressScreen(Vector3 pressPos)
    {
        touchPosList.Clear();
        lastPos = pressPos;

        drawingLine.enabled = true;
        drawingLine.positionCount = 0;
    }

    //�����ק
    Vector3 tmpStartPoint;
    Vector3 tmpEndPoint;
    public void OnTouchScreen(Vector3 touchPos)
    {
        tmpStartPoint = lastPos;
        tmpEndPoint = touchPos;

        //��ʾ����line
        if (Vector3.Distance(tmpStartPoint, tmpEndPoint) > minTouchDistance)
        {
            touchPosList.Add(lastPos);

            drawingLine.positionCount = touchPosList.Count;
            drawingLine.SetPosition(touchPosList.Count - 1, touchPosList[touchPosList.Count - 1]);

            lastPos = touchPos;
        }
    }

    //���̧��
    public void OnReleaseScreen(Vector3 releasePos)
    {
        drawingLine.positionCount = 0;
        drawingLine.enabled = false;

        //���ƽ�����������ײline
        touchPosList.Add(releasePos);
        if (touchPosList.Count > 3)
            CreateColliderLine(touchPosList);
    }

    //������ײline
    void CreateColliderLine(List<Vector3> pointList)
    {
        GameObject prefab = Instantiate(colliderLinePrefab, transform);
        LineRenderer lineRenderer = prefab.GetComponent<LineRenderer>();
        PolygonCollider2D polygonCollider = prefab.GetComponent<PolygonCollider2D>();

        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());

        List<Vector2> colliderPath = GetColliderPath(pointList);
        polygonCollider.SetPath(0, colliderPath.ToArray());
    }

    //������ײ������
    float colliderWidth;
    List<Vector2> pointList2 = new List<Vector2>();
    List<Vector2> GetColliderPath(List<Vector3> pointList3)
    {
        //��ײ����
        colliderWidth = drawingLine.startWidth;
        //Vector3תVector2
        pointList2.Clear();
        for (int i = 0; i < pointList3.Count; i++)
        {
            pointList2.Add(pointList3[i]);
        }
        //��ײ��������λ
        List<Vector2> edgePointList = new List<Vector2>();
        //��LineRenderer�ĵ�λΪ����, �ط��߷����뷨�߷������ƫ��һ������, �γ�һ���պ��Ҳ����������
        for (int j = 1; j < pointList2.Count; j++)
        {
            //��ǰ��ָ��ǰһ�������
            Vector2 distanceVector = pointList2[j - 1] - pointList2[j];
            //��������
            Vector3 crossVector = Vector3.Cross(distanceVector, Vector3.forward);
            //��׼��, ��λ����
            Vector2 offectVector = crossVector.normalized;
            //�ط��߷����뷨�߷������ƫ��һ������
            Vector2 up = pointList2[j - 1] + 0.5f * colliderWidth * offectVector;
            Vector2 down = pointList2[j - 1] - 0.5f * colliderWidth * offectVector;
            //�ֱ�ӵ�List����λ��ĩβ, ��֤List�еĵ�λ����Χ��һ���պ��Ҳ����������
            edgePointList.Insert(0, down);
            edgePointList.Add(up);
            //�������һ��
            if (j == pointList2.Count - 1)
            {
                up = pointList2[j] + 0.5f * colliderWidth * offectVector;
                down = pointList2[j] - 0.5f * colliderWidth * offectVector;
                edgePointList.Insert(0, down);
                edgePointList.Add(up);
            }
        }
        //���ص�λ
        return edgePointList;
    }




}
