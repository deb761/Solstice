﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SolsticeAPI_db")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  partial void InsertResult(Result instance);
  partial void UpdateResult(Result instance);
  partial void DeleteResult(Result instance);
  partial void InsertSchoolYear(SchoolYear instance);
  partial void UpdateSchoolYear(SchoolYear instance);
  partial void DeleteSchoolYear(SchoolYear instance);
  partial void InsertClassStudent(ClassStudent instance);
  partial void UpdateClassStudent(ClassStudent instance);
  partial void DeleteClassStudent(ClassStudent instance);
  partial void InsertUserType(UserType instance);
  partial void UpdateUserType(UserType instance);
  partial void DeleteUserType(UserType instance);
  partial void InsertProblemType(ProblemType instance);
  partial void UpdateProblemType(ProblemType instance);
  partial void DeleteProblemType(ProblemType instance);
  partial void InsertAddSubProblem(AddSubProblem instance);
  partial void UpdateAddSubProblem(AddSubProblem instance);
  partial void DeleteAddSubProblem(AddSubProblem instance);
  partial void InsertClass(Class instance);
  partial void UpdateClass(Class instance);
  partial void DeleteClass(Class instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SolsticeAPI_dbConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<User> Users
	{
		get
		{
			return this.GetTable<User>();
		}
	}
	
	public System.Data.Linq.Table<Result> Results
	{
		get
		{
			return this.GetTable<Result>();
		}
	}
	
	public System.Data.Linq.Table<SchoolYear> SchoolYears
	{
		get
		{
			return this.GetTable<SchoolYear>();
		}
	}
	
	public System.Data.Linq.Table<ClassStudent> ClassStudents
	{
		get
		{
			return this.GetTable<ClassStudent>();
		}
	}
	
	public System.Data.Linq.Table<UserType> UserTypes
	{
		get
		{
			return this.GetTable<UserType>();
		}
	}
	
	public System.Data.Linq.Table<ProblemType> ProblemTypes
	{
		get
		{
			return this.GetTable<ProblemType>();
		}
	}
	
	public System.Data.Linq.Table<AddSubProblem> AddSubProblems
	{
		get
		{
			return this.GetTable<AddSubProblem>();
		}
	}
	
	public System.Data.Linq.Table<Class> Classes
	{
		get
		{
			return this.GetTable<Class>();
		}
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetProblemIDs")]
	public ISingleResult<GetProblemIDsResult> GetProblemIDs([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> probType, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> level)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), probType, level);
		return ((ISingleResult<GetProblemIDsResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetLastRound")]
	public ISingleResult<GetLastRoundResult> GetLastRound([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentID);
		return ((ISingleResult<GetLastRoundResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetMissedProblems")]
	public ISingleResult<GetMissedProblemsResult> GetMissedProblems([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> probTypeID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentID, probTypeID);
		return ((ISingleResult<GetMissedProblemsResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.LastTimeRight")]
	public ISingleResult<LastTimeRightResult> LastTimeRight([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> studentID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> problemID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), studentID, problemID);
		return ((ISingleResult<LastTimeRightResult>)(result.ReturnValue));
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _UserID;
	
	private global::UserTypeEnum _UserType;
	
	private string _Login;
	
	private string _FirstName;
	
	private string _LastName;
	
	private string _Password;
	
	private EntitySet<ClassStudent> _ClassStudents;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    partial void OnUserTypeChanging(global::UserTypeEnum value);
    partial void OnUserTypeChanged();
    partial void OnLoginChanging(string value);
    partial void OnLoginChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
	
	public User()
	{
		this._ClassStudents = new EntitySet<ClassStudent>(new Action<ClassStudent>(this.attach_ClassStudents), new Action<ClassStudent>(this.detach_ClassStudents));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserType", DbType="Int NOT NULL", CanBeNull=false)]
	public global::UserTypeEnum UserType
	{
		get
		{
			return this._UserType;
		}
		set
		{
			if ((this._UserType != value))
			{
				this.OnUserTypeChanging(value);
				this.SendPropertyChanging();
				this._UserType = value;
				this.SendPropertyChanged("UserType");
				this.OnUserTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Login", DbType="NVarChar(MAX)")]
	public string Login
	{
		get
		{
			return this._Login;
		}
		set
		{
			if ((this._Login != value))
			{
				this.OnLoginChanging(value);
				this.SendPropertyChanging();
				this._Login = value;
				this.SendPropertyChanged("Login");
				this.OnLoginChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX)")]
	public string FirstName
	{
		get
		{
			return this._FirstName;
		}
		set
		{
			if ((this._FirstName != value))
			{
				this.OnFirstNameChanging(value);
				this.SendPropertyChanging();
				this._FirstName = value;
				this.SendPropertyChanged("FirstName");
				this.OnFirstNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX)")]
	public string LastName
	{
		get
		{
			return this._LastName;
		}
		set
		{
			if ((this._LastName != value))
			{
				this.OnLastNameChanging(value);
				this.SendPropertyChanging();
				this._LastName = value;
				this.SendPropertyChanged("LastName");
				this.OnLastNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NChar(89)")]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ClassStudent", Storage="_ClassStudents", ThisKey="UserID", OtherKey="UserID")]
	public EntitySet<ClassStudent> ClassStudents
	{
		get
		{
			return this._ClassStudents;
		}
		set
		{
			this._ClassStudents.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_ClassStudents(ClassStudent entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_ClassStudents(ClassStudent entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Results")]
public partial class Result : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ResultID;
	
	private int _StudentID;
	
	private int _ProblemID;
	
	private System.Nullable<int> _Answer;
	
	private int _Level;
	
	private int _Round;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnResultIDChanging(int value);
    partial void OnResultIDChanged();
    partial void OnStudentIDChanging(int value);
    partial void OnStudentIDChanged();
    partial void OnProblemIDChanging(int value);
    partial void OnProblemIDChanged();
    partial void OnAnswerChanging(System.Nullable<int> value);
    partial void OnAnswerChanged();
    partial void OnLevelChanging(int value);
    partial void OnLevelChanged();
    partial void OnRoundChanging(int value);
    partial void OnRoundChanged();
    #endregion
	
	public Result()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ResultID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ResultID
	{
		get
		{
			return this._ResultID;
		}
		set
		{
			if ((this._ResultID != value))
			{
				this.OnResultIDChanging(value);
				this.SendPropertyChanging();
				this._ResultID = value;
				this.SendPropertyChanged("ResultID");
				this.OnResultIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StudentID", DbType="Int NOT NULL")]
	public int StudentID
	{
		get
		{
			return this._StudentID;
		}
		set
		{
			if ((this._StudentID != value))
			{
				this.OnStudentIDChanging(value);
				this.SendPropertyChanging();
				this._StudentID = value;
				this.SendPropertyChanged("StudentID");
				this.OnStudentIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProblemID", DbType="Int NOT NULL")]
	public int ProblemID
	{
		get
		{
			return this._ProblemID;
		}
		set
		{
			if ((this._ProblemID != value))
			{
				this.OnProblemIDChanging(value);
				this.SendPropertyChanging();
				this._ProblemID = value;
				this.SendPropertyChanged("ProblemID");
				this.OnProblemIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Answer", DbType="Int")]
	public System.Nullable<int> Answer
	{
		get
		{
			return this._Answer;
		}
		set
		{
			if ((this._Answer != value))
			{
				this.OnAnswerChanging(value);
				this.SendPropertyChanging();
				this._Answer = value;
				this.SendPropertyChanged("Answer");
				this.OnAnswerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int NOT NULL")]
	public int Level
	{
		get
		{
			return this._Level;
		}
		set
		{
			if ((this._Level != value))
			{
				this.OnLevelChanging(value);
				this.SendPropertyChanging();
				this._Level = value;
				this.SendPropertyChanged("Level");
				this.OnLevelChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Round", DbType="Int NOT NULL")]
	public int Round
	{
		get
		{
			return this._Round;
		}
		set
		{
			if ((this._Round != value))
			{
				this.OnRoundChanging(value);
				this.SendPropertyChanging();
				this._Round = value;
				this.SendPropertyChanged("Round");
				this.OnRoundChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SchoolYears")]
public partial class SchoolYear : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _YearID;
	
	private string _Name;
	
	private System.Nullable<System.DateTime> _Start;
	
	private System.Nullable<System.DateTime> _End;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnYearIDChanging(int value);
    partial void OnYearIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnStartChanging(System.Nullable<System.DateTime> value);
    partial void OnStartChanged();
    partial void OnEndChanging(System.Nullable<System.DateTime> value);
    partial void OnEndChanged();
    #endregion
	
	public SchoolYear()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int YearID
	{
		get
		{
			return this._YearID;
		}
		set
		{
			if ((this._YearID != value))
			{
				this.OnYearIDChanging(value);
				this.SendPropertyChanging();
				this._YearID = value;
				this.SendPropertyChanged("YearID");
				this.OnYearIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Start", DbType="DateTime")]
	public System.Nullable<System.DateTime> Start
	{
		get
		{
			return this._Start;
		}
		set
		{
			if ((this._Start != value))
			{
				this.OnStartChanging(value);
				this.SendPropertyChanging();
				this._Start = value;
				this.SendPropertyChanged("Start");
				this.OnStartChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[End]", Storage="_End", DbType="DateTime")]
	public System.Nullable<System.DateTime> End
	{
		get
		{
			return this._End;
		}
		set
		{
			if ((this._End != value))
			{
				this.OnEndChanging(value);
				this.SendPropertyChanging();
				this._End = value;
				this.SendPropertyChanged("End");
				this.OnEndChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ClassStudents")]
public partial class ClassStudent : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ClassID;
	
	private int _UserID;
	
	private EntityRef<User> _User;
	
	private EntityRef<Class> _Class;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnClassIDChanging(int value);
    partial void OnClassIDChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
	
	public ClassStudent()
	{
		this._User = default(EntityRef<User>);
		this._Class = default(EntityRef<Class>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int ClassID
	{
		get
		{
			return this._ClassID;
		}
		set
		{
			if ((this._ClassID != value))
			{
				if (this._Class.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnClassIDChanging(value);
				this.SendPropertyChanging();
				this._ClassID = value;
				this.SendPropertyChanged("ClassID");
				this.OnClassIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ClassStudent", Storage="_User", ThisKey="UserID", OtherKey="UserID", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.ClassStudents.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.ClassStudents.Add(this);
					this._UserID = value.UserID;
				}
				else
				{
					this._UserID = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Class_ClassStudent", Storage="_Class", ThisKey="ClassID", OtherKey="ClassID", IsForeignKey=true)]
	public Class Class
	{
		get
		{
			return this._Class.Entity;
		}
		set
		{
			Class previousValue = this._Class.Entity;
			if (((previousValue != value) 
						|| (this._Class.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Class.Entity = null;
					previousValue.ClassStudents.Remove(this);
				}
				this._Class.Entity = value;
				if ((value != null))
				{
					value.ClassStudents.Add(this);
					this._ClassID = value.ClassID;
				}
				else
				{
					this._ClassID = default(int);
				}
				this.SendPropertyChanged("Class");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserTypes")]
public partial class UserType : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private global::UserTypeEnum _UserTypeID;
	
	private string _UserTypeName;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserTypeIDChanging(global::UserTypeEnum value);
    partial void OnUserTypeIDChanged();
    partial void OnUserTypeNameChanging(string value);
    partial void OnUserTypeNameChanged();
    #endregion
	
	public UserType()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserTypeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
	public global::UserTypeEnum UserTypeID
	{
		get
		{
			return this._UserTypeID;
		}
		set
		{
			if ((this._UserTypeID != value))
			{
				this.OnUserTypeIDChanging(value);
				this.SendPropertyChanging();
				this._UserTypeID = value;
				this.SendPropertyChanged("UserTypeID");
				this.OnUserTypeIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserTypeName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
	public string UserTypeName
	{
		get
		{
			return this._UserTypeName;
		}
		set
		{
			if ((this._UserTypeName != value))
			{
				this.OnUserTypeNameChanging(value);
				this.SendPropertyChanging();
				this._UserTypeName = value;
				this.SendPropertyChanged("UserTypeName");
				this.OnUserTypeNameChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ProblemTypes")]
public partial class ProblemType : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private global::ProblemTypeEnum _ProblemTypeID;
	
	private string _ProblemTypeName;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProblemTypeIDChanging(global::ProblemTypeEnum value);
    partial void OnProblemTypeIDChanged();
    partial void OnProblemTypeNameChanging(string value);
    partial void OnProblemTypeNameChanged();
    #endregion
	
	public ProblemType()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProblemTypeID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", CanBeNull=false, IsPrimaryKey=true, IsDbGenerated=true)]
	public global::ProblemTypeEnum ProblemTypeID
	{
		get
		{
			return this._ProblemTypeID;
		}
		set
		{
			if ((this._ProblemTypeID != value))
			{
				this.OnProblemTypeIDChanging(value);
				this.SendPropertyChanging();
				this._ProblemTypeID = value;
				this.SendPropertyChanged("ProblemTypeID");
				this.OnProblemTypeIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProblemTypeName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
	public string ProblemTypeName
	{
		get
		{
			return this._ProblemTypeName;
		}
		set
		{
			if ((this._ProblemTypeName != value))
			{
				this.OnProblemTypeNameChanging(value);
				this.SendPropertyChanging();
				this._ProblemTypeName = value;
				this.SendPropertyChanged("ProblemTypeName");
				this.OnProblemTypeNameChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AddSubProblems")]
public partial class AddSubProblem : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _AddSubProblemID;
	
	private int _Level;
	
	private int _Operator1;
	
	private int _Operator2;
	
	private int _Result;
	
	private global::ProblemTypeEnum _ProblemType;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAddSubProblemIDChanging(int value);
    partial void OnAddSubProblemIDChanged();
    partial void OnLevelChanging(int value);
    partial void OnLevelChanged();
    partial void OnOperator1Changing(int value);
    partial void OnOperator1Changed();
    partial void OnOperator2Changing(int value);
    partial void OnOperator2Changed();
    partial void OnResultChanging(int value);
    partial void OnResultChanged();
    partial void OnProblemTypeChanging(global::ProblemTypeEnum value);
    partial void OnProblemTypeChanged();
    #endregion
	
	public AddSubProblem()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddSubProblemID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int AddSubProblemID
	{
		get
		{
			return this._AddSubProblemID;
		}
		set
		{
			if ((this._AddSubProblemID != value))
			{
				this.OnAddSubProblemIDChanging(value);
				this.SendPropertyChanging();
				this._AddSubProblemID = value;
				this.SendPropertyChanged("AddSubProblemID");
				this.OnAddSubProblemIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int NOT NULL")]
	public int Level
	{
		get
		{
			return this._Level;
		}
		set
		{
			if ((this._Level != value))
			{
				this.OnLevelChanging(value);
				this.SendPropertyChanging();
				this._Level = value;
				this.SendPropertyChanged("Level");
				this.OnLevelChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Operator1", DbType="Int NOT NULL")]
	public int Operator1
	{
		get
		{
			return this._Operator1;
		}
		set
		{
			if ((this._Operator1 != value))
			{
				this.OnOperator1Changing(value);
				this.SendPropertyChanging();
				this._Operator1 = value;
				this.SendPropertyChanged("Operator1");
				this.OnOperator1Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Operator2", DbType="Int NOT NULL")]
	public int Operator2
	{
		get
		{
			return this._Operator2;
		}
		set
		{
			if ((this._Operator2 != value))
			{
				this.OnOperator2Changing(value);
				this.SendPropertyChanging();
				this._Operator2 = value;
				this.SendPropertyChanged("Operator2");
				this.OnOperator2Changed();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Result", DbType="Int NOT NULL")]
	public int Result
	{
		get
		{
			return this._Result;
		}
		set
		{
			if ((this._Result != value))
			{
				this.OnResultChanging(value);
				this.SendPropertyChanging();
				this._Result = value;
				this.SendPropertyChanged("Result");
				this.OnResultChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProblemType", DbType="Int NOT NULL", CanBeNull=false)]
	public global::ProblemTypeEnum ProblemType
	{
		get
		{
			return this._ProblemType;
		}
		set
		{
			if ((this._ProblemType != value))
			{
				this.OnProblemTypeChanging(value);
				this.SendPropertyChanging();
				this._ProblemType = value;
				this.SendPropertyChanged("ProblemType");
				this.OnProblemTypeChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Classes")]
public partial class Class : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ClassID;
	
	private int _YearID;
	
	private System.Nullable<int> _TeacherID;
	
	private string _ClassName;
	
	private System.Nullable<int> _RoomID;
	
	private EntitySet<ClassStudent> _ClassStudents;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnClassIDChanging(int value);
    partial void OnClassIDChanged();
    partial void OnYearIDChanging(int value);
    partial void OnYearIDChanged();
    partial void OnTeacherIDChanging(System.Nullable<int> value);
    partial void OnTeacherIDChanged();
    partial void OnClassNameChanging(string value);
    partial void OnClassNameChanged();
    partial void OnRoomIDChanging(System.Nullable<int> value);
    partial void OnRoomIDChanged();
    #endregion
	
	public Class()
	{
		this._ClassStudents = new EntitySet<ClassStudent>(new Action<ClassStudent>(this.attach_ClassStudents), new Action<ClassStudent>(this.detach_ClassStudents));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ClassID
	{
		get
		{
			return this._ClassID;
		}
		set
		{
			if ((this._ClassID != value))
			{
				this.OnClassIDChanging(value);
				this.SendPropertyChanging();
				this._ClassID = value;
				this.SendPropertyChanged("ClassID");
				this.OnClassIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearID", DbType="Int NOT NULL")]
	public int YearID
	{
		get
		{
			return this._YearID;
		}
		set
		{
			if ((this._YearID != value))
			{
				this.OnYearIDChanging(value);
				this.SendPropertyChanging();
				this._YearID = value;
				this.SendPropertyChanged("YearID");
				this.OnYearIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TeacherID", DbType="Int")]
	public System.Nullable<int> TeacherID
	{
		get
		{
			return this._TeacherID;
		}
		set
		{
			if ((this._TeacherID != value))
			{
				this.OnTeacherIDChanging(value);
				this.SendPropertyChanging();
				this._TeacherID = value;
				this.SendPropertyChanged("TeacherID");
				this.OnTeacherIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClassName", DbType="VarChar(50)")]
	public string ClassName
	{
		get
		{
			return this._ClassName;
		}
		set
		{
			if ((this._ClassName != value))
			{
				this.OnClassNameChanging(value);
				this.SendPropertyChanging();
				this._ClassName = value;
				this.SendPropertyChanged("ClassName");
				this.OnClassNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomID", DbType="Int")]
	public System.Nullable<int> RoomID
	{
		get
		{
			return this._RoomID;
		}
		set
		{
			if ((this._RoomID != value))
			{
				this.OnRoomIDChanging(value);
				this.SendPropertyChanging();
				this._RoomID = value;
				this.SendPropertyChanged("RoomID");
				this.OnRoomIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Class_ClassStudent", Storage="_ClassStudents", ThisKey="ClassID", OtherKey="ClassID")]
	public EntitySet<ClassStudent> ClassStudents
	{
		get
		{
			return this._ClassStudents;
		}
		set
		{
			this._ClassStudents.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_ClassStudents(ClassStudent entity)
	{
		this.SendPropertyChanging();
		entity.Class = this;
	}
	
	private void detach_ClassStudents(ClassStudent entity)
	{
		this.SendPropertyChanging();
		entity.Class = null;
	}
}

public partial class GetProblemIDsResult
{
	
	private int _AddSubProblemID;
	
	public GetProblemIDsResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AddSubProblemID", DbType="Int NOT NULL")]
	public int AddSubProblemID
	{
		get
		{
			return this._AddSubProblemID;
		}
		set
		{
			if ((this._AddSubProblemID != value))
			{
				this._AddSubProblemID = value;
			}
		}
	}
}

public partial class GetLastRoundResult
{
	
	private int _Level;
	
	private int _Round;
	
	private System.Nullable<int> _Count;
	
	public GetLastRoundResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Level]", Storage="_Level", DbType="Int NOT NULL")]
	public int Level
	{
		get
		{
			return this._Level;
		}
		set
		{
			if ((this._Level != value))
			{
				this._Level = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Round", DbType="Int NOT NULL")]
	public int Round
	{
		get
		{
			return this._Round;
		}
		set
		{
			if ((this._Round != value))
			{
				this._Round = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Count", DbType="Int")]
	public System.Nullable<int> Count
	{
		get
		{
			return this._Count;
		}
		set
		{
			if ((this._Count != value))
			{
				this._Count = value;
			}
		}
	}
}

public partial class GetMissedProblemsResult
{
	
	private System.Nullable<int> _Last;
	
	private System.Nullable<int> _Count;
	
	private int _ProblemID;
	
	public GetMissedProblemsResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Last", DbType="Int")]
	public System.Nullable<int> Last
	{
		get
		{
			return this._Last;
		}
		set
		{
			if ((this._Last != value))
			{
				this._Last = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Count", DbType="Int")]
	public System.Nullable<int> Count
	{
		get
		{
			return this._Count;
		}
		set
		{
			if ((this._Count != value))
			{
				this._Count = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProblemID", DbType="Int NOT NULL")]
	public int ProblemID
	{
		get
		{
			return this._ProblemID;
		}
		set
		{
			if ((this._ProblemID != value))
			{
				this._ProblemID = value;
			}
		}
	}
}

public partial class LastTimeRightResult
{
	
	private System.Nullable<int> _Last;
	
	public LastTimeRightResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Last", DbType="Int")]
	public System.Nullable<int> Last
	{
		get
		{
			return this._Last;
		}
		set
		{
			if ((this._Last != value))
			{
				this._Last = value;
			}
		}
	}
}
#pragma warning restore 1591
