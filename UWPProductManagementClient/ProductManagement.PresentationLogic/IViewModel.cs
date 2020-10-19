using System;

namespace ProductManagement.PresentationLogic
{
    public interface IViewModel
    {
        void Initialize(Action whenDone, object model);
    }
}