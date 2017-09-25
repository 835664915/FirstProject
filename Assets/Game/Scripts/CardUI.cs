using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CardUI : ReuseableObject,IPointerClickHandler
{    //用来显示的图片
    private Image image;


    /// <summary>
    /// 选中就是卡片沿y轴朝上移，没选中
    /// </summary>
    private bool isSelected;
    public bool IsSelectes
    {
        get { return isSelected; }
        set
        {
            //如果附相同的值，就不操作他，避免一直是选中的向上移
            if (value==isSelected||card.BelongTo!=CharacterType.Player)
            {
                return;

            }
            if (value == true)
            {
                transform.localPosition += Vector3.up * 10;

            }
            else
            {
                transform.localPosition -= Vector3.up * 10;

            }
            isSelected = value;


        }

    }
    private Card card;
    /// <summary>
    /// 卡牌的信息
    /// </summary>
    public Card Card
    {
        get { return card; }
        set { card = value;
            SetImage();

        }

    }
    /// <summary>
    /// 显示图片
    /// </summary>
    private void SetImage()
    {
        if (card.BelongTo == CharacterType.Player || card.BelongTo == CharacterType.Desk)
        {

            Sprite s = Resources.Load<Sprite>("Pokers/" + card.CardName);
            image.sprite = s;

        }
        else
        {

            Sprite s = Resources.Load<Sprite>("Pokers/CardBack" );
            image.sprite = s;


        }



    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //规定只有鼠标左键点击才有用
        if (eventData.button==PointerEventData.InputButton.Left)
        {
            //除非是自己的卡牌才能点
            if (card.BelongTo==CharacterType.Player)
            {

                IsSelectes = !IsSelectes;
            }

        }
        
    }

    /// <summary>
    /// 销毁卡牌
    /// </summary>
    public void Destroy()
    {

        PoolManager.Instance.HideObjet(gameObject);

    }


    /// <summary>
    /// 从对象池获取之前做的事
    /// </summary>
    public override void BeforeGetObject()
    {
        image = GetComponent<Image>();

     
    }

    /// <summary>
    /// 从对象池获隐藏之前做的事
    /// </summary>
    public override void BeforeHideObject()
    {
        isSelected = false;
        image.sprite = null;
        card = null;
    }

    /// <summary>
    /// 设置卡牌的位置
    /// </summary>
    /// <param name="parent">父物体</param>
    /// <param name="index">索引</param>
    public void SetPosition(Transform parent,int index)
    {
        transform.SetParent(parent, false);
        transform.SetSiblingIndex(index);
        //右方向
        if (card.BelongTo == CharacterType.Desk || card.BelongTo == CharacterType.Player)
        {
            transform.localPosition = Vector3.right * 25 * index;
            if (isSelected)
                //@!33
                transform.localPosition += Vector3.up * 10;
        }
        else if (card.BelongTo == CharacterType.ComputerLeft || card.BelongTo == CharacterType.ComputerRight)
        {
            transform.localPosition = -Vector3.up * 15 * index;
        }

    }



}
