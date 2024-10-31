using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1.Evaluators
{
    public interface IEvaluator
    {
        int Evaluate(Hand hand);
    }
}
