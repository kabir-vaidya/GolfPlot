using System;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
public class Solver {

    public float CalculateY(string expression, float x) {
        try {
            if (expression == null) throw new Exception("Expression empty");
            Function Fx = new Function("Fx(x) = "+expression);
            Argument xArg = new Argument("x", x);
            Expression e1 = new Expression("Fx(x)", Fx, xArg);
            mXparser.consolePrintln(e1.getExpressionString() + "=" + e1.calculate());
            return (float)e1.calculate(); 
        }
        catch (Exception ex) {
            Debug.Log("Exception: " + ex.Message);
            return 0;
        }
    } 
}

