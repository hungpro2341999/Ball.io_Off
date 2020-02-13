


    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections.Generic;
    using System;
public class Example04ScrollViewCell : FancyScrollViewCell<Example04CellDto, Example04ScrollViewContext>
    {
        [SerializeField]
        Animator animator = null;
        [SerializeField]
        Text message = null;
        [SerializeField]
        Image image = null;
        [SerializeField]
        Button button = null;
        public List<GameObject> Skin = new List<GameObject>();
        public List<GameObject> ListSkin = new List<GameObject>();
        static readonly int scrollTriggerHash = Animator.StringToHash("scroll");
        public GameObject Skin_Ball;
      
        public  List<int> Page_1 = new List<int>();
        public  List<int> Page_2 = new List<int>();
        public  List<int> Page_3 = new List<int>();

        public Dot_Ctrl Dot_Ctrl;

    void Awake()
    {
        int Page = 0;
        int count = 0;
        for (int i = 0; i < DataMananger.Instance.Data_Skills.Images.Count; i++)
        {
            if (i % 9 == 0 && i != 0)
            {
                Page++;
            }
            switch (Page)
            {
                case 0:
                    Page_1.Add(i);
                    break;
                case 1:
                    Page_2.Add(i);
                    break;
                case 2:
                    Page_3.Add(i);
                    break;
            }

        }
    }
        void Start()
        {
            button.onClick.AddListener(OnPressedCell);
        }
        

        /// <summary>
        /// Updates the content.
        /// </summary>
        /// <param name="itemData">Item data.</param>
        public override void UpdateContent(Example04CellDto itemData)
        {

        // message.text = itemData.Message;
        //  Debug.Log("MESS :" + message.text);
        gameObject.name = "Page " + itemData.index;
            switch (int.Parse(itemData.Message))
            {
                case 0:
                PushData(Page_1);
                    break;
                case 1:
                PushData(Page_2);
                break;
                case 2:
                PushData(Page_3);
                break;
            }
            //if (Context != null)
            //{
            //    var isSelected = Context.SelectedIndex == DataIndex;
            //    image.color = isSelected
            //        ? new Color32(0, 255, 255, 100)
            //        : new Color32(255, 255, 255, 77);
            //}
         


        }
   
        public void PushData(List<int> Skin)
        {
            DestroySKin();
              for(int i = 0; i < Skin.Count; i++)
          {
            var a = Instantiate(Skin_Ball,transform);
            a.transform.parent = transform.Find("Image");
             Shop_Mananger.Instance.AddSkin(a);
              a.GetComponent<InforSkill>().infor = DataMananger.Instance.Data_Skills.List_infor_Skill[Skin[i]];
              a.GetComponent<InforSkill>().Load_Infor(Skin[i]);
              ListSkin.Add(a);
           
        }
        }
    public void DestroySKin()
    {
      
        for(int i = 0; i < ListSkin.Count; i++)
        {
            if (ListSkin[i] != null)
            {
                Shop_Mananger.Instance.RemoveSkin(ListSkin[i]);
                ListSkin[i].GetComponent<InforSkill>().DestroySelf();
            }
            
        }
    }
        /// <summary>
        /// Updates the position.
        /// </summary>
        /// <param name="position">Position.</param>
        public override void UpdatePosition(float position)
        {
            
            currentPosition = position;
            animator.Play(scrollTriggerHash, -1, position);
            animator.speed = 0;
        }

        void OnPressedCell()
        {
            if (Context != null)
            {
                Context.OnPressedCell(this);
            }
        }

   
        float currentPosition = 0;
        void OnEnable()
        {
            UpdatePosition(currentPosition);
        }
    }

