using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.Extensions.Examples
{
    public class Example04ScrollView : FancyScrollView<Example04CellDto, Example04ScrollViewContext>
    {
        [SerializeField]
        ScrollPositionController scrollPositionController = null;

        Action<int> onSelectedIndexChanged;

        public Dot_Ctrl Dot_Ctrl;

        public List<int> Page_1 = new List<int>();

        public List<int> Page_2 = new List<int>();

        public List<int> Page_3 = new List<int>();
     

        void Awake()
        {
            int Page = 0;
            int count = 0;
            for(int i = 0; i < DataMananger.Instance.Data_Skills.Images.Count; i++)
            {
                if (i % 9 == 0 && i!=0)
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

            scrollPositionController.OnUpdatePosition(p => UpdatePosition(p));
            scrollPositionController.OnItemSelected(HandleItemSelected);

            SetContext(new Example04ScrollViewContext
            {
                OnPressedCell = OnPressedCell,
                OnSelectedIndexChanged = index =>
                {
                    if (onSelectedIndexChanged != null)
                    {
                        onSelectedIndexChanged(index);
                    }
                }
            });
        }

        public void UpdateData(List<Example04CellDto> data)
        {
            cellData = data;
            scrollPositionController.SetDataCount(cellData.Count);
            Debug.Log("DATA_CELL : " + data.Count);
            UpdateContents();
        }

        public void UpdateSelection(int index)
        {
            if (index < 0 || index >= cellData.Count)
            {
                return;
            }

            scrollPositionController.ScrollTo(index, 0.4f);
            Context.SelectedIndex = index;
            UpdateContents();
        }

        public void OnSelectedIndexChanged(Action<int> onSelectedIndexChanged)
        {
            this.onSelectedIndexChanged = onSelectedIndexChanged;
            this.onSelectedIndexChanged += Dot_Ctrl.Select_At_Index;
        }

        public void SelectNextCell()
        {
            UpdateSelection(Context.SelectedIndex + 1);
        }

        public void SelectPrevCell()
        {
            UpdateSelection(Context.SelectedIndex - 1);
        }

        void HandleItemSelected(int selectedItemIndex)
        {
            Context.SelectedIndex = selectedItemIndex;
            UpdateContents();
        }

        void OnPressedCell(Example04ScrollViewCell cell)
        {
            UpdateSelection(cell.DataIndex);
        }
    }
}
