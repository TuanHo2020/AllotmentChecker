using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceChecker.MyExceptions
{
    public class MyMyExceptions : Exception
    {
        public MyMyExceptions() : base() { }
        public MyMyExceptions(string message) : base(message) { }
        public MyMyExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
    public class ActionCanceledException : MyMyExceptions
    {
        public ActionCanceledException() : base() { }
        public ActionCanceledException(string message) : base(message) { }
        public ActionCanceledException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class LabelException : MyMyExceptions
    {
        public LabelException() : base() { }
        public LabelException(string message) : base(message) { }
        public LabelException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class BreakRoutineIfFoundException : LabelException
    {
        public BreakRoutineIfFoundException() : base() { }
        public BreakRoutineIfFoundException(string message) : base(message) { }
        public BreakRoutineIfFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
    /// <summary>
    /// Use for optional element, may be a board we already follow then there will no follow button?
    /// </summary>
    public class BreakRoutineIfNOTFoundException : LabelException
    {
        public BreakRoutineIfNOTFoundException() : base() { }
        public BreakRoutineIfNOTFoundException(string message) : base(message) { }
        public BreakRoutineIfNOTFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class LabelErrorWithinLimit : LabelException
    {
        public LabelErrorWithinLimit() : base() { }
        public LabelErrorWithinLimit(string message) : base(message) { }
        public LabelErrorWithinLimit(string message, Exception innerException) : base(message, innerException) { }
    }
    public class LabelErrorOverLimit : LabelException
    {
        public LabelErrorOverLimit() : base() { }
        public LabelErrorOverLimit(string message) : base(message) { }
        public LabelErrorOverLimit(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ElementHasDisappearException : LabelException
    {
        public ElementHasDisappearException() : base() { }
        public ElementHasDisappearException(string message) : base(message) { }
        public ElementHasDisappearException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class TimeOutException : LabelException
    {
        public TimeOutException() : base() { }
        public TimeOutException(string message) : base(message) { }
        public TimeOutException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class LabelExecutionResultFailException : LabelException
    {
        public LabelExecutionResultFailException() : base() { }
        public LabelExecutionResultFailException(string message) : base(message) { }
        public LabelExecutionResultFailException(string message, Exception innerException) : base(message, innerException) { }
    }
  
    public class NotFound404Exception : MyMyExceptions
    {
        public NotFound404Exception() : base() { }
        public NotFound404Exception(string message) : base(message) { }
        public NotFound404Exception(string message, Exception innerException) : base(message, innerException) { }
    }
    public class NoDataFoundException : MyMyExceptions
    {
        public NoDataFoundException() : base() { }
        public NoDataFoundException(string message) : base(message) { }
        public NoDataFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
