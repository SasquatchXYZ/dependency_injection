using System;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public class HalfOpenCircuitState : ICircuitState
    {
        private readonly TimeSpan _timeout;
        private bool _tripped;
        private bool _succeeded;

        public HalfOpenCircuitState(TimeSpan timeout)
        {
            _timeout = timeout;
        }

        public ICircuitState NextState() =>
            _succeeded
                ? new ClosedCircuitState(_timeout)
                : _tripped
                    ? new OpenCircuitState(_timeout)
                    : (ICircuitState) this;

        public void Guard()
        {
        }

        public void Succeed() => _succeeded = true;

        public void Trip(Exception e) => _tripped = true;
    }
}