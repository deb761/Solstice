using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Additional methods for DataClassesDataContext, which is auto-generated using
/// LINQ to SQL
/// </summary>
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
    /// <summary>
    /// Retrieve the AddSubProblems that match the IDs
    /// </summary>
    /// <param name="ids">list of AddSubProblem IDs</param>
    public IEnumerable<AddSubProblem> GetProblems(List<int> ids)
    {
        DataTable idsTable = new DataTable();
        idsTable.Columns.Add("ID", typeof(int));

        foreach (int id in ids)
            idsTable.Rows.Add(id);

        using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("GetProblems", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p = cmd.Parameters.AddWithValue("@probids", idsTable);
            p.SqlDbType = SqlDbType.Structured;
            p.TypeName = "integer_list_tbltype";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // Naturally, you already retrieved your objects so no deferred
            // loading needed nor possible, hence the ToList()
            return this.Translate<AddSubProblem>(reader).ToList();
        }
    }
    /// <summary>
    /// Find out what level and round a student should start at when starting a game.
    /// </summary>
    /// <param name="studentID"></param>
    /// <returns>A result element with level, round, and count</returns>
    public GetLastRoundResult GetCurrentRound(int studentID)
    {
        GetLastRoundResult roundTable = (GetLastRoundResult)GetLastRound(studentID).ReturnValue;
        if (roundTable.Count == Solstice.ProblemSet.NUM_PROBS_PER_ROUND)
        {
            if (roundTable.Round == Solstice.ProblemSet.NUM_ROUNDS_PER_LEVEL)
            {
                roundTable.Level++;
                roundTable.Round = 1;
            }
            else
            {
                roundTable.Round++;
            }
            roundTable.Count = 0;
        }

        return roundTable;
    }
}