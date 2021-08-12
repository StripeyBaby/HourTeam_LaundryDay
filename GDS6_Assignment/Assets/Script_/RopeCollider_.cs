using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rope_))]
public class RopeCollider_ : MonoBehaviour
{
    [SerializeField] LineRenderer drawingLine;
    //带有碰撞体的LineRenderer, 要有PolygonCollider2D、LineRenderer组件, 
    [SerializeField] GameObject colliderLinePrefab;
    //灵敏度 
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

    //鼠标点击
    Vector3 lastPos;
    List<Vector3> touchPosList = new List<Vector3>();
    public void OnPressScreen(Vector3 pressPos)
    {
        touchPosList.Clear();
        lastPos = pressPos;

        drawingLine.enabled = true;
        drawingLine.positionCount = 0;
    }

    //鼠标拖拽
    Vector3 tmpStartPoint;
    Vector3 tmpEndPoint;
    public void OnTouchScreen(Vector3 touchPos)
    {
        tmpStartPoint = lastPos;
        tmpEndPoint = touchPos;

        //显示绘制line
        if (Vector3.Distance(tmpStartPoint, tmpEndPoint) > minTouchDistance)
        {
            touchPosList.Add(lastPos);

            drawingLine.positionCount = touchPosList.Count;
            drawingLine.SetPosition(touchPosList.Count - 1, touchPosList[touchPosList.Count - 1]);

            lastPos = touchPos;
        }
    }

    //鼠标抬起
    public void OnReleaseScreen(Vector3 releasePos)
    {
        drawingLine.positionCount = 0;
        drawingLine.enabled = false;

        //绘制结束，生成碰撞line
        touchPosList.Add(releasePos);
        if (touchPosList.Count > 3)
            CreateColliderLine(touchPosList);
    }

    //生成碰撞line
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

    //计算碰撞体轮廓
    float colliderWidth;
    List<Vector2> pointList2 = new List<Vector2>();
    List<Vector2> GetColliderPath(List<Vector3> pointList3)
    {
        //碰撞体宽度
        colliderWidth = drawingLine.startWidth;
        //Vector3转Vector2
        pointList2.Clear();
        for (int i = 0; i < pointList3.Count; i++)
        {
            pointList2.Add(pointList3[i]);
        }
        //碰撞体轮廓点位
        List<Vector2> edgePointList = new List<Vector2>();
        //以LineRenderer的点位为中心, 沿法线方向与法线反方向各偏移一定距离, 形成一个闭合且不交叉的折线
        for (int j = 1; j < pointList2.Count; j++)
        {
            //当前点指向前一点的向量
            Vector2 distanceVector = pointList2[j - 1] - pointList2[j];
            //法线向量
            Vector3 crossVector = Vector3.Cross(distanceVector, Vector3.forward);
            //标准化, 单位向量
            Vector2 offectVector = crossVector.normalized;
            //沿法线方向与法线反方向各偏移一定距离
            Vector2 up = pointList2[j - 1] + 0.5f * colliderWidth * offectVector;
            Vector2 down = pointList2[j - 1] - 0.5f * colliderWidth * offectVector;
            //分别加到List的首位和末尾, 保证List中的点位可以围成一个闭合且不交叉的折线
            edgePointList.Insert(0, down);
            edgePointList.Add(up);
            //加入最后一点
            if (j == pointList2.Count - 1)
            {
                up = pointList2[j] + 0.5f * colliderWidth * offectVector;
                down = pointList2[j] - 0.5f * colliderWidth * offectVector;
                edgePointList.Insert(0, down);
                edgePointList.Add(up);
            }
        }
        //返回点位
        return edgePointList;
    }




}
