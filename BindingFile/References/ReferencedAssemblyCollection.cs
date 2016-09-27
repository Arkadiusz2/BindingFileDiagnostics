using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile
{
    public class ReferencedAssemblyCollection
    {
        /// <summary>
        /// Assemblies that are referenced by maps or pipelines
        /// </summary>
        private Dictionary<string, ReferencedAssembly> _items;

        public ReferencedAssemblyCollection()
        {
            _items = new Dictionary<string, ReferencedAssembly>();
        }

        /// <summary>
        /// Gets or create assembly in the collection
        /// </summary>
        /// <param name="assemblyQualifiedName">Qualified name of the assembly</param>
        /// <returns></returns>
        private ReferencedAssembly GetOrCreateItem(string assemblyQualifiedName)
        {
            ReferencedAssembly item;
            if (_items.ContainsKey(assemblyQualifiedName))
            {
                item = _items[assemblyQualifiedName];
            }
            else
            {
                item = new ReferencedAssembly(assemblyQualifiedName);
                _items.Add(assemblyQualifiedName, item);
            }
            return item;
        }

        private ReferencedPipeline GetOrCreatePipeline(PipelineRef pipelineRef)
        {
            ClassQualifiedName qn = new ClassQualifiedName(pipelineRef.FullyQualifiedName);
            ReferencedAssembly referencedAssembly = this.GetOrCreateItem(qn.AssemblyQualifiedName);
            ReferencedPipeline referencedPipeline = referencedAssembly.PipelineCollection.GetOrCreateItem(qn.CalssQualifiedName);
            referencedPipeline.ReferencedAssembly = referencedAssembly;

            return referencedPipeline;
        }


        private ReferencedMap GetOrCreateMap(Transform transform)
        {
            ClassQualifiedName qn = new ClassQualifiedName(transform.AssemblyQualifiedName);
            ReferencedAssembly referencedAssembly = this.GetOrCreateItem(qn.AssemblyQualifiedName);
            ReferencedMap referencedMap = referencedAssembly.MapCollection.GetOrCreateItem(qn.CalssQualifiedName);
            referencedMap.ReferencedAssembly = referencedAssembly;

            return referencedMap;
        }

        /// <summary>
        /// Adds pipeline-receive port dependency to assembly collection
        /// </summary>
        /// <param name="pipelineRef"></param>
        /// <param name="receiveLocation"></param>
        public void Add(PipelineRef pipelineRef, ReceiveLocation receiveLocation)
        {
            GetOrCreatePipeline(pipelineRef).ReceiveLocations.Add(receiveLocation);
        }

        /// <summary>
        /// Adds pipeline-send port dependency to assembly collection
        /// </summary>
        /// <param name="pipelineRef"></param>
        /// <param name="sendPort"></param>
        public void Add(PipelineRef pipelineRef, SendPort sendPort)
        {            
            GetOrCreatePipeline(pipelineRef).SendPorts.Add(sendPort);
        }

        /// <summary>
        /// Adds map-receive port dependency to assembly collection
        /// </summary>
        /// <param name="pipelineRef"></param>
        /// <param name="receivePort"></param>
        public void Add(Transform transform, ReceivePort receivePort)
        {
            GetOrCreateMap(transform).ReceivePorts.Add(receivePort);
        }

        /// <summary>
        /// Adds map-send port dependency to assembly collection
        /// </summary>
        /// <param name="pipelineRef"></param>
        /// <param name="sendPort"></param>
        public void Add(Transform transform, SendPort sendPort)
        {
            GetOrCreateMap(transform).SendPorts.Add(sendPort);
        }

        public IEnumerable<ReferencedAssembly> Items
        {
            get
            {
                return _items.Values;
            }
        }
    }
}
