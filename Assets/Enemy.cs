using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WallCollison { TOP, DOWN, LEFT, RIGHT }
public enum Type_Status { ATTACK, DODGE, MOVE, RUN_AWAY }
public enum Type_AI { BLOOD_WAR, TROLL, NOBLE, NORMAL, SMART, FRIEND }
public enum RANK { BLOOD_WALL, DODGE, MOVE, RUN_AWAY }
public enum WARRING_LIMIT {LV1,LV2,LV3,LV4,LV5}
public enum WARRING_ENEMY {LV1,LV2,LV3,LV4 }
public enum POWER {LV1,LV2,LV3,LV4,LV5}
public enum CHANGE_VELOCITY { MOVE, ATTACK,DODGE,RUN,NONE}
public class Enemy : MonoBehaviour
{

  
    public float MassChance = 1;
    public AiStatus Status;
    public Text text;
    public CHANGE_VELOCITY Type_Chance = CHANGE_VELOCITY.NONE;
    public ForceMode ForceModeWhenMove;
    public ForceMode ForceModeWhenInteraction;
    public ForceMode ForceModeWhenBrake;
    public Type_Status status = Type_Status.MOVE;
    public WARRING_LIMIT type_warring;
    public POWER type_power;
    public WARRING_ENEMY type_warring_enemy;
    public GameObject Ground = null;
    public Rigidbody body;
    public Player Target;
    public float Speed=3;
    public Vector3 Direct;
    public  bool isMoveBack = false;
    public LayerMask MaskPlayer;
    public LayerMask WallLayer;
    public float Force;
    public float Bonnd;
    public float Mass;
    public float ForceMass=1;
    public float ForceIntereact;
    public float CheckGround = 1;
    public bool isGround = false;
    public float Range;
    public float SpeedChance = 5;
    public float Length = 100;
    public float SpeedSlownDown = 1f;
    public Transform Skin;
    //Local Variable
    public List<Transform> ListRay = new List<Transform>();
    float Percent;
   

    //Info Strenght Ball
    public float weight = 1;
    public float distanceRay;
    
    public float Radius = 1;
    // Go Back
    public float MinForce;
    public float MaxForce;


    public bool isMoveLimit = false;
    public float Bound;
    public float MassLimit;
    public float Weight = 1;
    public Vector3 VectorReflect;
    //AI
    public float LevelBall = 1;
    public bool isRunAway = false;
    public bool isDodge = false;
    public bool IsAttack = false;
    public float ForceIntertion;
    public Vector3 DirectMove = Vector3.zero;
    public float maxTime = 4;
    public float minTime = 2;
    public bool isMoving = false;
    public bool isLoopDirect = false;
    public int index_Enemy = 0;
    public int index_Limit = 0;
    public int index_Power = 0;
    public int index_Skill = 0;
    public int index_scoward = 0;
    public float indexPower;
    public float maxVec=3;
    public int index_Blood_War = 0;
    public int index_Dodge = 0;

    public bool Keep_Direction_Move = false;
    public bool Keep_Direction_Dodge = false;
    public bool Keep_Direction_RunAway = false;
    public bool Keep_Direction_Attack = false;
    // RunAway
    public Player[] playerRunAway;
    public Player PlayerDodge;
    public Vector3[] directX8 = { new Vector3(0, 0, 1) ,new Vector3(0.5f,0,0.5f),new Vector3(1,0,0),new Vector3(0.5f,0,-0.5f),new Vector3(-0.5f,0,-0.5f),new Vector3(-0.5f,0,0.5f),new Vector3(-1,0,0),new Vector3(0,0,-1)};
    public Vector3[] directx4 = { new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, -1) };
   

    //Local Variable
    bool Stop = false;
    bool isDead = false;
    //Effect
    public GameObject ParticeSmoke;
    public float CoolTimeSmoke = 1;
    //Set String
    public Transform Parent_Skin;
    public Player isTargetBy;
    public float Length_Push;
    public float level=1;
    public float SizeSmoke = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
         LevelBall = 1;
        if (DataMananger.MapSelec == 3 || DataMananger.MapSelec == 4)
        {
            Radius =  Random.Range(0.5f,1f);
            maxVec = 10;
          
            maxVec = 15;
        }
        else
        {
            Radius = Random.Range(0.5f, 1.5f);
           
            maxVec = 20;
        }
        if (Random.Range(0, 6) != 1)
        {
         
            index_Blood_War = Random.Range(1, 10);
            index_Dodge = Random.Range(1, 3);

        }
        else
        {
            Radius = 3f;
           
            index_Blood_War = 9;
            index_Dodge = 1;
        }
      
        SizeSmoke = 0.2f;
        Percent = GameObject.Find("Map").GetComponent<InforMap>().Radian;
    //    Debug.Log(gameObject.name +" "+ DistanceFromWall(new Vector3(1,0,0)));
      
        body = GetComponent<Rigidbody>();
        Random_Skill();
    }
    public void Random_Skill()
    {
        Parent_Skin.GetChild(0).gameObject.AddComponent<Destroy_Review>().Destroy();
        int id = Random.Range(0, DataMananger.Instance.Data_Skills.ListModel.Count-1);
        while (id == 11 || id == 18)
        {
             id = Random.Range(0, DataMananger.Instance.Data_Skills.ListModel.Count);
        }
        var a = Instantiate(DataMananger.Instance.Data_Skills.ListModel[id], Parent_Skin);
        a.transform.localScale = Vector3.one;
        a.transform.localPosition = Vector3.zero;
          
    }

    public void Set_Skin()
    {
        Parent_Skin.GetChild(0).gameObject.AddComponent<Destroy_Review>().Destroy();
       
    }
    public Vector3 TransfromVector(Vector3 pos)
    {
        Vector3 idk = Quaternion.Euler(0, transform.localEulerAngles.y,0) * pos;
        return idk;
    }
    // Update is called once per frame
    public virtual void Update()
    {
       
        if (Physics.Raycast(new Ray(transform.position, -Vector3.up), CheckGround))
        {
            // body.constraints = RigidbodyConstraints.FreezePositionY;
            isGround = true;
        }
        else
        {
            //  isGround = false;
            StartCoroutine(Remove(0.05f));
            body.constraints = RigidbodyConstraints.None;
        }
        if (!GamePlayerCtrl.Instance.isGamePause )
        {
        
            /// Move

            if (isGround)
            {
                Power();
                Warring_Enemy();
                Warring_Limit();

                MoveFollowDirect();
                Spawn_Effect();
            }
            else
            {
                if (!isDead)
                {
                    isDead = true;
                    GamePlayerCtrl.Instance.Incre_Radius();
                    if (isTargetBy != null)
                    {
                        if (isTargetBy.tag == "Player")
                        {
                            DataMananger.Instance.PlayAudio("levelup", Vector3.zero);
                           RollBall.Coin += 25;
                            DataMananger.Instance.Add_Coin(25);
                            var a = Instantiate(SpawnEffect.Instance.getEffectName("Score"), null);
                            a.GetComponent<Destroy>().SetPosText(transform.position);

                        }
                       
                            isTargetBy.GetComponent<Enemy>().Incre_Level(isTargetBy.GetComponent<Enemy>().LevelBall);
                            LevelBall += isTargetBy.GetComponent<Enemy>().LevelBall;
                        
                      
                       
                        isTargetBy = null;
                       
                    }
                   
                    body.constraints = RigidbodyConstraints.None;
                }
            
            }





            //InforBall
        
            Force = Vector3.Magnitude(body.velocity);
        }
    }
    public void FindAgainMove()
    {
        if (IsCollWall(body.velocity.normalized))
        {
            body.velocity = body.velocity - Time.deltaTime * body.velocity*MassChance;
        }
         
        
       
        if (!Keep_Direction_Move)
        {
            isMoving = false;
            StartCoroutine(RandomDirect(directX8));
            Keep_Direction_Move = true;
        }
        /*
        body.velocity = body.velocity - Time.deltaTime*body.velocity*MassChance ;
        if (status == Type_Status.MOVE)
        {
           
            isMoving = false;
            StartCoroutine(RandomDirect(directX8));
        }
        else if(status == Type_Status.DODGE)
        {
            isDodge = false;
            StartCoroutine(Start_Dodge());
          
        }else if(status == Type_Status.RUN_AWAY)
        {
            isRunAway = false;
            StartCoroutine(Start_RunAway());
        }else if (status == Type_Status.ATTACK)
        {
           
            body.AddForce(DirectMove * SpeedChance, ForceMode.VelocityChange);
        }
       */
    }

    public void FindAgainDodge()
    {
        if (IsCollWall(body.velocity.normalized))
        {
            body.velocity = body.velocity - Time.deltaTime * body.velocity * MassChance;
        }
        if (!Keep_Direction_Dodge)
        {
            isDodge = false;
            StartCoroutine(Start_Dodge());
            Keep_Direction_Dodge = true;
        }
    }

    public void FindAgainRunAway()
    {
        if (IsCollWall(body.velocity.normalized))
        {
            body.velocity = body.velocity - Time.deltaTime * body.velocity * MassChance;
        }
        if (!Keep_Direction_RunAway)
        {
            isRunAway = false;
            StartCoroutine(Start_RunAway());
            Keep_Direction_RunAway = true;
        }
    }
    public void FindAgainAttack()
    {
        if (IsCollWall(body.velocity.normalized))
        {
            body.velocity = body.velocity - Time.deltaTime * body.velocity * MassChance;
        }
        if (!Keep_Direction_Attack)
        {
            IsAttack = false;
           
            Keep_Direction_Attack = true;
        }
    }



    private void MoveFollowDirect()
    {
        // int direcy = (int)ScoreOfDirectx8();

        if (!isMoveBack)
        {
            // Try it   
            Process_Status();
         
          


                if (1==1)
                {
                  
                    switch (status)
                    {
                        case Type_Status.MOVE:

                            Move();
                            break;
                        case Type_Status.ATTACK:
                        StartCoroutine(Start_Attack());
                            break;
                        case Type_Status.DODGE:
                            StartCoroutine(Start_Dodge());

                            break;
                        case Type_Status.RUN_AWAY:
                            StartCoroutine(Start_RunAway());
                            break;
                    }

                    if (index_Limit >= 4)
                    {
                     
                        switch (status)
                        {
                            case Type_Status.MOVE:
                                Type_Chance = CHANGE_VELOCITY.MOVE;
                             
                                break;
                            case Type_Status.ATTACK:
                            if (Target != null)
                            {
                             
                                    Type_Chance = CHANGE_VELOCITY.ATTACK;
                                    FindAgainAttack();
                              
                            }   
                                
                               
                                break;
                            case Type_Status.DODGE:

                                Type_Chance = CHANGE_VELOCITY.DODGE;
                                break;
                            case Type_Status.RUN_AWAY:
                                Type_Chance = CHANGE_VELOCITY.RUN;
                                break;
                        }

                    }
                    else
                    {
                      Type_Chance = CHANGE_VELOCITY.NONE;
                    }

                    switch (Type_Chance)
                    {
                        case CHANGE_VELOCITY.NONE:
                            Keep_Direction_Move = false;
                            Keep_Direction_Dodge = false;
                            Keep_Direction_RunAway = false;
                        Keep_Direction_Attack = false;
                        
                            break;
                        case CHANGE_VELOCITY.MOVE:
                            FindAgainMove();

                            break;
                        case CHANGE_VELOCITY.RUN:
                            FindAgainRunAway();
                            break;
                        case CHANGE_VELOCITY.ATTACK:
                        FindAgainAttack();
                            break;
                        case CHANGE_VELOCITY.DODGE:
                            FindAgainDodge();
                            break;
                            
                    }
                      

                   // ICanNotDead();
                    body.AddForce(DirectMove*Speed*Time.deltaTime*2*0.85f,ForceModeWhenMove);




                 //   Debug.Log("Forece");
                }
               
        }
        else
        {
           
                if (Vector3.Magnitude(body.velocity) < Mass)
                {
                //    StartCoroutine(Remove_Target(1));
                    
                    isMoveBack = false;
                }
                else
                {
                    //     Debug.Log("Chance");
                    body.velocity = body.velocity - Time.deltaTime * body.velocity * MassChance;
                    // body.AddForce(-DirectMove.normalized * Mass);

                }
            
           
         
        }
    }
   
    public float Reset_Mass = 0.08f;
    public bool isCollWith(Player player)
    {
       
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit[] hits = Physics.SphereCastAll(ray,4, 0, MaskPlayer);
       

        string s = "";
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject != player.gameObject)
            {
                s += "  " + hits[i].collider.gameObject.name;
                return true;
            }

        }
{
            return false;

        }
       
        //  Debug.Log(gameObject.name+ " "+s);
     
    }
    
    private void FixedUpdate()
    {
       
        
    }

    public void Spawn_Effect()
    {
        if (CoolTimeSmoke < 0)
        {
            CoolTimeSmoke = 0.1f;
            if (Force >= 1f)
            {
                var a = Instantiate(ParticeSmoke, transform.position, Quaternion.identity, null);
                //ParticleSystem.MainModule sys = a.GetComponent<ParticleSystem.MainModule>();
                //sys.startSizeXMultiplier = SizeSmoke;
                //sys.startSizeYMultiplier = SizeSmoke;
                //sys.startSizeXMultiplier = SizeSmoke;

                var main = a.GetComponent<ParticleSystem>().main;
                main.startSizeXMultiplier = SizeSmoke;
                main.startSizeYMultiplier = SizeSmoke;
                main.startSizeZMultiplier = SizeSmoke;

            }


        }
        else
        {
            
            CoolTimeSmoke -= Time.deltaTime;
        }
    }
    public bool  IsCollWall(Vector3 direct)
        {
        Ray ray = new Ray(transform.position,direct.normalized);

       

           RaycastHit[] hit = null;
       
       
        hit = Physics.RaycastAll(ray, distanceRay);

            for (int i = 0; i < hit.Length; i++)
            {
                     


                if (hit[i].collider.gameObject.layer == 12)
                {
               //      Debug.Log("COll");


                return true;

                //   Debug.Log("Coll" + (hit[i].collider.gameObject.name));

              //  FindAgain();
            }
          
        }
        return false;
        }
    public bool isColling = false;
        public void MoveBack(GameObject player,Vector3 direct,Enemy enemy,Vector3 pos)
        {
        StopAllCoroutines();
       
        isMoveLimit = false;
        isDodge = false;
        isRunAway = false;
        float ForcePlayer = enemy.GetComponent<Enemy>().Get_Force();
       
        float BoundPlayer = enemy.GetComponent<Enemy>().Bonnd;
     
      
        float ForceBack = 0;
        if (!isMoveBack)
        {
            ForceBack = (ForcePlayer + Get_Force());
        }
        else
        {
            ForceBack = Mathf.Max(ForcePlayer,Get_Force());
        }

        if (ForceBack > 2)
        {
            DataMananger.Instance.PlayAudio("va2", pos);
           

        }
        if (ForceBack > 3)
        {
            Instantiate(SpawnEffect.Instance.getEffectName("Hit"), pos, Quaternion.identity, null);
            ForceIntertion = (ForceBack / weight) * BoundPlayer;
        }
          


        DirectMove = direct;
  
        if (gameObject.tag == "Player")
        {
            //   Debug.Log(DirectMove + "  " + ForcePlayer + "  " + Force + "  " + Length + " " + BoundPlayer);
            // Debug.Log((ForcePlayer + Force) * Length * 1.2f);
         //    StartCoroutine(Return_Move_Back(0.05f));
            AddForce((DirectMove * ForceIntertion), ForceModeWhenInteraction, ForceIntertion);
            if (DataMananger.Instance.Is_Variable() == 1) 
            {
                Handheld.Vibrate();
            }
          

        }
        else
        {
       //     StartCoroutine(Return_Move_Back(0.05f));
            // Debug.Log(DirectMove + "  " + ForcePlayer + "  " + Force + "  " + Length + " " + BoundPlayer);
            // Debug.Log((ForcePlayer + Force) * Length * 1.2f);
            AddForce((DirectMove * ForceIntertion), ForceModeWhenInteraction, ForceIntertion);
        

        }
        }
   
    
    public void AddForce(Vector3 Force,ForceMode Force_Mode,float ForceInteraction)
    {
        RestoreStatus();
        isMoveBack = true;
     //   body.velocity = Vector3.zero;
        this.ForceIntertion = ForceInteraction;
        body.AddForce(Vector3.ClampMagnitude(Force,maxVec),ForceModeWhenInteraction);
      

    }
    public void RestoreStatus()
    {
        IsAttack = false;
        isDodge = false;
        isMoving = false;
        isRunAway = false;
        Keep_Direction_Attack = false;
        Keep_Direction_Dodge = false;
        Keep_Direction_Move = false;
        Keep_Direction_RunAway = false;
    }
   
    private void OnCollisionEnter(Collision collision)
    {

     
   
        if (collision.gameObject.layer == 10)
        {
            isTargetBy = collision.gameObject.GetComponent<Player>();
            Vector3 posInit = collision.collider.ClosestPointOnBounds(transform.position);
       
            Vector3 pos1 = collision.gameObject.transform.position;
                Vector3 pos = transform.position;
                Vector3 direct = (pos - pos1).normalized;
                direct = new Vector3(direct.x, 0, direct.z);
                Debug.Log("Hit");
                MoveBack(gameObject, direct, collision.gameObject.GetComponent<Enemy>(),posInit);
            
         
          
         
        }
     
    }

  

    

    //

        public IEnumerator Start_Dodge()
    {
        if (!isDodge)
        {
           
            Dodge();
           
           
            StartCoroutine(Restore_Dodge(2));
            yield return new WaitForSeconds(0);


        }


    }

    public IEnumerator Start_Attack()
    {
        if (!IsAttack)
        {


            Attack();

            StartCoroutine(Restore_Attack(Random.Range(0,1.75f)));
            yield return new WaitForSeconds(0);


        }


    }

    public IEnumerator Restore_Attack(float time)
    {

        IsAttack = true;
        yield return new WaitForSeconds(time);

        IsAttack = false;
    }

    public IEnumerator Restore_Dodge(float time)
    {
        
        isDodge = true;
        yield return new WaitForSeconds(time);
        
        isDodge = false;
    }
    public IEnumerator Start_RunAway()
    {
        if (!isRunAway)
        {


            RunAway();
            StartCoroutine(Restore_RunAway(Random.Range(minTime, maxTime)));
            
            yield return new WaitForSeconds(0);

            
        }


    }



    public IEnumerator Restore_RunAway(float time)
    {
        isRunAway = true;
        yield return new WaitForSeconds(time);
        isRunAway = false;
    }
    public void RunAway()
    {
        if (playerRunAway != null)
        {
            List<Vector3> direct = new List<Vector3>();
            for (int i = 0; i < directX8.Length; i++)
            {
                direct.Add(directX8[i]);
            }
            float[] Score;
            for (int i = 0; i < playerRunAway.Length; i++)
            {


                for (int j = 0; j < directX8.Length; j++)
                {
                    if (IsCollWithPlayer(directX8[j], playerRunAway[i]))
                    {
                        Debug.Log("Remove Direct : " + gameObject.name + " " + playerRunAway[i].gameObject.name + "  " + directX8[j]);
                        if (direct.Contains(directX8[j]))
                        {
                            direct.Remove(directX8[j]);

                        }
                    }


                }



            }
            Score = new float[direct.Count];
            string s1 = "";
            for (int i = 0; i < direct.Count; i++)
            {
                s1 += " " + direct[i];
            }

            int index = ScoreOfDirect(direct.ToArray());

            DirectMove = direct[index];
            body.AddForce(DirectMove * SpeedChance*Length, ForceMode.Force);
         //   Debug.Log(s1);
          // Debug.Log(DirectMove);
        }
        else
        {
            status = Type_Status.MOVE;
        }
        

    }



    public void Dodge()
    {
        if (PlayerDodge != null)
        {
           
            List<Vector3> direct = new List<Vector3>();
            float[] Score;
            for (int i = 0; i < directX8.Length; i++)
            {
                direct.Add(directX8[i]);
            }


            for (int j = 0; j < directX8.Length; j++)
            {
                
                if (IsCollWithPlayer(directX8[j], PlayerDodge))
                {
                    if (direct.Contains(directX8[j]))
                    {
                       
                        direct.Remove(directX8[j]);
                        direct.Remove(-directX8[j]);
                        //       
                    }
                }

            }
           






            Score = new float[direct.Count];
      //     Debug.Log(direct.Count + "  "+directX8.Length);

            int index = ScoreOfDirectWithAngle(direct.ToArray(),(transform.position-PlayerDodge.transform.position).normalized);

             DirectMove = direct[index];
           
       //     Debug.Log(DirectMove);

        }
        else
        {
            status = Type_Status.MOVE;
        }

    }
    public  void isCollWithPlayer(Player[] player)
    {
     
    }
    public bool IsCollWithPlayer(Vector3 direct,Player player)
    {
        bool isColl = false;
       for(int i = 0; i < ListRay.Count; i++) 
        
        {
           
            RaycastHit[] hits = Physics.RaycastAll(ListRay[i].transform.position, direct, Mathf.Infinity, MaskPlayer);
            for (int j = 0; j < hits.Length; j++)
            {
                if (hits[j].collider.gameObject == player.gameObject)
                    if (status == Type_Status.DODGE)
                    {
                        {
                            isColl = true;
                        }
                    }
                /*
                    RaycastHit[] hits1 = Physics.RaycastAll(ListRay[i].transform.position, -direct, Mathf.Infinity, MaskPlayer);
                    for (int j = 0; j < hits1.Length; j++)
                    {
                        if (hits1[j].collider.gameObject == player.gameObject)
                        {
                            isColl = true;
                        }
                    }
                }
                */
            }
    }
        return isColl;
    }

    public void Process_Status()
    {
     
        Player[] player;
        if (GetEnemyInRadius(Radius, transform.position, transform.up, out player)!=0)
        {
           
           
                int indexBall = index_Limit + index_Enemy;
                int isDodge = index_Blood_War - index_Dodge;
            if (indexBall <= index_Blood_War)
            {

                status = Type_Status.ATTACK;
                Target = GetTargert(Radius);
                if (Target != null && Target.GetComponent<Enemy>().isGround)
                {
                    if (isDodge <= index_Dodge && index_Dodge <= index_Blood_War)
                    {




                        Player[] dodgePlayer;
                        if (GetEnemyInRadius(Radius / 2, transform.position, transform.up, out dodgePlayer) != 0)
                        {
                            PlayerDodge = PlayerStrongerst(dodgePlayer);

                            if (PlayerDodge != null)
                            {

                                status = Type_Status.DODGE;
                            }
                        }

                    }
                }
                else
                {
                    status = Type_Status.MOVE;
                }


            }

            else
            {

                // Run Away
                playerRunAway = player;
                status = Type_Status.RUN_AWAY;

            }
            
            

        }
        else
        {
          //  Debug.Log("Move");
           // status = Type_Status.MOVE;
            ChangeStatus(Type_Status.MOVE);
        }
        
        
    }

    public bool isAttack(Player[] players)
    {
        //Debug.Log("COLL : " + players.Length);
        
        if (players != null)
        {
            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].GetComponent<Enemy>().index_Limit < index_Limit)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
        
    }
    public Player PlayerStrongerst(Player[] player)
    {
        List<float> Score = new List<float>();
        if (player != null)
        {
            for (int i = 0; i < player.Length; i++)
            {
                Vector3 direct = player[i].GetComponent<Enemy>().body.velocity.normalized;
                if (player[i].GetComponent<Enemy>().IsCollWithPlayer(direct, GetComponent<Player>()))
                {
                     Debug.Log("IsColl");
                    float Magtidue = player[i].GetComponent<Enemy>().Magtidue();
                    float DistanceNearLimit = player[i].GetComponent<Enemy>().DistanceFromLimitNeart();
                    float DistanceToItsSelf = Vector3.Distance(transform.position, player[i].GetComponent<Enemy>().transform.position);
                    float indexPower = player[i].GetComponentInChildren<Enemy>().index_Power;
                    Score.Add(((DistanceToItsSelf + DistanceNearLimit) * index_Power));
                    Debug.Log(gameObject.name + " :: " + player[i]);
                }

            }
            int indexMax = getIndexMax(Score.ToArray());
            return player[indexMax];
        }
        else
        {
            return null;
        }

    }

    public void SetPlayerEnemy(Player[] player)
    {
        
    }

    public void ChangeStatus(Type_Status status)
    {
        switch (status)
        {
            case Type_Status.ATTACK:
                PlayerDodge = null;
                playerRunAway = null;
                break;
            case Type_Status.MOVE:
                status = Type_Status.MOVE;
                Target = null;
                PlayerDodge = null;
                playerRunAway = null;
                break;
            case Type_Status.RUN_AWAY:
                Target = null;
                PlayerDodge = null;
                break;
            case Type_Status.DODGE:
                Target = null;
                playerRunAway = null;
                PlayerDodge = null;
                break;
           ;
        }
    }
   
   

    public void Attack()
    {
        if (Target != null)
        {


            if (!Target.GetComponent<Enemy>().isGround)
            {
                Target = null;
                status = Type_Status.MOVE;
                return;
            }
            else
            {
                float ForceTarget = Target.GetComponent<Enemy>().Get_Force();

                float AttackPower = ((Force / DistanceFromLimitNeart()) * Mass);



                DirectMove = (new Vector3(Target.transform.position.x, 0, Target.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z))*0.75f;

            }
        }
        else
        {
            status = Type_Status.MOVE;



        }


    }
  
    // DDOGE :::::::::::::
  
   

    public void DistanceFromLimit()
    {

    }
    public float Magtidue()
    {
        return Vector3.Magnitude(body.velocity);
    }

    public float DistanceFromLimitNeart()
    {
        float distance = Mathf.Infinity;
       for(int i = 0; i < directx4.Length; i++)
        {
            Ray ray = new Ray(transform.position, directx4[i]);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
            if (hits.Length > 0)
            {
                for(int j = 0; j < hits.Length; j++)
                {
                    if(hits[j].collider.gameObject.layer == 12)
                    {
                        if (Vector3.Distance(transform.position, hits[j].point) < distance)
                        {
                          
                            distance = Vector3.Distance(transform.position, hits[j].point);
                     //       Debug.Log(hits[j].collider.gameObject.name + "  TARGET " + distance);
                        }
                    }
                }
            }
           
        }
        return distance;
    }


    public float DistanceFromWall(Vector3 direct)
    {
        float distance = 0;
        Ray ray = new Ray(transform.position,direct);
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity);
        if (hits.Length > 0)
        {
            for (int j = 0; j < hits.Length; j++)
            {
                if (hits[j].collider.gameObject.layer == 12)
                {
                   
                        distance = Vector3.Distance(transform.position, hits[j].point);
                //        Debug.Log(hits[j].collider.gameObject.name + "  TARGET " + distance);
                    break;
                }
            }
        }
                return distance;
       

       
    }
    
    
   
    private int ScoreOfDirect(Vector3[] directs)
    {
        string s1 = "";
        string s2 = "";

        int index = 0;
        /*
        for(int i = 0; i < directX8.Length; i++)
        {
            Ray ray = new Ray(transform.position, directX8[i]);
          RaycastHit[] hits =   Physics.SphereCastAll(ray,Radius,Range,MaskPlayer);
            
            Debug.Log(gameObject.name + " " + directX8[i] + "  " + hits.Length);
              
        }
        */
      
        float[] score = new float[directs.Length];
        float[] DistanceToWall = new float[directs.Length];
        float[] Time = new float[directs.Length];
        for (int i = 0; i < directs.Length; i++)
        {
            score[i] = DistanceFromWall(directs[i]);

        }

    
        float[] ScoreGood = GetArrayMax(score,1);
        int r = Random.Range(0,1);
        int r1 = getIndexMax(score);
     
        index =  getIndex(score, ScoreGood[r]);
       
        
        
      for(int i = 0; i < score.Length; i++)
        {
            s1 += "  " + score[i];
        }
      if(gameObject.name == "ball (3)")
        {
            Debug.Log(s1);
            Debug.Log(gameObject.name + " " + ScoreGood[r] + "  " + index);
        }
     
       
        return index;
       
    
    

    }
    private int ScoreOfDirectWithAngle(Vector3[] directs,Vector3 directPlayer)
    {
        string s1 = "";
        string s2 = "";

        int index = 0;
        /*
        for(int i = 0; i < directX8.Length; i++)
        {
            Ray ray = new Ray(transform.position, directX8[i]);
          RaycastHit[] hits =   Physics.SphereCastAll(ray,Radius,Range,MaskPlayer);
            
            Debug.Log(gameObject.name + " " + directX8[i] + "  " + hits.Length);
              
        }
        */

        float[] score = new float[directs.Length];
        float[] DistanceToWall = new float[directs.Length];
        float[] Time = new float[directs.Length];
        for (int i = 0; i < directs.Length; i++)
        {
            float angle = Vector3.Angle(directs[i], -directPlayer);

            score[i] =angle*DistanceFromWall(directs[i]);

        }


        //     float[] ScoreGood = GetArrayMax(score, directs.Length / 2);
        //   int r = Random.Range(0, directs.Length / 2);
            
        index = getIndexMax(score);
     

        for (int i = 0; i < score.Length; i++)
        {
            s1 += "  " + score[i];
        }
        if (gameObject.name == "ball (3)")
        {
            //   Debug.Log(s1);
            //  Debug.Log(gameObject.name + " " + ScoreGood[r] + "  " + index);
        }


        return index;




    }
    private int ScoreOfDirect(Vector3[] directs,float power)
    {
        string s1 = "";
        string s2 = "";

        int index = 0;
        /*
        for(int i = 0; i < directX8.Length; i++)
        {
            Ray ray = new Ray(transform.position, directX8[i]);
          RaycastHit[] hits =   Physics.SphereCastAll(ray,Radius,Range,MaskPlayer);
            
            Debug.Log(gameObject.name + " " + directX8[i] + "  " + hits.Length);
              
        }
        */

        float[] score = new float[directs.Length];
        float[] DistanceToWall = new float[directs.Length];
        float[] Time = new float[directs.Length];
        for (int i = 0; i < directs.Length; i++)
        {
            score[i] = DistanceFromWall(directs[i]);

        }


        float[] ScoreGood = GetArrayMax(score, directs.Length / 2);
        int r = Random.Range(0, directs.Length);

        index = getIndexMax(score);

        for (int i = 0; i < score.Length; i++)
        {
            s1 += "  " + score[i];
        }
        Debug.Log(s1);
        Debug.Log(gameObject.name + " " + ScoreGood[r] + "  " + index);

        return index;



    }




    private int getCountEnemyInDirect(float time,Vector3 direct)
    {
        int count = 0;
        for(int i = 0; i < ListRay.Count; i++)
        {
            Ray ray = new Ray(ListRay[i].transform.position, direct);
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, MaskPlayer);
            count += hits.Length;

        }
        return count;
    }
   
    


    private IEnumerator RandomDirect(Vector3[] Direct)
    {
        if (!isMoving)
        {

            isMoving = true;
            
            StartCoroutine(Create_Direct(Random.Range(minTime, maxTime)));
           
            int direct = ScoreOfDirect(Direct);
        
            DirectMove = Direct[direct];
         //   Debug.Log(DirectMove);
            yield return new WaitForSeconds(0);
        }


    }
    private IEnumerator Create_Direct(float time)
    {
        yield return new WaitForSeconds(time);
        isMoving = false;
    }

    public void Move()
    {
        StartCoroutine(RandomDirect(directX8));
        
    }
   
    // Move Random
  
    public int GetEnemyInRadius(float radius, Vector3 pos, Vector3 direct)
    {
        int number = 0;
        Ray ray = new Ray(pos, direct);
        RaycastHit[] hits = Physics.SphereCastAll(ray,radius,0,MaskPlayer);
     //     Debug.Log(gameObject.name + "COLL WITH " + hits.Length);
        number = hits.Length;
        
        string s ="";
        for(int i = 0; i < hits.Length; i++)
        {
           if( hits[i].collider.gameObject != this.gameObject)
            {
                s += "  " + hits[i].collider.gameObject.name;
            }
          
        }
        number--;
     
        return number;
    }
    private int GetEnemyInRadius(float radius, Vector3 pos, Vector3 direct, out Player[] player)
    {
        int number = 0;

        Ray ray = new Ray(pos, direct);
        RaycastHit[] hits = Physics.SphereCastAll(ray, radius, 0, MaskPlayer);
       
        number = hits.Length;
        number--;
        int index = 0;
        if (number > 0)
        {
            player = new Player[number];
            if (player.Length != 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.name != this.gameObject.name)
                    {                        

                        player[index] = hits[i].collider.gameObject.GetComponent<Player>();
                     //   Debug.Log(gameObject.name + "   " + index);
                        index++;
                    }

                }
                return number;
            }
            else
            {
                player = null;
                return 0;

            }
            
        }
        else
        {
            player = null;
            return 0;
        }

     
     

    }
    /// <summary>
    /// ///////////  
    ///    Caculate Score of Enemy
    /// </summary>
    /// 
    public Player GetTargert(float radius)
    {
        
        Player[] player;
        float[] Score = new float[GetEnemyInRadius(radius,transform.position,body.velocity.normalized,out player)];
        
        if (player != null)
        {
            for (int i = 0; i < player.Length; i++)
            {
                float Magtidue = player[i].GetComponent<Enemy>().Magtidue();
                float DistanceNearLimit = player[i].GetComponent<Enemy>().DistanceFromLimitNeart();
                float DistanceToItsSelf = Vector3.Distance(transform.position, player[i].GetComponent<Enemy>().transform.position);
                float indexPower = player[i].GetComponentInChildren<Enemy>().index_Power;
                Score[i] = (DistanceToItsSelf + DistanceNearLimit)*index_Power;

            }
            int indexMin = getIndexMin(Score);
            return player[indexMin];
        }
        else
        {
            return null;
        }
        
    }
    
   
    public Vector3 getDirect()
    {
     return   body.velocity.normalized;
    }
    public Player[] player;



   

    public void Warring_Enemy()
    {
        index_Enemy = 0;
       int  level_power = 0;
        Player[] players = null;

        GetEnemyInRadius(Radius, transform.position, transform.up, out players);
      
        if (players!=null)
        {
            for (int i = 0; i < players.Length; i++)
            {

                if (players[i] != null)
                {
                    Vector3 direct = players[i].GetComponent<Enemy>().DirectMove;
                    if (players[i].GetComponent<Enemy>().IsCollWithPlayer(direct, GetComponent<Player>()))
                    {
                        level_power++;
                        if (players[i].GetComponent<Enemy>().Force > 0.5f)
                        {
                            level_power++;
                        }
                    }
                }
                

            }
            if (level_power == 0)
            {

                index_Enemy = 1;
                type_warring_enemy = WARRING_ENEMY.LV1;
            }
            else if (level_power > 0 && level_power < 2)
            {
                index_Enemy = 2;
                type_warring_enemy = WARRING_ENEMY.LV2;
            }
            else if (level_power >= 2 && level_power < 3)
            {
                index_Enemy = 3;
                type_warring_enemy = WARRING_ENEMY.LV3;
            }
            else if (level_power >= 3)
            {
                index_Enemy = 4;
                type_warring_enemy = WARRING_ENEMY.LV4;
            }

        }
        else
        {
            index_Enemy = 0;
            type_warring_enemy = WARRING_ENEMY.LV1;
        }


    }
    

   
    public void Power()
    {
         index_Power = 0;
        float percent = 7;
        for (int i = 0; i < 5; i++)
        {
            if (Force> i * percent && Force < (i + 1) * percent)
            {
                index_Power = i++;
                break;
            }

        }
        Swapped_To_Enmu_Power((int)index_Power);
    }
   

    public void Warring_Limit()
    {
        index_Limit = 0;
        if (DistanceFromLimitNeart() >= 0 && DistanceFromLimitNeart() < 0.5f*level)
        {
            index_Limit = 1;
        }
        else if (DistanceFromLimitNeart() >= 0.5f*level && DistanceFromLimitNeart() < 1*level)
        {
            index_Limit = 2;
        }
        else if (DistanceFromLimitNeart() >= 1f*level && DistanceFromLimitNeart() < 1.5f*level)
        {
            index_Limit = 3;
        }
        else if (DistanceFromLimitNeart() >= 1.5f*level && DistanceFromLimitNeart() < 2*level)
        {
            index_Limit = 4;
        }
        else
        {
            index_Limit = 5;

        }

        Swapped_To_Enmu_Limit_Level((int)index_Limit);
    }

   
    public void Swapped_To_Enmu_Limit_Level(int level)
    {
        switch (level)
        {
            case 1:
                type_warring = WARRING_LIMIT.LV5;
                index_Limit = 4;
                break;
            case 2:
                type_warring = WARRING_LIMIT.LV4;
                index_Limit = 3;
                break;
            case 3:
                type_warring = WARRING_LIMIT.LV3;
                index_Limit = 2;
                break;
            case 4:
                type_warring = WARRING_LIMIT.LV2;
                index_Limit = 1;
                break;
            case 5:
                type_warring = WARRING_LIMIT.LV1;
                index_Limit = 0;
                break;
            default:
                index_Limit = 5;
                type_warring = WARRING_LIMIT.LV5;
                break;
        }


    }

    public void Swapped_To_Enmu_Power(int level)
    {
        switch (level)
        {
            case 1:
                type_power = POWER.LV1;
                break;
            case 2:
                type_power = POWER.LV2;
                break;
            case 3:
                type_power = POWER.LV3;
                break;
            case 4:
                type_power = POWER.LV4;
                break;
            case 5:
                type_power = POWER.LV5;
                break;
            
               
        }


    }

    private void OnDrawGizmos()
    {
        if (Target != null)
        {
            Gizmos.DrawLine(transform.position, Target.transform.position);
        }
       
        Gizmos.DrawWireSphere(transform.position,Radius);
      //  Debug.Log(gameObject.name + " " + GetEnemyInRadius(Radius, transform.position, transform.up));
        Gizmos.color = Color.blue;
       for (int i = 0; i < ListRay.Count; i++)
        {
                Gizmos.DrawLine(ListRay[i].transform.position, ListRay[i].transform.position + DirectMove* 50);
        }
       

      

       
    }
    
    public float getValueMax(float[] score)
    {
        float index = 0;
        float max = 0;
        for(int i = 0; i < score.Length; i++)
        {
            if (score[i] > max)
            {
                index = i;
                max = score[i];
            }
        }
        return max;
    }

    public float getValueMin(float[] score)
    {
        float index = 0;
        float min = Mathf.Infinity;
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] < min)
            {
                index = i;
                min = score[i];
            }
        }
        return min;
    }
   
    public int getIndexMax(float[] score)
    {
        int index = 0;
        float max = 0;
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] > max)
            {
                index = i;
                max = score[i];
            }
        }
        return index;
    }
    public int getIndexMin(float[] score)
    {
        int index = 0;
        float min = Mathf.Infinity;
        for (int i = 0; i < score.Length; i++)
        {
            if (score[i] < min)
            {
                index = i;
                min = score[i];
            }
        }
        return index;
    }
    public  float[] GetArrayMax(float[] Score ,int number)
    {
        float[] ScoreCopy = new float[8];
        Score.CopyTo(ScoreCopy, 0);

        string s = "";
        string s1 = "";

        List<float> Scores = new List<float>();
        List<float> ScoresMax = new List<float>();
        for (int i=0;i< ScoreCopy.Length; i++)
        {
            Scores.Add(ScoreCopy[i]);
            s += " " + ScoreCopy[i];
        }

        for(int i = 0; i < number; i++)
        {
            float max = getValueMax(ScoreCopy);
            ScoresMax.Add(max);
            ScoreCopy = RemoveArray(max, ScoreCopy);
            s1 += " " + max;
        
        }
      
        return ScoresMax.ToArray();
    }
  

    

    public float[] RemoveArray(float value,float[] Score)
    {
        int number = Score.Length;
        List<float> list = new List<float>();
        for(int i = 0; i < Score.Length; i++)
        {
            if(Score[i] != value)
            {
                list.Add(Score[i]);
            }
        }
        return list.ToArray();
    }

    public int getIndex(float[] Score,float value)
    {
        int index = 0;
        for(int i = 0; i < Score.Length; i++)
        {
            if(value == Score[i])
            {
             //   Debug.Log("Found :" +value +"  "+ i);
                index = i;
                return index;
            }
        }
        Debug.Log("Not Found");
        return 0;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
   
    public void Incre_Level(float level_Ball)
    {
        Debug.Log(" LEVEL UP ");
           
    
            transform.localScale +=  Vector3.one*level_Ball;
            Vector3 pos = transform.position;
            pos.y += 0.2f *level_Ball;
            weight += 1 * level_Ball;
            if (DataMananger.MapSelec != 3 || DataMananger.MapSelec != 4)
            {
               Radius += 0.8f;
            }
            Mass += 1f * level_Ball;
            Speed -= 0.5f * level_Ball;
    
            Speed = Mathf.Clamp(Speed, 3, Mathf.Infinity);
            Bound += 1f * level_Ball;
            transform.position = pos;
            level += 0.25f * level_Ball;
            MassChance +=5f * level_Ball;
            
           SizeSmoke += 0.2f * level_Ball;
     
        // ParticeSmoke.GetComponent<ParticleSystem>().startSize += 1.5f;
    }

    // Movement
    public List<Vector3> Point = new List<Vector3>();
    public Vector3 PosInit = Vector3.zero;

    public float Get_Force()
    {
        return body.velocity.sqrMagnitude;
    }
    public IEnumerator Return_Move_Back(float time)
    {
        yield return new WaitForSeconds(time);
   
       
        isMoveBack = false;
    }
    public IEnumerator Remove_Target(float time)
    {

        yield return new WaitForSeconds(time);
        Target = null;
    }
    public IEnumerator Remove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isGround = Physics.Raycast(new Ray(transform.position, -Vector3.up), CheckGround);
        if (isGround)
        {
            Skin.gameObject.SetActive(true);
        }
        else
        {
            Skin.gameObject.SetActive(false);
        }
      

    }

}
    
    
       







