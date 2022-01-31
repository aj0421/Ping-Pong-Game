using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    class DecisionResult : DecisionTree
    {
        public bool Result { get; set; }
     
        /// <summary>
        /// Shows the final result in the console
        /// </summary>
        /// <param name="ball"></param>
        public override void Evaluate(Ball ball)
        {
            Debug.WriteLine("Result " + Result);
        }
    }
}
