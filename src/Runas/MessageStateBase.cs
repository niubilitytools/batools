namespace Runas
{
    public abstract class MessageStateBase<TState, TValue>

    {
        protected MessageStateBase(TState state, string value)
        {
            this.State = state;
            this.Message = value;
        }

        public TState State { get; }

        public TValue Value { get; set; }

        public string Message { get; }
    }
}