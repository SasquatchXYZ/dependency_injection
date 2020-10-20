using System;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public class OpenCircuitState : ICircuitState
    {
        private readonly TimeSpan _timeout;
        private readonly DateTime _closedAt;

        public OpenCircuitState(TimeSpan timeout)
        {
            _timeout = timeout;
            _closedAt = DateTime.UtcNow;
        }

        public ICircuitState NextState() =>
            DateTime.UtcNow - _closedAt >= _timeout
                ? new HalfOpenCircuitState(_timeout)
                : (ICircuitState) this;

        public void Guard() => throw new InvalidOperationException("The circuit is currently open.");

        public void Succeed()
        {
        }

        public void Trip(Exception e)
        {
        }
    }
}