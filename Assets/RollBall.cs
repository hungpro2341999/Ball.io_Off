using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class RollBall : Enemy
{

   
    public Vector2 posMouse;
  
    public Vector3 direct;
   
    public bool isClick1 = false;
    public bool isClick2 = false;
   
   
    Vector2 posOriginal = Vector2.zero;
    public Vector3 LastDirect=Vector2.zero;
    // Velocity
  
    public float SpeedVelocity;
    public float SpeedNode;
    public float SpeedRoll = 3;
   
    // Gird
    //Vector2[,] Gird;
    //int Width = Screen.width;
    //int Height = Screen.height;
    //public int offSetX;
    //public int offSetY;

    // Recover Path
    public List<Vector3> ListPoint= new List<Vector3>();
    public List<Vector3> ListDirect = new List<Vector3>();
    public List<Point> ListPath = new List<Point>();
    public bool IncreTimeRecover = false;
    public bool isNewPath = false;
    public float SpeedTimeRecover;
    public bool  isMovePath = false;
    public float Wait_For_Complete = 0.2f;
    //GoBack
    public bool isGoBack = false;
    public int id_Skin;
    public static int Coin;
    private void Awake()
    {

       
    }
   

   
void Start()
    {
        RollBall.Coin = 0;
        SizeSmoke = 0.2f;
        InitGird();
        SetUpSkin();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

        public void SetUpSkin() 
    {
        Parent_Skin.GetChild(0).gameObject.AddComponent<Destroy_Review>().Destroy();
        int id = DataMananger.Instance.Get_Id_Skin();
        id_Skin = id;
        var a = Instantiate(DataMananger.Instance.Data_Skills.ListModel[id], Parent_Skin);
        a.transform.localScale = Vector3.one;
        a.transform.localPosition = Vector3.zero;
    }
    public override void Update()
    {

        if (Physics.Raycast(new Ray(transform.position, -Vector3.up), CheckGround))
        {
            isGround = true;
        }
        else
        {
            StartCoroutine(GameOver(1));
           
        }

        if (!GamePlayerCtrl.Instance.isGameOver || !GamePlayerCtrl.Instance.isGamePause)
        {
            body.maxAngularVelocity = Mathf.Infinity;

            if (isGround)
            {
                Power();
                Warring_Enemy();
                Warring_Limit();
                if (Input.GetMouseButtonDown(0))
                {
                    isClick1 = true;
                }

                if (!isMoveBack)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        isClick1 = true;
                    }

                    //int count = ListPoint.Count;
                    //int x = (int)(Width / offSetX);
                    //int y = (int)(Height / offSetY);



                    if (isClick1)
                    {
                        //    if (count < 1)
                        //    {

                        //    }
                        //    //    Debug.Log("Get");



                        //    AddPoint(point);
                        //    int LastPoint = ListPoint.Count - 1;
                        //    if (ListPoint.Count > 1)
                        //    {
                        //        DirectMove = (ListPoint[LastPoint] - ListPoint[LastPoint - 1]) * Time.deltaTime;


                        //    }
                        //    else
                        //    {
                        //        DirectMove = Vector3.zero;
                        //        AddDirect(DirectMove);
                        //    }
                        //    // GeneratePath();





                        //}
                        //else
                        //{
                        //    ClearRecover();
                        //}
                        Vector3 point = Input.mousePosition;
                        DirectMove = Process_Point(point);
                        MoveToWardMouse();


                    }
                    else
                    {

                        //ClearRecover();
                        Reset();
                      
                        
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        isClick1 = false;
                        Reset();
                        //ClearRecover();

                    }
                   
                }
                else
                {

                    if (Vector3.SqrMagnitude(body.velocity) < Mass)
                    {
                        isMoveBack = false;
                    }
                    else
                    {
                        body.velocity = body.velocity - Time.deltaTime * body.velocity * MassChance;



                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        isClick1 = false;
                        Reset();
                        //ClearRecover();

                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        isClick1 = true;
                    }
                    if (isClick1)
                    {
                        Vector3 point = Input.mousePosition;
                        Process_Point(point);
                    }
                        // Reset();
                        //ClearRecover();

                    }
                Force = body.velocity.magnitude;

            }
        }
        Spawn_Effect();
    }
    private void LateUpdate()
    {
        //   SpinBall(LastDirect.normalized,LastDirect.magnitude);
        if (Wait_For_Complete > 0)
        {
            isGround = true;
            Wait_For_Complete -= Time.deltaTime;
        }
        
    }
    public float rotationX = 0;
    public float rotationY = 0;
    public float SpeedRotaion = 20;

   
   
    public void RotationBall()
    {
      
    }


    public void GoBack(float Force,Vector3 Direct)
    {

        isMoveBack = true;
        body.AddForce((Direct*Force),ForceModeWhenInteraction);
        isClick1 = false;
        
        ClearRecover();
        //    Debug.Log(-getDirect() * SpeedVelocity);
        // ClearRecover();
     
    }


    public void ClearRecover()
    {
       IncreTimeRecover = false;
       isNewPath = false;
       ListPath.Clear();
       ListDirect.Clear();
       ListPoint.Clear();
    }

    public void AddPoint(Vector3 point)
    {
        int count = ListPoint.Count;
       if(count == 0)
        {
            ListPoint.Add(point);
        }
        else
        {
            if (ListPoint[count - 1] != point)
            {
                IncreTimeRecover = true;
                ListPoint.Add(point);
            }
            else
            {
                IncreTimeRecover = false;
            }
           
        }
    }
    public void AddDirect(Vector3 direct)
    {
        int count = ListDirect.Count;
        if (count == 0)
        {
            ListDirect.Add(direct);
        }
        else
        {
            if (ListDirect[count - 1] != direct)
            {
                isNewPath = false;
                ListDirect.Add(direct);
            }
            else
            {
                isNewPath = true;
            }
           
        }
    }
    public void  GeneratePath()
    {
        if (isNewPath)
        {

            Point point = new Point();
            point.Pos = transform.position;
            point.Time = 0;
            if (ListPath.Count > 0)
            {
                point.Speed = ListPath[ListPath.Count - 1].Speed;
            }
            ListPath.Add(point);

        }
        else
        {
            if (ListPath.Count != 0)
            {
                RunningRecover();
            }
        }
    }

    public void RunningRecover()
    {
        int lastIndex = ListPath.Count - 1;
        if (ListDirect.Count != 0)
        {
            if (IncreTimeRecover)
            {
                ListPath[lastIndex].Time += Time.deltaTime * SpeedTimeRecover;
            }
          

        }
    }
    public Vector3 getDirect()
    {
        if (ListDirect.Count != 0)
        {
            return  new Vector3(ListDirect[ListDirect.Count - 1].x,0,-ListDirect[ListDirect.Count - 1].y).normalized;
        }
        else
        {
            return Vector3.zero;
        }
    }


    public  void ResetStatus()
    {
                
    }

    

    public Vector3 DetectDirect(List<Vector3> listPoint)

    {
        Vector3 direct;
        
            if (ListPoint.Count == 1)
            {
                return Vector3.zero;
            }

            direct = ListPoint[ListPoint.Count] - ListPoint[ListPoint.Count-1];
        return direct;

        
    }

    public void MoveToWardMouse()
    {
       
                DirectMove = new Vector3(DirectMove.x, 0, DirectMove.y);

            

            body.AddForce(DirectMove * Speed*Time.deltaTime*Length,ForceModeWhenMove);
            //  Body.AddForce(new Vector3(LastDirect.x * SpeedVelocity, 0, -LastDirect.y * SpeedVelocity));
            // Body.AddForce(LastDirect* SpeedVelocity,ForceMode.VelocityChange);
            //   Debug.Log("ADD FORCE_1");
        
       
       

      //  Body.velocity = Vector3.ClampMagnitude(Body.velocity, maxVec);
        Force = Vector3.Magnitude(body.velocity);



    }
  
    public void RotateAroundMouse(Vector3 direct)

    {

      //  transform.rotation = Quaternion.Euler(Time.deltaTime * moveSpeed, 1, 1);

    }

    public void Limit_Velocity()
    {


    }

    

    public void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 1000))
        {
            DirectMove = hit.point;
        }

    }

    //Path
 

    Vector3 PosTarget = Vector3.zero;
    public bool isNext()
    {
        if (ListPath.Count > 0)
        {
            return false;
        }   
        else
        {
            return true;
        }
    }
   
    
    public void InitGird()
    {
      // // Debug.Log(Width + "  " + Height);
      //  int x = (int)( Width / offSetX);
      //  int y = (int)(Height / offSetY);
      //  Gird = new Vector2[x, y];
      ////  Debug.Log(x+" "+y);
      //  for(int i=y-1; i>=0; i --)
      //      for(int j = 0; j <x; j++)
      //      {
      //          Gird[j,i] = new Vector2(j*offSetX,Height-i*offSetY);
      //      }
        
    }
    public void IncreTime()
    {
        if (ListPath.Count > 0)
        {
            ListPath[0].Time += Time.deltaTime;
        }
    }
    public Point GetNodeCurr()
    {
        return ListPath[0];
    }
  



    
   


    public Vector3 getPosWordSpace(Vector3 vector3) {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Vector3 pos = new Vector3(hit.point.x, hit.point.y,hit.point.z) ;
            return pos;
        }
        else
        {
            return Vector3.zero;
        }
       

    }



    private void FixedUpdate()
    {
       
       // Body.AddTorque(Body.angularVelocity.normalized * 30, ForceMode.Impulse);
    }
    public IEnumerator GameOver(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isGround = Physics.Raycast(new Ray(transform.position, -Vector3.up), CheckGround);
        

    }

    public float cachedReal = 0;
    public Vector3 Process_Point(Vector3 point)
    {
        Point.Add(point);
        int length = Point.Count;
        if (length > 1)
        {
            if (Point[length - 1] != Point[length - 2])
            {
                Vector3 direct = Point[length - 1] - PosInit;

                Debug.Log("TOWARD_MOUSE");

                if (Vector3.Angle(direct.normalized,DirectMove.normalized)>4)
                {
                    PosInit = Point[length - 1];
                    Point.RemoveRange(0, length - 1);
                    direct = Vector3.zero;
                    return Vector3.zero;
                    
                }
                return direct.normalized*cachedReal;

            }
            else
            {
                Debug.Log("INIT_2");
                PosInit = Point[length - 1];
                Point.RemoveRange(0, length - 1);
                return Vector3.zero;
            }
        }
        else
        {
            Debug.Log("INIT");
            PosInit = Point[length - 1];
            return Vector3.zero;
        }


    }
    public void Reset()
    {
        PosInit = Vector3.zero;
        Point.Clear();
    }

    private void OnDrawGizmos()
    {

        //Rect rectInt = new Rect(1, 1, 1, 1);
        //int x = (int)(Width / offSetX);
        //int y = (int)(Height / offSetY);
        //Vector3 PosInit = Camera.main.ScreenToViewportPoint(new Vector3(0, 1280, 0));
        //InitGird();
        //for (int i = 0; i <= y; i++)
        //{


        //    //  Debug.DrawLine(new Vector3(0, i * offSetY, 0), new Vector3(720, i * offSetY, 0));
        //}
        //for (int i = 0; i <= x; i++)
        //{
        //    Gizmos.color = Color.blue;

        //    //   Debug.DrawLine(new Vector3(i * offSetX, 0, 0), new Vector3(i * offSetX, 1280, 0));

        //}
        //Gizmos.DrawRay(new Ray(transform.position, DirectMove * 100));
        
       



    }
    

}