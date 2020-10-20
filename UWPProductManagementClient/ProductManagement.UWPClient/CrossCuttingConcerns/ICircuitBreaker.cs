using System;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public interface ICircuitBreaker
    {
        void Guard();
        void Succeed();
        void Trip(Exception exception);
    }
}