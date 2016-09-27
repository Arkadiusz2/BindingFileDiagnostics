using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Adapters;

namespace BindingFile.Diagnostics.Rules
{
    public static class RuleTemplateExtensions
    {
        /// <summary>
        /// Get BizTalkArtifactTargets attributes assigned to a binding rule, lazy binding
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static RuleTargetsEnum GetTargets(this RuleTemplate rule)
        {           
            RuleTargetsAttribute[] attributes = (RuleTargetsAttribute[])rule.GetType().GetCustomAttributes(typeof(RuleTargetsAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Targets;
            }
            return RuleTargetsEnum.All;
        }

        public static IEnumerable<IAdapterInfo> GetAdapters(this RuleTemplate rule)
        {
            RuleTargetsAttribute[] attributes = (RuleTargetsAttribute[])rule.GetType().GetCustomAttributes(typeof(RuleTargetsAttribute), false);
            if (attributes[0].AdapterInfo.ToList().Count > 0)
            {
                return attributes[0].AdapterInfo;
            }
            return null;
        }
    }
}
