using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PowerSoftScanner.Abstracts
{
    public class BaseCommandHandler : DelegateCommand
    {

        public BaseCommandHandler(Action action, Func<bool> canExecute = null) : base(
            () =>
            {
                try
                {
                    if (canExecute == null || canExecute())
                        action();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }, () => true)
        {
        }

        public BaseCommandHandler(Func<Task> action, Func<bool> canExecute = null)
            : base(async () =>
            {
                try
                {
                    if (canExecute == null || canExecute())
                    {
                        await action();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            })
        {
        }

    }

    public class BaseCommandHandler<T> : DelegateCommand<T>
    {
        public BaseCommandHandler(Action<T> action, Func<bool> canExecute = null) : base(
            (obj) =>
            {
                try
                {
                    if (canExecute == null || canExecute())
                        action(obj);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }, (obj) =>
            {
                if (canExecute != null)
                    return canExecute();

                return true;
            })
        {

        }

        public BaseCommandHandler(Func<T, Task> action, Func<bool> canExecute = null) : base(
            async (obj) =>
            {
                try
                {
                    if (canExecute == null || canExecute())
                        await action(obj);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Handle(ex);
                }
            }, (obj) =>
            {
                if (canExecute != null)
                    return canExecute();

                return true;
            })
        {

        }
    }

}
