using System;
using Protoinject;

namespace {PROJECT_SAFE_NAME}
{
    public class {PROJECT_SAFE_NAME}Module : IProtoinjectModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Bind<IEntityFactory>().ToFactory();
        }
    }
}

