using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solstice;

public partial class SecretFillAddSub : ProtectedPage
{
    /// <summary>
    /// The database
    /// </summary>
    DataClassesDataContext db = new DataClassesDataContext();
    /// <summary>
    /// Fill the AddSubProblem table when the page loads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Redirect(UserTypeEnum.Super))
            return;

        const int MaxLev1 = 10;
        //const int MaxLev2 = 100;
        try
        {
            if (db.AddSubProblems.Count() == 0) // table is empty
            {
                // Add level 1 problems
                int level = 1;
                for (int op1 = 0; op1 < MaxLev1; op1++)
                {
                    for (int op2 = 0; op2 < MaxLev1; op2++)
                    {
                        int sum = op1 + op2;
                        if (sum < MaxLev1)
                        {
                            AddRecord(level, op1, op2, sum, ProblemTypeEnum.Addition);
                        }
                    }
                }
                // subtraction
                for (int op1 = 0; op1 < MaxLev1; op1++)
                {
                    for (int op2 = 0; op2 <= op1; op2++)
                    {
                        int result = op1 - op2;
                        AddRecord(level, op1, op2, result, ProblemTypeEnum.Subtraction);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblCreateError.Visible = true;
            lblCreateError.Text = "Error: " + ex.ToString();
        }
    }
    private void AddRecord(int level, int op1, int op2, int result, ProblemTypeEnum prob)
    {
        {
            AddSubProblem problem = new AddSubProblem();
            problem.Level = level;
            problem.Operator1 = op1;
            problem.Operator1 = op2;
            problem.Result = result;
            db.AddSubProblems.InsertOnSubmit(problem);
        }
    }
}