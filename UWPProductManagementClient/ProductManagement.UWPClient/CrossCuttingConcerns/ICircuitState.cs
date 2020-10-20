using System;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public interface ICircuitState
    {
        ICircuitState NextState();
        void Guard();
        void Succeed();
        void Trip(Exception ex);
    }
}