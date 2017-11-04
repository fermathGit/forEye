using UnityEngine;

public class MyBezier : MonoBehaviour {

    //贝塞尔曲线算法类
    public Bezier myBezier;

    //曲线的对象
    public GameObject Yellowline;

    //曲线对象的曲线组件
    private LineRenderer YellowlineRenderer;

    //标记第二个第三个点
    public GameObject dotClone;

    int c_linePosCount = 100;
    int c_dotCount = 4;
    Vector3 c_dotStartPos = new Vector3( -5f, 0f, 0f );
    Vector3 c_dotDisPos = new Vector3( 2.5f, 0f, 0f );

    Transform m_dotPool;
    void Start() {
        //得到曲线组件
        YellowlineRenderer = Yellowline.GetComponent<LineRenderer>();
        //为了让曲线更加美观，设置曲线由100个点来组成
        YellowlineRenderer.positionCount = c_linePosCount;
        m_dotPool = transform.Find( "DotPool" );
        for ( int i = 0, imax = c_dotCount; i < imax; ++i ) {
            var go = Instantiate( dotClone, m_dotPool );
            if ( go != null ) {
                go.transform.position = c_dotStartPos + i * c_dotDisPos;
            }

        }
    }

    void Update() {
        if ( m_dotPool.childCount != c_dotCount ) return;
        //在这里来计算贝塞尔曲线
        //四个参数 表示当前贝塞尔曲线上的4个点 第一个点和第四个点
        //我们是不需要移动的，中间的两个点是由拖动条来控制的。
        myBezier = new Bezier( m_dotPool.GetChild( 0 ).position,
            m_dotPool.GetChild( 1 ).position,
            m_dotPool.GetChild( 2 ).position,
            m_dotPool.GetChild( 3 ).position );

        //循环100遍来绘制贝塞尔曲线每个线段
        for ( int i = 1; i <= c_linePosCount; i++ ) {
            //参数的取值范围 0 - 1 返回曲线没一点的位置
            //为了精确这里使用i * 0.01 得到当前点的坐标
            Vector3 vec = myBezier.GetPointAtTime( (float)( i * 0.01 ) );
            //把每条线段绘制出来 完成白塞尔曲线的绘制
            YellowlineRenderer.SetPosition( i - 1, vec );
        }
    }
}
