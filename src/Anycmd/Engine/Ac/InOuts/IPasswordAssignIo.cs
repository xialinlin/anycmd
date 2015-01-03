﻿
namespace Anycmd.Engine.Ac.InOuts
{
    using System;

    /// <summary>
    /// 表示该接口的实现类是为账户分配密码时的输入或输出参数类型。
    /// </summary>
    public interface IPasswordAssignIo
    {
        Guid Id { get; set; }
        string LoginName { get; }
        string Password { get; }
    }
}