using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 积分,
/// </summary>
public class IntegrationModel
{
    /// <summary>
    /// 底分
    /// </summary>
    public int BasePoint;


    /// <summary>
    /// 倍数
    /// </summary>
    public int Multiples;


    /// <summary>
    /// 总分
    /// </summary>
    public int Result
    {

        get { return BasePoint * Multiples; }

    }
    /// <summary>
    /// w玩家的积分
    /// </summary>
    private  int playerIntergration;
    public int PlayerIntergration
    {


        get { return playerIntergration; }
        set
        {
            if (playerIntergration < 0)
            {
                playerIntergration = 0;
            }
            else
            {
                playerIntergration = value;

            }

        }

    }


    private  int computerLeftIntergration;
    public int ComputerLeftIntergration
    {
        get { return computerLeftIntergration; }
        set
        {
            if (computerLeftIntergration < 0)
            {
                computerLeftIntergration = 0;
            }
            else
            {
                computerLeftIntergration = value;

            }

        }

    }



    private int computerRightIntergration;
    public int ComputerRightIntergration
    {
        get { return computerRightIntergration; }
        set
        {
            if (computerRightIntergration < 0)
            {
                computerRightIntergration = 0;
            }
            else
            {
                computerRightIntergration = value;

            }

        }

    }


    /// <summary>
    /// 初始化积分信息
    /// </summary>
    public void Initintergration()
    {
        PlayerIntergration = 2000;
        ComputerLeftIntergration = 3011;
        ComputerRightIntergration = 2345;

        Multiples = 1;
        BasePoint = 100;


    }


}
