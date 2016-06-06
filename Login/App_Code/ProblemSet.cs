using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Solstice
{
    /// <summary>
    /// A student problem contains the problem info and the student response
    /// </summary>
    public class StudentProblem
    {
        /// <summary>
        /// Constructor
        /// </summary>        
        public StudentProblem(AddSubProblem p, Result r)
        {
            Problem = p;
            studentResult = r;
        }

        // Information about the actual problem, including operands, level, and ID
        public AddSubProblem Problem { get; set; }

        // Information about the student response
        public Result studentResult { get; set; }
    }

    // A problem set contains a list of problems.
    // Each problem has two parts: the problem data, and the student result data
    // TODO Do we want access for the list, or for individual problems, or for problem IDs?
    /// <summary>
    /// A problem set contains a list of problems.
    /// Each problem has two parts: the problem data, and the student result data
    /// </summary>
    public class ProblemSet
    {
        // Default of 10 problems per round
        // TODO Release 3: Allow for teacher increase or decrease in number of problems
        public const int NUM_PROBS_PER_ROUND = 10;
        public const int NUM_ROUNDS_PER_LEVEL = 3;

        // Rounds are populated based on level and problem type (addition, subtraction, place value)
        private int sid;
        private int level;
        private ProblemTypeEnum probType;

        // The list of Student Problems. 
        // Each Problem contains the AddSubProblem (data related to the problem),
        // and Result (data related to the student's answer)
        public List<StudentProblem> ProblemList = new List<StudentProblem>();

        // Create a problem set, based on the student, level, and problem type
        // TODO Need to add missed problems to this set
        public ProblemSet(int studentID, int Level, ProblemTypeEnum probType)
        {
            this.sid = studentID;
            this.level = Level;
            this.probType = probType;

            // Populate the problem list for this student,
            // with random problems based on level and problem type
            PopulateProblemList();
        }

        // Save the student's results
        public void SaveResults()
        {
            StoreResultsInDB();
        }

        // Store this student's results in the Results table
        private void StoreResultsInDB()
        {
            // Open a connection to the DB
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
            // Create a new row in the Results table, for the current student result
                foreach (StudentProblem problem in ProblemList)
                {
                    // Set the sql string
                    Result result = new Result();

                    // Add row and execute
                    result.StudentID = this.sid;
                    result.ProblemID = problem.Problem.AddSubProblemID;
                    result.Answer = problem.studentResult.Answer;
                    result.Level = problem.Problem.Level;
                    result.Round = problem.studentResult.Round;
                    dc.Results.InsertOnSubmit(result);

                    // Based on the problem type and the two operators, store in Missed Problems
                }
                dc.SubmitChanges();
            }
        }

        // Randomly fill problem list with problems from the appropriate level and problem type
        // TODO: Query the Results table for id = StudentID, level = Level, and problem type = ProbType
        // This should return a list of the missed problems of this type in this level.
        // Use these values to start the PopulateProblemList list
        private void PopulateProblemList()
        {
            AddSubProblem thisAddSubProb = null;
            Result thisResult;

            // Open a connection to the DB
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                // RELEASE 2:
                // Remove the 0..55 range, and replace
                // it with a random selection where Level = desired level
                // NEWID() provides a randomization function.
                // See MSDN, Selecting Rows Randomly from a Large Table
                // https://msdn.microsoft.com/en-us/library/cc441928.aspx

                // Get list of *missed* problem IDs for this level
                // This will form the first part of the problem list
                var missedProbs = dc.GetMissedProblems(sid, (int)probType);
                List<int> missedProbIds = new List<int>();

                foreach(GetMissedProblemsResult m in missedProbs)
                    missedProbIds.Add(m.ProblemID);

                // Now get a list of *new* problem IDs for this level and problem type
                var problemQuery = dc.GetProblemIDs((int)probType, level);
                List<int> newProbIds = new List<int>();

                foreach (GetProblemIDsResult i in problemQuery)
                    newProbIds.Add(i.AddSubProblemID);

                // Finally, combine the lists.
                // For now, we will start with missed problem ids, 
                // and fill the rest of the list with new problem ids
                // There will be problem ids that are not covered in this round
                // TODO: How to deal with more than NUM_PROBS_PER_ROUND missed problems?
                List<int> allProbIds = new List<int>();

                // At most, the number of missed problems to be shown
                // is the number of problems in the current round
                int numMissedShown = Math.Min(missedProbIds.Count, NUM_PROBS_PER_ROUND);

                // If there are any problems not yet used, the slots will
                // be filled by new problems
                int numNewShown = NUM_PROBS_PER_ROUND - numMissedShown;

                for (int i = 0; i < numMissedShown; i++)
                    allProbIds.Add(missedProbIds[i]);

                int newProbCount = 0;

                for (int i = numMissedShown; i < NUM_PROBS_PER_ROUND; i++)
                    allProbIds.Add(newProbIds[newProbCount++]);
                    
                // Get problems based on the list of ids
                var problems = dc.GetProblems(allProbIds);

                foreach (var prob in problems)
                {
                    // Create the new Result
                    thisResult = new Result();

                    // Pre-set values in the new Result
                    thisResult.ProblemID = prob.AddSubProblemID;
                    thisResult.Level = prob.Level;

                    // Create a new StudentProblem
                    StudentProblem sp =
                        new StudentProblem(prob, thisResult);
                        // new StudentProblem(thisAddSubProb, thisResult);

                    // Add to problem list
                    ProblemList.Add(sp);
                }
            }
        }
    }
}
