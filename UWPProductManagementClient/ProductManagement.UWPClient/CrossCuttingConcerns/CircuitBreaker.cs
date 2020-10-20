using System;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public class CircuitBreaker : ICircuitBreaker
    {
        public CircuitBreaker(TimeSpan timeout)
        {
            this.State = new ClosedCircuitState(timeout);
        }

        public ICircuitState State { get; private set; }

        public void Guard()
        {
            this.State = this.State.NextState();
            this.State.Guard();
            this.State = this.State.NextState();
        }

        public void Trip(Exception exception)
        {
            this.State = this.State.NextState();
            this.State.Trip(exception);
            this.State = this.State.NextState();
        }

        public void Succeed()
        {
            this.State = this.State.NextState();
            this.State.Succeed();
            this.State = this.State.NextState();
        }
    }
}