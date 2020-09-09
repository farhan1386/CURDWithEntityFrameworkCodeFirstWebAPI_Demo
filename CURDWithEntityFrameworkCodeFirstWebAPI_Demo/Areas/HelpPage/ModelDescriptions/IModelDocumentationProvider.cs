using System;
using System.Reflection;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}