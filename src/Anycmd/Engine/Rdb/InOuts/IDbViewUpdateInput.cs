﻿
namespace Anycmd.Engine.Rdb.InOuts
{
    using System;

    public interface IDbViewUpdateInput : IAnycmdInput
    {
        string Id { get; }
        Guid DatabaseId { get; }
        string Description { get; }
    }
}
