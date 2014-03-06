using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emash.GeoPatNet.Infrastructure.Enums;

namespace Emash.GeoPatNet.Infrastructure.Events
{

    public delegate void GenericListEventHandler<M>(object source, GenericListEventArg<M> e);

    public abstract class GenericListEventArg<M> : EventArgs 
    {
    }


    public class GenericListCommitedEventArg<M> : GenericListEventArg<M>
    {
        public GenericCommitAction CommitAction { get; private set; }
        public M CommitItem { get; private set; }
        public GenericListCommitedEventArg(GenericCommitAction commitAction,M commitItem)
        {
            this.CommitAction = commitAction;
            this.CommitItem = commitItem;
        }
    }


}
