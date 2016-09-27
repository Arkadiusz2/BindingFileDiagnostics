using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingFile.Extensions
{
    public static class PipelineRefExtensions
    {
        public static bool IsNil(this PipelineRef pipelineRef)
        {
            return pipelineRef == null || pipelineRef.Name == null;
        }
    }
}
