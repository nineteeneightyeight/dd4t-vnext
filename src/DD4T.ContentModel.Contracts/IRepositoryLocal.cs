﻿

namespace DD4T.ContentModel
{
    public interface IRepositoryLocal : IItem
    {
        IPublication Publication { get; }
        IPublication OwningPublication { get; }
    }
}
