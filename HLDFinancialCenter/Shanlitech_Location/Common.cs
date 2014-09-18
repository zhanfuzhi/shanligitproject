using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shanlitech_Location
{
    /// <summary>
    /// 角色列表
    /// </summary>
    public enum RoleName
    {
        /// <summary>
        /// 项目预算中的项目组长
        /// </summary>
        XMZZJS = 2,
        /// <summary>
        /// 承办人角色
        /// </summary>
        CBRJS=3
    }



    /// <summary>
    /// 数据记录状态
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 存档状态
        /// </summary>
        CunDang=1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 9
    }

    /// <summary>
    /// 流转状态（0为申请状态，1为待审核状态，2为待批准状态，3待存档状态）
    /// </summary>
    public enum TransferState
    {
        /// <summary>
        /// 申请状态
        /// </summary>
        ShenQing = 0,
        /// <summary>
        /// 待审核状态
        /// </summary>
        ShenHe = 1,
        /// <summary>
        /// 审核不通过
        /// </summary>
        NoShenHe = -1,
        /// <summary>
        /// 待批准状态
        /// </summary>
        PiZhun = 2,
        /// <summary>
        /// 批准不通过
        /// </summary>
        NoPiZhun = -2,
        /// <summary>
        /// 待存档状态
        /// </summary>
        CunDang = 3
    }

    /// <summary>
    /// （0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
    /// </summary>
    public enum DealType
    { 
        /// <summary>
        /// 平衡入库
        /// </summary>
        PHRK=0,
        /// <summary>
        /// 核销入库
        /// </summary>
        HXRK=1,
        /// <summary>
        ///受赠入库
        /// </summary>
        SZRK=2,
        /// <summary>
        /// 平衡出库
        /// </summary>
        PHCK=10,
        /// <summary>
        /// 申领出库
        /// </summary>
        SLCK=11,
        /// <summary>
        /// 折旧出库
        /// </summary>
        ZJCK=12
    }


}
