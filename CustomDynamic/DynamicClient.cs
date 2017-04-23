using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CustomDynamic
{
    public class DynamicClient : DynamicObject
    {
        string MemberName = string.Empty;

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if(!string.IsNullOrEmpty(MemberName))
            {
                MemberName += ".";
            }
            MemberName += binder.Name;
            result = this;
            return true;
        }

        //public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        //{
        //    result = MemberName;
        //    return true;
        //}

        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            result = MemberName;
            return true;
        }
    }
}
