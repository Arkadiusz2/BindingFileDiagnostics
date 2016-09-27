using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedPipelineCollection
    {
        private Dictionary<string, ReferencedPipeline> _items = new Dictionary<string, ReferencedPipeline>();
        public ReferencedPipelineCollection()
        {
        }

        /// <summary>
        /// Gets or create pipeline in the collection
        /// </summary>
        /// <param name="fullyQualifiedName">Qualified name of the assembly</param>
        /// <returns></returns>
        public ReferencedPipeline GetOrCreateItem(string fullyQualifiedName)
        {
            ReferencedPipeline referencedPipeline;
            if (_items.ContainsKey(fullyQualifiedName))
            {
                referencedPipeline = _items[fullyQualifiedName];
            }
            else
            {
                referencedPipeline = new ReferencedPipeline(null, fullyQualifiedName);
                _items.Add(fullyQualifiedName, referencedPipeline);
            }
            return referencedPipeline;
        }

        ///// <summary>
        ///// Adds map-receive port dependency to assembly collection
        ///// </summary>
        ///// <param name="pipelineRef"></param>
        ///// <param name="receivePort"></param>
        //public void Add(PipelineRef pipelineRef, ReceivePort receivePort)
        //{
        //    ReferencedPipeline referencedPipeline = GetOrCreateItem(pipelineRef.FullyQualifiedName);
        //    referencedPipeline.ReceivePorts.Add(receivePort);
        //}

        ///// <summary>
        ///// Adds map-send port dependency to assembly collection
        ///// </summary>
        ///// <param name="pipelineRef"></param>
        ///// <param name="sendPort"></param>
        //public void Add(PipelineRef pipelineRef, SendPort sendPort)
        //{
        //    ReferencedPipeline referencedPipeline = GetOrCreateItem(pipelineRef.FullyQualifiedName);
        //    referencedPipeline.SendPorts.Add(sendPort);
        //}

        ///// <summary>
        ///// Collection of maps referenced by receive lcoations and send ports
        ///// </summary>
        //public IEnumerable<ReferencedPipeline> Items
        //{
        //    get
        //    {
        //        return _items.Values;
        //    }
        //}
    }
}
