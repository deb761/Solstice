/************************
Fred Jaworski
BIT 286 Spring 2016
Solstice Math Game
************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solstice
{
    public partial class GameScreen : ProtectedPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Redirect(UserTypeEnum.Student))
                return;

			if (!IsPostBack)
			{
                SetSession();
			}
		}

        /// <summary>
        /// Sets up the session based on the users last recorded session
        /// </summary>
        private void SetSession()
        {
            int studentID = (int)Session["UserID"];
            DataClassesDataContext dcdContext = new DataClassesDataContext();
            GetLastRoundResult lastRound = dcdContext.GetCurrentRound(studentID);
            ProblemTypeEnum probType = DetermineProbType(lastRound.Level);
            ProblemSet probSet = new ProblemSet(studentID, lastRound.Level, probType);
            Session["LastRound"] = lastRound;
            Session["CurProbSet"] = probSet;
            Session["CurProbSetType"] = probType;
            Session["ProblemIdx"] = 0;
            Session["GameOver"] = false;
            Session["CurRound"] = lastRound.Round;
            Session["RightAnswerCount"] = 0;
            Session["WrongAnswerCount"] = 0;
            setWelcome();
            setUI(probSet.ProblemList[0]);
        }

        /// <summary>
        /// Determines problem type based on level
        /// </summary>
        /// <param name="level"></param>
        /// <returns>Problem type of the current set of problems</returns>
        private ProblemTypeEnum DetermineProbType(int level)
        {
            if (level % 2 == 0)
                return ProblemTypeEnum.Subtraction;
            // TODO: add in capability to have both add and sub problems in the list
            else
                return ProblemTypeEnum.Addition;
        }

		/// <summary>
		/// Submits student's answer and checks against stored answer.
		/// Displays pop up with Correct/Incorrect and sets the UI for the next problem.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			// check that the user input is not blank
			if (String.IsNullOrWhiteSpace(txtStudentInput.Text))
				return; // return out if the input is blank

            GetInput();
            CheckStudentAnswer();
            StoreResults();
            ChangePanels();
        }

        /// <summary>
        /// Stores student text input as session variable
        /// </summary>
        private void GetInput()
        {
            // get student answer from textbox
            int studentAnswer;
            Int32.TryParse(txtStudentInput.Text, out studentAnswer);
            Session["StudentAnswer"] = studentAnswer;
            txtStudentInput.Text = ""; 
        }

        /// <summary>
        /// Checks the student's answer against the stored correct answer
        /// </summary>
        private void CheckStudentAnswer()
        {
            int studentAnswer = (int)Session["StudentAnswer"];
            StudentProblem curProb = GetCurProb();
            
            // correct answer
            if (studentAnswer == curProb.Problem.Result)
            {
                // add happy cookie image
                imgCookie.ImageUrl = "images/cookie-happy.png";
                imgCookie.AlternateText = "Happy Cookie";

                //change the label text and color
                lblAnswerResult.Text = "Correct!";
                lblAnswerResult.CssClass = "correct";

                // increment right answers
                int x = (int)Session["RightAnswerCount"];
                Session["RightAnswerCount"] = ++x;
            }
            // incorrect answer
            else
            {
                // add sad cookie image
                imgCookie.ImageUrl = "images/cookie-sad.png";
                imgCookie.AlternateText = "Sad Cookie";

                //change the label text and color
                lblAnswerResult.Text = "Incorrect!";
                lblAnswerResult.CssClass = "incorrect";

                // increment wrong answers
                int x = (int)Session["WrongAnswerCount"];
                Session["WrongAnswerCount"] = ++x;
            }
        }

        /// <summary>
        /// Stores student answer as a result
        /// </summary>
        private void StoreResults()
        {
            int studentAnswer = (int)Session["StudentAnswer"];
            StudentProblem curProb = GetCurProb();

            // Store problem and student's answer as a Result object
            Result result = new Result();
            result.StudentID = (int)Session["UserID"];
            result.ProblemID = curProb.Problem.AddSubProblemID;
            result.Answer = studentAnswer;
            result.Level = curProb.Problem.Level;
            result.Round = (int)Session["CurRound"];

            // Add the result to the list node
            curProb.studentResult = result;           
        }

        /// <summary>
        /// Determines which panel to switch to
        /// </summary>
        private void ChangePanels()
        {
            ProblemSet probSet = (ProblemSet)Session["CurProbSet"];
            int idx = (int)Session["ProblemIdx"];

            // bring up the results pop up panel
            pnlGame.Visible = false;
            pnlResults.Visible = true;

            // check if we've reached the end of the list
            if (++idx >= probSet.ProblemList.Count)
            {
                // save the results to the DB
                probSet.SaveResults();

                Session["GameOver"] = true;

                // advance the round
                int round = (int)Session["CurRound"];
                Session["CurRound"] = ++round;

                // switch panels to display
                setFinal();
            }
            else
            {
                // store current index in hidden label
                Session["ProblemIdx"] = idx;

                // move to the next problem
                setUI(probSet.ProblemList[idx]);
            }
        }

        /// <summary>
        /// Grabs the current problem form the problem set's list 
        /// using the current index value
        /// </summary>
        /// <returns>Current Problem that the student is working on</returns>
        private StudentProblem GetCurProb()
        {
            int idx = (int)Session["ProblemIdx"];
            ProblemSet probSet = (ProblemSet)Session["CurProbSet"];
            StudentProblem curProb = probSet.ProblemList[idx];
            return curProb;
        }

		/// <summary>
		/// Sets the UI for the game screen.
		/// </summary>
		private void setUI(StudentProblem curProb)
		{
            // Pull current problem from problem list
			AddSubProblem prob = curProb.Problem;
			Session["CurAnswer"] = prob.Result;
			string ord1 = prob.Operator1.ToString();
			string ord2 = prob.Operator2.ToString();
            string opSign =
                prob.ProblemType == ProblemTypeEnum.Addition ? "+" : "-";

            // set text
			lblOpSign.Text = opSign;
			lblOrd1.Text = ord1;
			lblOrd2.Text = ord2;
		}

		/// <summary>
		/// Intializes the Welcome Popup
		/// </summary>
		private void setWelcome()
		{
            // Get problem type and last round data from Session variables
            ProblemTypeEnum probType = (ProblemTypeEnum)Session["CurProbSetType"];
            GetLastRoundResult lastRound = (GetLastRoundResult)Session["LastRound"];

            // Pass variables to strings for displaying in Panel
			string name = (string)Session["FirstName"];
            string type =
                probType == ProblemTypeEnum.Addition ? "addition" : "subtraction";
			string round = lastRound.Level.ToString();

			// Set the label text
			lblWelcomeName.Text = "Welcome, " + name;
			lblLastTime.Text = "Last, you made it to round " + round;
			lblThisTime.Text = "Today, you work on " + type;
		}

        /// <summary>
        /// Sets up the final results panel
        /// </summary>
        private void setFinal()
        {
            // Pull the data from session variables
            int right = (int)Session["RightAnswerCount"];
            int wrong = (int)Session["WrongAnswerCount"];

            // Set the labels
            lblRight.Text = "You got " + right.ToString() + " right!";
            lblWrong.Text = "You got " + wrong.ToString() + " wrong";
        }

        /// <summary>
        /// Displays the final results panel
        /// </summary>
        private void goToFinal()
        {
            pnlGame.Visible = false;
            pnlResults.Visible = false;
            pnlWelcome.Visible = false;
            pnlFinal.Visible = true;
        }

		/// <summary>
		/// Closes the Welcome popup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnReady_Click(object sender, EventArgs e)
		{
			pnlWelcome.Visible = false;
            pnlGame.Visible = true;
		}

		/// <summary>
		/// Closes the Results popup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnContinue_Click(object sender, EventArgs e)
		{
			pnlResults.Visible = false;
            pnlGame.Visible = true;

            if (lblGameOver.Text == "true")
            {
                goToFinal();
            }
		}

		protected void btnLogoff_Click(object sender, EventArgs e)
		{
            Server.Transfer("logout.aspx");
		}
	}
}