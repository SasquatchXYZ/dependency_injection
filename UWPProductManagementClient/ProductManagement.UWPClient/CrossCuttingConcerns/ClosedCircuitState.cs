using System;
using System.Runtime.CompilerServices;

namespace ProductManagement.UWPClient.CrossCuttingConcerns
{
    public class ClosedCircuitState : ICircuitState
    {
        private readonly TimeSpan _timeout;
        private bool _tripped;

        public ClosedCircuitState(TimeSpan timeout)
        {
            _timeout = timeout;
        }

        public ICircuitState NextState() =>
            _tripped
                ? new OpenCircuitState(_timeout)
                : (ICircuitState) this;

        public void Guard()
        {
        }

        public void Succeed()
        {
        }

        public void Trip(Exception e) => _tripped = true;
    }
}