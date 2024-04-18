using System.Security.Policy;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Controllers.Constrains;

[AttributeUsage(AttributeTargets.Class)]
class PathNotPermitedConstraintAttribute : ActionMethodSelectorAttribute
{

    private readonly string authPath;   
    public PathNotPermitedConstraintAttribute(string path)
    {
        authPath=path;
    }
    public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
    {
        
        string path = routeContext.HttpContext.Request.Path;

        if(path.Length >= authPath.Length && path.Substring(0, authPath.Length) == authPath)
            return false;
        return true;
    }
}