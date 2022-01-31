using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_AI
{
    class DecisionNode : DecisionTree
    {
        #region Variables

        public DecisionTree trueNode { get; set; }
        public DecisionTree falseNode { get; set; }

        // check to see if the conditions is met
        public Func<Ball, bool> condition { get; set; }
        #endregion

        #region Methods

      
        public override void Evaluate(Ball ball)
        {
            bool result = this.condition(ball);
            if (result)
            {
                this.trueNode.Evaluate(ball);
            }
            else
            {
                this.falseNode.Evaluate(ball);
            }
        }

        /// <summary>
        /// All the tree nodes
        /// Depending on the result of test we set the Result true or false
        /// </summary>
        /// <param name="paddle"></param>
        /// <returns></returns>
        public DecisionNode MainDecision(Paddle paddle)
        {
            //Node 5
            var DoNothing = new DecisionNode
            {
                condition = (Ball) => paddle.DoNothing(),
                trueNode = new DecisionResult { Result = true },
                falseNode = new DecisionResult { Result = false }
            };
           
            //Node 4
            var MoveDown = new DecisionNode
            {
             //move Down 
                condition = (Ball) => paddle.MoveDown(),
                trueNode = new DecisionResult { Result = true },
                falseNode = new DecisionResult { Result = false }
            };

            //Node 3
            var rightOfPaddle = new DecisionNode
            {
                // is the ball right of the paddle
                condition = (Ball) => Ball.position.Y > paddle.position.Y,
                trueNode = MoveDown,
                falseNode = DoNothing
            };

            //Node 2
            var MoveUp = new DecisionNode
            {
                // Move Up
                condition = (Ball) => paddle.MoveUp(),
                trueNode = rightOfPaddle,
                falseNode = new DecisionResult { Result = false }
            };
            //Node 1
            var leftOfPaddle = new DecisionNode
            {
                //is the ball left of the paddle
                condition = (Ball) => Ball.position.Y < paddle.position.Y,
                trueNode = MoveUp,
                falseNode = rightOfPaddle
            };
            //Node 0 
            var root = new DecisionNode
            {
               // is it our turn
                condition = (Ball) => Ball.isTurn,
                trueNode = leftOfPaddle,
                falseNode = DoNothing
            };
            return root;
        }

        #endregion
    }
}
