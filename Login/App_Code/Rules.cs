using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using System.Web.UI;
using Newtonsoft.Json;
using System.Web;

/// <summary>
/// An enumeration that tracks problem type
/// </summary>
public enum ProblemTypeEnum { Addition, Subtraction, PlaceValue }
/// <summary>
/// An enumeration that tracks user type
/// </summary>
public enum UserTypeEnum { Student, Teacher, Administrator, Super }
/// <summary>
/// This class defines the rules for a level
/// </summary>
public class LevelRules
{
    /// <summary>
    /// The level number
    /// </summary>
    public int Level { get; set; }
    /// <summary>
    /// The minimum value for problem operator 1
    /// </summary>
    public int MinVal1 { get; set; }
    /// <summary>
    /// The maximum value for problem operator 1
    /// </summary>
    public int MaxVal1 { get; set; }
    /// <summary>
    /// The minimum value for problem operator 2
    /// </summary>
    public int MinVal2 { get; set; }
    /// <summary>
    /// The maximum value for problem operator 2
    /// </summary>
    public int MaxVal2 { get; set; }
    /// <summary>
    /// Maximim value for result
    /// </summary>
    public int MaxResult { get; set; }
    /// <summary>
    /// True if placevalue problems should be included
    /// </summary>
    public bool PlaceVal { get; set; }
    /// <summary>
    /// Number of rounds in the level
    /// </summary>
    public int NumRounds { get; set; }
    /// <summary>
    /// Number of problems in each round
    /// </summary>
    public int ProbsPerRound { get; set; }
}
/// <summary>
/// This class is used to provide general problem definition and creation
/// </summary>
public static class Rules
{
    /// <summary>
    /// The rules for each level
    /// </summary>
    public static Dictionary<int, LevelRules> Levels { get; private set; }
    /// <summary>
    /// Load the levels from rules.json
    /// </summary>
    /// <param name="server">Server object</param>
    public static void Load(HttpServerUtility server)
    {
        List<LevelRules> levels = null;
        Levels = new Dictionary<int, LevelRules>();
        using (StreamReader rdr = new StreamReader(server.MapPath("App_Data/rules.json")))
        {
            levels = JsonConvert.DeserializeObject<List<LevelRules>>(rdr.ReadToEnd());
            foreach (LevelRules level in levels)
            {
                Levels[level.Level] = level;
            }
        }

    }
}
