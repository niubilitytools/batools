using System.Runtime.CompilerServices;

namespace Runas
{
    public class MessageState : MessageStateBase<State, string>
    {
        public static MessageState OK = new MessageState(State.Success, null);

        public MessageState(State state, string message)
            : base(state, message)
        {
        }

        public static MessageState Ok(string message)
        {
            return new MessageState(State.Success, message);
        }

        public static MessageState Fail(string message)
        {
            return new MessageState(State.Fail, message);
        }

        public static MessageState ParseError(string message)
        {
            return new MessageState(State.ParseError, message);
        }

        public static bool operator ==(MessageState a, MessageState b)
        {
            return a != null && b != null && a.State.Equals(b.State);
        }

        public static bool operator !=(MessageState a, MessageState b)
        {
            return !(a != null && b != null && a.State.Equals(b.State));
        }

        public override bool Equals(object obj)
        {
            var other = obj as MessageState;
            if (other != null) return this.State.Equals(other.State);

            return false;
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this.State);
        }

        public override string ToString()
        {
            return this.Message ?? this.Message;
        }
    }
}