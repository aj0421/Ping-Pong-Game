using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    abstract class DecisionTree
    {
        /// <summary>
        /// Evaluates based on the decisionNode(the question) and the decision Result(the respond)
        /// </summary>
        /// <param name="ball"></param>
        public abstract void Evaluate(Ball ball);
    }
}
