using System;

namespace AviaPassangerViewer.ViewModels.Base
{
    internal sealed class Command : CommandBase
    {
        public Command(Action action, Func<bool> canExecute) : base(o => action(), o => canExecute()) { }

        public Command(Action action) : base(o => action()) { }
    }
}
