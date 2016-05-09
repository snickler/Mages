﻿namespace Mages.Core.Ast.Expressions
{
    using System;

    /// <summary>
    /// Represents the access of a variable.
    /// </summary>
    public sealed class VariableExpression : AssignableExpression, IExpression
    {
        #region Fields

        private readonly String _name;
        private readonly AbstractScope _scope;

        #endregion

        #region ctor

        public VariableExpression(String name, AbstractScope scope, TextPosition start, TextPosition end)
            : base(start, end)
        {
            _name = name;
            _scope = scope;
        }

        #endregion

        #region Properties

        public String Name
        {
            get { return _name; }
        }

        public AbstractScope Scope
        {
            get { return _scope; }
        }

        #endregion

        #region Methods

        public void Accept(ITreeWalker visitor)
        {
            visitor.Visit(this);
        }

        public void Validate(IValidationContext context)
        {
        }

        #endregion
    }
}
