'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.4927
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


'Original file name:
'Generation date: 9/16/2009 7:25:53 PM
Namespace SchoolLinqToSQLService
    '''<summary>
    '''There are no comments for SchoolLinqToSQLDataContext in the schema.
    '''</summary>
    Partial Public Class SchoolLinqToSQLDataContext
        Inherits Global.System.Data.Services.Client.DataServiceContext
        '''<summary>
        '''Initialize a new SchoolLinqToSQLDataContext object.
        '''</summary>
        Public Sub New(ByVal serviceRoot As Global.System.Uri)
            MyBase.New(serviceRoot)
            Me.ResolveName = AddressOf Me.ResolveNameFromType
            Me.ResolveType = AddressOf Me.ResolveTypeFromName
            Me.OnContextCreated
        End Sub
        Partial Private Sub OnContextCreated()
        End Sub
        Private Shared ROOTNAMESPACE As String = GetType(SchoolLinqToSQLService.SchoolLinqToSQLDataContext).Namespace.Remove(GetType(SchoolLinqToSQLService.SchoolLinqToSQLDataContext).Namespace.LastIndexOf("SchoolLinqToSQLService"))
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        Protected Function ResolveTypeFromName(ByVal typeName As String) As Global.System.Type
            If typeName.StartsWith("VBADONETDataService.LinqToSQL", Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return Me.GetType.Assembly.GetType(String.Concat(String.Concat(ROOTNAMESPACE, "SchoolLinqToSQLService"), typeName.Substring(29)), true)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        Protected Function ResolveNameFromType(ByVal clientType As Global.System.Type) As String
            If clientType.Namespace.Equals(String.Concat(ROOTNAMESPACE, "SchoolLinqToSQLService"), Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return String.Concat("VBADONETDataService.LinqToSQL.", clientType.Name)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''There are no comments for Courses in the schema.
        '''</summary>
        Public ReadOnly Property Courses() As Global.System.Data.Services.Client.DataServiceQuery(Of Course)
            Get
                If (Me._Courses Is Nothing) Then
                    Me._Courses = MyBase.CreateQuery(Of Course)("Courses")
                End If
                Return Me._Courses
            End Get
        End Property
        Private _Courses As Global.System.Data.Services.Client.DataServiceQuery(Of Course)
        '''<summary>
        '''There are no comments for CourseGrades in the schema.
        '''</summary>
        Public ReadOnly Property CourseGrades() As Global.System.Data.Services.Client.DataServiceQuery(Of CourseGrade)
            Get
                If (Me._CourseGrades Is Nothing) Then
                    Me._CourseGrades = MyBase.CreateQuery(Of CourseGrade)("CourseGrades")
                End If
                Return Me._CourseGrades
            End Get
        End Property
        Private _CourseGrades As Global.System.Data.Services.Client.DataServiceQuery(Of CourseGrade)
        '''<summary>
        '''There are no comments for CourseInstructors in the schema.
        '''</summary>
        Public ReadOnly Property CourseInstructors() As Global.System.Data.Services.Client.DataServiceQuery(Of CourseInstructor)
            Get
                If (Me._CourseInstructors Is Nothing) Then
                    Me._CourseInstructors = MyBase.CreateQuery(Of CourseInstructor)("CourseInstructors")
                End If
                Return Me._CourseInstructors
            End Get
        End Property
        Private _CourseInstructors As Global.System.Data.Services.Client.DataServiceQuery(Of CourseInstructor)
        '''<summary>
        '''There are no comments for Persons in the schema.
        '''</summary>
        Public ReadOnly Property Persons() As Global.System.Data.Services.Client.DataServiceQuery(Of Person)
            Get
                If (Me._Persons Is Nothing) Then
                    Me._Persons = MyBase.CreateQuery(Of Person)("Persons")
                End If
                Return Me._Persons
            End Get
        End Property
        Private _Persons As Global.System.Data.Services.Client.DataServiceQuery(Of Person)
        '''<summary>
        '''There are no comments for Courses in the schema.
        '''</summary>
        Public Sub AddToCourses(ByVal course As Course)
            MyBase.AddObject("Courses", course)
        End Sub
        '''<summary>
        '''There are no comments for CourseGrades in the schema.
        '''</summary>
        Public Sub AddToCourseGrades(ByVal courseGrade As CourseGrade)
            MyBase.AddObject("CourseGrades", courseGrade)
        End Sub
        '''<summary>
        '''There are no comments for CourseInstructors in the schema.
        '''</summary>
        Public Sub AddToCourseInstructors(ByVal courseInstructor As CourseInstructor)
            MyBase.AddObject("CourseInstructors", courseInstructor)
        End Sub
        '''<summary>
        '''There are no comments for Persons in the schema.
        '''</summary>
        Public Sub AddToPersons(ByVal person As Person)
            MyBase.AddObject("Persons", person)
        End Sub
    End Class
    '''<summary>
    '''There are no comments for VBADONETDataService.LinqToSQL.Course in the schema.
    '''</summary>
    '''<KeyProperties>
    '''CourseID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.DataServiceKeyAttribute("CourseID")>  _
    Partial Public Class Course
        '''<summary>
        '''Create a new Course object.
        '''</summary>
        '''<param name="courseID">Initial value of CourseID.</param>
        '''<param name="credits">Initial value of Credits.</param>
        '''<param name="departmentID">Initial value of DepartmentID.</param>
        Public Shared Function CreateCourse(ByVal courseID As Integer, ByVal credits As Integer, ByVal departmentID As Integer) As Course
            Dim course As Course = New Course
            course.CourseID = courseID
            course.Credits = credits
            course.DepartmentID = departmentID
            Return course
        End Function
        '''<summary>
        '''There are no comments for Property CourseID in the schema.
        '''</summary>
        Public Property CourseID() As Integer
            Get
                Return Me._CourseID
            End Get
            Set
                Me.OnCourseIDChanging(value)
                Me._CourseID = value
                Me.OnCourseIDChanged
            End Set
        End Property
        Private _CourseID As Integer
        Partial Private Sub OnCourseIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnCourseIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Title in the schema.
        '''</summary>
        Public Property Title() As String
            Get
                Return Me._Title
            End Get
            Set
                Me.OnTitleChanging(value)
                Me._Title = value
                Me.OnTitleChanged
            End Set
        End Property
        Private _Title As String
        Partial Private Sub OnTitleChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnTitleChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Credits in the schema.
        '''</summary>
        Public Property Credits() As Integer
            Get
                Return Me._Credits
            End Get
            Set
                Me.OnCreditsChanging(value)
                Me._Credits = value
                Me.OnCreditsChanged
            End Set
        End Property
        Private _Credits As Integer
        Partial Private Sub OnCreditsChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnCreditsChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property DepartmentID in the schema.
        '''</summary>
        Public Property DepartmentID() As Integer
            Get
                Return Me._DepartmentID
            End Get
            Set
                Me.OnDepartmentIDChanging(value)
                Me._DepartmentID = value
                Me.OnDepartmentIDChanged
            End Set
        End Property
        Private _DepartmentID As Integer
        Partial Private Sub OnDepartmentIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnDepartmentIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for CourseGrades in the schema.
        '''</summary>
        Public Property CourseGrades() As Global.System.Collections.ObjectModel.Collection(Of CourseGrade)
            Get
                Return Me._CourseGrades
            End Get
            Set
                If (Not (value) Is Nothing) Then
                    Me._CourseGrades = value
                End If
            End Set
        End Property
        Private _CourseGrades As Global.System.Collections.ObjectModel.Collection(Of CourseGrade) = New Global.System.Collections.ObjectModel.Collection(Of CourseGrade)
        '''<summary>
        '''There are no comments for CourseInstructors in the schema.
        '''</summary>
        Public Property CourseInstructors() As Global.System.Collections.ObjectModel.Collection(Of CourseInstructor)
            Get
                Return Me._CourseInstructors
            End Get
            Set
                If (Not (value) Is Nothing) Then
                    Me._CourseInstructors = value
                End If
            End Set
        End Property
        Private _CourseInstructors As Global.System.Collections.ObjectModel.Collection(Of CourseInstructor) = New Global.System.Collections.ObjectModel.Collection(Of CourseInstructor)
    End Class
    '''<summary>
    '''There are no comments for VBADONETDataService.LinqToSQL.CourseGrade in the schema.
    '''</summary>
    '''<KeyProperties>
    '''EnrollmentID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.DataServiceKeyAttribute("EnrollmentID")>  _
    Partial Public Class CourseGrade
        '''<summary>
        '''Create a new CourseGrade object.
        '''</summary>
        '''<param name="enrollmentID">Initial value of EnrollmentID.</param>
        '''<param name="courseID">Initial value of CourseID.</param>
        '''<param name="studentID">Initial value of StudentID.</param>
        Public Shared Function CreateCourseGrade(ByVal enrollmentID As Integer, ByVal courseID As Integer, ByVal studentID As Integer) As CourseGrade
            Dim courseGrade As CourseGrade = New CourseGrade
            courseGrade.EnrollmentID = enrollmentID
            courseGrade.CourseID = courseID
            courseGrade.StudentID = studentID
            Return courseGrade
        End Function
        '''<summary>
        '''There are no comments for Property EnrollmentID in the schema.
        '''</summary>
        Public Property EnrollmentID() As Integer
            Get
                Return Me._EnrollmentID
            End Get
            Set
                Me.OnEnrollmentIDChanging(value)
                Me._EnrollmentID = value
                Me.OnEnrollmentIDChanged
            End Set
        End Property
        Private _EnrollmentID As Integer
        Partial Private Sub OnEnrollmentIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnEnrollmentIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property CourseID in the schema.
        '''</summary>
        Public Property CourseID() As Integer
            Get
                Return Me._CourseID
            End Get
            Set
                Me.OnCourseIDChanging(value)
                Me._CourseID = value
                Me.OnCourseIDChanged
            End Set
        End Property
        Private _CourseID As Integer
        Partial Private Sub OnCourseIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnCourseIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property StudentID in the schema.
        '''</summary>
        Public Property StudentID() As Integer
            Get
                Return Me._StudentID
            End Get
            Set
                Me.OnStudentIDChanging(value)
                Me._StudentID = value
                Me.OnStudentIDChanged
            End Set
        End Property
        Private _StudentID As Integer
        Partial Private Sub OnStudentIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnStudentIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Grade in the schema.
        '''</summary>
        Public Property Grade() As Global.System.Nullable(Of Decimal)
            Get
                Return Me._Grade
            End Get
            Set
                Me.OnGradeChanging(value)
                Me._Grade = value
                Me.OnGradeChanged
            End Set
        End Property
        Private _Grade As Global.System.Nullable(Of Decimal)
        Partial Private Sub OnGradeChanging(ByVal value As Global.System.Nullable(Of Decimal))
        End Sub
        Partial Private Sub OnGradeChanged()
        End Sub
        '''<summary>
        '''There are no comments for Course in the schema.
        '''</summary>
        Public Property Course() As Course
            Get
                Return Me._Course
            End Get
            Set
                Me._Course = value
            End Set
        End Property
        Private _Course As Course
        '''<summary>
        '''There are no comments for Person in the schema.
        '''</summary>
        Public Property Person() As Person
            Get
                Return Me._Person
            End Get
            Set
                Me._Person = value
            End Set
        End Property
        Private _Person As Person
    End Class
    '''<summary>
    '''There are no comments for VBADONETDataService.LinqToSQL.CourseInstructor in the schema.
    '''</summary>
    '''<KeyProperties>
    '''CourseID
    '''PersonID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.DataServiceKeyAttribute("CourseID", "PersonID")>  _
    Partial Public Class CourseInstructor
        '''<summary>
        '''Create a new CourseInstructor object.
        '''</summary>
        '''<param name="courseID">Initial value of CourseID.</param>
        '''<param name="personID">Initial value of PersonID.</param>
        Public Shared Function CreateCourseInstructor(ByVal courseID As Integer, ByVal personID As Integer) As CourseInstructor
            Dim courseInstructor As CourseInstructor = New CourseInstructor
            courseInstructor.CourseID = courseID
            courseInstructor.PersonID = personID
            Return courseInstructor
        End Function
        '''<summary>
        '''There are no comments for Property CourseID in the schema.
        '''</summary>
        Public Property CourseID() As Integer
            Get
                Return Me._CourseID
            End Get
            Set
                Me.OnCourseIDChanging(value)
                Me._CourseID = value
                Me.OnCourseIDChanged
            End Set
        End Property
        Private _CourseID As Integer
        Partial Private Sub OnCourseIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnCourseIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property PersonID in the schema.
        '''</summary>
        Public Property PersonID() As Integer
            Get
                Return Me._PersonID
            End Get
            Set
                Me.OnPersonIDChanging(value)
                Me._PersonID = value
                Me.OnPersonIDChanged
            End Set
        End Property
        Private _PersonID As Integer
        Partial Private Sub OnPersonIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnPersonIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Course in the schema.
        '''</summary>
        Public Property Course() As Course
            Get
                Return Me._Course
            End Get
            Set
                Me._Course = value
            End Set
        End Property
        Private _Course As Course
        '''<summary>
        '''There are no comments for Person in the schema.
        '''</summary>
        Public Property Person() As Person
            Get
                Return Me._Person
            End Get
            Set
                Me._Person = value
            End Set
        End Property
        Private _Person As Person
    End Class
    '''<summary>
    '''There are no comments for VBADONETDataService.LinqToSQL.Person in the schema.
    '''</summary>
    '''<KeyProperties>
    '''PersonID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.DataServiceKeyAttribute("PersonID")>  _
    Partial Public Class Person
        '''<summary>
        '''Create a new Person object.
        '''</summary>
        '''<param name="personID">Initial value of PersonID.</param>
        '''<param name="personCategory">Initial value of PersonCategory.</param>
        Public Shared Function CreatePerson(ByVal personID As Integer, ByVal personCategory As Short) As Person
            Dim person As Person = New Person
            person.PersonID = personID
            person.PersonCategory = personCategory
            Return person
        End Function
        '''<summary>
        '''There are no comments for Property PersonID in the schema.
        '''</summary>
        Public Property PersonID() As Integer
            Get
                Return Me._PersonID
            End Get
            Set
                Me.OnPersonIDChanging(value)
                Me._PersonID = value
                Me.OnPersonIDChanged
            End Set
        End Property
        Private _PersonID As Integer
        Partial Private Sub OnPersonIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnPersonIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property LastName in the schema.
        '''</summary>
        Public Property LastName() As String
            Get
                Return Me._LastName
            End Get
            Set
                Me.OnLastNameChanging(value)
                Me._LastName = value
                Me.OnLastNameChanged
            End Set
        End Property
        Private _LastName As String
        Partial Private Sub OnLastNameChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnLastNameChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property FirstName in the schema.
        '''</summary>
        Public Property FirstName() As String
            Get
                Return Me._FirstName
            End Get
            Set
                Me.OnFirstNameChanging(value)
                Me._FirstName = value
                Me.OnFirstNameChanged
            End Set
        End Property
        Private _FirstName As String
        Partial Private Sub OnFirstNameChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnFirstNameChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property PersonCategory in the schema.
        '''</summary>
        Public Property PersonCategory() As Short
            Get
                Return Me._PersonCategory
            End Get
            Set
                Me.OnPersonCategoryChanging(value)
                Me._PersonCategory = value
                Me.OnPersonCategoryChanged
            End Set
        End Property
        Private _PersonCategory As Short
        Partial Private Sub OnPersonCategoryChanging(ByVal value As Short)
        End Sub
        Partial Private Sub OnPersonCategoryChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property HireDate in the schema.
        '''</summary>
        Public Property HireDate() As Global.System.Nullable(Of Date)
            Get
                Return Me._HireDate
            End Get
            Set
                Me.OnHireDateChanging(value)
                Me._HireDate = value
                Me.OnHireDateChanged
            End Set
        End Property
        Private _HireDate As Global.System.Nullable(Of Date)
        Partial Private Sub OnHireDateChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnHireDateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property EnrollmentDate in the schema.
        '''</summary>
        Public Property EnrollmentDate() As Global.System.Nullable(Of Date)
            Get
                Return Me._EnrollmentDate
            End Get
            Set
                Me.OnEnrollmentDateChanging(value)
                Me._EnrollmentDate = value
                Me.OnEnrollmentDateChanged
            End Set
        End Property
        Private _EnrollmentDate As Global.System.Nullable(Of Date)
        Partial Private Sub OnEnrollmentDateChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnEnrollmentDateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Picture in the schema.
        '''</summary>
        Public Property Picture() As Byte()
            Get
                If (Not (Me._Picture) Is Nothing) Then
                    Return CType(Me._Picture.Clone,Byte())
                Else
                    Return Nothing
                End If
            End Get
            Set
                Me.OnPictureChanging(value)
                Me._Picture = value
                Me.OnPictureChanged
            End Set
        End Property
        Private _Picture() As Byte
        Partial Private Sub OnPictureChanging(ByVal value() As Byte)
        End Sub
        Partial Private Sub OnPictureChanged()
        End Sub
        '''<summary>
        '''There are no comments for CourseGrades in the schema.
        '''</summary>
        Public Property CourseGrades() As Global.System.Collections.ObjectModel.Collection(Of CourseGrade)
            Get
                Return Me._CourseGrades
            End Get
            Set
                If (Not (value) Is Nothing) Then
                    Me._CourseGrades = value
                End If
            End Set
        End Property
        Private _CourseGrades As Global.System.Collections.ObjectModel.Collection(Of CourseGrade) = New Global.System.Collections.ObjectModel.Collection(Of CourseGrade)
        '''<summary>
        '''There are no comments for CourseInstructors in the schema.
        '''</summary>
        Public Property CourseInstructors() As Global.System.Collections.ObjectModel.Collection(Of CourseInstructor)
            Get
                Return Me._CourseInstructors
            End Get
            Set
                If (Not (value) Is Nothing) Then
                    Me._CourseInstructors = value
                End If
            End Set
        End Property
        Private _CourseInstructors As Global.System.Collections.ObjectModel.Collection(Of CourseInstructor) = New Global.System.Collections.ObjectModel.Collection(Of CourseInstructor)
    End Class
End Namespace
