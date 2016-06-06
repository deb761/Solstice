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
                ProblemSet probSet = new ProblemSet(studentID, 1, ProblemTypeEnum.Addition);
                Session["CurProbSet"] = probSet;
                int idx = 0;
                lblProbIdx.Text = idx.ToString();
                lblGameOver.Text = "false";
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
		protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
		{
			// check that the user input is not blank
			if (String.IsNullOrWhiteSpace(txtStudentInput.Text))
				return; // return out if the input is blank

			// get index value from hidden label
			int idx;
			Int32.TryParse(lblProbIdx.Text, out idx);

			// get student answer from textbox
			int studentAnswer;
			Int32.TryParse(txtStudentInput.Text, out studentAnswer);
            txtStudentInput.Text = "";

			ProblemSet probSet = (ProblemSet)Session["CurProbSet"];
			StudentProblem curProb = probSet.ProblemList[idx];
			// correct answer
			if (studentAnswer == curProb.Problem.Result)
			{
				// add happy cookie image
				imgCookie.ImageUrl = "images/cookie-happy.png";
				imgCookie.AlternateText = "Happy Cookie";

				//change the label text and color
				lblAnswerResult.Text = "Correct!";
                //lblAnswerResult.ForeColor = "#9BFF3A";

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
                // lblAnswerResult.ForeColor = "#E52B14";

                // increment wrong answers
                int x = (int)Session["WrongAnswerCount"];
                Session["WrongAnswerCount"] = ++x;
			}

			// Store problem and student's answer as a Result object
			Result result = new Result();
			result.StudentID = (int)Session["UserID"];
			result.ProblemID = curProb.Problem.AddSubProblemID;
			result.Answer = studentAnswer;
			result.Level = curProb.Problem.Level;
			result.Round = (int)Session["CurRound"];

			// Add the result to the list node
			curProb.studentResult = result;

            // bring up the results pop up panel
            pnlGame.Visible = false;
			pnlResults.Visible = true;

			// check if we've reached the end of the list
			if (++idx >= probSet.ProblemList.Count)
			{
				// save the results to the DB
				probSet.SaveResults();

                lblGameOver.Text = "true";

				// advance the round
				int round = (int)Session["CurRound"];
				Session["CurRound"] = ++round;

                // switch panels to display
                setFinal();
			}
			else
			{
				// store current index in hidden label
				lblProbIdx.Text = idx.ToString();

				// move to the next problem
				setUI(probSet.ProblemList[idx]);
			}
		}

		/// <summary>
		/// Sets the UI for the game screen.
		/// </summary>
		private void setUI(StudentProblem curProb)
		{
			AddSubProblem prob = curProb.Problem;
			Session["CurAnswer"] = prob.Result;
			string ord1 = prob.Operator1.ToString();
			string ord2 = prob.Operator2.ToString();

            // set the images for the UI
            imgOpSign.ImageUrl = "images/signs/plus.png";
            imgOrd1.ImageUrl = "images/nums/" + ord1 + ".png";
            imgOrd2.ImageUrl = "images/nums/" + ord2 + ".png";

            // set alternate text
			imgOpSign.AlternateText = "+";
			imgOrd1.AlternateText = ord1;
			imgOrd2.AlternateText = ord2;
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

        private void setFinal()
        {
            int right = (int)Session["RightAnswerCount"];
            int wrong = (int)Session["WrongAnswerCount"];

            lblRight.Text = "You got " + right.ToString() + " right!";
            lblWrong.Text = "You got " + wrong.ToString() + " wrong";
        }

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
		protected void btnReady_Click(object sender, ImageClickEventArgs e)
		{
			pnlWelcome.Visible = false;
            pnlGame.Visible = true;
		}

		/// <summary>
		/// Closes the Results popup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnContinue_Click(object sender, ImageClickEventArgs e)
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