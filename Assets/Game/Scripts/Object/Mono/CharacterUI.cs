using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制UI显示
/// </summary>
public class CharacterUI : MonoBehaviour {

    public Image img_Head;
    public Image img_Identity;
    public Text txt_Int;
    public Text txt_Remain;
    public Transform CreatePoint;

  
    /// <summary>
    /// 设置身份
    /// </summary>
    /// <param name="identity"></param>
    public void SetIdentity(Identity identity)
    {

        Sprite head = null;
        Sprite iden = null;
        switch (identity)
        {
            case Identity.Farmer:

                head= Resources.Load<Sprite>("Pokers/Role_Farmer");
                iden = Resources.Load<Sprite>("Pokers/Identity_Farmer");


                break;
            case Identity.LandLord:

                head = Resources.Load<Sprite>("Pokers/Role_Landlord");
                iden = Resources.Load<Sprite>("Pokers/Identity_Landlord");
                break;
            default:
                break;
        }
        if (head==null||iden==null)
        {
            Debug.Log("没有在resources下找到图片");

        }
        img_Head.sprite = head;
        img_Identity.sprite = iden;
    }

    /// <summary>
    ///设置积分
    /// </summary>
    /// <param name="intergration"></param>
    public void SetIntergration(int intergration)
    {

        txt_Int.text = "积分：" + intergration.ToString();

    }

    /// <summary>
    /// 设置剩余手牌数
    /// </summary>
    /// <param name="number"></param>
    public void SetRemain(int number)
    {

        txt_Remain.text = "剩余手牌数：" + number.ToString();



    }
    



}
