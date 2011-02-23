using System;
using NSpec.Domain;

namespace NSpec.Interpreter.Indexer
{
    public class spec : SpecInterpreterBase
    {
        protected ActionRegister before;
        protected ActionRegister when;
        protected ActionRegister specify;
        protected ActionRegister given;
        protected ActionRegister with;
        protected ActionRegister after;

        public spec()
        {
            before = new ActionRegister( (f,b) =>
            {
                Context.BeforeFrequency = f;
                Context.Before = b;
            });

            after = new ActionRegister( (f, a) =>
            {
                Context.AfterFrequency = f;
                Context.After = a;
            });

            when = new ActionRegister(AddContext("when"));
            with = new ActionRegister(AddContext("with"));
            given = new ActionRegister(AddContext("given"));

            specify = new ActionRegister((name,action)=> Exercise(new Example(name),action));
        }

        private Action<string, Action> AddContext(string prefix)
        {
            return (name, action) => AddContext(name, action, prefix);
        }
    }
}