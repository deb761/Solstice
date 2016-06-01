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
                // Initialize page
                int studentID = (int)Session["UserID"];
                ProblemSet probSet = new ProblemSet(studentID, 1, ProblemType.Addition);
                Session["CurProbSet"] = probSet;
                Session["ProblemIdx"] = 0;
                Session["GameOver"] = false;
                Session["CurRound"] = 1;
                Session["RightAnswerCount"] = 0;
                Session["WrongAnswerCount"] = 0;
                setWelcome();
                setUI(probSet.ProblemList[0]);
			}
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
                prob.ProblemType == ProblemType.Addition ? "+" : "-";

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
			string name = (string)Session["FirstName"];
			string probType = "+"; // temp until we include other types of problems
			string lastRound = "0"; // temp until we keep track of round/levels passed

			// Set the label text
			lblWelcomeName.Text = "Welcome, " + name;
			lblLastTime.Text = "Last, you made it to round " + lastRound;
			lblThisTime.Text = "Today, you work on " + probType;
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