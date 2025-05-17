using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_1._2_Horbach_633p
{
    internal class Optimal_min
    {
        private string objective;
        private string[] constraints;
        private int varCount;
        private double[,] tableau;
        private List<string> variableNames = new();
        private List<int> basis = new();
        private bool isMinimization;

        public Optimal_min(string objective, string[] constraints, bool isMinimization = true)
        {
            this.isMinimization = isMinimization;
            this.objective = objective.Replace(" ", "");
            this.constraints = constraints.Select(c => c.Replace(" ", "")).ToArray();
            ParseVariables();
            BuildTableau();
        }

        private void ParseVariables()
        {
            var variableSet = new HashSet<string>();
            void ExtractVars(string expr)
            {
                var matches = Regex.Matches(expr, @"x\d+");
                foreach (Match m in matches)
                    variableSet.Add(m.Value);
            }

            ExtractVars(objective);
            foreach (var constraint in constraints)
                ExtractVars(constraint);

            variableNames = variableSet.OrderBy(v => int.Parse(v.Substring(1))).ToList();
            varCount = variableNames.Count;
        }

        private double[] ParseExpression(string expr)
        {
            var coeffs = new double[varCount];
            expr = expr.Replace("-", "+-");
            if (expr.StartsWith("+-")) expr = "-" + expr[2..];
            var terms = expr.Split('+', StringSplitOptions.RemoveEmptyEntries);

            foreach (var term in terms)
            {
                var match = Regex.Match(term, @"([\-]?\d*\.?\d*)(x\d+)");
                if (match.Success)
                {
                    double coef = match.Groups[1].Value == "" || match.Groups[1].Value == "+" ? 1 :
                                  match.Groups[1].Value == "-" ? -1 :
                                  double.Parse(match.Groups[1].Value);
                    string var = match.Groups[2].Value;
                    int idx = variableNames.IndexOf(var);
                    if (idx != -1)
                        coeffs[idx] = coef;
                }
            }
            return coeffs;
        }

        private void BuildTableau()
        {
            int slackCount = 0;
            int rows = constraints.Length + 1;
            int cols = varCount;

            List<double[]> expressions = new();
            List<double> rhs = new();
            List<string> operators = new();

            foreach (string constraint in constraints)
            {
                string op = constraint.Contains("<=") ? "<=" :
                            constraint.Contains(">=") ? ">=" :
                            constraint.Contains("=") ? "=" : throw new Exception("Невідомий оператор в обмеженні.");
                operators.Add(op);
                var parts = Regex.Split(constraint, @"<=|>=|=");
                if (parts.Length != 2)
                    throw new FormatException($"Невірне обмеження: {constraint}");
                var lhs = parts[0];
                var rhsVal = double.Parse(parts[1]);

                expressions.Add(ParseExpression(lhs));
                rhs.Add(rhsVal);
                slackCount += 1;
            }

            tableau = new double[rows, varCount + slackCount + 1];

            int slackIndex = varCount;

            for (int i = 0; i < expressions.Count; i++)
            {
                for (int j = 0; j < varCount; j++)
                    tableau[i, j] = expressions[i][j];

                if (operators[i] == "<=")
                    tableau[i, slackIndex++] = 1;
                else if (operators[i] == ">=")
                    tableau[i, slackIndex++] = -1;
                else if (operators[i] == "=")
                    tableau[i, slackIndex++] = 0;

                tableau[i, tableau.GetLength(1) - 1] = rhs[i];
                basis.Add(slackIndex - 1);
            }

            var objCoeffs = ParseExpression(objective);
            for (int j = 0; j < varCount; j++)
                tableau[rows - 1, j] = isMinimization ? objCoeffs[j] : -objCoeffs[j];
        }

        public (string variables, double objectiveValue) Solve()
        {
            int rows = tableau.GetLength(0);
            int cols = tableau.GetLength(1);

            while (true)
            {
                int pivotCol = -1;
                double min = 0;
                for (int j = 0; j < cols - 1; j++)
                {
                    if (tableau[rows - 1, j] < min)
                    {
                        min = tableau[rows - 1, j];
                        pivotCol = j;
                    }
                }

                if (pivotCol == -1)
                    break;

                int pivotRow = -1;
                double minRatio = double.MaxValue;
                for (int i = 0; i < rows - 1; i++)
                {
                    double elem = tableau[i, pivotCol];
                    if (elem > 0)
                    {
                        double ratio = tableau[i, cols - 1] / elem;
                        if (ratio < minRatio)
                        {
                            minRatio = ratio;
                            pivotRow = i;
                        }
                    }
                }

                if (pivotRow == -1)
                    throw new Exception("Розв’язок необмежений.");

                double pivot = tableau[pivotRow, pivotCol];
                for (int j = 0; j < cols; j++)
                    tableau[pivotRow, j] /= pivot;

                for (int i = 0; i < rows; i++)
                {
                    if (i == pivotRow) continue;
                    double factor = tableau[i, pivotCol];
                    for (int j = 0; j < cols; j++)
                        tableau[i, j] -= factor * tableau[pivotRow, j];
                }

                basis[pivotRow] = pivotCol;
            }

            double[] result = new double[cols - 1];
            for (int i = 0; i < basis.Count; i++)
            {
                if (basis[i] < result.Length)
                    result[basis[i]] = tableau[i, cols - 1];
            }

            string vars = "(" + string.Join("; ", result.Take(variableNames.Count).Select(x => Math.Round(x, 3))) + ")";
            double z = tableau[rows - 1, cols - 1];
            if (isMinimization)
                z = -z;

            return (vars, z);
        }
    }
}
