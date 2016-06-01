// Liz Fallin
// BIT 286 Project
// Spring Quarter 2016

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
    public class ProblemSet
    {

        // Default of 10 problems per round
        // TODO Allow for teacher increase or decrease in number of problems
        public const int NUM_PROBS_PER_ROUND = 10;
        public const int NUM_ROUNDS_PER_LEVEL = 3;

        // For first level, there are 100 possible problems, 0..9 and 0..9
        // Edit 5/5: We are only using addition problems with answers 0..9: there are 55 total problems
        // TODO For first release, we are hard coding in the problem id range
        // private const int NUM_POSSIBLE_PROBLEMS_IN_LEVEL = 100;
        private const int LOWEST_PROBLEM_ID = 0;
        private const int HIGHEST_PROBLEM_ID = 55;

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
                }
                dc.SubmitChanges();
            }
        }

        // Randomly fill problem list with problems from the appropriate level and problem type
        // TODO Currently hard coded for the first 55 problems, which are Addition Level 1
        // TODO Create a SQL query which gets a list of all IDs for the appropriate ProblemType and Level
        // TODO Then generate random IDs based on that list
        private void PopulateProblemList()
        {
            AddSubProblem thisAddSubProb = null;
            Result thisResult;

            // Open a connection to the DB
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                // Random number generator for problem IDs
                Random r = new Random();

                // Fill the ProblemList with problems, based on 
                // the problem ID, which is randomly generated
                for (int i = 0; i < NUM_PROBS_PER_ROUND; i++)
                {
                    // Random ID
                    // TODO random seed currently hardcoded to 0..55
                    int id = r.Next(LOWEST_PROBLEM_ID, (HIGHEST_PROBLEM_ID + 1));

                    // Set the sql string
                    var probq = dc.AddSubProblems.Where(x => x.AddSubProblemID == id);
                    if (probq.Count() > 0)
                    {
                        thisAddSubProb = (AddSubProblem)probq.First();

                        // Create the new Result
                        thisResult = new Result();

                        // Pre-set values in the new Result
                        thisResult.ProblemID = id;
                        thisResult.Level = thisAddSubProb.Level;

                        // Create a new StudentProblem
                        StudentProblem sp =
                            new StudentProblem(thisAddSubProb, thisResult);

                        // Add to problem list
                        ProblemList.Add(sp);
                    }
                }

            }
        }

    }
}
