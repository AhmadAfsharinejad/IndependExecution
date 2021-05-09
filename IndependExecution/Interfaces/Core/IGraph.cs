﻿using IndependExecution.Dto;
using IndependExecution.Interfaces.Plugin;

namespace IndependExecution.Interfaces.Core
{
    public interface IGraph
    {
        void AddNode(AddNodeRequest addNodeRequest);
        void AddLink(AddLinkRequest addLinkRequest);
        void RemoveNode(INode node);
        void RemoveLink(ILink link);
    }
}
