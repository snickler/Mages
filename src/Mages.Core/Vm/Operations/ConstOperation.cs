﻿namespace Mages.Core.Vm.Operations
{
    using System;

    /// <summary>
    /// Pushes a constant value on the stack.
    /// </summary>
    sealed class ConstOperation : IOperation
    {
        private readonly Object _constant;

        public ConstOperation(Object constant)
        {
            _constant = constant;
        }

        public void Invoke(IExecutionContext context)
        {
            context.Push(_constant);
        }
    }
}
