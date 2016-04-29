﻿namespace Mages.Core.Ast.Expressions
{
    using System;

    /// <summary>
    /// The base class for all binary expressions.
    /// </summary>
    public abstract class BinaryExpression : ComputingExpression, IExpression
    {
        #region Fields

        private readonly IExpression _left;
        private readonly IExpression _right;

        #endregion

        #region ctor

        public BinaryExpression(IExpression left, IExpression right)
            : base(left.Start, right.End)
        {
            _left = left;
            _right = right;
        }

        #endregion

        #region Properties

        public IExpression LValue 
        {
            get { return _left; }
        }

        public IExpression RValue
        {
            get { return _right; }
        }

        #endregion

        #region Methods

        public void Accept(ITreeWalker visitor)
        {
            visitor.Visit(this);
        }

        public void Validate(IValidationContext context)
        {
            if (_left is EmptyExpression)
            {
                var error = new ParseError(ErrorCode.LeftOperandRequired, LValue);
                context.Report(error);
            }
            else
            {
                _left.Validate(context);
            }

            if (_right is EmptyExpression)
            {
                var error = new ParseError(ErrorCode.RightOperandRequired, RValue);
                context.Report(error);
            }
            else
            {
                _right.Validate(context);
            }
        }

        public abstract Func<Object[], Object> GetFunction();

        #endregion

        #region Operations

        public sealed class And : BinaryExpression
        {
            public And(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] != 0.0 && (Double)args[1] != 0.0;
            }
        }

        public sealed class Or : BinaryExpression
        {
            public Or(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] != 0.0 || (Double)args[1] != 0.0;
            }
        }

        public sealed class Equal : BinaryExpression
        {
            public Equal(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] == (Double)args[1];
            }
        }

        public sealed class NotEqual : BinaryExpression
        {
            public NotEqual(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] != (Double)args[1];
            }
        }

        public sealed class Greater : BinaryExpression
        {
            public Greater(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] > (Double)args[1];
            }
        }

        public sealed class Less : BinaryExpression
        {
            public Less(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] < (Double)args[1];
            }
        }

        public sealed class GreaterEqual : BinaryExpression
        {
            public GreaterEqual(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] >= (Double)args[1];
            }
        }

        public sealed class LessEqual : BinaryExpression
        {
            public LessEqual(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] <= (Double)args[1];
            }
        }

        public sealed class Add : BinaryExpression
        {
            public Add(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] + (Double)args[1];
            }
        }

        public sealed class Subtract : BinaryExpression
        {
            public Subtract(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] - (Double)args[1];
            }
        }

        public sealed class Multiply : BinaryExpression
        {
            public Multiply(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] * (Double)args[1];
            }
        }

        public sealed class LeftDivide : BinaryExpression
        {
            public LeftDivide(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[1] / (Double)args[0];
            }
        }

        public sealed class RightDivide : BinaryExpression
        {
            public RightDivide(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] / (Double)args[1];
            }
        }

        public sealed class Power : BinaryExpression
        {
            public Power(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => Math.Pow((Double)args[0], (Double)args[1]);
            }
        }

        public sealed class Modulo : BinaryExpression
        {
            public Modulo(IExpression left, IExpression right)
                : base(left, right)
            {
            }

            public override Func<Object[], Object> GetFunction()
            {
                return args => (Double)args[0] % (Double)args[1];
            }
        }

        #endregion
    }
}
