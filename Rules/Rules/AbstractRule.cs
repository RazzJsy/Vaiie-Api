using Rules.Models;

namespace Rules.Rules
{
    public abstract class AbstractRule : AbstractRuleOrCheck
    {
        public abstract void Execute(ReportingModel model);
        public abstract bool IsThisRuleInScope(ReportingModel model);
    }
}
